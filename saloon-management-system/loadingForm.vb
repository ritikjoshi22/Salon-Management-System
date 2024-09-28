Imports Guna.UI2.WinForms

Public Class loadingForm
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Panel2.Width += 3
        Panel2.BackColor = Color.Black
        If Panel2.Width >= 1400 Then
            Timer1.Stop()
        End If
    End Sub

    Private Sub Guna2CircleProgressBar1_ValueChanged(sender As Object, e As EventArgs) Handles Guna2CircleProgressBar1.ValueChanged
        Timer1.Start()
        Guna2CircleProgressBar1.Value += 20
        If (Guna2CircleProgressBar1.Value = 100) Then
            Timer1.Stop()
        End If
    End Sub
End Class