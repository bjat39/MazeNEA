Public Class Point
    Public X As Integer
    Public Y As integer
    Public Parent As Point
    Public Sub New(ByRef x As Integer, ByRef y As Integer, Optional parent As Point = Nothing)
        Me.X = x
        Me.Y = y
        Me.Parent = parent
    End sub
End Class