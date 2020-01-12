Imports System.Xml.Serialization

Public Class Maze
    Public Height As Integer
    Public Width As Integer
    Public Seed As Integer
    <XmlArray("Cells")>
    Public Cells As List(Of Cell)

    Public Sub New()
        'no initialization used by xml serializer
    End Sub

    Public Sub New(x As Integer, y As Integer, seed As integer, Optional allWalls As Boolean = True)
        Height = y
        Width = x
        Seed = seed
        Cells = New List(Of Cell)()
        For i As Integer = 0 To Height - 1
            For j As Integer = 0 To Width - 1
                Cells.Add(New Cell(i, j, allWalls))
            Next
        Next
        If allWalls = False Then
            For l As Integer = 0 To Width - 1
                Dim topCell = GetCell(l, 0)
                topCell.NorthWall = True
                Dim bottomCell = GetCell(l, Height - 1)
                bottomCell.SouthWall = True
            Next
            For k As Integer = 0 To Height - 1
                Dim leftCell = GetCell(0, k)
                leftCell.WestWall = True
                Dim rightCell = GetCell(Width - 1, k)
                rightCell.EastWall = True
            Next
        End If

    End Sub

    Public Function GetCell(x As Integer, y As Integer) As Cell
        For Each cell In Cells
            If (cell.X = x And cell.Y = y) Then
                Return cell
            End If
        Next
        Throw New ArgumentException("bad input parameters")
    End Function

    Public Function GetCell(position As Point) As Cell
        Return GetCell(position.X, position.Y)
    End Function

End Class

