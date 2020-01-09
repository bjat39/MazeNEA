Public Class PrimsAlgorithm
    Public Function GetMaze(ByRef x As Integer, ByRef y As Integer, ByRef seed As String) As Maze
        Randomize()
        Dim randomNumber = New Random()
        Dim m As Maze = New Maze(x, y)
        Dim initialPosition As Point = New Point(0, 0) 'update
        Dim carvedPoints = New List(Of Point)
        carvedPoints.Add(initialPosition)

        Do While carvedPoints.Count < x * y
            Dim currentPosition = carvedPoints.Item(randomNumber.Next(0, carvedPoints.Count))
            Dim markedPoints = GetAdjacentPoints(currentPosition, x, y)
            For Each carvedPoint In carvedPoints 'removes the carved cells from the marked points
                Dim foundPoint = markedPoints.Find(Function(p) p.X = carvedPoint.X And p.Y = carvedPoint.Y)
                If (foundPoint IsNot Nothing)
                    markedPoints.Remove(foundPoint)
                End If
            Next

            If markedPoints.Count > 0 Then
                Dim currentCell = m.GetCell(currentPosition.X, currentPosition.Y)
                Dim pointToCarve = markedPoints.Item(randomNumber.Next(0, markedPoints.Count))
                Dim cellToCarve = m.GetCell(pointToCarve.X, pointToCarve.Y)
                If currentPosition.X < pointToCarve.X Then
                    currentCell.EastWall = False
                    cellToCarve.WestWall = False
                ElseIf currentPosition.X > pointToCarve.X Then
                    currentCell.WestWall = False
                    cellToCarve.EastWall = False
                ElseIf currentPosition.Y < pointToCarve.Y Then
                    currentCell.SouthWall = False
                    cellToCarve.NorthWall = False
                ElseIf currentPosition.Y > pointToCarve.Y Then
                    currentCell.NorthWall = False
                    cellToCarve.SouthWall = False
                End If
                carvedPoints.Add(pointToCarve)
            End If
        Loop
        Return m
    End Function

    Private Function GetAdjacentPoints(ByRef p As Point, ByRef maxX As Integer, ByRef maxY As Integer) As List(Of Point)
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

End Class