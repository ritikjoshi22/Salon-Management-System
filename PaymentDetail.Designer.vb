<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentDetail
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCustomerName = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCustomerAddress = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbPaymentMethod = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtDiscount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnNext = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(249, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(332, 47)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Payment Details"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(127, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Customer Name:"
        '
        'cmbCustomerName
        '
        Me.cmbCustomerName.BackColor = System.Drawing.Color.Transparent
        Me.cmbCustomerName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomerName.FocusedColor = System.Drawing.Color.Empty
        Me.cmbCustomerName.FocusedState.Parent = Me.cmbCustomerName
        Me.cmbCustomerName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbCustomerName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbCustomerName.FormattingEnabled = True
        Me.cmbCustomerName.HoverState.Parent = Me.cmbCustomerName
        Me.cmbCustomerName.ItemHeight = 30
        Me.cmbCustomerName.ItemsAppearance.Parent = Me.cmbCustomerName
        Me.cmbCustomerName.Location = New System.Drawing.Point(314, 157)
        Me.cmbCustomerName.Name = "cmbCustomerName"
        Me.cmbCustomerName.ShadowDecoration.Parent = Me.cmbCustomerName
        Me.cmbCustomerName.Size = New System.Drawing.Size(267, 36)
        Me.cmbCustomerName.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(106, 233)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 25)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Customer Address:"
        '
        'txtCustomerAddress
        '
        Me.txtCustomerAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCustomerAddress.DefaultText = ""
        Me.txtCustomerAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCustomerAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCustomerAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerAddress.DisabledState.Parent = Me.txtCustomerAddress
        Me.txtCustomerAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCustomerAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomerAddress.FocusedState.Parent = Me.txtCustomerAddress
        Me.txtCustomerAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCustomerAddress.HoverState.Parent = Me.txtCustomerAddress
        Me.txtCustomerAddress.Location = New System.Drawing.Point(314, 224)
        Me.txtCustomerAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCustomerAddress.Name = "txtCustomerAddress"
        Me.txtCustomerAddress.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCustomerAddress.PlaceholderText = ""
        Me.txtCustomerAddress.SelectedText = ""
        Me.txtCustomerAddress.ShadowDecoration.Parent = Me.txtCustomerAddress
        Me.txtCustomerAddress.Size = New System.Drawing.Size(267, 44)
        Me.txtCustomerAddress.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(121, 304)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 25)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Payment Method:"
        '
        'cmbPaymentMethod
        '
        Me.cmbPaymentMethod.BackColor = System.Drawing.Color.Transparent
        Me.cmbPaymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentMethod.FocusedColor = System.Drawing.Color.Empty
        Me.cmbPaymentMethod.FocusedState.Parent = Me.cmbPaymentMethod
        Me.cmbPaymentMethod.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbPaymentMethod.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cmbPaymentMethod.FormattingEnabled = True
        Me.cmbPaymentMethod.HoverState.Parent = Me.cmbPaymentMethod
        Me.cmbPaymentMethod.ItemHeight = 30
        Me.cmbPaymentMethod.ItemsAppearance.Parent = Me.cmbPaymentMethod
        Me.cmbPaymentMethod.Location = New System.Drawing.Point(314, 303)
        Me.cmbPaymentMethod.Name = "cmbPaymentMethod"
        Me.cmbPaymentMethod.ShadowDecoration.Parent = Me.cmbPaymentMethod
        Me.cmbPaymentMethod.Size = New System.Drawing.Size(267, 36)
        Me.cmbPaymentMethod.TabIndex = 10
        '
        'txtDiscount
        '
        Me.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscount.DefaultText = "0"
        Me.txtDiscount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount.DisabledState.Parent = Me.txtDiscount
        Me.txtDiscount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDiscount.FocusedState.Parent = Me.txtDiscount
        Me.txtDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDiscount.HoverState.Parent = Me.txtDiscount
        Me.txtDiscount.Location = New System.Drawing.Point(314, 370)
        Me.txtDiscount.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDiscount.PlaceholderText = ""
        Me.txtDiscount.SelectedText = ""
        Me.txtDiscount.SelectionStart = 1
        Me.txtDiscount.ShadowDecoration.Parent = Me.txtDiscount
        Me.txtDiscount.Size = New System.Drawing.Size(267, 44)
        Me.txtDiscount.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(193, 380)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 25)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Discount:"
        '
        'btnNext
        '
        Me.btnNext.BorderRadius = 20
        Me.btnNext.CheckedState.Parent = Me.btnNext
        Me.btnNext.CustomImages.Parent = Me.btnNext
        Me.btnNext.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNext.ForeColor = System.Drawing.Color.White
        Me.btnNext.HoverState.Parent = Me.btnNext
        Me.btnNext.Location = New System.Drawing.Point(330, 476)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.ShadowDecoration.Parent = Me.btnNext
        Me.btnNext.Size = New System.Drawing.Size(180, 45)
        Me.btnNext.TabIndex = 13
        Me.btnNext.Text = "Next"
        '
        'PaymentDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 650)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.txtDiscount)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbPaymentMethod)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCustomerAddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbCustomerName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PaymentDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PaymentDetail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCustomerName As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCustomerAddress As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbPaymentMethod As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnNext As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtDiscount As Guna.UI2.WinForms.Guna2TextBox
End Class
