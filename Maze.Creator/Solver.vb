Public Class Solver
    Public Enum MazeSolverAlgorithms
        BreadthFirstSearch
        Tremaux
    End Enum
    Public Shared Function CreateSolver(algo As MazeSolverAlgorithms) As IMazeSolver
        Select Case algo
            Case MazeSolverAlgorithms.BreadthFirstSearch
                Return New BreadthFirstSearchSolver()
            Case MazeSolverAlgorithms.Tremaux
                Return New Tremaux()
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Class
