Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports Maze.Creator

Module Module1

    Sub Main()
        'generates a maze


        Dim returnedMaze1 As Creator.Maze = GenerateMaze(MazeGenerationAlgorithms.PrimsAlgorithm)
        Dim solution1 As List(Of Point) = Utility.FindPath(returnedMaze1)
        Console.WriteLine("Prims")
        Utility.DisplayAsciiMaze(returnedMaze1, solution1)

        Dim returnedMaze2 As Creator.Maze = GenerateMaze(MazeGenerationAlgorithms.RecursiveBacktracker)
        Dim solution2 As List(Of Point) = Utility.FindPath(returnedMaze2)
        Console.WriteLine("RecursiveBacktracker")
        Utility.DisplayAsciiMaze(returnedMaze2, solution2)

        Dim returnedMaze3 As Creator.Maze = GenerateMaze(MazeGenerationAlgorithms.RecursiveDivision)
        Dim solution3 As List(Of Point) = Utility.FindPath(returnedMaze3)
        Console.WriteLine("RecursiveDivision")
        Utility.DisplayAsciiMaze(returnedMaze3, solution3)

        Console.WriteLine("Default maze test")
        Dim tempMaze = Utility.ConvertXMLToMaze(Utility.DefaultMaze)
        Dim solution As List(Of Point) = Utility.FindPath(tempMaze)
        Utility.DisplayAsciiMaze(tempMaze, solution)
        Console.ReadLine()
    End Sub

    Private Function GenerateMaze(algorithm As MazeGenerationAlgorithms) As Creator.Maze
        Dim m As Generate = New Generate()
        Dim mazeXml = m.InitialiseGrid(8, 8, 4, algorithm)
        'Console.WriteLine(mazeXml)

        Dim returnedMaze As Creator.Maze = Utility.ConvertXMLToMaze(mazeXml)
        Return returnedMaze
    End Function
End Module
