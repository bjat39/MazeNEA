Public Class MainMenu
    Private Sub MazeGenerator_Click(sender As Object, e As EventArgs) Handles MazeGenerator.Click
        Dim custom As MazeCustomisation = New MazeCustomisation()
        custom.ShowDialog(Me)
    End Sub
End Class
