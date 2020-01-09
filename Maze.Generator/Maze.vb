Imports System.Xml.Serialization

Public Class Maze
    Public Height As Integer
    Public Width As Integer
    Public Seed As String = ""
    <XmlArray("Cells")>
    Public Cells As List(Of Cell)

    Public Sub New()

    End Sub

    Public Sub New(x As Integer, y As Integer)
        Height = y
        Width = x
        Cells = New List(Of Cell)()
        For i As Integer = 0 To Height - 1
            For j As Integer = 0 To Width - 1
                Cells.Add(New Cell(i, j))
            Next
        Next
    End Sub
    
    Public Function GetCell(x As Integer, y As Integer) As Cell
        For Each cell In Cells
            If (cell.X = x And cell.Y = y)
                Return cell
            End If
        Next
        Throw new ArgumentException("bad input parameters")
    End Function

End Class

