Imports Maze.Creator
Public Interface IMazeSolver
    Function SolveMaze(mazeXML As String, startPoint As Point, endPoint As Point) As List(Of Point)
    Function SolveMaze(mazeToSolve As Creator.Maze, startPoint As Point, endPoint As Point) As List(Of Point)
End Interface
