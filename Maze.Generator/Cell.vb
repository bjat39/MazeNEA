Public Class Cell
    Public NorthWall As Boolean = True
    Public EastWall As Boolean = True
    Public SouthWall As Boolean = True
    Public WestWall As Boolean = True
    Public X As Integer
    Public Y As Integer

    Public Sub New()

    End Sub

    Public Sub New(x As Integer, y As Integer, Optional allWalls As Boolean = True)
        Me.X = x
        Me.Y = y
        If Not allWalls Then
            NorthWall = False
            EastWall = False
            SouthWall = False
            WestWall = False
        End If
    End Sub

End Class