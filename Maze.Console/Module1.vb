Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports Maze.Generator

Module Module1

    Sub Main()
        'generates a maze
        Dim returnedMaze1 As Generator.Maze = GenerateMaze(MazeGenerationAlgorithms.PrimsAlgorithm)
        'Console.WriteLine("Prims")
        'Utility.DisplayAsciiMaze(returnedMaze1)
        'Dim returnedMaze2 As Generator.Maze = GenerateMaze(MazeGenerationAlgorithms.RecursiveBacktracker)
        'Console.WriteLine("RecursiveBacktracker")
        'Utility.DisplayAsciiMaze(returnedMaze2)
        Dim returnedMaze3 As Generator.Maze = GenerateMaze(MazeGenerationAlgorithms.RecursiveDivision)
        Console.WriteLine("REcursiveDivision")
        Utility.DisplayAsciiMaze(returnedMaze3)
        Console.ReadLine()
    End Sub

    Private Function GenerateMaze(algorithm As MazeGenerationAlgorithms) As Generator.Maze
        Dim m As Generate = New Generate()
        Dim mazeXml = m.InitialiseGrid(5, 5, 4, algorithm)
        'Console.WriteLine(mazeXml)

        'reads/deserializes the maze from the returned xml
        Dim returnedMaze As Generator.Maze
        Dim xmlReader As TextReader = New StringReader(mazeXml)
        Dim serial As XmlSerializer = New XmlSerializer(GetType(Generator.Maze))
        returnedMaze = serial.Deserialize(xmlReader)
        Return returnedMaze
    End Function

End Module
