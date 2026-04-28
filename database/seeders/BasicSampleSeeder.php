<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Kisan;
use App\Models\Arazi;
use App\Models\Plot;
use App\Models\Customer;
use App\Models\Agent;
use App\Models\Investor;

class BasicSampleSeeder extends Seeder
{
    public function run(): void
    {
        $kisan = Kisan::firstOrCreate(['name' => 'Ram Singh'], ['mobile' => '9000000001', 'address' => 'Village Road']);

        $arazi = Arazi::firstOrCreate(
            ['plot_number' => 'AR-1001'],
            ['kisan_id' => $kisan->id, 'location' => 'Sector 7', 'total_area' => 10000, 'size' => 10000, 'status' => 'available']
        );

        Plot::firstOrCreate(
            ['arazi_id' => $arazi->id, 'plot_number' => 'P-1'],
            ['title' => 'Plot P-1', 'size' => 200, 'type' => 'residential', 'status' => 'available', 'price' => 1500000]
        );

        Customer::firstOrCreate(['mobile' => '9000000002'], ['name' => 'Sita Devi', 'address' => 'City Center']);

        Agent::firstOrCreate(['mobile' => '9000000003'], ['name' => 'Broker One']);

        Investor::firstOrCreate(['name' => 'Investor A'], ['mobile' => '9000000004', 'investment_amount' => 500000]);
    }
}
