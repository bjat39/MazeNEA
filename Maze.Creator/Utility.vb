Imports System.IO
Imports System.Xml.Serialization

Public Class Utility
    Public Shared Function GetAdjacentPoints(ByRef p As Point, ByRef maxX As Integer, ByRef maxY As Integer) As List(Of Point)
        Dim adjacentPoints = New List(Of Point)()
        If p.Y - 1 >= 0 Then
            Dim top = New Point(p.X, p.Y - 1)
            adjacentPoints.Add(top)
        End If
        If p.Y + 1 < maxY Then
            Dim bottom = New Point(p.X, p.Y + 1)
            adjacentPoints.Add(bottom)
        End If
        If p.X - 1 >= 0 Then
            Dim left = New Point(p.X - 1, p.Y)
            adjacentPoints.Add(left)
        End If
        If p.X + 1 < maxX Then
            Dim right = New Point(p.X + 1, p.Y)
            adjacentPoints.Add(right)
        End If
        Return adjacentPoints
    End Function

    Public Shared Sub ExcludePointsInFirstList(ByVal carvedPoints As List(Of Point), markedPoints As List(Of Point))

        Dim markedPointsToRemove = New List(Of Point)
        For Each markedPoint In markedPoints
            For Each carvedPoint In carvedPoints 'removes the carved cells from the marked points
                If markedPoint.X = carvedPoint.X And markedPoint.Y = carvedPoint.Y Then
                    markedPointsToRemove.Add(markedPoint)
                    Continue For 'the carved point has been found so no need to iterate through other marked points
                End If
            Next
        Next
        For Each markedPoint In markedPointsToRemove
            markedPoints.Remove(markedPoint)
        Next
    End Sub

    Public Shared Function GetCommonPoints(ByVal carvedPoints As List(Of Point), markedPoints As List(Of Point)) As List(Of Point)
        Dim commonPoints = New List(Of Point)

        For Each markedPoint In markedPoints
            For Each carvedPoint In carvedPoints 'removes the carved cells from the marked points
                If markedPoint.X = carvedPoint.X And markedPoint.Y = carvedPoint.Y Then
                    commonPoints.Add(markedPoint)
                    Continue For 'the carved point has been found so no need to iterate through other marked points
                End If
            Next
        Next
        Return commonPoints
    End Function

    Public Shared Sub RemoveParent(parent As Point, children As List(Of Point))
        Dim foundPoint = children.Find(Function(p) p.X = parent.X And p.Y = parent.Y)
        If (foundPoint IsNot Nothing) Then
            children.Remove(foundPoint)
        End If
    End Sub

    Public Shared Sub Carve(currentCell As Cell, cellToCarve As Cell)
        If currentCell.X < cellToCarve.X Then
            currentCell.EastWall = False
            cellToCarve.WestWall = False
        ElseIf currentCell.X > cellToCarve.X Then
            currentCell.WestWall = False
            cellToCarve.EastWall = False
        ElseIf currentCell.Y < cellToCarve.Y Then
            currentCell.SouthWall = False
            cellToCarve.NorthWall = False
        ElseIf currentCell.Y > cellToCarve.Y Then
            currentCell.NorthWall = False
            cellToCarve.SouthWall = False
        End If
    End Sub

    Public Shared Sub Fill(currentCell As Cell, otherCell As Cell)
        If currentCell.X < otherCell.X Then
            currentCell.EastWall = True
            otherCell.WestWall = True
        ElseIf currentCell.X > otherCell.X Then
            currentCell.WestWall = True
            otherCell.EastWall = True
        ElseIf currentCell.Y < otherCell.Y Then
            currentCell.SouthWall = True
            otherCell.NorthWall = True
        ElseIf currentCell.Y > otherCell.Y Then
            currentCell.NorthWall = True
            otherCell.SouthWall = True
        End If
    End Sub

    Public Shared Function IsWall(currentCell As Cell, otherCell As Cell) As Boolean
        If currentCell.X < otherCell.X Then
            Return currentCell.EastWall
        ElseIf currentCell.X > otherCell.X Then
            Return currentCell.WestWall
        ElseIf currentCell.Y < otherCell.Y Then
            Return currentCell.SouthWall
        ElseIf currentCell.Y > otherCell.Y Then
            Return currentCell.NorthWall
        End If
        Return False
    End Function

    Public Shared Sub DisplayAsciiMaze(returnedMaze As Creator.Maze, Optional path As List(Of Point) = Nothing)
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
                        Console.Write("- -")
                    Else
                        Console.Write("- ")
                    End If
                End If
            Next
            Console.WriteLine("")
            'writes the east and west walls
            For x As Integer = 0 To returnedMaze.Width - 1
                Dim c As Cell = returnedMaze.GetCell(x, y)
                Dim foundPoint As Point = Nothing
                If path IsNot Nothing Then
                    Dim height = y
                    Dim width = x
                    foundPoint = path.Find(Function(p) p.X = width And p.Y = height)
                End If
                If foundPoint IsNot Nothing Then
                    If c.WestWall = True Then
                        Console.Write("|x")
                    Else
                        Console.Write(" x")
                    End If
                Else
                    If c.WestWall = True Then
                        Console.Write("| ")
                    Else
                        Console.Write("  ")
                    End If
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
    End Sub

    Public Shared Function ConvertXMLToMaze(mazeXml As String) As Creator.Maze
        'reads/deserializes the maze from the returned xml
        Dim returnedMaze As Creator.Maze
        Dim xmlReader As TextReader = New StringReader(mazeXml)
        Dim serial As XmlSerializer = New XmlSerializer(GetType(Creator.Maze))
        returnedMaze = serial.Deserialize(xmlReader)
        Return returnedMaze
    End Function

    Public Shared Function FindPath(mazeToSolve As Creator.Maze) As List(Of Point)
        Dim solver = New Solve()
        Dim solution = solver.SolveMaze(mazeToSolve, New Point(0, 0), New Point(mazeToSolve.Width - 1, mazeToSolve.Width - 1))
        If solution Is Nothing Or solution.Count = 0 Then
            Console.WriteLine("no solution")
        Else
            Console.Write($"path = ")
            For Each point In solution
                Console.Write($"({point.X}, {point.Y}) ")
            Next
            Console.WriteLine()
        End If

        Return solution
    End Function

    Public Shared DefaultMaze = "<?xml version=""1.0"" encoding=""utf-16""?>
