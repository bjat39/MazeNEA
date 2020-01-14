Imports Maze.Creator

Public Class MazeCustomisation
    Dim MazeModel As Creator.Maze
    Dim CellSize As Integer
    Dim Solution As List(Of Point)

    Private Sub GenerateButton_Click(sender As Object, e As EventArgs) Handles GenerateButton.Click
        Dim m As Generate = New Generate()
        Dim mazeXml = m.InitialiseGrid(MazeWidth.Value, MazeHeight.Value, MazeSeed.Value, Algorithm.SelectedIndex)
        MazeModel = Utility.ConvertXMLToMaze(mazeXml)
        Dim mazeSolver = New Solve()
        Solution = mazeSolver.SolveMaze(mazeXml, New Point(0, 0), New Point(MazeModel.Width - 1, MazeModel.Height - 1))
        Dim CellWidth As Integer = Math.Floor((MazeGrid.Width - 1) / MazeWidth.Value)
        Dim CellHeight As Integer = Math.Floor((MazeGrid.Height - 1) / MazeHeight.Value)
        If CellWidth < CellHeight Then
            CellSize = CellWidth
        Else
            CellSize = CellHeight
        End If
        'Debug.WriteLine($"Cell width = {CellWidth}")
        'Debug.WriteLine($"Cell height = {CellHeight}")
        'Debug.WriteLine($"Cell size = {CellSize}")
        'Debug.WriteLine($"Maze Grid = {MazeGrid.Width}, {MazeGrid.Height}")
        Me.Refresh()
    End Sub

    Private Sub MazeCustomisation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Algorithm.Items.Add("Prim's Algorithm")
        Algorithm.Items.Add("Recursive Backtracker")
        Algorithm.Items.Add("Recursive Division")
        Algorithm.SelectedIndex = 0

        MazeHeight.Value = 10
        MazeWidth.Value = 10
        MazeHeight.Minimum = 2
        MazeWidth.Minimum = 2
        MazeHeight.Maximum = 1000
        MazeWidth.Maximum = 1000
        MazeSeed.Maximum = Integer.MaxValue

        CellSize = 0

        If MazeSeed.Value = 0 Then
            Randomize()
            Dim randomNumber As Random = New Random()
            MazeSeed.Value = randomNumber.Next(0, Integer.MaxValue - 1)
        End If
    End Sub

    Private Sub RandomSeed_Click(sender As Object, e As EventArgs) Handles RandomSeed.Click
        Randomize()
        Dim randomNumber As Random = New Random()
        MazeSeed.Value = randomNumber.Next(0, Integer.MaxValue - 1)

    End Sub

    Private Sub MazeGrid_Paint(sender As Object, e As PaintEventArgs) Handles MazeGrid.Paint

        'Debug.WriteLine($"Paint: {e.ClipRectangle.ToString()}")
        If MazeModel IsNot Nothing Then
            Dim pen = New Pen(Color.Black)
            Dim size = CellSize
            For x = 0 To MazeModel.Width - 1
                For y = 0 To MazeModel.Height - 1
                    Dim cell As Cell = MazeModel.GetCell(x, y)
                    If cell.NorthWall = True Then
                        e.Graphics.DrawLine(pen, x * size, y * size, (x + 1) * size, y * size)
                    End If
                    If cell.WestWall = True Then
                        e.Graphics.DrawLine(pen, x * size, y * size, x * size, (y + 1) * size)
                    End If
                    If y = MazeModel.Height - 1 Then
                        If cell.SouthWall = True Then
                            e.Graphics.DrawLine(pen, x * size, (y + 1) * size, (x + 1) * size, (y + 1) * size)
                        End If
                    End If
                    If x = MazeModel.Width - 1 Then
                        If cell.EastWall = True Then
                            e.Graphics.DrawLine(pen, (x + 1) * size, y * size, (x + 1) * size, (y + 1) * size)
                        End If
                    End If
                Next
            Next
            Dim firstPoint As Point
            Dim secondPoint As Point
            Dim redPen = New Pen(Color.Red)
            For Each point In Solution
                secondPoint = point
                If firstPoint IsNot Nothing Then
                    Dim x1 As Integer = firstPoint.X * size + size / 2
                    Dim y1 As Integer = firstPoint.Y * size + size / 2
                    Dim x2 As Integer = secondPoint.X * size + size / 2
                    Dim y2 As Integer = secondPoint.Y * size + size / 2
                    e.Graphics.DrawLine(redPen, x1, y1, x2, y2)
                End If
                firstPoint = secondPoint
            Next
        End If
    End Sub
End Class