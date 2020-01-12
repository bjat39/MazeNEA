Imports Maze.Creator
Public Interface IMazeSolver
    Function SolveMaze(mazeXML As String, startPoint As Point, endPoint As Point) As List(Of Point)
End Interface
