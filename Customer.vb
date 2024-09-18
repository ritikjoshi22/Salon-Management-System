Imports System.Data.SqlClient

Public Class Customer
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' Load customers when form loads
    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
    End Sub

    ' Function to load customers into DataGridView
    Private Sub LoadCustomers()
        Dim query As String = "SELECT CustomerID, Name, Phone, Email FROM Customer"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgCustomers.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error loading customers: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim customerName As String = txtCustomerName.Text
        Dim phone As String = txtPhone.Text
        Dim email As String = txtEmail.Text

        ' Check if it's a new entry or an edit (CustomerID is empty or not)
        If txtCustomerID.Text = "" Then
            ' Insert new customer
            Dim query As String = "INSERT INTO Customer (Name, Phone, Email) VALUES (@Name, @Phone, @Email)"
            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", customerName)
                    cmd.Parameters.AddWithValue("@Phone", phone)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Customer added successfully!")
                    LoadCustomers()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("Error adding customer: " & ex.Message)
                End Try
            End Using
        Else
            ' Update customer
            Dim customerID As Integer = CInt(txtCustomerID.Text)
            Dim query As String = "UPDATE Customer SET Name=@Name, Phone=@Phone, Email=@Email WHERE CustomerID=@CustomerID"
            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", customerName)
                    cmd.Parameters.AddWithValue("@Phone", phone)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Customer updated successfully!")
                    LoadCustomers()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("Error updating customer: " & ex.Message)
                End Try
            End Using
        End If
    End Sub

    ' Helper method to clear input fields
    Private Sub ClearFields()
        txtCustomerID.Text = ""
        txtCustomerName.Text = ""
        txtPhone.Text = ""
        txtEmail.Text = ""
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgCustomers.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgCustomers.SelectedRows(0)
            txtCustomerID.Text = selectedRow.Cells("CustomerID").Value.ToString()
            txtCustomerName.Text = selectedRow.Cells("Name").Value.ToString()
            txtPhone.Text = selectedRow.Cells("Phone").Value.ToString()
            txtEmail.Text = selectedRow.Cells("Email").Value.ToString()
        Else
            MessageBox.Show("Please select a customer to edit.")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgCustomers.SelectedRows.Count > 0 Then
            Dim customerID As Integer = CInt(dgCustomers.SelectedRows(0).Cells("CustomerID").Value)

            Dim query As String = "DELETE FROM Customer WHERE CustomerID=@CustomerID"
            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Customer deleted successfully!")
                    LoadCustomers()
                Catch ex As Exception
                    MessageBox.Show("Error deleting customer: " & ex.Message)
                End Try
            End Using
        Else
            MessageBox.Show("Please select a customer to delete.")
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchText As String = txtSearch.Text

        Dim query As String = "SELECT CustomerID, Name, Phone, Email FROM Customer WHERE Name LIKE @Search OR Phone LIKE @Search"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim adapter As New SqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" & searchText & "%")
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgCustomers.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error searching customers: " & ex.Message)
            End Try
        End Using
    End Sub

End Class
