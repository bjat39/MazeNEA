Imports Maze.Creator

Friend Class Tremaux
    Implements IMazeSolver

    Private visited = New List(Of Point)
    Private EndPoint As Point
    Private MazeToSolve As Maze

    ReadOnly Public Property VisitedPoints As List(Of Point) Implements IMazeSolver.VisitedPoints
        Get
            Return visited
        End Get
    End Property

    Public Function SolveMaze(mazeXML As String, startPoint As Point, endPoint As Point) As List(Of Point) Implements IMazeSolver.SolveMaze
        Dim mazeToSolve As Creator.Maze = Utility.ConvertXMLToMaze(mazeXML)

        Return SolveMaze(mazeToSolve, startPoint, endPoint)
    End Function

    Public Function SolveMaze(mazeToSolve As Maze, startPoint As Point, endPoint As Point) As List(Of Point) Implements IMazeSolver.SolveMaze
        Me.MazeToSolve = mazeToSolve
        Me.EndPoint = endPoint
        Dim solution = New List(Of Point)
        Dim l = New List(Of Point)
        Dim position As Point = startPoint
        If startPoint.X = endPoint.X And startPoint.Y = endPoint.Y Then
            solution.Add(startPoint)
            Return solution
        End If

        'visiting the child point
        l = FindPath(startPoint)

        Return l
    End Function

    Public Function FindPath(position As Point) As List(Of Point)
        VisitedPoints.Add(position)
        Dim passages = New List(Of Point)
        If position.X = EndPoint.X And position.Y = EndPoint.Y Then
            Dim l = New List(Of Point)
            l.Add(position)
            Return l
        End If
        ' GetAdjacentPoints()
        Dim adjacentPoints = Utility.GetAdjacentPoints(position, MazeToSolve.Width, MazeToSolve.Height)

        'Removes parent from possible adjecent points
        If position.Parent IsNot Nothing Then 'removes the parent's parent from the list of children cells
            Utility.RemoveParent(position.Parent, adjacentPoints)
        End If

        'Find passages in the adjacent points
        For Each adjacentPoint In adjacentPoints
            Dim currentCell = MazeToSolve.GetCell(position)
            Dim otherCell = MazeToSolve.GetCell(adjacentPoint)
            If Not Utility.IsWall(currentCell, otherCell) Then
                passages.Add(adjacentPoint)
            End If
        Next
        Dim path = New List(Of Point)
        If passages.Count <> 0 Then
            'Dim randomPoint As New Random
            'Dim nextPos = passages.Item(randomPoint.Next(passages.Count))
            'nextPos.Parent = position
            'FindPath(nextPos)
            For Each passage In passages
                If VisitedPoints.Contains(passage) Then
                    Return Nothing
                End If
                passage.Parent = position
                path = FindPath(passage)
                If path IsNot Nothing Then
                    path.Add(passage.Parent)
                    Return path
                End If
            Next
        Else
            Return Nothing
        End If
        Return path
    End Function
End Class
