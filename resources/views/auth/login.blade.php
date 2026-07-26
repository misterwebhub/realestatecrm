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

        <form method="POST" action="{{ route('login.post') }}" autocomplete="off">
            @csrf
            {{-- Decoy fields: some browsers ignore autocomplete="off" and fill the
                 first visible username/password inputs on the page anyway. These
                 absorb that autofill instead of the real fields below. --}}
            <input type="text" name="fake-username" style="position:absolute;left:-9999px;width:1px;height:1px;opacity:0;" tabindex="-1" autocomplete="off">
            <input type="password" name="fake-password" style="position:absolute;left:-9999px;width:1px;height:1px;opacity:0;" tabindex="-1" autocomplete="new-password">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <input type="email" name="email" value="{{ old('email') }}" class="form-control" required autofocus autocomplete="off" readonly onfocus="this.removeAttribute('readonly')">
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <input type="password" name="password" value="" class="form-control" required autocomplete="new-password" readonly onfocus="this.removeAttribute('readonly')">
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
<script>
    // Belt-and-suspenders: some browsers autofill asynchronously, after the
    // readonly/autocomplete tricks above have already run. Wipe anything that
    // got filled in without the user actually typing it.
    (function () {
        var email = document.querySelector('input[name="email"]');
        var password = document.querySelector('input[name="password"]');
        var userTyped = { email: false, password: false };

        [['email', email], ['password', password]].forEach(function (pair) {
            var key = pair[0], el = pair[1];
            if (!el) return;
            el.addEventListener('input', function () { userTyped[key] = true; });
        });

        setTimeout(function () {
            if (email && !userTyped.email && document.activeElement !== email) email.value = '';
            if (password && !userTyped.password && document.activeElement !== password) password.value = '';
        }, 150);
    })();
</script>
</body>
</html>
