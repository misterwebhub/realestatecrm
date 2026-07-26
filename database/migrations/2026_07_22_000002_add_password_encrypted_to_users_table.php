<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::table('users', function (Blueprint $table) {
            if (! Schema::hasColumn('users', 'password_encrypted')) {
                // Encrypted (reversible) copy of the password, set alongside the
                // one-way hash whenever a user's password is created/changed, so
                // Super Admins can reveal it from the User Master list. Passwords
                // set before this column existed have no recoverable value here —
                // the bcrypt hash in `password` cannot be reversed.
                $table->text('password_encrypted')->nullable()->after('password');
            }
        });
    }

    public function down(): void
    {
        Schema::table('users', function (Blueprint $table) {
            if (Schema::hasColumn('users', 'password_encrypted')) {
                $table->dropColumn('password_encrypted');
            }
        });
    }
};
