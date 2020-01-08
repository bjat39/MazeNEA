Imports System.Xml.Serialization

Public Class Maze
    Public Height As Integer
    Public Width As Integer
    Public Seed As String = ""
    <XmlArray("Cells")>
    Public Cells As List(Of Cell)

    Public Function GetCell(x As Integer, y As Integer) As Cell
        For Each cell In Cells
            If (cell.X = x And cell.Y = y)
                Return cell
            End If
        Next
        Throw new ArgumentException("bad input parameters")
    End Function

End Class

