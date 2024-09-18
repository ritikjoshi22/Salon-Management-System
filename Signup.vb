Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Signup
    ' Connection string to your database
    Dim cnstr As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;TrustServerCertificate=True"


    ' Function to hash the password using SHA256
    Private Function HashPassword(password As String) As String
        Dim sha256 As SHA256 = SHA256.Create()
        Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
        Dim builder As New StringBuilder()
        For Each b As Byte In bytes
            builder.Append(b.ToString("x2"))
        Next
        Return builder.ToString()
    End Function

    ' Validate the form before submission
    Private Function ValidateForm() As Boolean
        ' Validate email and required fields
        If String.IsNullOrEmpty(txtFirstName.Text) OrElse String.IsNullOrEmpty(txtLastName.Text) OrElse String.IsNullOrEmpty(txtEmail.Text) OrElse String.IsNullOrEmpty(txtPassword.Text) OrElse String.IsNullOrEmpty(txtUserName.Text) Then
            MessageBox.Show("Please fill out all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Simple email validation
        Dim emailPattern As String = "^\S+@\S+\.\S+$"
        If Not Regex.IsMatch(txtEmail.Text, emailPattern) Then
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Ensure password has minimum requirements (e.g., length)
        If txtPassword.Text.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Ensure gender is selected
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select your gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function


    ' Handle the click event of the Sign Up button
    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        If Not ValidateForm() Then
            Return ' Exit if validation fails
        End If

        ' Hash the password before storing
        Dim hashedPassword As String = HashPassword(txtPassword.Text)

        ' Insert the user data into the database
        Dim query As String = "INSERT INTO userData (FirstName, LastName, Username, Email, PasswordHash, DOB, Gender) VALUES (@fn, @ln, @un @email, @pwd, @birth, @gender)"

        Using con As New SqlConnection(cnstr)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = txtFirstName.Text
                cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = txtLastName.Text
                cmd.Parameters.Add("@un", SqlDbType.VarChar).Value = txtUserName.Text
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text
                cmd.Parameters.Add("@pwd", SqlDbType.VarChar).Value = hashedPassword ' Store hashed password
                cmd.Parameters.Add("@birth", SqlDbType.Date).Value = DateTimePicker1.Value ' Get value from DateTimePicker
                cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = ComboBox1.SelectedItem.ToString()

                Try
                    con.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Sign-up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try
            End Using
        End Using
    End Sub

    ' Update the text box with the selected date
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        txtDOB.Text = DateTimePicker1.Value.ToShortDateString()
    End Sub


    Private Sub btnBackToLogin_Click(sender As Object, e As EventArgs) Handles btnBackToLogin.Click
        Login.Show()
        Me.Close()
    End Sub
End Class
