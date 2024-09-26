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

    Private Function ConvertByteArrayToImage(byteArray As Byte()) As Image
        Using ms As New IO.MemoryStream(byteArray)
            Return Image.FromStream(ms)
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
        If txtUserID.Text = "" Then
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
        Else
            Dim imageBytes As Byte() = ConvertImageToByteArray(pictureBoxUser.Image)

            Dim hashedPassword As String = HashPassword(txtPassword.Text)
            ' Check if a user is selected
            If dataGridViewUsers.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a user to edit.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get the selected user's ID
            Dim UserID As Integer = CInt(txtUserID.Text)

            ' Check for required fields
            If String.IsNullOrEmpty(txtFirstName.Text) OrElse String.IsNullOrEmpty(txtLastName.Text) OrElse String.IsNullOrEmpty(txtUserName.Text) Then
                MessageBox.Show("Please fill in all the required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' SQL query to update the user details
            Dim updateQuery As String = "UPDATE userData SET FirstName = @FirstName, LastName = @LastName, Username = @Username, Email=@Email, PasswordHash = @PasswordHash, Role = @Role, Gender = @Gender, ProfilePicture = @pic WHERE UserID = @UserID"

            Using con As New SqlConnection(cnstr)
                Using cmd As New SqlCommand(updateQuery, con)
                    ' Bind parameters
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text)
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword) ' Consider hashing the password
                    cmd.Parameters.AddWithValue("@Role", ComboBoxRole.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@Gender", ComboBox1.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@pic", imageBytes)
                    cmd.Parameters.AddWithValue("@UserID", UserID)

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
        Dim query As String = "SELECT UserID, FirstName, LastName, Username, Email,Gender, Role, DOB FROM userData"

        Using con As New SqlConnection(cnstr)
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    Dim adapter As New SqlDataAdapter(query, con)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dataGridViewUsers.DataSource = dt

                    ' Add Edit button column only if it hasn't been added yet
                    If dataGridViewUsers.Columns("Edit") Is Nothing Then
                        Dim btnEdit As New DataGridViewButtonColumn()
                        btnEdit.HeaderText = "Edit"
                        btnEdit.Name = "Edit"
                        btnEdit.Text = "Edit"
                        btnEdit.UseColumnTextForButtonValue = True
                        dataGridViewUsers.Columns.Add(btnEdit)
                        dataGridViewUsers.AllowUserToAddRows = False
                    End If

                    ' Add Delete button column only if it hasn't been added yet
                    If dataGridViewUsers.Columns("Delete") Is Nothing Then
                        Dim deleteBtn As New DataGridViewButtonColumn()
                        deleteBtn.HeaderText = "Delete"
                        deleteBtn.Name = "Delete"
                        deleteBtn.Text = "Delete"
                        deleteBtn.UseColumnTextForButtonValue = True
                        dataGridViewUsers.Columns.Add(deleteBtn)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error loading customers: " & ex.Message)
                End Try
            End Using
        End Using
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
        Dim defaultProfile As String = "C:\Users\Acer\Downloads\profileDefault.jpeg"
        Dim imageBytes As Byte() = ConvertImageToByteArray(Image.FromFile(defaultProfile))
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dataGridViewUsers.Rows(e.RowIndex)
            Dim userID As Integer = CInt(selectedRow.Cells("UserID").Value)
            Dim profileImg As Image
            Try
                Using conn As New SqlConnection(cnstr)
                    conn.Open()
                    Dim query As String = "SELECT ProfilePicture from userData where UserID=@uid"
                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@uid", CInt(selectedRow.Cells("UserID").Value.ToString()))
                        Using reader As SqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim ProfilePicture As Byte() = TryCast(reader("ProfilePicture"), Byte())
                                If ProfilePicture Is Nothing OrElse ProfilePicture.Length = 0 Then
                                    ProfilePicture = imageBytes
                                End If
                                profileImg = ConvertByteArrayToImage(ProfilePicture)
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("No Image Please insert One!")
            End Try
            ' Handle the Edit button click
            If dataGridViewUsers.Columns(e.ColumnIndex).Name = "Edit" Then
                txtUserID.Text = selectedRow.Cells("UserID").Value.ToString()
                txtFirstName.Text = selectedRow.Cells("FirstName").Value.ToString()
                txtLastName.Text = selectedRow.Cells("LastName").Value.ToString()
                txtUserName.Text = selectedRow.Cells("Username").Value.ToString()
                txtEmail.Text = selectedRow.Cells("Email").Value.ToString()
                ComboBox1.Text = selectedRow.Cells("Gender").Value.ToString()
                ComboBoxRole.Text = selectedRow.Cells("Role").Value.ToString()
                txtEmail.Text = selectedRow.Cells("Email").Value.ToString()
                DateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells("DOB").Value)
                pictureBoxUser.Image = profileImg
            End If

            ' Handle the Delete button click
            If dataGridViewUsers.Columns(e.ColumnIndex).Name = "Delete" Then
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    deleteUserData(userID)
                    LoadUserData()
                End If
            End If
        End If
    End Sub

    Private Sub deleteUserData(userID As Integer)
        If dataGridViewUsers.SelectedRows.Count > 0 Then
            Dim query As String = "DELETE FROM userData WHERE UserID=@UserID"
            Using conn As New SqlConnection(cnstr)
                Try
                    conn.Open()
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Product deleted successfully!")
                    LoadUserData()
                Catch ex As Exception
                    MessageBox.Show("Error deleting product: " & ex.Message)
                End Try
            End Using
        Else
            MessageBox.Show("Please select a product to delete.")
        End If
    End Sub

    Private Sub dgCustomers_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dataGridViewUsers.CellPainting
        If e.ColumnIndex = dataGridViewUsers.Columns("Delete").Index AndAlso e.RowIndex >= 0 Then
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

            TextRenderer.DrawText(e.Graphics, "Delete", dataGridViewUsers.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If

        If e.ColumnIndex = dataGridViewUsers.Columns("Edit").Index AndAlso e.RowIndex >= 0 Then
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

            TextRenderer.DrawText(e.Graphics, "Edit", dataGridViewUsers.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If
    End Sub

End Class