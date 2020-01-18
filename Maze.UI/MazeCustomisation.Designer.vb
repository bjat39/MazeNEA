<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MazeCustomisation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Width = New System.Windows.Forms.Label()
        Me.Height = New System.Windows.Forms.Label()
        Me.Seed = New System.Windows.Forms.Label()
        Me.GenerateButton = New System.Windows.Forms.Button()
        Me.MazeWidth = New System.Windows.Forms.NumericUpDown()
        Me.MazeHeight = New System.Windows.Forms.NumericUpDown()
        Me.MazeSeed = New System.Windows.Forms.NumericUpDown()
        Me.Algorithm = New System.Windows.Forms.ComboBox()
        Me.AlgorithmLabel = New System.Windows.Forms.Label()
        Me.RandomSeed = New System.Windows.Forms.Button()
        Me.MazeGrid = New System.Windows.Forms.Panel()
        Me.ToggleSolution = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SaveMazeButton = New System.Windows.Forms.Button()
        Me.LoadMazeButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GoWest = New System.Windows.Forms.Button()
        Me.GoNorth = New System.Windows.Forms.Button()
        Me.GoEast = New System.Windows.Forms.Button()
        Me.GoSouth = New System.Windows.Forms.Button()
        CType(Me.MazeWidth,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.MazeHeight,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.MazeSeed,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Width
        '
        Me.Width.AutoSize = true
        Me.Width.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Width.Location = New System.Drawing.Point(12, 9)
        Me.Width.Name = "Width"
        Me.Width.Size = New System.Drawing.Size(35, 13)
        Me.Width.TabIndex = 13
        Me.Width.Text = "Width"
        '
        'Height
        '
        Me.Height.AutoSize = true
        Me.Height.Location = New System.Drawing.Point(12, 48)
        Me.Height.Name = "Height"
        Me.Height.Size = New System.Drawing.Size(38, 13)
        Me.Height.TabIndex = 14
        Me.Height.Text = "Height"
        '
        'Seed
        '
        Me.Seed.AutoSize = true
        Me.Seed.Location = New System.Drawing.Point(12, 87)
        Me.Seed.Name = "Seed"
        Me.Seed.Size = New System.Drawing.Size(32, 13)
        Me.Seed.TabIndex = 15
        Me.Seed.Text = "Seed"
        '
        'GenerateButton
        '
        Me.GenerateButton.Location = New System.Drawing.Point(15, 379)
        Me.GenerateButton.Name = "GenerateButton"
        Me.GenerateButton.Size = New System.Drawing.Size(140, 59)
        Me.GenerateButton.TabIndex = 12
        Me.GenerateButton.Text = "Generate"
        Me.GenerateButton.UseVisualStyleBackColor = true
        '
        'MazeWidth
        '
        Me.MazeWidth.Location = New System.Drawing.Point(15, 25)
        Me.MazeWidth.Name = "MazeWidth"
        Me.MazeWidth.Size = New System.Drawing.Size(140, 20)
        Me.MazeWidth.TabIndex = 0
        '
        'MazeHeight
        '
        Me.MazeHeight.Location = New System.Drawing.Point(15, 64)
        Me.MazeHeight.Name = "MazeHeight"
        Me.MazeHeight.Size = New System.Drawing.Size(140, 20)
        Me.MazeHeight.TabIndex = 1
        '
        'MazeSeed
        '
        Me.MazeSeed.Location = New System.Drawing.Point(15, 103)
        Me.MazeSeed.Name = "MazeSeed"
        Me.MazeSeed.Size = New System.Drawing.Size(140, 20)
        Me.MazeSeed.TabIndex = 2
        '
        'Algorithm
        '
        Me.Algorithm.FormattingEnabled = true
        Me.Algorithm.Location = New System.Drawing.Point(15, 168)
        Me.Algorithm.Name = "Algorithm"
        Me.Algorithm.Size = New System.Drawing.Size(140, 21)
        Me.Algorithm.TabIndex = 4
        '
        'AlgorithmLabel
        '
        Me.AlgorithmLabel.AutoSize = true
        Me.AlgorithmLabel.Location = New System.Drawing.Point(12, 152)
        Me.AlgorithmLabel.Name = "AlgorithmLabel"
        Me.AlgorithmLabel.Size = New System.Drawing.Size(50, 13)
        Me.AlgorithmLabel.TabIndex = 16
        Me.AlgorithmLabel.Text = "Algorithm"
        '
        'RandomSeed
        '
        Me.RandomSeed.Location = New System.Drawing.Point(15, 129)
        Me.RandomSeed.Name = "RandomSeed"
        Me.RandomSeed.Size = New System.Drawing.Size(140, 20)
        Me.RandomSeed.TabIndex = 3
        Me.RandomSeed.Text = "Random Seed"
        Me.RandomSeed.UseVisualStyleBackColor = true
        '
        'MazeGrid
        '
        Me.MazeGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.MazeGrid.Location = New System.Drawing.Point(161, 12)
        Me.MazeGrid.Name = "MazeGrid"
        Me.MazeGrid.Size = New System.Drawing.Size(450, 426)
        Me.MazeGrid.TabIndex = 17
        '
        'ToggleSolution
        '
        Me.ToggleSolution.Location = New System.Drawing.Point(15, 196)
        Me.ToggleSolution.Name = "ToggleSolution"
        Me.ToggleSolution.Size = New System.Drawing.Size(140, 23)
        Me.ToggleSolution.TabIndex = 5
        Me.ToggleSolution.Text = "Toggle Solution"
        Me.ToggleSolution.UseVisualStyleBackColor = true
        '
        'SaveMazeButton
        '
        Me.SaveMazeButton.Location = New System.Drawing.Point(15, 254)
        Me.SaveMazeButton.Name = "SaveMazeButton"
        Me.SaveMazeButton.Size = New System.Drawing.Size(140, 23)
        Me.SaveMazeButton.TabIndex = 7
        Me.SaveMazeButton.Text = "Save Maze"
        Me.SaveMazeButton.UseVisualStyleBackColor = true
        '
        'LoadMazeButton
        '
        Me.LoadMazeButton.Location = New System.Drawing.Point(15, 225)
        Me.LoadMazeButton.Name = "LoadMazeButton"
        Me.LoadMazeButton.Size = New System.Drawing.Size(140, 23)
        Me.LoadMazeButton.TabIndex = 6
        Me.LoadMazeButton.Text = "Load Maze"
        Me.LoadMazeButton.UseVisualStyleBackColor = true
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GoWest
        '
        Me.GoWest.Location = New System.Drawing.Point(37, 312)
        Me.GoWest.Name = "GoWest"
        Me.GoWest.Size = New System.Drawing.Size(42, 23)
        Me.GoWest.TabIndex = 8
        Me.GoWest.Text = "West"
        Me.GoWest.UseVisualStyleBackColor = true
        '
        'GoNorth
        '
        Me.GoNorth.Location = New System.Drawing.Point(61, 283)
        Me.GoNorth.Name = "GoNorth"
        Me.GoNorth.Size = New System.Drawing.Size(50, 23)
        Me.GoNorth.TabIndex = 9
        Me.GoNorth.Text = "North"
        Me.GoNorth.UseVisualStyleBackColor = true
        '
        'GoEast
        '
        Me.GoEast.Location = New System.Drawing.Point(98, 312)
        Me.GoEast.Name = "GoEast"
        Me.GoEast.Size = New System.Drawing.Size(39, 23)
        Me.GoEast.TabIndex = 10
        Me.GoEast.Text = "East"
        Me.GoEast.UseVisualStyleBackColor = true
        '
        'GoSouth
        '
        Me.GoSouth.Location = New System.Drawing.Point(61, 341)
        Me.GoSouth.Name = "GoSouth"
        Me.GoSouth.Size = New System.Drawing.Size(50, 23)
        Me.GoSouth.TabIndex = 11
        Me.GoSouth.Text = "South"
        Me.GoSouth.UseVisualStyleBackColor = true
        '
        'MazeCustomisation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 450)
        Me.Controls.Add(Me.GoSouth)
        Me.Controls.Add(Me.GoEast)
        Me.Controls.Add(Me.GoNorth)
        Me.Controls.Add(Me.GoWest)
        Me.Controls.Add(Me.LoadMazeButton)
        Me.Controls.Add(Me.SaveMazeButton)
        Me.Controls.Add(Me.ToggleSolution)
        Me.Controls.Add(Me.MazeGrid)
        Me.Controls.Add(Me.RandomSeed)
        Me.Controls.Add(Me.AlgorithmLabel)
        Me.Controls.Add(Me.Algorithm)
        Me.Controls.Add(Me.MazeSeed)
        Me.Controls.Add(Me.MazeHeight)
        Me.Controls.Add(Me.MazeWidth)
        Me.Controls.Add(Me.GenerateButton)
        Me.Controls.Add(Me.Seed)
        Me.Controls.Add(Me.Height)
        Me.Controls.Add(Me.Width)
        Me.Name = "MazeCustomisation"
        Me.Text = "MazeCustomisation"
        CType(Me.MazeWidth,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MazeHeight,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MazeSeed,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Width As Label
    Friend WithEvents Height As Label
    Friend WithEvents Seed As Label
    Friend WithEvents GenerateButton As Button
    Friend WithEvents MazeWidth As NumericUpDown
    Friend WithEvents MazeHeight As NumericUpDown
    Friend WithEvents MazeSeed As NumericUpDown
    Friend WithEvents Algorithm As ComboBox
    Friend WithEvents AlgorithmLabel As Label
    Friend WithEvents RandomSeed As Button
    Friend WithEvents MazeGrid As Panel
    Friend WithEvents ToggleSolution As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents SaveMazeButton As Button
    Friend WithEvents LoadMazeButton As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GoWest As Button
    Friend WithEvents GoNorth As Button
    Friend WithEvents GoEast As Button
    Friend WithEvents GoSouth As Button
End Class
