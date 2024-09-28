<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Appointment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Appointment))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnAddAppointment = New Guna.UI2.WinForms.Guna2Button()
        Me.lblMonthAndYear = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnToday = New Guna.UI2.WinForms.Guna2Button()
        Me.btnNextMonth = New Guna.UI2.WinForms.Guna2Button()
        Me.btnPrevMonth = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.flDays = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.lblMonthAndYear)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1653, 79)
        Me.Panel1.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnAddAppointment)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1390, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(263, 79)
        Me.Panel6.TabIndex = 0
        '
        'btnAddAppointment
        '
        Me.btnAddAppointment.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAddAppointment.BorderRadius = 20
        Me.btnAddAppointment.CheckedState.Parent = Me.btnAddAppointment
        Me.btnAddAppointment.CustomImages.Parent = Me.btnAddAppointment
        Me.btnAddAppointment.FillColor = System.Drawing.Color.Lime
        Me.btnAddAppointment.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddAppointment.ForeColor = System.Drawing.Color.Black
        Me.btnAddAppointment.HoverState.Parent = Me.btnAddAppointment
        Me.btnAddAppointment.Location = New System.Drawing.Point(39, 16)
        Me.btnAddAppointment.Name = "btnAddAppointment"
        Me.btnAddAppointment.ShadowDecoration.Parent = Me.btnAddAppointment
        Me.btnAddAppointment.Size = New System.Drawing.Size(180, 45)
        Me.btnAddAppointment.TabIndex = 3
        Me.btnAddAppointment.Text = "+NEW"
        '
        'lblMonthAndYear
        '
        Me.lblMonthAndYear.AutoSize = True
        Me.lblMonthAndYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthAndYear.Location = New System.Drawing.Point(12, 9)
        Me.lblMonthAndYear.Name = "lblMonthAndYear"
        Me.lblMonthAndYear.Size = New System.Drawing.Size(295, 51)
        Me.lblMonthAndYear.TabIndex = 2
        Me.lblMonthAndYear.Text = "January, 2024"
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel2.Controls.Add(Me.btnToday)
        Me.Panel2.Controls.Add(Me.btnNextMonth)
        Me.Panel2.Controls.Add(Me.btnPrevMonth)
        Me.Panel2.Location = New System.Drawing.Point(720, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(303, 79)
        Me.Panel2.TabIndex = 1
        '
        'btnToday
        '
        Me.btnToday.BackColor = System.Drawing.Color.White
        Me.btnToday.BorderColor = System.Drawing.Color.Transparent
        Me.btnToday.BorderRadius = 1000
        Me.btnToday.CheckedState.Parent = Me.btnToday
        Me.btnToday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnToday.CustomImages.Parent = Me.btnToday
        Me.btnToday.FillColor = System.Drawing.Color.White
        Me.btnToday.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnToday.ForeColor = System.Drawing.Color.Black
        Me.btnToday.HoverState.Parent = Me.btnToday
        Me.btnToday.Location = New System.Drawing.Point(61, 16)
        Me.btnToday.Name = "btnToday"
        Me.btnToday.ShadowDecoration.Parent = Me.btnToday
        Me.btnToday.Size = New System.Drawing.Size(169, 45)
        Me.btnToday.TabIndex = 47
        Me.btnToday.Text = "Today"
        '
        'btnNextMonth
        '
        Me.btnNextMonth.BackColor = System.Drawing.Color.White
        Me.btnNextMonth.BorderColor = System.Drawing.Color.Transparent
        Me.btnNextMonth.BorderRadius = 1000
        Me.btnNextMonth.CheckedState.Parent = Me.btnNextMonth
        Me.btnNextMonth.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNextMonth.CustomImages.Parent = Me.btnNextMonth
        Me.btnNextMonth.FillColor = System.Drawing.Color.White
        Me.btnNextMonth.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNextMonth.ForeColor = System.Drawing.Color.White
        Me.btnNextMonth.HoverState.Parent = Me.btnNextMonth
        Me.btnNextMonth.Image = CType(resources.GetObject("btnNextMonth.Image"), System.Drawing.Image)
        Me.btnNextMonth.Location = New System.Drawing.Point(236, 15)
        Me.btnNextMonth.Name = "btnNextMonth"
        Me.btnNextMonth.ShadowDecoration.Parent = Me.btnNextMonth
        Me.btnNextMonth.Size = New System.Drawing.Size(52, 45)
        Me.btnNextMonth.TabIndex = 46
        '
        'btnPrevMonth
        '
        Me.btnPrevMonth.BackColor = System.Drawing.Color.White
        Me.btnPrevMonth.BorderColor = System.Drawing.Color.Transparent
        Me.btnPrevMonth.BorderRadius = 1000
        Me.btnPrevMonth.CheckedState.Parent = Me.btnPrevMonth
        Me.btnPrevMonth.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrevMonth.CustomImages.Parent = Me.btnPrevMonth
        Me.btnPrevMonth.FillColor = System.Drawing.Color.White
        Me.btnPrevMonth.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPrevMonth.ForeColor = System.Drawing.Color.White
        Me.btnPrevMonth.HoverState.Parent = Me.btnPrevMonth
        Me.btnPrevMonth.Image = CType(resources.GetObject("btnPrevMonth.Image"), System.Drawing.Image)
        Me.btnPrevMonth.Location = New System.Drawing.Point(3, 16)
        Me.btnPrevMonth.Name = "btnPrevMonth"
        Me.btnPrevMonth.ShadowDecoration.Parent = Me.btnPrevMonth
        Me.btnPrevMonth.Size = New System.Drawing.Size(52, 45)
        Me.btnPrevMonth.TabIndex = 46
        '
        'Panel5
        '
        Me.Panel5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Location = New System.Drawing.Point(47, 79)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1571, 48)
        Me.Panel5.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Red
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1344, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(215, 48)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Saturday"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gray
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1122, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(215, 48)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Friday"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gray
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(900, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(215, 48)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Thursday"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gray
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(454, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 48)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tuesday"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gray
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(230, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 48)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Monday"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gray
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(678, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(215, 48)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Wednesday"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sunday"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 79)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(50, 932)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1624, 79)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(29, 932)
        Me.Panel4.TabIndex = 1
        '
        'flDays
        '
        Me.flDays.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.flDays.Location = New System.Drawing.Point(47, 133)
        Me.flDays.Name = "flDays"
        Me.flDays.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.flDays.Size = New System.Drawing.Size(1571, 875)
        Me.flDays.TabIndex = 4
        '
        'Appointment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1653, 1011)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.flDays)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Appointment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form5"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblMonthAndYear As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnPrevMonth As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNextMonth As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnToday As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnAddAppointment As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents flDays As FlowLayoutPanel
End Class
