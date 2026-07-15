@php($hasFiles = collect($fields)->contains(fn($f) => ($f['type'] ?? 'text') === 'file'))
<form action="{{ $action }}" method="POST" @if($hasFiles) enctype="multipart/form-data" @endif>
    @include('crud._form_fields')
</form>
