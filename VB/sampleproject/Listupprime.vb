Imports System

Module Listupprime
    Sub Main(args As String())
        Dim number As Integer = Integer.Parse(Console.ReadLine())

        For i As Integer = 2 To number
            If i = 2 Then
                Console.WriteLine(i)
            End If
            If IsPrime(i) Then
                Console.WriteLine(i)
            End If
        Next
    End Sub

    Function IsPrime(ByVal number As Integer) As Boolean
        For i As Integer = 2 To Math.Sqrt(number) + 1
            If number Mod i = 0 Then
                Return False
            End If
        Next
        Return True
    End Function
End Module
