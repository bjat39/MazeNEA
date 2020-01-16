Public Class PrimsAlgorithm
    Implements IMazeGenerator
    Public Function GetMaze(ByRef x As Integer, ByRef y As Integer, ByRef seed As integer, ByRef algorithm As MazeGenerationAlgorithms) As Maze Implements IMazeGenerator.GetMaze
        Randomize()
        Dim randomNumber = New Random(seed)
        Dim maze As Maze = New Maze(x, y, seed, algorithm)
        Dim initialPosition As Point = New Point(0, 0) 'update
        Dim carvedPoints = New List(Of Point)
        carvedPoints.Add(initialPosition)

        Do While carvedPoints.Count < x * y
            Dim currentPosition = carvedPoints.Item(randomNumber.Next(0, carvedPoints.Count))
            Dim markedPoints = Utility.GetAdjacentPoints(currentPosition, x, y)
            Utility.RemoveCarvedPoints(carvedPoints, markedPoints)

            If markedPoints.Count > 0 Then
                Dim pointToCarve = markedPoints.Item(randomNumber.Next(0, markedPoints.Count))

                Dim currentCell = maze.GetCell(currentPosition) 'cell has walls, position is a point on the grid without walls
                Dim cellToCarve = maze.GetCell(pointToCarve)

                Utility.Carve(currentCell, cellToCarve)
                carvedPoints.Add(pointToCarve)
            End If
        Loop
        Return maze
    End Function
End Class