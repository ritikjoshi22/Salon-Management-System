<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddAppoinment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddAppoinment))
        Me.cbCustomer = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cbService = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnSave = New Guna.UI2.WinForms.Guna2Button()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.dtpAppointment = New System.Windows.Forms.DateTimePicker()
        Me.Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbCustomer
        '
        Me.cbCustomer.BackColor = System.Drawing.Color.Transparent
        Me.cbCustomer.DisplayMember = "Text"
        Me.cbCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCustomer.FocusedColor = System.Drawing.Color.Empty
        Me.cbCustomer.FocusedState.Parent = Me.cbCustomer
        Me.cbCustomer.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cbCustomer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.HoverState.Parent = Me.cbCustomer
        Me.cbCustomer.ItemHeight = 30
        Me.cbCustomer.ItemsAppearance.Parent = Me.cbCustomer
        Me.cbCustomer.Location = New System.Drawing.Point(294, 122)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.ShadowDecoration.Parent = Me.cbCustomer
        Me.cbCustomer.Size = New System.Drawing.Size(195, 36)
        Me.cbCustomer.TabIndex = 0
        Me.cbCustomer.ValueMember = "Value"
        '
        'cbService
        '
        Me.cbService.BackColor = System.Drawing.Color.Transparent
        Me.cbService.DisplayMember = "Text"
        Me.cbService.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbService.FocusedColor = System.Drawing.Color.Empty
        Me.cbService.FocusedState.Parent = Me.cbService
        Me.cbService.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cbService.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cbService.FormattingEnabled = True
        Me.cbService.HoverState.Parent = Me.cbService
        Me.cbService.ItemHeight = 30
        Me.cbService.ItemsAppearance.Parent = Me.cbService
        Me.cbService.Location = New System.Drawing.Point(294, 184)
        Me.cbService.Name = "cbService"
        Me.cbService.ShadowDecoration.Parent = Me.cbService
        Me.cbService.Size = New System.Drawing.Size(195, 36)
        Me.cbService.TabIndex = 1
        Me.cbService.ValueMember = "Value"
        '
        'btnSave
        '
        Me.btnSave.CheckedState.Parent = Me.btnSave
        Me.btnSave.CustomImages.Parent = Me.btnSave
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.HoverState.Parent = Me.btnSave
        Me.btnSave.Location = New System.Drawing.Point(294, 321)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.ShadowDecoration.Parent = Me.btnSave
        Me.btnSave.Size = New System.Drawing.Size(180, 45)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(314, 39)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(131, 20)
        Me.GunaLabel1.TabIndex = 4
        Me.GunaLabel1.Text = "New Appointment"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.Location = New System.Drawing.Point(195, 138)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(72, 20)
        Me.GunaLabel2.TabIndex = 5
        Me.GunaLabel2.Text = "Customer"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel3.Location = New System.Drawing.Point(195, 200)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(62, 20)
        Me.GunaLabel3.TabIndex = 6
        Me.GunaLabel3.Text = "Services"
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel4.Location = New System.Drawing.Point(146, 263)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(133, 20)
        Me.GunaLabel4.TabIndex = 7
        Me.GunaLabel4.Text = "Appointment Date"
        '
        'dtpAppointment
        '
        Me.dtpAppointment.Location = New System.Drawing.Point(289, 263)
        Me.dtpAppointment.Name = "dtpAppointment"
        Me.dtpAppointment.Size = New System.Drawing.Size(200, 22)
        Me.dtpAppointment.TabIndex = 8
        '
        'Guna2CirclePictureBox1
        '
        Me.Guna2CirclePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Guna2CirclePictureBox1.Image = CType(resources.GetObject("Guna2CirclePictureBox1.Image"), System.Drawing.Image)
        Me.Guna2CirclePictureBox1.Location = New System.Drawing.Point(765, 2)
        Me.Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Me.Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox1.ShadowDecoration.Parent = Me.Guna2CirclePictureBox1
        Me.Guna2CirclePictureBox1.Size = New System.Drawing.Size(33, 30)
        Me.Guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox1.TabIndex = 9
        Me.Guna2CirclePictureBox1.TabStop = False
        '
        'AddAppoinment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Guna2CirclePictureBox1)
        Me.Controls.Add(Me.dtpAppointment)
        Me.Controls.Add(Me.GunaLabel4)
        Me.Controls.Add(Me.GunaLabel3)
        Me.Controls.Add(Me.GunaLabel2)
        Me.Controls.Add(Me.GunaLabel1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbService)
        Me.Controls.Add(Me.cbCustomer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddAppoinment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form4"
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbCustomer As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cbService As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents dtpAppointment As DateTimePicker
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
End Class
