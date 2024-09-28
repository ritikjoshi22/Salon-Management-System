Imports System.Data.SqlClient

Public Class Checkout
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;TrustServerCertificate=True"

    Private customerName As String
    Private totalPrice As Decimal
    Private paymentMethod As String

    Public Sub New(customerName As String, totalPrice As Decimal, paymentMethod As String)
        InitializeComponent()

        ' Set passed values
        Me.customerName = customerName
        Me.totalPrice = totalPrice
        Me.paymentMethod = paymentMethod
    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        qrCode.Show()
    End Sub

    Private Sub Checkout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDate.Text += DateTime.Now.ToString("yyyy-MM-dd")
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        ' Get the CustomerID
        Dim customerID As Integer = GetCustomerIDByName(customerName)

        ' If CustomerID is not found, stop the operation
        If customerID = 0 Then
            MessageBox.Show("Customer ID not found. Please check the customer name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Insert the revenue data into the Revenue table
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("INSERT INTO Revenue (DateOfPayment, CustomerID, TotalRevenue, PaymentMethod) VALUES (@DateOfPayment, @CustomerID, @TotalRevenue, @PaymentMethod)", conn)
            cmd.Parameters.AddWithValue("@DateOfPayment", DateTime.Now)
            cmd.Parameters.AddWithValue("@CustomerID", customerID)
            cmd.Parameters.AddWithValue("@TotalRevenue", totalPrice)
            cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)

            conn.Open()
            cmd.ExecuteNonQuery()
        End Using

        ' Show success message
        MessageBox.Show("Thank you for using Salon Management System", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Function GetCustomerIDByName(customerName As String) As Integer
        Dim customerID As Integer = 0
        ' Query the database to get the CustomerID by name
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT CustomerID FROM Customer WHERE Name = @Name", conn)
            cmd.Parameters.AddWithValue("@Name", customerName)
            conn.Open()

            ' Execute the query and retrieve the CustomerID
            Dim result = cmd.ExecuteScalar()

            ' Check if result is not null and set the CustomerID
            If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                customerID = Convert.ToInt32(result)
            Else
                ' If no CustomerID is found, show a message box for debugging
                MessageBox.Show("Customer not found: " & customerName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        Return customerID
    End Function


    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim printDialog As New PrintDialog()
        Dim printDoc As New Printing.PrintDocument()

        AddHandler printDoc.PrintPage, AddressOf Me.PrintDocument_PrintPage

        printDialog.Document = printDoc

        If printDialog.ShowDialog() = DialogResult.OK Then
            printDoc.Print()
        End If
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        ' Hide the form borders for printing
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Normal

        ' Capture the form content as a bitmap
        Dim bm As New Bitmap(Me.Width, Me.Height)
        Me.DrawToBitmap(bm, New Rectangle(0, 0, Me.Width, Me.Height))

        ' Print the form content
        e.Graphics.DrawImage(bm, 0, 0)

        ' Restore the original form border after printing
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class