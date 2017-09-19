Module Module1

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

        Public Sub Write_file(data As String)
            IO.File.WriteAllText("b.txt", data)
        End Sub

        Public Sub Ccc()
            For i As Integer = 0 To file_data_in.Length - 1
                Console.WriteLine(file_data_in.Chars(i))
            Next
        End Sub

        Public Function Data_com() As String
            Dim initial As Char() = file_data_in.ToCharArray
            Dim result As String = "("
            Dim i As Integer = 0
            Dim none As Char = " "

            Do While i < initial.Length
                Dim j As Integer = 0
                result += "("
                Do While j < 8
                    If Char.Equals(initial(i), none) Then
                        If j < 7 Then
                            result += " "
                        End If
                        j += 1
                        i += 1
                    Else
                        result += initial(i)
                        i += 1
                    End If
                Loop
                result += ")"
                If i <> initial.Length Then
                    result += " "
                End If
            Loop
            result += ")"
            Return result
        End Function

    End Class

    Sub Main()
        Dim s As ChangeFile = New ChangeFile
        s.Read_file("a.txt")
        s.Print_file("in")
        s.Print_file("out")

        Dim test As String = "fds"
        Dim ass() As Char = test.ToCharArray()
        For i As Integer = 0 To ass.Length - 1
            Console.Write(ass(i) + vbTab)
        Next
        Console.Write(vbCrLf)

        s.Write_file(s.Data_com())
    End Sub

End Module

