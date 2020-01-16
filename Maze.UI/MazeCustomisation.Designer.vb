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
        Me.Width.TabIndex = 0
        Me.Width.Text = "Width"
        '
        'Height
        '
        Me.Height.AutoSize = true
        Me.Height.Location = New System.Drawing.Point(12, 48)
        Me.Height.Name = "Height"
        Me.Height.Size = New System.Drawing.Size(38, 13)
        Me.Height.TabIndex = 2
        Me.Height.Text = "Height"
        '
        'Seed
        '
        Me.Seed.AutoSize = true
        Me.Seed.Location = New System.Drawing.Point(12, 87)
        Me.Seed.Name = "Seed"
        Me.Seed.Size = New System.Drawing.Size(32, 13)
        Me.Seed.TabIndex = 4
        Me.Seed.Text = "Seed"
        '
        'GenerateButton
        '
        Me.GenerateButton.Location = New System.Drawing.Point(15, 379)
        Me.GenerateButton.Name = "GenerateButton"
        Me.GenerateButton.Size = New System.Drawing.Size(140, 59)
        Me.GenerateButton.TabIndex = 6
        Me.GenerateButton.Text = "Generate"
        Me.GenerateButton.UseVisualStyleBackColor = true
        '
        'MazeWidth
        '
        Me.MazeWidth.Location = New System.Drawing.Point(15, 25)
        Me.MazeWidth.Name = "MazeWidth"
        Me.MazeWidth.Size = New System.Drawing.Size(140, 20)
        Me.MazeWidth.TabIndex = 7
        '
        'MazeHeight
        '
        Me.MazeHeight.Location = New System.Drawing.Point(15, 64)
        Me.MazeHeight.Name = "MazeHeight"
        Me.MazeHeight.Size = New System.Drawing.Size(140, 20)
        Me.MazeHeight.TabIndex = 8
        '
        'MazeSeed
        '
        Me.MazeSeed.Location = New System.Drawing.Point(15, 103)
        Me.MazeSeed.Name = "MazeSeed"
        Me.MazeSeed.Size = New System.Drawing.Size(140, 20)
        Me.MazeSeed.TabIndex = 9
        '
        'Algorithm
        '
        Me.Algorithm.FormattingEnabled = true
        Me.Algorithm.Location = New System.Drawing.Point(15, 168)
        Me.Algorithm.Name = "Algorithm"
        Me.Algorithm.Size = New System.Drawing.Size(140, 21)
        Me.Algorithm.TabIndex = 10
        '
        'AlgorithmLabel
        '
        Me.AlgorithmLabel.AutoSize = true
        Me.AlgorithmLabel.Location = New System.Drawing.Point(12, 152)
        Me.AlgorithmLabel.Name = "AlgorithmLabel"
        Me.AlgorithmLabel.Size = New System.Drawing.Size(50, 13)
        Me.AlgorithmLabel.TabIndex = 11
        Me.AlgorithmLabel.Text = "Algorithm"
        '
        'RandomSeed
        '
        Me.RandomSeed.Location = New System.Drawing.Point(15, 129)
        Me.RandomSeed.Name = "RandomSeed"
        Me.RandomSeed.Size = New System.Drawing.Size(140, 20)
        Me.RandomSeed.TabIndex = 12
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
        Me.MazeGrid.TabIndex = 13
        '
        'ToggleSolution
        '
        Me.ToggleSolution.Location = New System.Drawing.Point(15, 196)
        Me.ToggleSolution.Name = "ToggleSolution"
        Me.ToggleSolution.Size = New System.Drawing.Size(140, 23)
        Me.ToggleSolution.TabIndex = 14
        Me.ToggleSolution.Text = "Toggle Solution"
        Me.ToggleSolution.UseVisualStyleBackColor = true
        '
        'SaveMazeButton
        '
        Me.SaveMazeButton.Location = New System.Drawing.Point(15, 254)
        Me.SaveMazeButton.Name = "SaveMazeButton"
        Me.SaveMazeButton.Size = New System.Drawing.Size(140, 23)
        Me.SaveMazeButton.TabIndex = 15
        Me.SaveMazeButton.Text = "Save Maze"
        Me.SaveMazeButton.UseVisualStyleBackColor = true
        '
        'LoadMazeButton
        '
        Me.LoadMazeButton.Location = New System.Drawing.Point(15, 225)
        Me.LoadMazeButton.Name = "LoadMazeButton"
        Me.LoadMazeButton.Size = New System.Drawing.Size(140, 23)
        Me.LoadMazeButton.TabIndex = 16
        Me.LoadMazeButton.Text = "Load Maze"
        Me.LoadMazeButton.UseVisualStyleBackColor = true
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MazeCustomisation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 450)
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
End Class
