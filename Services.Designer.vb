<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Services
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Services))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnManicure = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnFacial = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnHaircolor = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnHaircut = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnCart = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.btnCart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1655, 87)
        Me.Panel1.TabIndex = 6
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnManicure)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(960, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.Panel7.Size = New System.Drawing.Size(320, 87)
        Me.Panel7.TabIndex = 25
        '
        'btnManicure
        '
        Me.btnManicure.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnManicure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnManicure.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnManicure.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnManicure.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManicure.ForeColor = System.Drawing.Color.White
        Me.btnManicure.Image = CType(resources.GetObject("btnManicure.Image"), System.Drawing.Image)
        Me.btnManicure.Location = New System.Drawing.Point(35, 0)
        Me.btnManicure.Name = "btnManicure"
        Me.btnManicure.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnManicure.Size = New System.Drawing.Size(285, 87)
        Me.btnManicure.TabIndex = 21
        Me.btnManicure.Text = "Manicure"
        Me.btnManicure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnManicure.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnFacial)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(640, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.Panel6.Size = New System.Drawing.Size(320, 87)
        Me.Panel6.TabIndex = 24
        '
        'btnFacial
        '
        Me.btnFacial.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnFacial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFacial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFacial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnFacial.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacial.ForeColor = System.Drawing.Color.White
        Me.btnFacial.Image = CType(resources.GetObject("btnFacial.Image"), System.Drawing.Image)
        Me.btnFacial.Location = New System.Drawing.Point(35, 0)
        Me.btnFacial.Name = "btnFacial"
        Me.btnFacial.Size = New System.Drawing.Size(285, 87)
        Me.btnFacial.TabIndex = 20
        Me.btnFacial.Text = "Facial"
        Me.btnFacial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFacial.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnHaircolor)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(320, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.Panel5.Size = New System.Drawing.Size(320, 87)
        Me.Panel5.TabIndex = 23
        '
        'btnHaircolor
        '
        Me.btnHaircolor.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnHaircolor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnHaircolor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHaircolor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHaircolor.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHaircolor.ForeColor = System.Drawing.Color.White
        Me.btnHaircolor.Image = CType(resources.GetObject("btnHaircolor.Image"), System.Drawing.Image)
        Me.btnHaircolor.Location = New System.Drawing.Point(35, 0)
        Me.btnHaircolor.Name = "btnHaircolor"
        Me.btnHaircolor.Size = New System.Drawing.Size(285, 87)
        Me.btnHaircolor.TabIndex = 19
        Me.btnHaircolor.Text = "Haircolor"
        Me.btnHaircolor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHaircolor.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnHaircut)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.Panel4.Size = New System.Drawing.Size(320, 87)
        Me.Panel4.TabIndex = 22
        '
        'btnHaircut
        '
        Me.btnHaircut.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnHaircut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnHaircut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHaircut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHaircut.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHaircut.ForeColor = System.Drawing.Color.White
        Me.btnHaircut.Image = CType(resources.GetObject("btnHaircut.Image"), System.Drawing.Image)
        Me.btnHaircut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHaircut.Location = New System.Drawing.Point(35, 0)
        Me.btnHaircut.Name = "btnHaircut"
        Me.btnHaircut.Size = New System.Drawing.Size(285, 87)
        Me.btnHaircut.TabIndex = 6
        Me.btnHaircut.Text = "Haircut"
        Me.btnHaircut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHaircut.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnNew)
        Me.Panel3.Controls.Add(Me.btnCart)
        Me.Panel3.Controls.Add(Me.Guna2CirclePictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1306, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(349, 87)
        Me.Panel3.TabIndex = 0
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.Lime
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.Color.Black
        Me.btnNew.Location = New System.Drawing.Point(4, 12)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(150, 59)
        Me.btnNew.TabIndex = 13
        Me.btnNew.Text = "+New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnCart
        '
        Me.btnCart.Image = CType(resources.GetObject("btnCart.Image"), System.Drawing.Image)
        Me.btnCart.Location = New System.Drawing.Point(174, 12)
        Me.btnCart.Name = "btnCart"
        Me.btnCart.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.btnCart.ShadowDecoration.Parent = Me.btnCart
        Me.btnCart.Size = New System.Drawing.Size(68, 59)
        Me.btnCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnCart.TabIndex = 22
        Me.btnCart.TabStop = False
        '
        'Guna2CirclePictureBox1
        '
        Me.Guna2CirclePictureBox1.Image = CType(resources.GetObject("Guna2CirclePictureBox1.Image"), System.Drawing.Image)
        Me.Guna2CirclePictureBox1.Location = New System.Drawing.Point(257, 12)
        Me.Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Me.Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox1.ShadowDecoration.Parent = Me.Guna2CirclePictureBox1
        Me.Guna2CirclePictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.Guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox1.TabIndex = 19
        Me.Guna2CirclePictureBox1.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 87)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1655, 946)
        Me.FlowLayoutPanel1.TabIndex = 12
        '
        'Services
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1655, 1033)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Services"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form6"
        Me.Panel1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.btnCart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnFacial As Button
    Friend WithEvents btnHaircolor As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnCart As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents btnNew As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnHaircut As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnManicure As Button
End Class
