<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.pbar = New System.Windows.Forms.ProgressBar
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.FileList = New System.Windows.Forms.CheckedListBox
        Me.lblProgress = New System.Windows.Forms.Label
        Me.cmdLoad = New System.Windows.Forms.Button
        Me.cmdConvert = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'pbar
        '
        Me.pbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbar.Location = New System.Drawing.Point(274, 270)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(249, 23)
        Me.pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbar.TabIndex = 15
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Location = New System.Drawing.Point(11, 22)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(120, 17)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "Check/Uncheck All"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FileList
        '
        Me.FileList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FileList.BackColor = System.Drawing.Color.White
        Me.FileList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FileList.FormattingEnabled = True
        Me.FileList.Location = New System.Drawing.Point(11, 55)
        Me.FileList.Name = "FileList"
        Me.FileList.Size = New System.Drawing.Size(512, 197)
        Me.FileList.TabIndex = 10
        '
        'lblProgress
        '
        Me.lblProgress.Location = New System.Drawing.Point(12, 270)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(220, 23)
        Me.lblProgress.TabIndex = 16
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(309, 18)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(104, 23)
        Me.cmdLoad.TabIndex = 12
        Me.cmdLoad.Text = "Load PDF Files"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'cmdConvert
        '
        Me.cmdConvert.Location = New System.Drawing.Point(419, 18)
        Me.cmdConvert.Name = "cmdConvert"
        Me.cmdConvert.Size = New System.Drawing.Size(104, 23)
        Me.cmdConvert.TabIndex = 11
        Me.cmdConvert.Text = "Merge PDF"
        Me.cmdConvert.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 302)
        Me.Controls.Add(Me.pbar)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.FileList)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.cmdConvert)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "PDF Merge"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbar As System.Windows.Forms.ProgressBar
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents FileList As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents cmdConvert As System.Windows.Forms.Button

End Class
