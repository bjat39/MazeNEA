Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports Maze.Generator

Module Module1

    Sub Main()
        'generates a maze
        Dim m As Generate = New Generate()
        Dim mazeXml = m.InitialiseGrid(4, 4, 4)
        Console.WriteLine(mazeXml)

        'reads/deserializes the maze from the returned xml
        Dim returnedMaze As Generator.Maze
        Dim xmlReader As TextReader = New StringReader(mazeXml)
        Dim x As XmlSerializer = New XmlSerializer(GetType(Generator.Maze))
        returnedMaze = x.Deserialize(xmlReader)

        For i As Integer = 0 To returnedMaze.Height - 1
            For j As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(i, j)
                If c.NorthWall = True Then
                    Console.Write("---")
                Else
                    Console.Write("   ")
                End If
            Next
            Console.WriteLine("")
            For j As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(i, j)
                If c.WestWall = True Then
                    Console.Write("| ")
                Else
                    Console.Write("  ")
                End If
                If c.EastWall = True Then
                    Console.Write("|")
                Else
                    Console.Write(" ")
                End If
            Next
            Console.WriteLine("")
            For j As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(i, j)
                If c.SouthWall = True Then
                    Console.Write("---")
                Else
                    Console.Write("   ")
                End If
            Next
            Console.WriteLine("")
        Next

        Console.ReadLine()
    End Sub

End Module
