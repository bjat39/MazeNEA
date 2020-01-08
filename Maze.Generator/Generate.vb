
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class Generate
    Public Function InitialiseGrid(ByVal height As Integer, ByVal width As Integer, ByVal seed As String) As String
        Dim xmlserialize As XmlSerializer = New XmlSerializer(GetType(Maze))
        Dim writer As TextWriter = New StringWriter()
        Dim maze As Maze = New Maze() 'Maze is a string representation of the Maze
        maze.Height = height
        maze.Width = width
        maze.Seed = seed
        AddCells(maze)
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