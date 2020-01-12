
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Enum MazeGenerationAlgorithms
    PrimsAlgorithm
    RecursiveBacktracker
    RecursiveDivision
End Enum

Public Class Generate
    Public Function InitialiseGrid(ByVal width As Integer, ByVal height As Integer, ByVal seed As String, ByVal algo As MazeGenerationAlgorithms) As String
        Dim xmlserialize As XmlSerializer = New XmlSerializer(GetType(Maze))
        Dim writer As TextWriter = New StringWriter()
        Dim gen As IMazeGenerator
        Select Case algo
            Case MazeGenerationAlgorithms.PrimsAlgorithm
                gen = New PrimsAlgorithm()
            Case MazeGenerationAlgorithms.RecursiveBacktracker
                gen = New RecursiveBacktracker()
            Case MazeGenerationAlgorithms.RecursiveDivision
                gen = New RecursiveDivision()
            Case Else
                Throw New NotImplementedException()
        End Select
        Dim maze As Maze = gen.GetMaze(width, height, seed) ' New Maze(width, height) 'Maze is a string representation of the Maze
        maze.Seed = seed
        xmlserialize.Serialize(writer, maze)
        Return writer.ToString()
    End Function

    Private Sub AddCells(ByRef maze As Maze)
        maze.Cells = New List(Of Cell)()

        For i As Integer = 0 To maze.Height - 1
            For j As Integer = 0 To maze.Width - 1
                maze.Cells.Add(New Cell(i, j))
            Next
        Next

    End Sub
End Class