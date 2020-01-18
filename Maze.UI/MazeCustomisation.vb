Imports System.IO
Imports System.Xml.Serialization
Imports Maze.Creator

Public Class MazeCustomisation
    Dim MazeModel As Creator.Maze
    Dim CellSize As Integer
    Dim Solution As List(Of Point)
    Dim ShowSolution As Boolean = False
    Dim UserLocation As Point = New Point(0, 0)
    Dim ExitPoint As Point

    Private Sub GenerateButton_Click(sender As Object, e As EventArgs) Handles GenerateButton.Click
        Dim m As Generate = New Generate()
        Dim startTime As DateTime = DateTime.Now
        Dim mazeXml = m.InitialiseGrid(MazeWidth.Value, MazeHeight.Value, MazeSeed.Value, Algorithm.SelectedIndex)
        Dim endTime As DateTime = DateTime.Now
        Dim duration As TimeSpan = endTime - startTime
        MazeModel = Utility.ConvertXMLToMaze(mazeXml)
        Dim mazeSolver = New Solve()
        Solution = mazeSolver.SolveMaze(mazeXml, New Point(0, 0), New Point(MazeModel.Width - 1, MazeModel.Height - 1))
        SetCellSize()
        ExitPoint = New Point(MazeModel.Width, MazeModel.Height)
        MazeSize.Text = $"no. cells = {MazeModel.Height * MazeModel.Width}"
        TimeTaken.Text = $"maze gen took {CInt(duration.TotalMilliseconds)} ms"
        PathLength.Text = $"shortest path is {Solution.Count - 1} cells"
        
        'Debug.WriteLine($"Cell width = {CellWidth}")
        'Debug.WriteLine($"Cell height = {CellHeight}")
        'Debug.WriteLine($"Cell size = {CellSize}")
        'Debug.WriteLine($"Maze Grid = {MazeGrid.Width}, {MazeGrid.Height}")
        Me.Refresh()
    End Sub

    Private Sub SetCellSize()
        Dim CellWidth As Integer = Math.Floor((MazeGrid.Width - 1) / MazeWidth.Value)
        Dim CellHeight As Integer = Math.Floor((MazeGrid.Height - 1) / MazeHeight.Value)
        If CellWidth < CellHeight Then
            CellSize = CellWidth
        Else
            CellSize = CellHeight
        End If
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
            If ShowSolution = True Then
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
            Dim fontSize As Integer = Math.Floor(size / 2)
            Dim drawFont As Font = New Font("Arial", fontSize, FontStyle.Bold)
            Dim drawBrush As SolidBrush = New SolidBrush(Color.Green)
            Dim drawPoint As PointF = New PointF(size / 4, size / 4)
            e.Graphics.DrawString("*", drawFont, drawBrush, drawPoint)

            Dim exitX As Integer = MazeModel.Width * size - size * 0.75
            Dim exitY As Integer = MazeModel.Height * size - size * 0.75
            Dim exitPoint As PointF = New PointF(exitX, exitY)
            e.Graphics.DrawString("*", drawFont, drawBrush, exitPoint)

            Dim userX As Integer = UserLocation.X * size + size / 8
            Dim userY As Integer = UserLocation.Y * size + size / 8
            Dim userPoint As PointF = New PointF(userX, userY)
            e.Graphics.DrawString("@", drawFont, drawBrush, userPoint)
        End If
    End Sub

    Private Sub ToggleSolution_Click(sender As Object, e As EventArgs) Handles ToggleSolution.Click
        If ShowSolution = False Then
            ShowSolution = True
        Else
            ShowSolution = False
        End If
        Me.Refresh()
    End Sub

    Private Sub SaveMazeButton_Click(sender As Object, e As EventArgs) Handles SaveMazeButton.Click
        SaveFileDialog1.Filter = "XML | *.xml"
        SaveFileDialog1.Title = "Save A Maze"
        SaveFileDialog1.ShowDialog()

        If Not String.IsNullOrEmpty(SaveFileDialog1.FileName) Then
            Dim xmlserialize As XmlSerializer = New XmlSerializer(GetType(Creator.Maze))
            Dim file As StreamWriter = New StreamWriter(SaveFileDialog1.FileName)

            xmlserialize.Serialize(file, MazeModel)
            file.Close()
        End If
    End Sub

    Private Sub LoadMazeButton_Click(sender As Object, e As EventArgs) Handles LoadMazeButton.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim serial As XmlSerializer = New XmlSerializer(GetType(Creator.Maze))
            Dim readStream As FileStream = New FileStream(OpenFileDialog1.FileName, FileMode.Open)

            MazeModel = serial.Deserialize(readStream)
            readStream.Close()
            MazeHeight.Value = MazeModel.Height
            MazeWidth.Value = MazeModel.Width
            MazeSeed.Value = MazeModel.Seed
            SetCellSize()
            Me.Refresh()
        End If
    End Sub


    Private Sub MazeCustomisation_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp, MyBase.KeyDown
        If e.KeyCode = Keys.Left Then
        End If
        If e.KeyCode = Keys.Up Then
        End If
        If e.KeyCode = Keys.Down Then
        End If
        If e.KeyCode = Keys.Right Then
        End If
        Me.Refresh()
    End Sub


    Private Sub GoEast_Click(sender As Object, e As EventArgs) Handles GoEast.Click
        Dim cell = MazeModel.GetCell(UserLocation)
        If Not cell.EastWall Then
            UserLocation.X = UserLocation.X + 1
            Me.Refresh()
        End If
    End Sub

    Private Sub GoNorth_Click(sender As Object, e As EventArgs) Handles GoNorth.Click
        Dim cell = MazeModel.GetCell(UserLocation)
        If Not cell.NorthWall Then
            UserLocation.Y = UserLocation.Y - 1
            Me.Refresh()
        End If
    End Sub

    Private Sub GoWest_Click(sender As Object, e As EventArgs) Handles GoWest.Click
        Dim cell = MazeModel.GetCell(UserLocation)
        If Not cell.WestWall Then
            UserLocation.X = UserLocation.X - 1
            Me.Refresh()
        End If
    End Sub

    Private Sub GoSouth_Click(sender As Object, e As EventArgs) Handles GoSouth.Click
        Dim cell = MazeModel.GetCell(UserLocation)
        If Not cell.SouthWall Then
            UserLocation.Y = UserLocation.Y + 1
            Me.Refresh()
        End If
    End Sub
End Class