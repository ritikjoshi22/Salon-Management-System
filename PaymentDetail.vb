Imports System.Data.SqlClient
Imports saloon_management_system.Services

Public Class PaymentDetail
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;TrustServerCertificate=True"

    Private role As String
    Private cart As New List(Of CartItem)()
    Public Sub New(cart As List(Of CartItem), role As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Now populate the TableLayoutPanel with the passed cart and discount
        Me.cart = cart
        Me.role = role
    End Sub

    Private Sub PaymentDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If role = "User" Then
            cmbCustomerName.Items.Add("Guest")
        Else
            ' Populate customer names from the Customer table
            Dim query As String = "SELECT Name FROM Customer"
            Using conn As New SqlConnection(connectionString)
                Dim cmd As New SqlCommand(query, conn)
                conn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    cmbCustomerName.Items.Add(reader("Name").ToString())
                End While
            End Using
        End If
        ' Populate payment method options
        cmbPaymentMethod.Items.AddRange({"Credit Card", "Debit Card", "Cash", "Online"})
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Get values from PaymentDetail form
        Dim customerName As String = cmbCustomerName.Text
        Dim customerAddress As String = txtCustomerAddress.Text
        Dim paymentMethod As String = cmbPaymentMethod.Text
        Dim discount As Decimal = CDec(txtDiscount.Text)

        ' Parse the discount value from the textbox
        If Not Decimal.TryParse(txtDiscount.Text, discount) Then
            discount = 0 ' Set to 0 if the input is invalid
        End If
        Dim totalPrice As Decimal = CalculateTotalPriceWithDiscount(discount)

        ' Open the Checkout form
        Dim checkoutForm As New Checkout(customerName, totalPrice, paymentMethod)

        ' Set the Invoice Number
        Dim newInvoiceID As Integer = GetNextInvoiceID() ' This method retrieves the last InvoiceID and increments it
        checkoutForm.lblInvoiceNo.Text += newInvoiceID.ToString()

        ' Set Customer Name and Address
        checkoutForm.lblCustomerName.Text += customerName
        checkoutForm.lblCustomerAddress.Text += customerAddress

        ' Populate the TableLayoutPanel with cart items
        PopulateTableLayoutPanelWithCartItems(checkoutForm, discount)

        ' Show the Checkout form
        checkoutForm.StartPosition = FormStartPosition.CenterScreen
        checkoutForm.ShowDialog()
    End Sub
    Private Function CalculateTotalPriceWithDiscount(discount As Decimal) As Decimal
        Dim totalPrice As Decimal = 0

        ' Calculate the total price from cart items
        For Each item As CartItem In cart
            totalPrice += item.Price
        Next

        ' Apply the discount
        Dim discountAmount As Decimal = (discount / 100) * totalPrice
        Return totalPrice - discountAmount
    End Function
    Private Function GetNextInvoiceID() As Integer
        Dim lastRevenueID As Integer = 0
        ' Query the database to get the last RevenueID
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT MAX(RevenueID) FROM Revenue", conn)
            conn.Open()
            Dim result = cmd.ExecuteScalar()
            If result IsNot DBNull.Value Then
                lastRevenueID = Convert.ToInt32(result)
            End If
        End Using
        ' Increment the last RevenueID by 1
        Return lastRevenueID + 1
    End Function

    Private Sub PopulateTableLayoutPanelWithCartItems(checkoutForm As Checkout, discount As Decimal)
        ' Clear any existing rows in the TableLayoutPanel
        checkoutForm.TableLayoutPanel1.Controls.Clear()
        checkoutForm.TableLayoutPanel1.ColumnStyles.Clear()

        ' Set up the column styles
        checkoutForm.TableLayoutPanel1.ColumnCount = 2
        checkoutForm.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70)) ' 70% for Description
        checkoutForm.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30)) ' 30% for Price

        ' Set up the headers in the first row
        checkoutForm.TableLayoutPanel1.RowCount = 1
        checkoutForm.TableLayoutPanel1.Controls.Add(New Label() With {.Text = "Description", .Font = New Font("Arial", 12, FontStyle.Bold), .Anchor = AnchorStyles.Left Or AnchorStyles.Right, .AutoSize = True}, 0, 0)
        checkoutForm.TableLayoutPanel1.Controls.Add(New Label() With {.Text = "Price", .Font = New Font("Arial", 12, FontStyle.Bold), .Anchor = AnchorStyles.Left Or AnchorStyles.Right, .AutoSize = True}, 1, 0)

        ' Initialize total price
        Dim totalPrice As Decimal = 0

        ' Add each item from the cart to the table
        Dim rowIndex As Integer = 1
        For Each item As CartItem In cart
            checkoutForm.TableLayoutPanel1.RowCount += 1
            checkoutForm.TableLayoutPanel1.Controls.Add(New Label() With {.Text = item.ServiceName, .Font = New Font("Arial", 10, FontStyle.Regular), .Anchor = AnchorStyles.Left Or AnchorStyles.Right, .AutoSize = True}, 0, rowIndex)
            checkoutForm.TableLayoutPanel1.Controls.Add(New Label() With {.Text = "Rs. " & item.Price.ToString("F2"), .Font = New Font("Arial", 10, FontStyle.Regular), .Anchor = AnchorStyles.Left Or AnchorStyles.Right, .AutoSize = True}, 1, rowIndex)

            totalPrice += item.Price
            rowIndex += 1
        Next

        ' Add discount row
        checkoutForm.TableLayoutPanel1.RowCount += 1
        checkoutForm.TableLayoutPanel1.Controls.Add(New Label() With {.Text = "Discount (" & discount.ToString("F2") & "%)", .Font = New Font("Arial", 12, FontStyle.Bold), .Anchor = AnchorStyles.Left Or AnchorStyles.Right, .AutoSize = True}, 0, rowIndex)
        checkoutForm.TableLayoutPanel1.Controls.Add(New Label() With {.Text = "-Rs. " & (discount * totalPrice / 100).ToString("F2"), .Font = New Font("Arial", 12, FontStyle.Bold), .Anchor = AnchorStyles.Left Or AnchorStyles.Right, .AutoSize = True}, 1, rowIndex)

        rowIndex += 1

        ' Apply discount to the total price
        Dim discountAmount As Decimal = (discount / 100) * totalPrice
        Dim finalPrice As Decimal = totalPrice - discountAmount

        ' Add total price at the end
        checkoutForm.TableLayoutPanel1.RowCount += 1
        checkoutForm.TableLayoutPanel1.Controls.Add(New Label() With {.Text = "Total", .Font = New Font("Arial", 12, FontStyle.Bold), .Anchor = AnchorStyles.Left Or AnchorStyles.Right, .AutoSize = True}, 0, rowIndex)
        checkoutForm.TableLayoutPanel1.Controls.Add(New Label() With {.Text = "Rs. " & finalPrice.ToString("F2"), .Font = New Font("Arial", 12, FontStyle.Bold), .Anchor = AnchorStyles.Left Or AnchorStyles.Right, .AutoSize = True}, 1, rowIndex)
    End Sub

End Class