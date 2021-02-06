function circle {
    param (
            $X
        )
    return [Math]::sqrt(1 - $X * $X)
}
function integral_circle {
    param (
            $N
          )
    $sum = 0;
    for($i = -$N; $i -le $N; $i ++) {
        $result = circle ($i / $N)
        $sum += (1 / $N) * $result
    }
    return $sum
}
$N_str = Read-Host
$N = [int]$N_str
$result = 2 * (integral_circle $N)

Write-Host $result