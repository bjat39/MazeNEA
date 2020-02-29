Imports Maze.Creator

Public Class Point
    Implements IEquatable(Of Point)
    Public X As Integer
    Public Y As Integer
    Public Parent As Point
    Public Sub New(ByRef x As Integer, ByRef y As Integer, Optional parent As Point = Nothing)
        Me.X = x
        Me.Y = y
        Me.Parent = parent
    End Sub

    Public Overloads Function Equals(other As Point) As Boolean Implements IEquatable(Of Point).Equals
        If other Is Nothing Then
            Return False
        End If
        If other.X = Me.X And other.Y = Me.Y Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Overloads Overrides Function Equals(obj As Object) As Boolean
        Return TypeOf obj Is Point AndAlso Equals(DirectCast(obj, Point))
    End Function

    Public Overrides Function GetHashCode() As Int32
        Dim hash As Int32 = 179 

        hash = hash * 27 + Me.X.GetHashCode()
        hash = hash * 27 + Me.Y.GetHashCode()

        Return hash
    End Function
End Class