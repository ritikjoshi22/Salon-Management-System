Imports System.Data.SqlClient

Public Class Employee
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' Load employees when form loads
    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployees()
    End Sub

    ' Function to load employees into DataGridView
    Private Sub LoadEmployees()
        Dim query As String = "SELECT EmployeeID, Name, Phone, Position FROM Employee"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgEmployees.DataSource = dt

                ' Add Edit button column only if it hasn't been added yet
                If dgEmployees.Columns("Edit") Is Nothing Then
                    Dim btnEdit As New DataGridViewButtonColumn()
                    btnEdit.HeaderText = "Edit"
                    btnEdit.Name = "Edit"
                    btnEdit.Text = "Edit"
                    btnEdit.UseColumnTextForButtonValue = True
                    dgEmployees.Columns.Add(btnEdit)
                    dgEmployees.AllowUserToAddRows = False
                End If

                ' Add Delete button column only if it hasn't been added yet
                If dgEmployees.Columns("Delete") Is Nothing Then
                    Dim deleteBtn As New DataGridViewButtonColumn()
                    deleteBtn.HeaderText = "Delete"
                    deleteBtn.Name = "Delete"
                    deleteBtn.Text = "Delete"
                    deleteBtn.UseColumnTextForButtonValue = True
                    dgEmployees.Columns.Add(deleteBtn)
                End If
            Catch ex As Exception
                MessageBox.Show("Error loading customers: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim employeeName As String = txtEmployeeName.Text
        Dim phone As String = txtPhone.Text
        Dim position As String = txtPosition.Text

        ' Check if it's a new entry or an edit (EmployeeID is empty or not)
        If txtEmployeeID.Text = "" Then
            ' Insert new employee (no EmployeeID needed here, as it's auto-generated)
            Dim query As String = "INSERT INTO Employee (Name, Phone, Position) VALUES (@Name, @Phone, @Position)"
            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", employeeName)
                    cmd.Parameters.AddWithValue("@Phone", phone)
                    cmd.Parameters.AddWithValue("@Position", position)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Employee added successfully!")
                    LoadEmployees()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("Error adding employee: " & ex.Message)
                End Try
            End Using
        Else
            ' Update employee
            Dim employeeID As Integer = CInt(txtEmployeeID.Text)
            Dim query As String = "UPDATE Employee SET Name=@Name, Phone=@Phone, Position=@Position WHERE EmployeeID=@EmployeeID"
            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", employeeName)
                    cmd.Parameters.AddWithValue("@Phone", phone)
                    cmd.Parameters.AddWithValue("@Position", position)
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Employee updated successfully!")
                    LoadEmployees()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("Error updating employee: " & ex.Message)
                End Try
            End Using
        End If
    End Sub

    ' Helper method to clear input fields
    Private Sub ClearFields()
        txtEmployeeID.Text = ""
        txtEmployeeName.Text = ""
        txtPhone.Text = ""
        txtPosition.Text = ""
    End Sub


    Private Sub dgEmployee_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEmployees.CellContentClick
        ' Check if the click is on a valid cell and not the header row
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgEmployees.Rows(e.RowIndex)
            Dim employeeID As Integer = CInt(selectedRow.Cells("EmployeeID").Value)

            ' Handle the Edit button click
            If dgEmployees.Columns(e.ColumnIndex).Name = "Edit" Then
                txtEmployeeID.Text = selectedRow.Cells("EmployeeID").Value.ToString()
                txtEmployeeName.Text = selectedRow.Cells("Name").Value.ToString()
                txtPhone.Text = selectedRow.Cells("Phone").Value.ToString()
                txtPosition.Text = selectedRow.Cells("Position").Value.ToString()
            End If

            ' Handle the Delete button click
            If dgEmployees.Columns(e.ColumnIndex).Name = "Delete" Then
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    deleteEmployee(employeeID)
                    LoadEmployees()
                End If
            End If
        End If
    End Sub

    Private Sub deleteEmployee(employeeID As Integer)
        If dgEmployees.SelectedRows.Count > 0 Then
            Dim query As String = "DELETE FROM Employee WHERE EmployeeID=@EmployeeID"
            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Employee deleted successfully!")
                    LoadEmployees()
                Catch ex As Exception
                    MessageBox.Show("Error deleting employee: " & ex.Message)
                End Try
            End Using
        Else
            MessageBox.Show("Please select an employee to delete.")
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchText As String = txtSearch.Text

        Dim query As String = "SELECT EmployeeID, Name, Phone, Position FROM Employee WHERE Name LIKE @Search OR Phone LIKE @Search"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim adapter As New SqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" & searchText & "%")
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgEmployees.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error searching employees: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub dgCustomers_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgEmployees.CellPainting
        If e.ColumnIndex = dgEmployees.Columns("Delete").Index AndAlso e.RowIndex >= 0 Then
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

            TextRenderer.DrawText(e.Graphics, "Delete", dgEmployees.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If

        If e.ColumnIndex = dgEmployees.Columns("Edit").Index AndAlso e.RowIndex >= 0 Then
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

            TextRenderer.DrawText(e.Graphics, "Edit", dgEmployees.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If
    End Sub

End Class