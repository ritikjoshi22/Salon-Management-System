Imports Guna.UI2.WinForms.Suite
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text


Public Class ManageUser
    Dim cnstr As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' Open File Dialog to select a picture
    Private Sub btnAddPicture_Click(sender As Object, e As EventArgs) Handles btnAddPicture.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedImage As Image = Image.FromFile(openFileDialog.FileName)
            pictureBoxUser.Image = selectedImage ' Display image in PictureBox
            ' Set the PictureBox SizeMode property
            pictureBoxUser.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub CheckAdminLimit()
        ' Query to check the number of Admins
        Dim query As String = "SELECT COUNT(*) FROM userData WHERE Role = 'Admin'"

        Using con As New SqlConnection(cnstr)
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    Dim adminCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If adminCount >= 2 Then
                        ' Remove "Admin" from the Role ComboBox
                        ComboBoxRole.Items.Remove("Admin")
                    ElseIf Not ComboBoxRole.Items.Contains("Admin") Then
                        ' Add "Admin" back to the Role ComboBox if it's less than 2
                        ComboBoxRole.Items.Add("Admin")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try
            End Using
        End Using
    End Sub


    ' Convert image to byte array
    Private Function ConvertImageToByteArray(img As Image) As Byte()
        Using ms As New IO.MemoryStream()
            img.Save(ms, img.RawFormat)
            Return ms.ToArray()
        End Using
    End Function

    Private Function HashPassword(password As String) As String
        Dim sha256 As SHA256 = sha256.Create()
        Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
        Dim builder As New StringBuilder()
        For Each b As Byte In bytes
            builder.Append(b.ToString("x2"))
        Next
        Return builder.ToString()
    End Function

    ' Save user data with image
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If pictureBoxUser.Image IsNot Nothing Then
            Dim imageBytes As Byte() = ConvertImageToByteArray(pictureBoxUser.Image)

            ' Hash the password
            Dim hashedPassword As String = HashPassword(txtPassword.Text)

            ' Insert query including the profile picture
            Dim query As String = "INSERT INTO userData (FirstName, LastName, Username, Email, PasswordHash, DOB, Gender, Role, ProfilePicture) " &
                              "VALUES (@fn, @ln, @un, @email, @pwd, @birth, @gender, @role, @pic)"

            Using con As New SqlConnection(cnstr)
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@fn", txtFirstName.Text)
                    cmd.Parameters.AddWithValue("@ln", txtLastName.Text)
                    cmd.Parameters.AddWithValue("@un", txtUserName.Text)
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                    cmd.Parameters.AddWithValue("@pwd", hashedPassword)
                    cmd.Parameters.AddWithValue("@birth", DateTimePicker1.Value)
                    cmd.Parameters.AddWithValue("@gender", ComboBox1.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@role", ComboBoxRole.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@pic", imageBytes) ' Profile picture

                    Try
                        con.Open()
                        cmd.ExecuteNonQuery()
                        CheckAdminLimit()
                        MessageBox.Show("User details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadUserData()
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        con.Close()
                    End Try
                End Using
            End Using
        Else
            MessageBox.Show("Please select a profile picture.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar ' Show password
        Else
            txtPassword.PasswordChar = "*" ' Hide password
        End If
    End Sub

    Private Sub LoadUserData()
        Dim query As String = "SELECT UserID, FirstName, LastName, Username,Email, Role FROM userData"

        Using con As New SqlConnection(cnstr)
            Using cmd As New SqlCommand(query, con)
                Dim dt As New DataTable()
                Dim da As New SqlDataAdapter(cmd)

                Try
                    con.Open()
                    da.Fill(dt)
                    dataGridViewUsers.DataSource = dt ' Bind data to DataGridView
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Check if a user is selected
        If dataGridViewUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to edit.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected user's ID
        Dim selectedUserID As Integer = Convert.ToInt32(dataGridViewUsers.SelectedRows(0).Cells("UserID").Value)

        ' Check for required fields
        If String.IsNullOrEmpty(txtFirstName.Text) OrElse String.IsNullOrEmpty(txtLastName.Text) OrElse String.IsNullOrEmpty(txtUserName.Text) Then
            MessageBox.Show("Please fill in all the required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' SQL query to update the user details
        Dim updateQuery As String = "UPDATE userData SET FirstName = @FirstName, LastName = @LastName, Username = @Username, Email=@Email, PasswordHash = @PasswordHash, Role = @Role, Gender = @Gender WHERE UserID = @UserID"

        Using con As New SqlConnection(cnstr)
            Using cmd As New SqlCommand(updateQuery, con)
                ' Bind parameters
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@PasswordHash", txtPassword.Text) ' Consider hashing the password
                cmd.Parameters.AddWithValue("@Role", ComboBoxRole.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@Gender", ComboBox1.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@UserID", selectedUserID)

                Try
                    con.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Refresh your DataGridView after editing
                    LoadUserData()
                Catch ex As Exception
                    MessageBox.Show("Error updating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try
            End Using
        End Using
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Check if a user is selected (assuming you have a DataGridView to select users)
        If dataGridViewUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected user's ID from the DataGridView
        Dim selectedUserID As Integer = Convert.ToInt32(dataGridViewUsers.SelectedRows(0).Cells("UserID").Value)

        ' Ask for confirmation before deleting
        If MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' SQL query to delete the user
            Dim deleteQuery As String = "DELETE FROM userData WHERE UserID = @UserID"

            Using con As New SqlConnection(cnstr)
                Using cmd As New SqlCommand(deleteQuery, con)
                    cmd.Parameters.AddWithValue("@UserID", selectedUserID)

                    Try
                        con.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ' Refresh your DataGridView after deletion
                        LoadUserData()
                    Catch ex As Exception
                        MessageBox.Show("Error deleting user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        con.Close()
                    End Try
                End Using
            End Using
        End If
    End Sub


    Private Sub ManageUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserData()
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(New String() {"Male", "Female", "Other"})

        ' Populate Role ComboBox
        ComboBoxRole.Items.Clear()
        ComboBoxRole.Items.AddRange(New String() {"Admin", "Manager", "User"})

        ' Set the PictureBox SizeMode to StretchImage
        pictureBoxUser.SizeMode = PictureBoxSizeMode.StretchImage

        ' Check the number of Admins
        CheckAdminLimit()
    End Sub

    Private Sub dataGridViewUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridViewUsers.CellContentClick
        If e.RowIndex >= 0 Then
            ' Populate the textboxes with the selected user's information
            Dim selectedRow As DataGridViewRow = dataGridViewUsers.Rows(e.RowIndex)

            txtFirstName.Text = selectedRow.Cells("FirstName").Value.ToString()
            txtLastName.Text = selectedRow.Cells("LastName").Value.ToString()
            txtUserName.Text = selectedRow.Cells("Username").Value.ToString()
            txtEmail.Text = selectedRow.Cells("Email").Value.ToString()

            ' Assuming you store hashed passwords in the database, you should not load the password
            ' txtPassword.Text = selectedRow.Cells("PasswordHash").Value.ToString()

        End If
    End Sub
End Class