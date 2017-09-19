Module Module1

    Sub Main()
        Dim s As ChangeFile = New ChangeFile
        s.Read_file("a.txt")
        s.Print_file("in")
        s.Print_file("out")
    End Sub

End Module

Class ChangeFile

    Private file_data_in As String
    Private file_data_out As String

    Public Sub Read_file(name As String)
        file_data_in = IO.File.ReadAllText(name)
        file_data_out = file_data_in
    End Sub

    Public Sub Print_file(io As String)
        If String.Equals(io, "in") Then
            Console.WriteLine(file_data_in)
        ElseIf String.Equals(io, "out") Then
            Console.WriteLine(file_data_out)
        End If
    End Sub

    Public Sub ccc()
        For i As Integer = 0 To file_data_in.Length - 1
            Console.WriteLine(file_data_in.Chars(i))
        Next
    End Sub

End Class
