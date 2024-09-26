Imports System.Data.SqlClient

Public Class AppointmentDetailsForm
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
    Dim id As Integer
    Public Sub New(appointmentID As Integer)
        id = appointmentID
        InitializeComponent()
        LoadAppointmentDetails(appointmentID)
    End Sub

    Private Sub LoadAppointmentDetails(appointmentID As Integer)

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT c.Name AS CustomerName, c.Phone, s.ServiceName, s.ServiceGenre, s.Price, a.AppointmentDateTime
                                       FROM Appointment a
                                       INNER JOIN Customer c ON a.CustomerID = c.CustomerID
                                       INNER JOIN Service s ON a.ServiceID = s.ServiceID
                                       WHERE a.AppointmentID = @AppointmentID"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblCustomerName.Text = $"Customer Name: {reader("CustomerName")}"
                            lblPhone.Text = $"Phone: {reader("Phone")}"
                            lblServiceName.Text = $"Service: {reader("ServiceName")}"
                            lblServiceGenre.Text = $"Service Genre: {reader("ServiceGenre")}"
                            lblPrice.Text = $"Price: {Convert.ToDecimal(reader("Price")).ToString("C")}"
                            lblAppointmentDateTime.Text = $"Appointment Date: {Convert.ToDateTime(reader("AppointmentDateTime")).ToString("dd MMMM yyyy")}"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading appointment details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Dim query As String = "DELETE FROM Appointment WHERE AppointmentID = @AppointmentID"

            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim command As New SqlCommand(query, conn)
                    command.Parameters.AddWithValue("@AppointmentID", id) ' Assuming appointmentID is the ID of the appointment you want to delete
                    command.ExecuteNonQuery()

                    MessageBox.Show("Appointment deleted successfully!")
                    Me.Close() ' Close the form after deletion
                Catch ex As Exception
                    MessageBox.Show("Error deleting appointment: " & ex.Message)
                End Try
            End Using
        End If
    End Sub

    Private Sub btnReschedule_Click(sender As Object, e As EventArgs) Handles btnReschedule.Click
        Dim rescheduleForm As New RescheduleAppointmentForm(id)
        rescheduleForm.ShowDialog()
    End Sub

    Private Sub Guna2CirclePictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox1.Click
        Me.Close()
    End Sub
End Class