<?php

namespace Tests\Feature;

use App\Models\User;
use Illuminate\Foundation\Testing\RefreshDatabase;
use Tests\TestCase;

class RoleMiddlewareTest extends TestCase
{
    use RefreshDatabase;

    public function test_accountant_cannot_access_admin_sections()
    {
        $user = User::create(['name' => 'Acc', 'email' => 'acc@example.com', 'password' => bcrypt('pass'), 'role' => 'accountant']);

        $response = $this->actingAs($user)->get(route('arazis.index'));

        $response->assertStatus(403);
    }
}
