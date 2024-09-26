Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports Guna.UI2.WinForms

Public Class Customer
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' Load customers when form loads
    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
    End Sub

    ' Function to load customers into DataGridView
    ' Function to load customers into DataGridView
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

                ' Add Edit button column only if it hasn't been added yet
                If dgCustomers.Columns("Edit") Is Nothing Then
                    Dim btnEdit As New DataGridViewButtonColumn()
                    btnEdit.HeaderText = "Edit"
                    btnEdit.Name = "Edit"
                    btnEdit.Text = "Edit"
                    btnEdit.UseColumnTextForButtonValue = True
                    dgCustomers.Columns.Add(btnEdit)
                    dgCustomers.AllowUserToAddRows = False
                End If

                ' Add Delete button column only if it hasn't been added yet
                If dgCustomers.Columns("Delete") Is Nothing Then
                    Dim deleteBtn As New DataGridViewButtonColumn()
                    deleteBtn.HeaderText = "Delete"
                    deleteBtn.Name = "Delete"
                    deleteBtn.Text = "Delete"
                    deleteBtn.UseColumnTextForButtonValue = True
                    dgCustomers.Columns.Add(deleteBtn)
                End If
            Catch ex As Exception
                MessageBox.Show("Error loading customers: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub dgCustomers_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgCustomers.CellPainting
        If e.ColumnIndex = dgCustomers.Columns("Delete").Index AndAlso e.RowIndex >= 0 Then
            e.Handled = True
            e.Graphics.FillRectangle(New SolidBrush(Color.White), e.CellBounds)

            Dim buttonWidth As Integer = 80
            Dim buttonHeight As Integer = 20
            Dim buttonX As Integer = e.CellBounds.Left + (e.CellBounds.Width - buttonWidth) / 2
            Dim buttonY As Integer = e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2

            Dim buttonBounds As Rectangle = New Rectangle(buttonX, buttonY, buttonWidth, buttonHeight)

            Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
            Dim radius As Integer = 20
            path.AddArc(buttonBounds.Left, buttonBounds.Top, radius, radius, 180, 90)
            path.AddArc(buttonBounds.Right - radius, buttonBounds.Top, radius, radius, 270, 90)
            path.AddArc(buttonBounds.Right - radius, buttonBounds.Bottom - radius, radius, radius, 0, 90)
            path.AddArc(buttonBounds.Left, buttonBounds.Bottom - radius, radius, radius, 90, 90)
            path.CloseAllFigures()

            e.Graphics.FillPath(New SolidBrush(ColorTranslator.FromHtml("#FF6969")), path) ' Red color for Delete button

            TextRenderer.DrawText(e.Graphics, "Delete", dgCustomers.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If

        If e.ColumnIndex = dgCustomers.Columns("Edit").Index AndAlso e.RowIndex >= 0 Then
            e.Handled = True
            e.Graphics.FillRectangle(New SolidBrush(Color.White), e.CellBounds)

            Dim buttonWidth As Integer = 80
            Dim buttonHeight As Integer = 20
            Dim buttonX As Integer = e.CellBounds.Left + (e.CellBounds.Width - buttonWidth) / 2
            Dim buttonY As Integer = e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2

            Dim buttonBounds As Rectangle = New Rectangle(buttonX, buttonY, buttonWidth, buttonHeight)

            Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
            Dim radius As Integer = 20
            path.AddArc(buttonBounds.Left, buttonBounds.Top, radius, radius, 180, 90)
            path.AddArc(buttonBounds.Right - radius, buttonBounds.Top, radius, radius, 270, 90)
            path.AddArc(buttonBounds.Right - radius, buttonBounds.Bottom - radius, radius, radius, 0, 90)
            path.AddArc(buttonBounds.Left, buttonBounds.Bottom - radius, radius, radius, 90, 90)
            path.CloseAllFigures()

            e.Graphics.FillPath(New SolidBrush(ColorTranslator.FromHtml("#1E90FF")), path) ' Blue color for Edit button

            TextRenderer.DrawText(e.Graphics, "Edit", dgCustomers.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If
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

    Private Sub dgCustomers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCustomers.CellContentClick
        ' Check if the click is on a valid cell and not the header row
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgCustomers.Rows(e.RowIndex)
            Dim customerID As Integer = CInt(selectedRow.Cells("CustomerID").Value)

            ' Handle the Edit button click
            If dgCustomers.Columns(e.ColumnIndex).Name = "Edit" Then
                txtCustomerID.Text = customerID.ToString()
                txtCustomerName.Text = selectedRow.Cells("Name").Value.ToString()
                txtPhone.Text = selectedRow.Cells("Phone").Value.ToString()
                txtEmail.Text = selectedRow.Cells("Email").Value.ToString()
            End If

            ' Handle the Delete button click
            If dgCustomers.Columns(e.ColumnIndex).Name = "Delete" Then
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    DeleteCustomer(customerID)
                    LoadCustomers()
                End If
            End If
        End If
    End Sub

    ' Function to delete customer
    Private Sub DeleteCustomer(customerID As Integer)
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