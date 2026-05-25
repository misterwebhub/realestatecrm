@csrf
@if($method !== 'POST')
    @method($method)
@endif

<div class="row g-3">
    @foreach($fields as $field)
        @php($value = old($field['name'], $field['value'] ?? data_get($item, $field['name'])))
        @if(($field['type'] ?? '') === 'hidden')
            <input type="hidden" name="{{ $field['name'] }}" id="{{ $field['name'] }}" value="{{ $value }}">
            @continue
        @endif
        <div class="col-md-6">
            <label class="form-label" for="{{ $field['name'] }}">
                {{ $field['label'] }}
                @if(!empty($field['required']))
                    <span class="text-danger">*</span>
                @endif
            </label>

            @if(($field['type'] ?? 'text') === 'textarea')
                <textarea
                    id="{{ $field['name'] }}"
                    name="{{ $field['name'] }}"
                    class="form-control"
                    rows="4"
                    @if(!empty($field['required'])) required @endif
                >{{ $value }}</textarea>
            @elseif(($field['type'] ?? 'text') === 'readonly_text')
                <input
                    type="text"
                    id="{{ $field['name'] }}"
                    class="form-control bg-light"
                    value="{{ $value }}"
                    readonly
                    tabindex="-1"
                    autocomplete="off"
                >
            @elseif(($field['type'] ?? 'text') === 'select')
                <select id="{{ $field['name'] }}" name="{{ $field['name'] }}" class="form-select" @if(!empty($field['required'])) required @endif>
                    <option value="">Select {{ $field['label'] }}</option>
                    @foreach($field['options'] ?? [] as $optionValue => $optionLabel)
                        <option value="{{ $optionValue }}" @selected((string) $value === (string) $optionValue)>{{ $optionLabel }}</option>
                    @endforeach
                </select>
            @elseif(($field['type'] ?? 'text') === 'multiselect')
                @php($selectedValues = collect(is_array($value) ? $value : (filled($value) ? [$value] : []))->map(fn ($v) => (string) $v)->all())
                <select id="{{ $field['name'] }}" name="{{ $field['name'] }}[]" class="form-select" multiple size="{{ $field['size'] ?? 6 }}" @if(!empty($field['required'])) required @endif>
                    @foreach($field['options'] ?? [] as $optionValue => $optionLabel)
                        <option value="{{ $optionValue }}" @selected(in_array((string) $optionValue, $selectedValues, true))>{{ $optionLabel }}</option>
                    @endforeach
                </select>
            @elseif(($field['type'] ?? 'text') === 'file')
                <input
                    id="{{ $field['name'] }}"
                    name="{{ $field['name'] }}"
                    type="file"
                    class="form-control"
                    @if(!empty($field['accept'])) accept="{{ $field['accept'] }}" @endif
                    @if(!empty($field['required'])) required @endif
                >
            @else
                <input
                    id="{{ $field['name'] }}"
                    name="{{ $field['name'] }}"
                    type="{{ $field['type'] ?? 'text' }}"
                    value="{{ $value }}"
                    class="form-control"
                    @if(isset($field['step'])) step="{{ $field['step'] }}" @endif
                    @if(isset($field['placeholder'])) placeholder="{{ $field['placeholder'] }}" @endif
                    @if(!empty($field['required'])) required @endif
                    @if(!empty($field['readonly'])) readonly @endif
                >
            @endif
        </div>
    @endforeach
</div>

<div class="mt-4 d-flex gap-2">
    <button type="submit" class="btn btn-primary">Save</button>
    <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">Cancel</button>
</div>
