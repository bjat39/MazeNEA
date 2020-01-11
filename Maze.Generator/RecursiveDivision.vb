
Imports Maze.Generator

Public Class RecursiveDivision
    Implements IMazeGenerator

    Public Function GetMaze(ByRef x As Integer, ByRef y As Integer, ByRef seed As String) As Maze Implements IMazeGenerator.GetMaze
        Randomize()
        Dim randomNumber = New Random()
        Dim maze As Maze = New Maze(x, y)

    End Function
End Class
