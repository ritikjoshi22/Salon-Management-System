Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Diagnostics
Imports System.IO
Imports System.Web.Security

Public Class Login
    ' Connection string to your database
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;TrustServerCertificate=True"

    ' Path to your eye images
    Dim eyeClosedPath As String = "C:\Users\Acer\Downloads\hide.png" ' Path to closed eye icon
    Dim eyeOpenPath As String = "C:\Users\Acer\Downloads\view.png"     ' Path to open eye icon
    Dim defaultProfile As String = "C:\Users\Acer\Downloads\profileDefault.jpeg"
    Dim imageBytes As Byte() = ConvertImageToByteArray(Image.FromFile(defaultProfile))

    ' Form Load Event to set the initial image
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picEye.Image = Image.FromFile(eyeClosedPath) ' Set the default eye-closed image
    End Sub

    ' Function to hash the password using SHA256 (same as in signup form)
    Private Function HashPassword(password As String) As String
        Dim sha256 As SHA256 = SHA256.Create()
        Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
        Dim builder As New StringBuilder()
        For Each b As Byte In bytes
            builder.Append(b.ToString("x2"))
        Next
        Return builder.ToString()
    End Function

    Private Function ConvertImageToByteArray(img As Image) As Byte()
        Using ms As New IO.MemoryStream()
            img.Save(ms, img.RawFormat)
            Return ms.ToArray()
        End Using
    End Function

    ' Method to load usernames into the ComboBox (combobox instead of username textbox)
    'Private Sub LoadUsernames()
    '    Try
    '        Using conn As New SqlConnection(connectionString)
    '            conn.Open()

    '            ' Create SQL command to get all usernames
    '            Dim query As String = "SELECT Username FROM userData"
    '            Using cmd As New SqlCommand(query, conn)
    '                Using reader As SqlDataReader = cmd.ExecuteReader()
    '                    ' Clear existing items
    '                    cmbUsername.Items.Clear()

    '                    ' Loop through the data and add usernames to the ComboBox
    '                    While reader.Read()
    '                        cmbUsername.Items.Add(reader("Username").ToString())
    '                    End While
    '                End Using
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("An error occurred while loading usernames: " & ex.Message)
    '    End Try
    'End Sub

    ' Login button click event to validate the username and password
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim selectedUsername As String = txtUsername.Text
        Dim enteredPassword As String = txtPassword.Text

        If String.IsNullOrEmpty(selectedUsername) OrElse String.IsNullOrEmpty(enteredPassword) Then
            MessageBox.Show("Please enter your username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Hash the entered password to compare with stored hash
        Dim hashedEnteredPassword As String = HashPassword(enteredPassword)

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                ' Query to get the stored password hash and role for the selected username
                Dim query As String = "SELECT FirstName, PasswordHash, Role, ProfilePicture FROM userData WHERE Username = @username"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", selectedUsername)

                    ' Execute the query and retrieve the stored password hash and role
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim storedPasswordHash As String = reader("PasswordHash").ToString()
                            Dim role As String = reader("Role").ToString()
                            Dim FirstName As String = reader("FirstName").ToString()
                            Dim ProfilePicture As Byte() = TryCast(reader("ProfilePicture"), Byte())

                            If ProfilePicture Is Nothing OrElse ProfilePicture.Length = 0 Then
                                ProfilePicture = imageBytes
                            End If



                            ' Compare the stored password hash with the entered hashed password
                            If storedPasswordHash = hashedEnteredPassword Then
                                ' Pass the user role to Form3
                                Dim form As New Form3(role, FirstName, ProfilePicture)
                                form.Show()
                                Me.Hide()
                            Else
                                MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred during login: " & ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Signup.Show()
        Me.Hide()
    End Sub

    Private Sub picEye_Click(sender As Object, e As EventArgs) Handles picEye.Click
        If txtPassword.PasswordChar = "*"c Then
            ' Change to visible (show password)
            txtPassword.PasswordChar = ControlChars.NullChar
            picEye.Image = Image.FromFile(eyeOpenPath) ' Change to eye-open image
        Else
            ' Change to hidden (mask password)
            txtPassword.PasswordChar = "*"c
            picEye.Image = Image.FromFile(eyeClosedPath) ' Change back to eye-closed image
        End If
    End Sub

    Private Sub picGoogle_Click(sender As Object, e As EventArgs) Handles picGoogle.Click
        Process.Start("https://www.google.com")
    End Sub

    Private Sub picGithub_Click(sender As Object, e As EventArgs) Handles picGithub.Click
        Process.Start("https://www.github.com")
    End Sub

    Private Sub picFacebook_Click(sender As Object, e As EventArgs) Handles picFacebook.Click
        Process.Start("https://www.facebook.com")
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim form As New Form3("User", "", imageBytes)
        form.Show()
        Me.Hide()
    End Sub
End Class