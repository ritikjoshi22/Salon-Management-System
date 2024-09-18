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
            Catch ex As Exception
                MessageBox.Show("Error loading employees: " & ex.Message)
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

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgEmployees.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgEmployees.SelectedRows(0)
            txtEmployeeID.Text = selectedRow.Cells("EmployeeID").Value.ToString()
            txtEmployeeName.Text = selectedRow.Cells("Name").Value.ToString()
            txtPhone.Text = selectedRow.Cells("Phone").Value.ToString()
            txtPosition.Text = selectedRow.Cells("Position").Value.ToString()
        Else
            MessageBox.Show("Please select an employee to edit.")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgEmployees.SelectedRows.Count > 0 Then
            Dim employeeID As Integer = CInt(dgEmployees.SelectedRows(0).Cells("EmployeeID").Value)

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

End Class
