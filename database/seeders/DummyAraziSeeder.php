<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Arazi;
use App\Models\Kisan;
use App\Models\Plot;
use App\Models\Customer;
use App\Models\CustomerBond;
use App\Models\Registry;
use App\Models\Agent;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Schema;

class DummyAraziSeeder extends Seeder
{
    public function run()
    {
        $faker = \Faker\Factory::create();

        // Ensure some kisans exist
        if (Kisan::count() < 10) {
            for ($i = 1; $i <= 10; $i++) {
                Kisan::create([
                    'name' => 'Kisan ' . $i,
                    'mobile' => '03' . $faker->numerify('#########'),
                    'location' => $faker->city,
                    'reg_no' => 'KIS' . str_pad($i, 4, '0', STR_PAD_LEFT),
                ]);
            }
        }

        // Ensure some customers exist
        if (Customer::count() < 50) {
            for ($i = 1; $i <= 50; $i++) {
                Customer::create([
                    'name' => $faker->name,
                    'mobile' => '03' . $faker->numerify('#########'),
                    'legacy_customer_code' => 'CUST' . str_pad($i, 4, '0', STR_PAD_LEFT),
                    'address' => $faker->address,
                ]);
            }
        }

        $kisanIds = Kisan::pluck('id')->all();
        $customerIds = Customer::pluck('id')->all();

        // Ensure at least one agent exists
        if (Agent::count() < 1) {
            Agent::create([
                'name' => 'Default Agent',
                'mobile' => '03' . $faker->numerify('#########'),
                'code' => 'AG' . str_pad(1, 3, '0', STR_PAD_LEFT),
            ]);
        }
        $agentIds = Agent::pluck('id')->all();

        // Create 400 arazis
        for ($i = 1; $i <= 400; $i++) {
            $kisanId = $faker->randomElement($kisanIds);
            $unit = $faker->randomElement(['gaz', 'marla', 'kanal']);
            $size = $faker->randomFloat(2, 10, 500);
            $road = $faker->randomFloat(2, 0, max(0, $size * 0.15));

            $arazi = Arazi::create([
                'legacy_arazi_code' => 'ARA' . str_pad($i, 5, '0', STR_PAD_LEFT),
                'kisan_id' => $kisanId,
                'location' => $faker->city,
                'unit' => $unit,
                'size' => $size,
                'road_area' => $road,
                'sale_amount_per_gaz' => $faker->numberBetween(5000, 200000),
                'coordinates' => $faker->latitude . ',' . $faker->longitude,
                // `status` column is an enum('available','sold') in migrations
                'status' => $faker->randomElement(['available', 'sold']),
            ]);

            // create plots for this arazi
            $numPlots = $faker->numberBetween(1, 8);
            $plotIds = [];
            for ($p = 1; $p <= $numPlots; $p++) {
                $plot = Plot::create([
                    'arazi_id' => $arazi->id,
                    'plot_number' => (string)$p,
                    'title' => 'Plot ' . $p,
                    'area' => round(max(0.01, ($arazi->saleable_area / max(1, $numPlots))), 2),
                    'status' => 'available',
                ]);
                $plotIds[] = $plot->id;
            }

            // Randomly create a customer bond for some arazis
            if ($faker->boolean(12)) { // ~12% chance
                $custId = $faker->randomElement($customerIds);
                $bond = CustomerBond::create([
                    'customer_id' => $custId,
                    'arazi_id' => $arazi->id,
                    'bond_no' => 'B' . strtoupper($faker->bothify('??###')) . $i,
                    'bond_date' => now()->subDays($faker->numberBetween(0, 365)),
                    'bond_amount' => $faker->numberBetween(50000, 500000),
                    'land_size' => $arazi->saleable_area,
                    'sale_rate' => $arazi->sale_amount_per_gaz,
                    'total_amount' => $arazi->saleable_area * $arazi->sale_amount_per_gaz,
                ]);

                // attach some plots
                $attach = $faker->randomElements($plotIds, $faker->numberBetween(1, min(3, count($plotIds))));
                foreach ($attach as $pid) {
                    $bond->plots()->attach($pid, ['sale_amount' => $faker->numberBetween(20000, 100000)]);
                }
            }

            // Randomly create a registry (purchase) for some plots
            if ($faker->boolean(6)) { // ~6% chance
                $buyerId = $faker->randomElement($customerIds);
                $plotId = $faker->randomElement($plotIds);
                $regData = [
                    'registry_code' => 'R' . strtoupper($faker->bothify('??###')) . $i,
                    'receipt_no' => strtoupper($faker->bothify('REC-####')),
                    'plot_id' => $plotId,
                    'customer_id' => $buyerId,
                    'arazi_id' => $arazi->id,
                    'agent_id' => $faker->randomElement($agentIds),
                    'registry_date' => now()->subDays($faker->numberBetween(0, 400)),
                    'land_size' => Plot::find($plotId)->area ?? 0,
                    'registry_amount' => $faker->numberBetween(30000, 400000),
                    'status' => 'completed',
                    'payment_status' => 'completed',
                ];

                if (Schema::hasColumn('registries', 'witness_name')) {
                    $regData['witness_name'] = $faker->name;
                }
                if (Schema::hasColumn('registries', 'mobile')) {
                    $regData['mobile'] = $faker->phoneNumber;
                }

                Registry::create($regData);
            }
        }
    }
}
