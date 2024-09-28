<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddServices
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddServices))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtServiceName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnAdd = New Guna.UI2.WinForms.Guna2Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServicePrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbServiceGenre = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btnAddPicture = New System.Windows.Forms.PictureBox()
        Me.Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pictureBoxService = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        CType(Me.btnAddPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pictureBoxService, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(153, 345)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Service Name"
        '
        'txtServiceName
        '
        Me.txtServiceName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtServiceName.DefaultText = ""
        Me.txtServiceName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtServiceName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtServiceName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtServiceName.DisabledState.Parent = Me.txtServiceName
        Me.txtServiceName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtServiceName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtServiceName.FocusedState.Parent = Me.txtServiceName
        Me.txtServiceName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtServiceName.HoverState.Parent = Me.txtServiceName
        Me.txtServiceName.Location = New System.Drawing.Point(274, 329)
        Me.txtServiceName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtServiceName.Name = "txtServiceName"
        Me.txtServiceName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtServiceName.PlaceholderText = ""
        Me.txtServiceName.SelectedText = ""
        Me.txtServiceName.ShadowDecoration.Parent = Me.txtServiceName
        Me.txtServiceName.Size = New System.Drawing.Size(267, 44)
        Me.txtServiceName.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.BorderRadius = 10
        Me.btnAdd.CheckedState.Parent = Me.btnAdd
        Me.btnAdd.CustomImages.Parent = Me.btnAdd
        Me.btnAdd.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.HoverState.Parent = Me.btnAdd
        Me.btnAdd.Location = New System.Drawing.Point(312, 576)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.ShadowDecoration.Parent = Me.btnAdd
        Me.btnAdd.Size = New System.Drawing.Size(185, 45)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 408)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Service Price"
        '
        'txtServicePrice
        '
        Me.txtServicePrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtServicePrice.DefaultText = ""
        Me.txtServicePrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtServicePrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtServicePrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtServicePrice.DisabledState.Parent = Me.txtServicePrice
        Me.txtServicePrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtServicePrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtServicePrice.FocusedState.Parent = Me.txtServicePrice
        Me.txtServicePrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtServicePrice.HoverState.Parent = Me.txtServicePrice
        Me.txtServicePrice.Location = New System.Drawing.Point(274, 396)
        Me.txtServicePrice.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtServicePrice.Name = "txtServicePrice"
        Me.txtServicePrice.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtServicePrice.PlaceholderText = ""
        Me.txtServicePrice.SelectedText = ""
        Me.txtServicePrice.ShadowDecoration.Parent = Me.txtServicePrice
        Me.txtServicePrice.Size = New System.Drawing.Size(267, 44)
        Me.txtServicePrice.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(153, 475)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Service Genre"
        '
        'cbServiceGenre
        '
        Me.cbServiceGenre.BackColor = System.Drawing.Color.Transparent
        Me.cbServiceGenre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbServiceGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServiceGenre.FocusedColor = System.Drawing.Color.Empty
        Me.cbServiceGenre.FocusedState.Parent = Me.cbServiceGenre
        Me.cbServiceGenre.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cbServiceGenre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cbServiceGenre.FormattingEnabled = True
        Me.cbServiceGenre.HoverState.Parent = Me.cbServiceGenre
        Me.cbServiceGenre.ItemHeight = 30
        Me.cbServiceGenre.ItemsAppearance.Parent = Me.cbServiceGenre
        Me.cbServiceGenre.Location = New System.Drawing.Point(274, 467)
        Me.cbServiceGenre.Name = "cbServiceGenre"
        Me.cbServiceGenre.ShadowDecoration.Parent = Me.cbServiceGenre
        Me.cbServiceGenre.Size = New System.Drawing.Size(267, 36)
        Me.cbServiceGenre.TabIndex = 3
        '
        'btnAddPicture
        '
        Me.btnAddPicture.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnAddPicture.Image = CType(resources.GetObject("btnAddPicture.Image"), System.Drawing.Image)
        Me.btnAddPicture.Location = New System.Drawing.Point(450, 243)
        Me.btnAddPicture.Name = "btnAddPicture"
        Me.btnAddPicture.Size = New System.Drawing.Size(27, 31)
        Me.btnAddPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnAddPicture.TabIndex = 30
        Me.btnAddPicture.TabStop = False
        '
        'Guna2CirclePictureBox1
        '
        Me.Guna2CirclePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Guna2CirclePictureBox1.Image = CType(resources.GetObject("Guna2CirclePictureBox1.Image"), System.Drawing.Image)
        Me.Guna2CirclePictureBox1.Location = New System.Drawing.Point(685, 28)
        Me.Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Me.Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox1.ShadowDecoration.Parent = Me.Guna2CirclePictureBox1
        Me.Guna2CirclePictureBox1.Size = New System.Drawing.Size(53, 50)
        Me.Guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox1.TabIndex = 9
        Me.Guna2CirclePictureBox1.TabStop = False
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.ForeColor = System.Drawing.Color.White
        Me.GunaLabel1.Location = New System.Drawing.Point(254, 28)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(253, 50)
        Me.GunaLabel1.TabIndex = 4
        Me.GunaLabel1.Text = "New Services"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Blue
        Me.Panel1.Controls.Add(Me.Guna2CirclePictureBox1)
        Me.Panel1.Controls.Add(Me.GunaLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(750, 100)
        Me.Panel1.TabIndex = 31
        '
        'pictureBoxService
        '
        Me.pictureBoxService.Location = New System.Drawing.Point(312, 131)
        Me.pictureBoxService.Name = "pictureBoxService"
        Me.pictureBoxService.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.pictureBoxService.ShadowDecoration.Parent = Me.pictureBoxService
        Me.pictureBoxService.Size = New System.Drawing.Size(165, 143)
        Me.pictureBoxService.TabIndex = 32
        Me.pictureBoxService.TabStop = False
        '
        'AddServices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 700)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAddPicture)
        Me.Controls.Add(Me.cbServiceGenre)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtServicePrice)
        Me.Controls.Add(Me.txtServiceName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pictureBoxService)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddServices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add new service"
        CType(Me.btnAddPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pictureBoxService, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtServiceName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnAdd As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtServicePrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbServiceGenre As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents btnAddPicture As PictureBox
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pictureBoxService As Guna.UI2.WinForms.Guna2CirclePictureBox
End Class
