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
    Public Shared Sub Fill(currentCell As Cell, otherCell As Cell)
        If currentCell.X < otherCell.X Then
            currentCell.EastWall = True
            otherCell.WestWall = True
        ElseIf currentCell.X > otherCell.X Then
            currentCell.WestWall = True
            otherCell.EastWall = True
        ElseIf currentCell.Y < otherCell.Y Then
            currentCell.SouthWall = True
            otherCell.NorthWall = True
        ElseIf currentCell.Y > otherCell.Y Then
            currentCell.NorthWall = True
            otherCell.SouthWall = True
        End If
    End Sub

    Public Shared Sub DisplayAsciiMaze(returnedMaze As Generator.Maze)
        For y As Integer = 0 To returnedMaze.Height - 1
            'writes the north walls
            For x As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(x, y)
                If c.NorthWall = True Then
                    If x = returnedMaze.Width - 1 Then
                        Console.Write("---")
                    Else
                        Console.Write("--")
                    End If
                Else
                    If x = 0 Then
                        Console.Write("- ")
                    ElseIf x = returnedMaze.Width - 1 Then
                        Console.Write("- -") 'change perhaps
                    Else
                        Console.Write("- ") 'change perhaps
                    End If
                End If
            Next
            Console.WriteLine("")
            'writes the east and west walls
            For x As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(x, y)
                If c.WestWall = True Then
                    Console.Write("| ")
                Else
                    Console.Write("  ")
                End If
                If c.EastWall = True And x = returnedMaze.Height - 1 Then
                    Console.Write("|")
                End If
            Next
            Console.WriteLine("")
            'writes the south wall for the the bottom most row
            For x As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(x, y)
                If c.SouthWall = True And y = returnedMaze.Height - 1 Then
                    If x = returnedMaze.Width - 1 Then
                        Console.Write("---")
                    Else
                        Console.Write("--")
                    End If
                End If
            Next
        Next

        Console.WriteLine("")
    End Sub

End Class
