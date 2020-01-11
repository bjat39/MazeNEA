Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports Maze.Generator

Module Module1

    Sub Main()
        'generates a maze
        Dim m As Generate = New Generate()
        Dim mazeXml = m.InitialiseGrid(10, 10, 4, MazeGenerationAlgorithms.RecursiveBacktracker)
        Console.WriteLine(mazeXml)

        'reads/deserializes the maze from the returned xml
        Dim returnedMaze As Generator.Maze
        Dim xmlReader As TextReader = New StringReader(mazeXml)
        Dim serial As XmlSerializer = New XmlSerializer(GetType(Generator.Maze))
        returnedMaze = serial.Deserialize(xmlReader)

        For y As Integer = 0 To returnedMaze.Height - 1
            'writes the north walls
            For x As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(x, y)
                If c.NorthWall = True Then
                    If x = returnedMaze.Width - 1 Then
                        Console.Write("---")
                    Else
                        Console.Write("--")
                    End If
                Else
                    If x = 0 Then
                        Console.Write("- ")
                    ElseIf x = returnedMaze.Width - 1 Then
                        Console.Write("- -") 'change perhaps
                    Else
                        Console.Write("- ") 'change perhaps
                    End If
                End If
            Next
            Console.WriteLine("")
            'writes the east and west walls
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
            'writes the south wall for the the bottom most row
            For x As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(x, y)
                If c.SouthWall = True And y = returnedMaze.Height - 1 Then
                    If x = returnedMaze.Width - 1 Then
                        Console.Write("---")
                    Else
                        Console.Write("--")
                    End If
                End If
            Next
        Next

        Console.WriteLine("")
        Console.ReadLine()
    End Sub

End Module
