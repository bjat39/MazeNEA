
Imports System.IO
Imports System.Xml.Serialization
Imports Maze.Creator

Public Class RecursiveDivision
    Implements IMazeGenerator

    Public Function GetMaze(ByRef x As Integer, ByRef y As Integer, ByRef seed As String) As Maze Implements IMazeGenerator.GetMaze
        Randomize()
        Dim maze As Maze = New Maze(x, y, False)

        BisectMaze(0, x - 1, 0, y - 1, maze)

        Return maze
    End Function

    Private Shared Sub BisectMaze(beginX As Integer, endX As Integer, beginY As Integer, endY As Integer, maze As Maze)
        'Console.WriteLine($"Bisect maze beginX = {beginX} endX = {endX} beginY = {beginY} endY = {endY}")

        Dim randomNumber = New Random()
        Dim rowtobisect As Integer
        Dim wheretocarve As Integer
        Dim horizontalVertical = 0 'randomNumber.Next(0, 2)
        If endX - beginX > endY - beginY Then
            horizontalVertical = 1
        ElseIf endX - beginX < endY - beginY Then
            horizontalVertical = 0
        Else
            horizontalVertical = randomNumber.Next(0, 2)
        End If
        If horizontalVertical = 0 Then
            rowtobisect = randomNumber.Next(beginY, endY)
            wheretocarve = randomNumber.Next(beginX, endX)
            For o As Integer = beginX To endX
                If o <> wheretocarve Then
                    Dim currentCell = maze.GetCell(o, rowtobisect)
                    Dim otherCell = maze.GetCell(o, rowtobisect + 1)
                    Utility.Fill(currentCell, otherCell)
                End If
            Next
            'Console.WriteLine($"Horizontol, split at {rowtobisect}")
            'Utility.DisplayAsciiMaze(maze)

            If beginY <> rowtobisect Then
                BisectMaze(beginX, endX, beginY, rowtobisect, maze)
            End If
            If rowtobisect + 1 <> endY Then
                BisectMaze(beginX, endX, rowtobisect + 1, endY, maze)
            End If
        Else
            rowtobisect = randomNumber.Next(beginX, endX)
            wheretocarve = randomNumber.Next(beginY, endY)
            For o As Integer = beginY To endY
                If o <> wheretocarve Then
                    Dim currentCell = maze.GetCell(rowtobisect, o)
                    Dim otherCell = maze.GetCell(rowtobisect + 1, o)
                    Utility.Fill(currentCell, otherCell)
                End If

            Next
            'Console.WriteLine($"Vertical, split at {rowtobisect}")
            'Utility.DisplayAsciiMaze(maze)

            If beginX <> rowtobisect Then
                BisectMaze(beginX, rowtobisect, beginY, endY, maze)
            End If
            If rowtobisect + 1 <> endX Then
                BisectMaze(rowtobisect + 1, endX, beginY, endY, maze)
            End If
        End If
    End Sub
End Class
