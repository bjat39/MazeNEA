Imports Maze.Creator

Public Class BreadthFirstSearchSolver
    Implements IMazeSolver
    Dim visited = New List(Of Point)
    ReadOnly Public Property VisitedPoints As List(Of Point) Implements IMazeSolver.VisitedPoints
        Get
            Return visited
        End Get
    End Property

    Public Function SolveMaze(mazeXML As String, startPoint As Point, endPoint As Point) As List(Of Point) Implements IMazeSolver.SolveMaze
        Dim mazeToSolve As Creator.Maze = Utility.ConvertXMLToMaze(mazeXML)

        return SolveMaze(mazeToSolve, startPoint, endPoint)
    End Function

    Public Function SolveMaze(mazeToSolve As Creator.Maze, startPoint As Point, endPoint As Point) As List(Of Point) Implements IMazeSolver.SolveMaze
        Dim solution = New List(Of Point)
        Dim q = New Queue(Of Point)
        Dim parent As Point = startPoint
        If startPoint.X = endPoint.X And startPoint.Y = endPoint.Y Then
            solution.Add(startPoint)
            Return solution
        End If

        'visiting the child point
        q.Enqueue(startPoint)
        Do While q.Count <> 0
            parent = q.Dequeue()
            VisitedPoints.Add(parent)
            'Console.WriteLine($"Parent = {parent.X}, {parent.Y}")
            Dim children = Utility.GetAdjacentPoints(parent, mazeToSolve.Width, mazeToSolve.Height)
            If parent.Parent IsNot Nothing Then 'removes the parent's parent from the list of children cells
                Utility.RemoveParent(parent.Parent, children)
            End If
            For Each child In children
                Dim currentCell = mazeToSolve.GetCell(parent)
                Dim otherCell = mazeToSolve.GetCell(child)
                If Not Utility.IsWall(currentCell, otherCell) Then 
                    child.Parent = parent
                    If child.X = endPoint.X And child.Y = endPoint.Y Then 'found the end point
                        Dim solutionPoint = child
                        Do While solutionPoint.Parent IsNot Nothing 'shortest pathway
                            solution.Add(solutionPoint)
                            solutionPoint = solutionPoint.Parent
                        Loop
                        solution.Add(startPoint)
                        solution.Reverse()
                        Return solution
                    Else
                        q.Enqueue(child)
                    End If
                End If
            Next
        Loop
        Return solution
    End Function
End Class
