Public Interface IMazeGenerator
    Function GetMaze(ByRef x As Integer, ByRef y As Integer, ByRef seed As Integer, ByRef algorithm As MazeGenerationAlgorithms) As Maze


End Interface
