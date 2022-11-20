Public Class Form1
    Dim div As Integer = 0
    Dim notas As Integer = 0
    Dim alu As Integer = 0
    Dim numeronota As Integer = 0
    Dim max As Integer = 0
    Dim max2 As Integer = 0
    Dim max3 As Integer = 0

    Dim notasguardadas As Integer = 0
    Dim cursoscreados As Integer = 0
    Dim alumnoscreados As Integer = 0

    Dim IsUsed(10) As Boolean
    Dim IsUsed2(10, 1) As Boolean
    Dim IsUsed3(10, 255, 255) As Boolean
    Dim division(10) As Integer
    Dim Nombre(10, 1) As String
    Dim Nota(10, 255, 255) As Integer
    Dim cantnotas(10, 100) As Integer

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        div = NumericUpDown1.Value

        If IsUsed(div) = False Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
        NumericUpDown5.Maximum = division(div)
    End Sub
    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs)
        alu = NumericUpDown5.Value
        If IsUsed2(div, alu) = False Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
        NumericUpDown6.Maximum = cantnotas(div, alu)
    End Sub
    Private Sub NumericUpDown6_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown6.ValueChanged
        numeronota = NumericUpDown6.Value
        If IsUsed3(div, alu, numeronota) = True Then
            Button1.Text = "Cambiar"
        Else
            Button1.Text = "Guardar"
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        div = NumericUpDown1.Value
        Label3.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        NumericUpDown4.Visible = True
        NumericUpDown5.Visible = True
        TextBox1.Visible = True
        Button2.Visible = True
        division(div) = NumericUpDown2.Value
        cursoscreados = cursoscreados + 1

        IsUsed(NumericUpDown1.Value) = True

        If max = 0 Or division(div) > max Then
            ReDim Preserve Nombre(10, division(div))
            ReDim Preserve IsUsed2(10, division(div))
            max = division(div)
        End If

        If IsUsed(div) = False Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
        NumericUpDown5.Maximum = division(div)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        alu = NumericUpDown5.Value
        Nombre(div, alu) = TextBox1.Text
        alumnoscreados = alumnoscreados + 1

        If max3 = 0 Or cantnotas(div, alu) > max3 Then
            ReDim Preserve cantnotas(10, alu)
            max3 = cantnotas(div, alu)
        End If

        cantnotas(div, alu) = NumericUpDown4.Value

        Label4.Visible = True
        NumericUpDown3.Visible = True
        Button1.Visible = True
        IsUsed2(div, alu) = True

        If IsUsed2(div, alu) = False Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Nota(div, alu, numeronota) = NumericUpDown3.Value

        IsUsed3(div, alu, numeronota) = True

        If Button1.Text = "Guardar" Then
            notasguardadas = notasguardadas + 1
        End If

        If IsUsed3(div, alu, numeronota) = True Then
            Button1.Text = "Cambiar"
        Else
            Button1.Text = "Guardar"
        End If
    End Sub
    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        ListView1.Items.Clear()
        For i As Integer = 1 To cursoscreados
            For j As Integer = 1 To alumnoscreados
                Dim sumanotas, promedio As Double
                Dim noev As Boolean = False
                For k As Integer = 1 To cantnotas(i, j)
                    If Nota(i, j, k) = 0 Then
                        noev = True
                    Else
                        sumanotas = sumanotas + Nota(i, j, k)
                    End If
                Next
                promedio = sumanotas / cantnotas(i, j)
                If noev = True Then
                    ListView1.Items.Add(Nombre(i, j) + " No esta evaluado")
                ElseIf promedio >= 6 Then
                    ListView1.Items.Add(Nombre(i, j) + " " & promedio & " Aprobo")
                Else
                    ListView1.Items.Add(Nombre(i, j) + " " & promedio & " Desaprobo")
                End If
            Next
        Next
    End Sub

End Class
