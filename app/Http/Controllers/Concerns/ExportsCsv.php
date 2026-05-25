<?php

namespace App\Http\Controllers\Concerns;

use Illuminate\Support\Str;

trait ExportsCsv
{
    /**
     * @param  iterable<int, array<int, mixed>>  $rows
     */
    protected function csvDownload(string $filenameBase, array $columns, iterable $rows): \Symfony\Component\HttpFoundation\StreamedResponse
    {
        $filename = Str::slug($filenameBase).'-'.now()->format('Y-m-d-His').'.csv';

        return response()->streamDownload(function () use ($columns, $rows) {
            $out = fopen('php://output', 'w');
            fprintf($out, chr(0xEF).chr(0xBB).chr(0xBF));
            fputcsv($out, $columns);
            foreach ($rows as $row) {
                $cells = is_array($row) ? $row : iterator_to_array($row);
                $flat = array_map(function ($cell) {
                    if ($cell === null) {
                        return '';
                    }
                    if (is_int($cell) || is_float($cell)) {
                        return $cell;
                    }

                    return preg_replace('/\s+/', ' ', trim(strip_tags((string) $cell)));
                }, array_values($cells));
                fputcsv($out, $flat);
            }
            fclose($out);
        }, $filename, [
            'Content-Type' => 'text/csv; charset=UTF-8',
        ]);
    }
}
