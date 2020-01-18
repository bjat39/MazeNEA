Public Class PrimsAlgorithm
    Implements IMazeGenerator
    Public Function GetMaze(ByRef x As Integer, ByRef y As Integer, ByRef seed As Integer, ByRef algorithm As MazeGenerationAlgorithms) As Maze Implements IMazeGenerator.GetMaze
        Randomize()
        Dim randomNumber = New Random(seed)
        Dim maze As Maze = New Maze(x, y, seed, algorithm)
        Dim frontierPoints = New List(Of Point)
        Dim carvedPoints = New List(Of Point)

        Dim currentPosition As Point = New Point(0, 0)
        carvedPoints.Add(currentPosition)
        Dim adjacentPoints = Utility.GetAdjacentPoints(currentPosition, x, y)
        frontierPoints.AddRange(adjacentPoints)

        Do While carvedPoints.Count < x * y
            'get the frontier point and it's possible carve points
            Dim frontierPoint = frontierPoints.Item(randomNumber.Next(0, frontierPoints.Count))
            Dim possibleCarvePoints = Utility.GetAdjacentPoints(frontierPoint, x, y)
            possibleCarvePoints = Utility.GetCommonPoints(carvedPoints, possibleCarvePoints)

            ' choose the point to carve to
            Dim carvePoint = possibleCarvePoints.Item(randomNumber.Next(0, possibleCarvePoints.Count))

            'do the carving
            Dim currentCell = maze.GetCell(carvePoint) 'cell has walls, position is a point on the grid without walls
            Dim cellToCarve = maze.GetCell(frontierPoint)
            Utility.Carve(currentCell, cellToCarve)

            'move the frontier point from the frontier list to the carved list
            frontierPoints.Remove(frontierPoint)
            carvedPoints.Add(frontierPoint)

            'add the points beside the old frontier to the frontier list
            adjacentPoints = Utility.GetAdjacentPoints(frontierPoint, x, y)
            Utility.ExcludePointsInFirstList(carvedPoints, adjacentPoints)
            Utility.ExcludePointsInFirstList(frontierPoints, adjacentPoints)
            frontierPoints.AddRange(adjacentPoints)
        Loop

        'Dim initialPosition As Point = New Point(0, 0) 'update
        'Dim carvedPoints = New List(Of Point)
        'carvedPoints.Add(initialPosition)

        'Do While carvedPoints.Count < x * y
        '    Dim currentPosition = carvedPoints.Item(randomNumber.Next(0, carvedPoints.Count))
        '    Dim markedPoints = Utility.GetAdjacentPoints(currentPosition, x, y)
        '    Utility.RemoveCarvedPoints(carvedPoints, markedPoints)

        '    If markedPoints.Count > 0 Then
        '        Dim pointToCarve = markedPoints.Item(randomNumber.Next(0, markedPoints.Count))

        '        Dim currentCell = maze.GetCell(currentPosition) 'cell has walls, position is a point on the grid without walls
        '        Dim cellToCarve = maze.GetCell(pointToCarve)

        '        Utility.Carve(currentCell, cellToCarve)
        '        carvedPoints.Add(pointToCarve)
        '    End If
        'Loop
        Return maze
    End Function
End Class