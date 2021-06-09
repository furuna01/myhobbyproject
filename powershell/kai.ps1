Param($Args1)

$sum = $Args1
for($i = $Args1 - 1; $i -gt 0; $i --) 
{
    $sum *= $i;
}
Write-Host $sum