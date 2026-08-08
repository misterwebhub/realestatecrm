<?php

if (! function_exists('inr')) {
    /**
     * Format a number using the Indian numbering system (lakh/crore digit
     * grouping), e.g. 1,00,000.00 instead of the international 100,000.00.
     *
     * Precision behaves exactly like number_format($amount, $decimals) — the
     * amount is shown to $decimals places (2 by default, i.e. paise), the
     * same rounding number_format() has always applied. This does NOT add
     * any extra rounding on top of that; the entered amount's value itself
     * is never touched, only its on-screen digit grouping.
     */
    function inr(float|int|string|null $amount, int $decimals = 2): string
    {
        $amount = (float) $amount;
        $negative = $amount < 0;
        $amount = abs($amount);

        $parts = explode('.', number_format($amount, $decimals, '.', ''));
        $integerPart = $parts[0];
        $decimalPart = $parts[1] ?? '';

        // Indian grouping: rightmost 3 digits together, then groups of 2.
        if (strlen($integerPart) > 3) {
            $lastThree = substr($integerPart, -3);
            $rest = substr($integerPart, 0, -3);
            $rest = preg_replace('/\B(?=(\d{2})+(?!\d))/', ',', $rest);
            $integerPart = $rest.','.$lastThree;
        }

        $formatted = $integerPart.($decimals > 0 ? '.'.$decimalPart : '');

        return ($negative ? '-' : '').$formatted;
    }
}
