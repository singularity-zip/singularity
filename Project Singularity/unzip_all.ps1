$root = Split-Path -Parent $MyInvocation.MyCommand.Path
$done = @{}

do {
    $zips = Get-ChildItem -Path $root -Filter *.zip -Recurse | Where-Object { -not $done.ContainsKey($_.FullName) }
    foreach ($z in $zips) {
        $done[$z.FullName] = $true
        $destFolder = Join-Path $z.DirectoryName ([System.IO.Path]::GetFileNameWithoutExtension($z.Name))
        try {
            Expand-Archive -Path $z.FullName -DestinationPath $destFolder -Force
        } catch {
            Write-Host "Skipped: $($z.FullName)"
        }
    }
} while ($zips.Count -gt 0)