<Maze xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Height>5</Height>
  <Width>5</Width>
  <Seed>4</Seed>
  <Cells>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>true</WestWall>
      <X>0</X>
      <Y>0</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>true</WestWall>
      <X>0</X>
      <Y>1</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>true</WestWall>
      <X>0</X>
      <Y>2</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>true</WestWall>
      <X>0</X>
      <Y>3</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>true</WestWall>
      <X>0</X>
      <Y>4</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>false</WestWall>
      <X>1</X>
      <Y>0</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>true</WestWall>
      <X>1</X>
      <Y>1</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>false</WestWall>
      <X>1</X>
      <Y>2</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>true</WestWall>
      <X>1</X>
      <Y>3</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>true</WestWall>
      <X>1</X>
      <Y>4</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>false</WestWall>
      <X>2</X>
      <Y>0</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>true</WestWall>
      <X>2</X>
      <Y>1</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>false</WestWall>
      <X>2</X>
      <Y>2</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>true</WestWall>
      <X>2</X>
      <Y>3</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>true</WestWall>
      <X>2</X>
      <Y>4</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>false</WestWall>
      <X>3</X>
      <Y>0</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>true</WestWall>
      <X>3</X>
      <Y>1</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>false</WestWall>
      <X>3</X>
      <Y>2</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>false</SouthWall>
      <WestWall>false</WestWall>
      <X>3</X>
      <Y>3</Y>
    </Cell>
    <Cell>
      <NorthWall>false</NorthWall>
      <EastWall>false</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>true</WestWall>
      <X>3</X>
      <Y>4</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>false</WestWall>
      <X>4</X>
      <Y>0</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>false</WestWall>
      <X>4</X>
      <Y>1</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>false</WestWall>
      <X>4</X>
      <Y>2</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>false</WestWall>
      <X>4</X>
      <Y>3</Y>
    </Cell>
    <Cell>
      <NorthWall>true</NorthWall>
      <EastWall>true</EastWall>
      <SouthWall>true</SouthWall>
      <WestWall>false</WestWall>
      <X>4</X>
      <Y>4</Y>
    </Cell>
  </Cells>
</Maze>"
End Class
