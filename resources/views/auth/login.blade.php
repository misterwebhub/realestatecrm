<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>body{background:#f7f7f7}</style>
</head>
<body>
<div class="container d-flex align-items-center justify-content-center" style="min-height:100vh">
    <div class="card p-4" style="width:380px">
        <h5 class="mb-3">Sign in</h5>

        @if($errors->any())
            <div class="alert alert-danger">{{ $errors->first() }}</div>
        @endif

        <form method="POST" action="{{ route('login.post') }}">
            @csrf
            <div class="mb-3">
                <label class="form-label">Email</label>
                <input type="email" name="email" value="{{ old('email', $defaultEmail ?? 'admin@example.com') }}" class="form-control" required autofocus autocomplete="username">
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <input type="password" name="password" value="{{ old('password', $defaultPassword ?? '') }}" class="form-control" required autocomplete="current-password">
            </div>
            <div class="mb-3 form-check">
                <input type="checkbox" name="remember" class="form-check-input" id="remember">
                <label class="form-check-label" for="remember">Remember me</label>
            </div>
            <div class="d-grid">
                <button class="btn btn-primary">Login</button>
            </div>
        </form>
    </div>
</div>
</body>
</html>
