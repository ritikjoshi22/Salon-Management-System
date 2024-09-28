<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Checkout
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.lblInvoiceNo = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnDone = New Guna.UI2.WinForms.Guna2Button()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.lblCustomerAddress = New System.Windows.Forms.Label()
        Me.BtnPrint = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.68208!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.31792!))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(61, 311)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.30502!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.69498!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(858, 349)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(209, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(551, 47)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Salon Management System"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(413, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 39)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Invoice"
        '
        'Guna2Button1
        '
        Me.Guna2Button1.CheckedState.Parent = Me.Guna2Button1
        Me.Guna2Button1.CustomImages.Parent = Me.Guna2Button1
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.HoverState.Parent = Me.Guna2Button1
        Me.Guna2Button1.Location = New System.Drawing.Point(130, 766)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.ShadowDecoration.Parent = Me.Guna2Button1
        Me.Guna2Button1.Size = New System.Drawing.Size(180, 45)
        Me.Guna2Button1.TabIndex = 3
        Me.Guna2Button1.Text = "QR Scan"
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.AutoSize = True
        Me.lblInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoiceNo.Location = New System.Drawing.Point(56, 187)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(110, 25)
        Me.lblInvoiceNo.TabIndex = 4
        Me.lblInvoiceNo.Text = "Invoice No:"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(640, 187)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(64, 25)
        Me.lblDate.TabIndex = 5
        Me.lblDate.Text = "Date: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(640, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(228, 25)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Address: Chitwan, Nepal"
        '
        'btnDone
        '
        Me.btnDone.CheckedState.Parent = Me.btnDone
        Me.btnDone.CustomImages.Parent = Me.btnDone
        Me.btnDone.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDone.ForeColor = System.Drawing.Color.White
        Me.btnDone.HoverState.Parent = Me.btnDone
        Me.btnDone.Location = New System.Drawing.Point(645, 766)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.ShadowDecoration.Parent = Me.btnDone
        Me.btnDone.Size = New System.Drawing.Size(180, 45)
        Me.btnDone.TabIndex = 7
        Me.btnDone.Text = "Done"
        '
        'lblCustomerName
        '
        Me.lblCustomerName.AutoSize = True
        Me.lblCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerName.Location = New System.Drawing.Point(56, 212)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(160, 25)
        Me.lblCustomerName.TabIndex = 8
        Me.lblCustomerName.Text = "Customer Name:"
        '
        'lblCustomerAddress
        '
        Me.lblCustomerAddress.AutoSize = True
        Me.lblCustomerAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerAddress.Location = New System.Drawing.Point(56, 237)
        Me.lblCustomerAddress.Name = "lblCustomerAddress"
        Me.lblCustomerAddress.Size = New System.Drawing.Size(91, 25)
        Me.lblCustomerAddress.TabIndex = 9
        Me.lblCustomerAddress.Text = "Address:"
        '
        'BtnPrint
        '
        Me.BtnPrint.CheckedState.Parent = Me.BtnPrint
        Me.BtnPrint.CustomImages.Parent = Me.BtnPrint
        Me.BtnPrint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BtnPrint.ForeColor = System.Drawing.Color.White
        Me.BtnPrint.HoverState.Parent = Me.BtnPrint
        Me.BtnPrint.Location = New System.Drawing.Point(645, 829)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.ShadowDecoration.Parent = Me.BtnPrint
        Me.BtnPrint.Size = New System.Drawing.Size(180, 45)
        Me.BtnPrint.TabIndex = 10
        Me.BtnPrint.Text = "Print"
        '
        'Checkout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 953)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.lblCustomerAddress)
        Me.Controls.Add(Me.lblCustomerName)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblInvoiceNo)
        Me.Controls.Add(Me.Guna2Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Checkout"
        Me.Text = "Checkout"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblInvoiceNo As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnDone As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents lblCustomerName As Label
    Friend WithEvents lblCustomerAddress As Label
    Friend WithEvents BtnPrint As Guna.UI2.WinForms.Guna2Button
End Class
