Public Class Utility
    Public Shared Function GetAdjacentPoints(ByRef p As Point, ByRef maxX As Integer, ByRef maxY As Integer) As List(Of Point)
        Dim adjacentPoints = New List(Of Point)()
        If p.Y - 1 >= 0 Then
            Dim top = New Point(p.X, p.Y - 1)
            adjacentPoints.Add(top)
        End If
        If p.Y + 1 < maxY Then
            Dim bottom = New Point(p.X, p.Y + 1)
            adjacentPoints.Add(bottom)
        End If
        If p.X - 1 >= 0 Then
            Dim left = New Point(p.X - 1, p.Y)
            adjacentPoints.Add(left)
        End If
        If p.X + 1 < maxX Then
            Dim right = New Point(p.X + 1, p.Y)
            adjacentPoints.Add(right)
        End If
        Return adjacentPoints
    End Function

    Public Shared Sub RemoveCarvedPoints(carvedPoints As List(Of Point), markedPoints As List(Of Point))
        For Each carvedPoint In carvedPoints 'removes the carved cells from the marked points
            Dim foundPoint = markedPoints.Find(Function(p) p.X = carvedPoint.X And p.Y = carvedPoint.Y)
            If (foundPoint IsNot Nothing) Then
                markedPoints.Remove(foundPoint)
            End If
        Next
    End Sub

    Public Shared Sub Carve(currentCell As Cell, cellToCarve As Cell)
        If currentCell.X < cellToCarve.X Then
            currentCell.EastWall = False
            cellToCarve.WestWall = False
        ElseIf currentCell.X > cellToCarve.X Then
            currentCell.WestWall = False
            cellToCarve.EastWall = False
        ElseIf currentCell.Y < cellToCarve.Y Then
            currentCell.SouthWall = False
            cellToCarve.NorthWall = False
        ElseIf currentCell.Y > cellToCarve.Y Then
            currentCell.NorthWall = False
            cellToCarve.SouthWall = False
        End If
    End Sub
End Class
