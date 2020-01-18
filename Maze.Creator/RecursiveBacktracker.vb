Imports Maze.Creator

Friend Class RecursiveBacktracker
    Implements IMazeGenerator
    Public Function GetMaze(ByRef x As Integer, ByRef y As Integer, ByRef seed As integer, ByRef algorithm As MazeGenerationAlgorithms) As Maze Implements IMazeGenerator.GetMaze
        Randomize()
        Dim randomNumber = New Random(seed)
        Dim maze As Maze = New Maze(x, y, seed, algorithm)
        Dim currentPosition As Point = New Point(0, 0)
        Dim stack = New Stack(Of Point)
        Dim carvedPoints = New List(Of Point)
        Do While carvedPoints.Count < x * y
            Dim markedPoints = Utility.GetAdjacentPoints(currentPosition, x, y)
            Utility.ExcludePointsInFirstList(carvedPoints, markedPoints)
            If markedPoints.Count > 0 Then
                Dim pointToCarve = markedPoints.Item(randomNumber.Next(0, markedPoints.Count))
                Dim currentCell = maze.GetCell(currentPosition)
                Dim cellToCarve = maze.GetCell(pointToCarve)
                Utility.Carve(currentCell, cellToCarve)
                carvedPoints.Add(pointToCarve)
                stack.Push(currentPosition)
                currentPosition = pointToCarve
            Else
                currentPosition = stack.Pop()
            End If
        Loop
        Return maze
    End Function
End Class
