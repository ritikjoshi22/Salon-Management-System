Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Login
    ' Connection string to your database
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;TrustServerCertificate=True"

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

    ' Method to load usernames into the ComboBox (combobox instead of username textbox)
    Private Sub LoadUsernames()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                ' Create SQL command to get all usernames
                Dim query As String = "SELECT Username FROM userData"
                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        ' Clear existing items
                        cmbUsername.Items.Clear()

                        ' Loop through the data and add usernames to the ComboBox
                        While reader.Read()
                            cmbUsername.Items.Add(reader("Username").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading usernames: " & ex.Message)
        End Try
    End Sub

    ' Login button click event to validate the username and password
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim selectedUsername As String = cmbUsername.Text
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

                ' Query to get the stored password hash for the selected username
                Dim query As String = "SELECT PasswordHash FROM userData WHERE Username = @username"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", selectedUsername)

                    ' Execute the query and retrieve the stored password hash
                    Dim storedPasswordHash As String = cmd.ExecuteScalar()?.ToString()

                    ' Compare the stored password hash with the entered hashed password
                    If storedPasswordHash IsNot Nothing AndAlso storedPasswordHash = hashedEnteredPassword Then
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ' Proceed with the login (you can open the main form here)
                    Else
                        MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred during login: " & ex.Message)
        End Try
    End Sub

    ' Call LoadUsernames when the form loads
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsernames()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Signup.Show()
        Me.Hide()
    End Sub
End Class
