<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Me.MazeGenerator = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'MazeGenerator
        '
        Me.MazeGenerator.Location = New System.Drawing.Point(12, 12)
        Me.MazeGenerator.Name = "MazeGenerator"
        Me.MazeGenerator.Size = New System.Drawing.Size(119, 55)
        Me.MazeGenerator.TabIndex = 0
        Me.MazeGenerator.Text = "Maze Generator"
        Me.MazeGenerator.UseVisualStyleBackColor = true
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 178)
        Me.Controls.Add(Me.MazeGenerator)
        Me.Name = "MainMenu"
        Me.Text = "Main Menu"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents MazeGenerator As Button
End Class
