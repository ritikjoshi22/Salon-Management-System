<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.revenueChart = New LiveCharts.WinForms.CartesianChart()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btn10Y = New System.Windows.Forms.Button()
        Me.btn1W = New System.Windows.Forms.Button()
        Me.btn1M = New System.Windows.Forms.Button()
        Me.btn1Y = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PieChart1 = New LiveCharts.WinForms.PieChart()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Guna2TextBox1 = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2GradientPanel4 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.totalProduct = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Guna2GradientPanel3 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.totalServices = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Guna2GradientPanel2 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.totalEmp = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Guna2GradientPanel1 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.totalCtm = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Guna2GradientPanel4.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GradientPanel3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GradientPanel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GradientPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 289)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1655, 744)
        Me.Panel2.TabIndex = 1
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Panel4)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(20)
        Me.Panel9.Size = New System.Drawing.Size(1062, 744)
        Me.Panel9.TabIndex = 19
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.revenueChart)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(20, 20)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1022, 648)
        Me.Panel4.TabIndex = 25
        '
        'revenueChart
        '
        Me.revenueChart.BackColor = System.Drawing.Color.White
        Me.revenueChart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.revenueChart.Location = New System.Drawing.Point(0, 0)
        Me.revenueChart.Name = "revenueChart"
        Me.revenueChart.Size = New System.Drawing.Size(1022, 648)
        Me.revenueChart.TabIndex = 26
        Me.revenueChart.Text = "CartesianChart1"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.btn10Y)
        Me.Panel10.Controls.Add(Me.btn1W)
        Me.Panel10.Controls.Add(Me.btn1M)
        Me.Panel10.Controls.Add(Me.btn1Y)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(20, 668)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1022, 56)
        Me.Panel10.TabIndex = 24
        '
        'btn10Y
        '
        Me.btn10Y.ForeColor = System.Drawing.Color.Black
        Me.btn10Y.Location = New System.Drawing.Point(625, 17)
        Me.btn10Y.Name = "btn10Y"
        Me.btn10Y.Size = New System.Drawing.Size(75, 23)
        Me.btn10Y.TabIndex = 22
        Me.btn10Y.Text = "10Y"
        Me.btn10Y.UseVisualStyleBackColor = True
        '
        'btn1W
        '
        Me.btn1W.ForeColor = System.Drawing.Color.Black
        Me.btn1W.Location = New System.Drawing.Point(330, 17)
        Me.btn1W.Name = "btn1W"
        Me.btn1W.Size = New System.Drawing.Size(75, 23)
        Me.btn1W.TabIndex = 19
        Me.btn1W.Text = "1W"
        Me.btn1W.UseVisualStyleBackColor = True
        '
        'btn1M
        '
        Me.btn1M.ForeColor = System.Drawing.Color.Black
        Me.btn1M.Location = New System.Drawing.Point(426, 17)
        Me.btn1M.Name = "btn1M"
        Me.btn1M.Size = New System.Drawing.Size(75, 23)
        Me.btn1M.TabIndex = 20
        Me.btn1M.Text = "1M"
        Me.btn1M.UseVisualStyleBackColor = True
        '
        'btn1Y
        '
        Me.btn1Y.ForeColor = System.Drawing.Color.Black
        Me.btn1Y.Location = New System.Drawing.Point(525, 17)
        Me.btn1Y.Name = "btn1Y"
        Me.btn1Y.Size = New System.Drawing.Size(75, 23)
        Me.btn1Y.TabIndex = 21
        Me.btn1Y.Text = "1Y"
        Me.btn1Y.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Label15)
        Me.Panel8.Controls.Add(Me.Label16)
        Me.Panel8.Controls.Add(Me.PieChart1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(1062, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(20, 20, 20, 120)
        Me.Panel8.Size = New System.Drawing.Size(593, 744)
        Me.Panel8.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(99, 604)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(164, 20)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Revenue Analytics"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(16, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(165, 20)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Products Variation"
        '
        'PieChart1
        '
        Me.PieChart1.BackColor = System.Drawing.Color.White
        Me.PieChart1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PieChart1.Location = New System.Drawing.Point(20, 20)
        Me.PieChart1.Name = "PieChart1"
        Me.PieChart1.Size = New System.Drawing.Size(553, 604)
        Me.PieChart1.TabIndex = 21
        Me.PieChart1.Text = "PieChart1"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1655, 84)
        Me.Panel3.TabIndex = 5
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.lblName)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(267, 84)
        Me.Panel6.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(27, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(213, 29)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Welcome to SMS"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(29, 15)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(23, 16)
        Me.lblName.TabIndex = 9
        Me.lblName.Text = "Hi "
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PictureBox6)
        Me.Panel5.Controls.Add(Me.Guna2CirclePictureBox1)
        Me.Panel5.Controls.Add(Me.PictureBox5)
        Me.Panel5.Controls.Add(Me.Guna2TextBox1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(1109, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(546, 84)
        Me.Panel5.TabIndex = 6
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(15, 18)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(45, 44)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 11
        Me.PictureBox6.TabStop = False
        '
        'Guna2CirclePictureBox1
        '
        Me.Guna2CirclePictureBox1.Image = CType(resources.GetObject("Guna2CirclePictureBox1.Image"), System.Drawing.Image)
        Me.Guna2CirclePictureBox1.Location = New System.Drawing.Point(75, 15)
        Me.Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Me.Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox1.ShadowDecoration.Parent = Me.Guna2CirclePictureBox1
        Me.Guna2CirclePictureBox1.Size = New System.Drawing.Size(70, 59)
        Me.Guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox1.TabIndex = 10
        Me.Guna2CirclePictureBox1.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.White
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(173, 31)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(34, 16)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 8
        Me.PictureBox5.TabStop = False
        '
        'Guna2TextBox1
        '
        Me.Guna2TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.BorderRadius = 20
        Me.Guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Guna2TextBox1.DefaultText = "Search"
        Me.Guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox1.DisabledState.Parent = Me.Guna2TextBox1
        Me.Guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.FocusedState.Parent = Me.Guna2TextBox1
        Me.Guna2TextBox1.Font = New System.Drawing.Font("Calibri", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2TextBox1.HoverState.Parent = Me.Guna2TextBox1
        Me.Guna2TextBox1.Location = New System.Drawing.Point(167, 15)
        Me.Guna2TextBox1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Guna2TextBox1.Name = "Guna2TextBox1"
        Me.Guna2TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Guna2TextBox1.PlaceholderText = ""
        Me.Guna2TextBox1.SelectedText = ""
        Me.Guna2TextBox1.SelectionStart = 6
        Me.Guna2TextBox1.ShadowDecoration.Parent = Me.Guna2TextBox1
        Me.Guna2TextBox1.Size = New System.Drawing.Size(331, 47)
        Me.Guna2TextBox1.TabIndex = 6
        Me.Guna2TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Guna2GradientPanel4)
        Me.Panel1.Controls.Add(Me.Guna2GradientPanel3)
        Me.Panel1.Controls.Add(Me.Guna2GradientPanel2)
        Me.Panel1.Controls.Add(Me.Guna2GradientPanel1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1655, 289)
        Me.Panel1.TabIndex = 0
        '
        'Guna2GradientPanel4
        '
        Me.Guna2GradientPanel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Guna2GradientPanel4.BorderRadius = 20
        Me.Guna2GradientPanel4.Controls.Add(Me.PictureBox4)
        Me.Guna2GradientPanel4.Controls.Add(Me.totalProduct)
        Me.Guna2GradientPanel4.Controls.Add(Me.Label12)
        Me.Guna2GradientPanel4.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Guna2GradientPanel4.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Guna2GradientPanel4.Location = New System.Drawing.Point(1211, 90)
        Me.Guna2GradientPanel4.Name = "Guna2GradientPanel4"
        Me.Guna2GradientPanel4.ShadowDecoration.Parent = Me.Guna2GradientPanel4
        Me.Guna2GradientPanel4.Size = New System.Drawing.Size(292, 193)
        Me.Guna2GradientPanel4.TabIndex = 26
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(233, 13)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 36)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 3
        Me.PictureBox4.TabStop = False
        '
        'totalProduct
        '
        Me.totalProduct.AutoSize = True
        Me.totalProduct.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.totalProduct.Font = New System.Drawing.Font("Century Gothic", 35.0!, System.Drawing.FontStyle.Bold)
        Me.totalProduct.ForeColor = System.Drawing.Color.White
        Me.totalProduct.Location = New System.Drawing.Point(110, 62)
        Me.totalProduct.Name = "totalProduct"
        Me.totalProduct.Size = New System.Drawing.Size(95, 68)
        Me.totalProduct.TabIndex = 1
        Me.totalProduct.Text = "20"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(36, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(150, 23)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Total Products:"
        '
        'Guna2GradientPanel3
        '
        Me.Guna2GradientPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Guna2GradientPanel3.BorderRadius = 20
        Me.Guna2GradientPanel3.Controls.Add(Me.PictureBox3)
        Me.Guna2GradientPanel3.Controls.Add(Me.totalServices)
        Me.Guna2GradientPanel3.Controls.Add(Me.Label9)
        Me.Guna2GradientPanel3.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Guna2GradientPanel3.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Guna2GradientPanel3.Location = New System.Drawing.Point(858, 90)
        Me.Guna2GradientPanel3.Name = "Guna2GradientPanel3"
        Me.Guna2GradientPanel3.ShadowDecoration.Parent = Me.Guna2GradientPanel3
        Me.Guna2GradientPanel3.Size = New System.Drawing.Size(292, 193)
        Me.Guna2GradientPanel3.TabIndex = 27
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(233, 13)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 36)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 3
        Me.PictureBox3.TabStop = False
        '
        'totalServices
        '
        Me.totalServices.AutoSize = True
        Me.totalServices.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.totalServices.Font = New System.Drawing.Font("Century Gothic", 35.0!, System.Drawing.FontStyle.Bold)
        Me.totalServices.ForeColor = System.Drawing.Color.White
        Me.totalServices.Location = New System.Drawing.Point(109, 62)
        Me.totalServices.Name = "totalServices"
        Me.totalServices.Size = New System.Drawing.Size(95, 68)
        Me.totalServices.TabIndex = 1
        Me.totalServices.Text = "20"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(27, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 23)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Total Services:"
        '
        'Guna2GradientPanel2
        '
        Me.Guna2GradientPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Guna2GradientPanel2.BorderRadius = 20
        Me.Guna2GradientPanel2.Controls.Add(Me.PictureBox2)
        Me.Guna2GradientPanel2.Controls.Add(Me.totalEmp)
        Me.Guna2GradientPanel2.Controls.Add(Me.Label6)
        Me.Guna2GradientPanel2.FillColor = System.Drawing.Color.DarkOrchid
        Me.Guna2GradientPanel2.FillColor2 = System.Drawing.Color.DarkOrchid
        Me.Guna2GradientPanel2.Location = New System.Drawing.Point(505, 90)
        Me.Guna2GradientPanel2.Name = "Guna2GradientPanel2"
        Me.Guna2GradientPanel2.ShadowDecoration.Parent = Me.Guna2GradientPanel2
        Me.Guna2GradientPanel2.Size = New System.Drawing.Size(292, 193)
        Me.Guna2GradientPanel2.TabIndex = 28
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.DarkOrchid
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(240, 13)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'totalEmp
        '
        Me.totalEmp.AutoSize = True
        Me.totalEmp.BackColor = System.Drawing.Color.DarkOrchid
        Me.totalEmp.Font = New System.Drawing.Font("Century Gothic", 35.0!, System.Drawing.FontStyle.Bold)
        Me.totalEmp.ForeColor = System.Drawing.Color.White
        Me.totalEmp.Location = New System.Drawing.Point(97, 62)
        Me.totalEmp.Name = "totalEmp"
        Me.totalEmp.Size = New System.Drawing.Size(95, 68)
        Me.totalEmp.TabIndex = 1
        Me.totalEmp.Text = "20"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.DarkOrchid
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(27, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 23)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Total Employee:"
        '
        'Guna2GradientPanel1
        '
        Me.Guna2GradientPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Guna2GradientPanel1.BorderRadius = 20
        Me.Guna2GradientPanel1.Controls.Add(Me.PictureBox1)
        Me.Guna2GradientPanel1.Controls.Add(Me.totalCtm)
        Me.Guna2GradientPanel1.Controls.Add(Me.Label1)
        Me.Guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.Guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.Guna2GradientPanel1.Location = New System.Drawing.Point(152, 90)
        Me.Guna2GradientPanel1.Name = "Guna2GradientPanel1"
        Me.Guna2GradientPanel1.ShadowDecoration.Parent = Me.Guna2GradientPanel1
        Me.Guna2GradientPanel1.Size = New System.Drawing.Size(292, 193)
        Me.Guna2GradientPanel1.TabIndex = 25
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(233, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'totalCtm
        '
        Me.totalCtm.AutoSize = True
        Me.totalCtm.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.totalCtm.Font = New System.Drawing.Font("Century Gothic", 35.0!, System.Drawing.FontStyle.Bold)
        Me.totalCtm.ForeColor = System.Drawing.Color.White
        Me.totalCtm.Location = New System.Drawing.Point(99, 62)
        Me.totalCtm.Name = "totalCtm"
        Me.totalCtm.Size = New System.Drawing.Size(95, 68)
        Me.totalCtm.TabIndex = 1
        Me.totalCtm.Text = "20"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(24, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Customers:"
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1655, 1033)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Dashboard"
        Me.Text = "Form4"
        Me.Panel2.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Guna2GradientPanel4.ResumeLayout(False)
        Me.Guna2GradientPanel4.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GradientPanel3.ResumeLayout(False)
        Me.Guna2GradientPanel3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GradientPanel2.ResumeLayout(False)
        Me.Guna2GradientPanel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GradientPanel1.ResumeLayout(False)
        Me.Guna2GradientPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Guna2TextBox1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2GradientPanel4 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents totalProduct As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Guna2GradientPanel3 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents totalServices As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Guna2GradientPanel2 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents totalEmp As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Guna2GradientPanel1 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents totalCtm As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents btn10Y As Button
    Friend WithEvents btn1W As Button
    Friend WithEvents btn1M As Button
    Friend WithEvents btn1Y As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents PieChart1 As LiveCharts.WinForms.PieChart
    Friend WithEvents Panel4 As Panel
    Friend WithEvents revenueChart As LiveCharts.WinForms.CartesianChart
End Class
