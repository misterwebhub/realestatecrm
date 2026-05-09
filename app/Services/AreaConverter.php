<?php

namespace App\Services;

class AreaConverter
{
    /**
    * Convert a value from given unit to gaz.
    * Supported units: gaz, marla, kanal, sqft, m2 (square meter), ha (hectare)
     *
     * @param float|int $value
     * @param string $unit
     * @return float
     */
    public static function toGaz($value, string $unit): float
    {
        $v = (float) $value;

        $unit = strtolower(trim($unit));

        if ($unit === 'gaz') {
            return round($v, 2);
        }

        // Conversion assumptions (common approximations):
        // 1 marla = 30.25 gaz (approx)
        // 1 kanal = 20 marla = 20 * 30.25 = 605 gaz
        // 1 sqft = 0.111111 gaz (approx) -> using 9 sqft = 1 gaz
        // 1 gaz ~= 0.83612736 square meters
        // 1 hectare = 10000 square meters

        switch ($unit) {
            case 'marla':
                return round($v * 30.25, 2);
            case 'kanal':
                return round($v * 605, 2);
            case 'sqft':
            case 'sq ft':
            case 'squarefeet':
                // here we use 1 gaz = 9 sq ft as an example; adjust to your convention
                return round($v / 9, 2);
            case 'm2':
            case 'sqm':
            case 'squaremeter':
            case 'square meter':
            case 'sq m':
                // convert square meters to gaz using 1 gaz = 0.83612736 m2
                return round($v / 0.83612736, 2);
            case 'ha':
            case 'hectare':
                // hectares to square meters, then to gaz
                return round(($v * 10000) / 0.83612736, 2);
            default:
                throw new \InvalidArgumentException('Unsupported unit: ' . $unit);
        }
    }
}
