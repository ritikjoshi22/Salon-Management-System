Imports System.Data.SqlClient

Public Class AddServices

    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;TrustServerCertificate=True"

    Private Sub AddServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbServiceGenre.Items.Add("Hair Cut")
        cbServiceGenre.Items.Add("Hair Color")
        cbServiceGenre.Items.Add("Facial")
        cbServiceGenre.Items.Add("Manicure")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If pictureBoxService.Image IsNot Nothing Then
            Dim imageBytes As Byte() = ConvertImageToByteArray(pictureBoxService.Image)
            'Insert the New service data into the Service table
            Dim query As String = "INSERT INTO Service (ServicePicture, ServiceName, ServiceGenre, Price) VALUES (@pic, @name, @genre, @price)"
            Using con As New SqlConnection(connectionString),
                  cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@name", txtServiceName.Text)
                cmd.Parameters.AddWithValue("@genre", cbServiceGenre.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@price", Decimal.Parse(txtServicePrice.Text))
                cmd.Parameters.AddWithValue("@pic", imageBytes) ' Profile picture
                Try
                    con.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Service details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try

            End Using
            ' Close the form after adding the service
            Me.Close()
        Else
            MessageBox.Show("Please select a service picture.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Function ConvertImageToByteArray(img As Image) As Byte()
        Using ms As New IO.MemoryStream()
            img.Save(ms, img.RawFormat)
            Return ms.ToArray()
        End Using
    End Function

    Private Sub btnAddPicture_Click(sender As Object, e As EventArgs) Handles btnAddPicture.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedImage As Image = Image.FromFile(openFileDialog.FileName)
            pictureBoxService.Image = selectedImage ' Display image in PictureBox
            ' Set the PictureBox SizeMode property
            pictureBoxService.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub Guna2CirclePictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox1.Click
        Me.Close()
    End Sub
End Class