<?php

namespace App\Models;

// use Illuminate\Contracts\Auth\MustVerifyEmail;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Illuminate\Notifications\Notifiable;
use Laravel\Sanctum\HasApiTokens;

class User extends Authenticatable
{
    use HasApiTokens, HasFactory, Notifiable;

    /**
     * The attributes that are mass assignable.
     *
     * @var array<int, string>
     */
    protected $fillable = [
        'name',
        'username',
        'email',
        'password',
        'password_encrypted',
        'role',
        'role_id',
        'mobile',
        'secondary_mobile',
        'address',
        'is_active',
    ];

    /**
     * The attributes that should be hidden for serialization.
     *
     * @var array<int, string>
     */
    protected $hidden = [
        'password',
        'password_encrypted',
        'remember_token',
    ];

    /**
     * The attributes that should be cast.
     *
     * @var array<string, string>
     */
    protected $casts = [
        'email_verified_at' => 'datetime',
        'password' => 'hashed',
    ];

    public function payments()
    {
        return $this->hasMany(\App\Models\CustomerBondPayment::class, 'taken_by_user_id');
    }

    public function roleModel()
    {
        return $this->belongsTo(\App\Models\Role::class, 'role_id');
    }

    /**
     * Super Admin via the assigned role, or the legacy 'role' string === 'admin'/'super_admin'.
     */
    public function isSuperAdmin(): bool
    {
        if ($this->roleModel && $this->roleModel->isSuperAdmin()) {
            return true;
        }

        return in_array($this->role, ['super_admin', 'admin'], true)
            && $this->role_id === null; // legacy admins with no assigned role
    }

    /**
     * Check a single permission name (e.g. "arazis.create").
     * Super Admin always passes (also enforced by Gate::before).
     */
    public function hasPermission(string $permission): bool
    {
        if ($this->isSuperAdmin()) {
            return true;
        }

        return (bool) $this->roleModel?->hasPermission($permission);
    }
}
