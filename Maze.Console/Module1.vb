Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports Maze.Generator

Module Module1

    Sub Main()
        'generates a maze
        Dim m As Generate = New Generate()
        Dim mazeXml = m.InitialiseGrid(4, 4, 4, MazeGenerationAlgorithms.RecursiveDivision)
        Console.WriteLine(mazeXml)

        'reads/deserializes the maze from the returned xml
        Dim returnedMaze As Generator.Maze
        Dim xmlReader As TextReader = New StringReader(mazeXml)
        Dim serial As XmlSerializer = New XmlSerializer(GetType(Generator.Maze))
        returnedMaze = serial.Deserialize(xmlReader)

        For y As Integer = 0 To returnedMaze.Height - 1
            For x As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(x, y)
                If c.NorthWall = True Then
                    Console.Write("--")
                Else
                    Console.Write("  ")
                End If
            Next
            Console.WriteLine("")
            For x As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(x, y)
                If c.WestWall = True Then
                    Console.Write("| ")
                Else
                    Console.Write("  ")
                End If
                If c.EastWall = True And x = returnedMaze.Height - 1 Then
                    Console.Write("|")
                End If
            Next
            Console.WriteLine("")
            For x As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(x, y)
                If c.SouthWall = True And y = returnedMaze.Height - 1 Then
                    Console.Write("--")
                End If
            Next
        Next

        Console.WriteLine("")
        Console.ReadLine()
    End Sub

End Module
