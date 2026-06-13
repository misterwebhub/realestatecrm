@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-header">
            <h5 class="card-title mb-0 fw-bold">Area Converter</h5>
        </div>
        <div class="card-body">
            <form method="POST" action="{{ route('converter.convert') }}">
                @csrf

                <div class="row mb-3">
                    <div class="col-md-4">
                        <label class="form-label">Value</label>
                        <input name="value" type="number" step="0.01" class="form-control" value="{{ old('value', $value ?? '') }}" required>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Unit</label>
                        <select name="unit" class="form-select" required>
                            <option value="gaz" {{ (old('unit', $unit ?? '')==='gaz') ? 'selected' : '' }}>Gaz</option>
                            <option value="sqft" {{ (old('unit', $unit ?? '')==='sqft') ? 'selected' : '' }}>Sq Ft</option>
                            <option value="m2" {{ (old('unit', $unit ?? '')==='m2') ? 'selected' : '' }}>Square Meter (m2)</option>
                            <option value="ha" {{ (old('unit', $unit ?? '')==='ha') ? 'selected' : '' }}>Hectare (ha)</option>
                        </select>
                    </div>
                    <div class="col-md-4 align-self-end">
                        <button class="btn btn-primary">Convert to Gaz</button>
                    </div>
                </div>
            </form>

            @if(isset($result))
                <div class="alert alert-info">Result: <strong>{{ $result }}</strong> gaz</div>
            @endif

            @if($errors->any())
                <div class="alert alert-danger">
                    <ul class="mb-0">
                        @foreach($errors->all() as $e)
                            <li>{{ $e }}</li>
                        @endforeach
                    </ul>
                </div>
            @endif
        </div>
    </div>
@endsection
