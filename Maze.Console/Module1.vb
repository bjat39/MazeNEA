Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports Maze.Creator

Module Module1

    Sub Main()
        'generates a maze
        'Dim returnedMaze1 As Creator.Maze = GenerateMaze(MazeGenerationAlgorithms.PrimsAlgorithm)
        'Console.WriteLine("Prims")
        'Utility.DisplayAsciiMaze(returnedMaze1)
        'Dim returnedMaze2 As Creator.Maze = GenerateMaze(MazeGenerationAlgorithms.RecursiveBacktracker)
        'Console.WriteLine("RecursiveBacktracker")
        'Utility.DisplayAsciiMaze(returnedMaze2)
        'Dim returnedMaze3 As Creator.Maze = GenerateMaze(MazeGenerationAlgorithms.RecursiveDivision)
        'Console.WriteLine("REcursiveDivision")
        'Utility.DisplayAsciiMaze(returnedMaze3)
        Dim solver = New Solve()

        Dim tempMaze = Utility.ConvertXMLToMaze(Utility.DefaultMaze)
        Dim solution = solver.SolveMaze(Utility.DefaultMaze, New Point(0, 0), New Point(tempMaze.Width - 1, tempMaze.Width - 1))
        If solution Is Nothing Or solution.Count = 0 Then
            Console.WriteLine("no solution")
        Else
            Console.Write($"path = ")
            For Each point In solution
                Console.Write($"({point.X}, {point.Y}) ")
            Next
            Console.WriteLine()
        End If
        Utility.DisplayAsciiMaze(tempMaze, solution)
        Console.ReadLine()
    End Sub

    Private Function GenerateMaze(algorithm As MazeGenerationAlgorithms) As Creator.Maze
        Dim m As Generate = New Generate()
        Dim mazeXml = m.InitialiseGrid(5, 5, 4, algorithm)
        Console.WriteLine(mazeXml)

        Dim returnedMaze As Creator.Maze = Utility.ConvertXMLToMaze(mazeXml)
        Return returnedMaze
    End Function
End Module
