﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.MainCanvas = New System.Windows.Forms.PictureBox()
        Me.FlyRadioButton = New System.Windows.Forms.RadioButton()
        Me.WalkRadioButton = New System.Windows.Forms.RadioButton()
        Me.CoordinatesLabel = New System.Windows.Forms.Label()
        Me.TimerAnimation = New System.Windows.Forms.Timer(Me.components)
        Me.RotateRadioButton = New System.Windows.Forms.RadioButton()
        Me.ChickPos = New System.Windows.Forms.Label()
        Me.DestPoint = New System.Windows.Forms.Label()
        Me.TurnBodyAnimation = New System.Windows.Forms.Timer(Me.components)
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainCanvas
        '
        Me.MainCanvas.BackColor = System.Drawing.Color.White
        Me.MainCanvas.Location = New System.Drawing.Point(13, 13)
        Me.MainCanvas.Name = "MainCanvas"
        Me.MainCanvas.Size = New System.Drawing.Size(616, 483)
        Me.MainCanvas.TabIndex = 0
        Me.MainCanvas.TabStop = False
        '
        'FlyRadioButton
        '
        Me.FlyRadioButton.AutoSize = True
        Me.FlyRadioButton.Location = New System.Drawing.Point(639, 13)
        Me.FlyRadioButton.Name = "FlyRadioButton"
        Me.FlyRadioButton.Size = New System.Drawing.Size(68, 17)
        Me.FlyRadioButton.TabIndex = 1
        Me.FlyRadioButton.TabStop = True
        Me.FlyRadioButton.Text = "Fly Mode"
        Me.FlyRadioButton.UseVisualStyleBackColor = True
        '
        'WalkRadioButton
        '
        Me.WalkRadioButton.AutoSize = True
        Me.WalkRadioButton.Location = New System.Drawing.Point(639, 37)
        Me.WalkRadioButton.Name = "WalkRadioButton"
        Me.WalkRadioButton.Size = New System.Drawing.Size(80, 17)
        Me.WalkRadioButton.TabIndex = 2
        Me.WalkRadioButton.TabStop = True
        Me.WalkRadioButton.Text = "Walk Mode"
        Me.WalkRadioButton.UseVisualStyleBackColor = True
        '
        'CoordinatesLabel
        '
        Me.CoordinatesLabel.AutoSize = True
        Me.CoordinatesLabel.Location = New System.Drawing.Point(636, 482)
        Me.CoordinatesLabel.Name = "CoordinatesLabel"
        Me.CoordinatesLabel.Size = New System.Drawing.Size(125, 13)
        Me.CoordinatesLabel.TabIndex = 3
        Me.CoordinatesLabel.Text = "Coordinates: X = 0, Y = 0"
        '
        'TimerAnimation
        '
        Me.TimerAnimation.Interval = 20
        '
        'RotateRadioButton
        '
        Me.RotateRadioButton.AutoSize = True
        Me.RotateRadioButton.Location = New System.Drawing.Point(639, 60)
        Me.RotateRadioButton.Name = "RotateRadioButton"
        Me.RotateRadioButton.Size = New System.Drawing.Size(99, 17)
        Me.RotateRadioButton.TabIndex = 5
        Me.RotateRadioButton.TabStop = True
        Me.RotateRadioButton.Text = "Rotate Chicken"
        Me.RotateRadioButton.UseVisualStyleBackColor = True
        '
        'ChickPos
        '
        Me.ChickPos.AutoSize = True
        Me.ChickPos.Location = New System.Drawing.Point(636, 447)
        Me.ChickPos.Name = "ChickPos"
        Me.ChickPos.Size = New System.Drawing.Size(108, 13)
        Me.ChickPos.TabIndex = 6
        Me.ChickPos.Text = "Chicken: X = 0, Y = 0"
        '
        'DestPoint
        '
        Me.DestPoint.AutoSize = True
        Me.DestPoint.Location = New System.Drawing.Point(635, 413)
        Me.DestPoint.Name = "DestPoint"
        Me.DestPoint.Size = New System.Drawing.Size(149, 13)
        Me.DestPoint.TabIndex = 7
        Me.DestPoint.Text = "Destination Point: X = 0, Y = 0"
        '
        'TurnBodyAnimation
        '
        Me.TurnBodyAnimation.Interval = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 508)
        Me.Controls.Add(Me.DestPoint)
        Me.Controls.Add(Me.ChickPos)
        Me.Controls.Add(Me.RotateRadioButton)
        Me.Controls.Add(Me.CoordinatesLabel)
        Me.Controls.Add(Me.WalkRadioButton)
        Me.Controls.Add(Me.FlyRadioButton)
        Me.Controls.Add(Me.MainCanvas)
        Me.Name = "Form1"
        Me.Text = "Majestic Flap-Flap Egg Machine"
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainCanvas As PictureBox
    Friend WithEvents FlyRadioButton As RadioButton
    Friend WithEvents WalkRadioButton As RadioButton
    Friend WithEvents CoordinatesLabel As Label
    Friend WithEvents TimerAnimation As Timer
    Friend WithEvents RotateRadioButton As RadioButton
    Friend WithEvents ChickPos As Label
    Friend WithEvents DestPoint As Label
    Friend WithEvents TurnBodyAnimation As Timer
End Class
