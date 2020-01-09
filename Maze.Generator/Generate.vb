
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class Generate
    Public Function InitialiseGrid(ByVal height As Integer, ByVal width As Integer, ByVal seed As String) As String
        Dim xmlserialize As XmlSerializer = New XmlSerializer(GetType(Maze))
        Dim writer As TextWriter = New StringWriter()
        Dim algo = New PrimsAlgorithm()
        Dim maze As Maze = algo.GetMaze(4, 4, 5) ' New Maze(width, height) 'Maze is a string representation of the Maze
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