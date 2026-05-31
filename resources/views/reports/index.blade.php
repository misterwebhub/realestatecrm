@extends('layouts.app')

@section('content')
    <div class="card card-outline card-primary">
        <div class="card-body">
            <h5 class="card-title">Reports</h5>
            <ul class="list-group">
                <li class="list-group-item"><a href="{{ route('reports.plot.details') }}">Plot Details</a></li>
            </ul>
        </div>
    </div>
@endsection
