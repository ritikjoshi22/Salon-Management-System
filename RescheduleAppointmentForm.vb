Imports System.Data.SqlClient

Public Class RescheduleAppointmentForm
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
    Dim id As Integer
    Public Sub New(appointmentID As Integer)
        id = appointmentID
        InitializeComponent()
    End Sub

    Private Sub RescheduleAppointmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpReschedule.MinDate = DateTime.Today
        LoadServices()
    End Sub

    Private Sub LoadServices()
        Dim query As String = "SELECT ServiceID, ServiceName FROM Service"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                Dim command As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = command.ExecuteReader()

                Dim services As New List(Of Object)

                While reader.Read()
                    services.Add(New With {
                    .ServiceID = reader("ServiceID"),
                    .ServiceName = reader("ServiceName").ToString()
                })
                End While

                cbService.DisplayMember = "ServiceName"
                cbService.ValueMember = "ServiceID"
                cbService.DataSource = services

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error loading services: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim newServiceID As Integer = CInt(cbService.SelectedValue)
        Dim newAppointmentDateTime As DateTime = dtpReschedule.Value

        ' Check if the selected date is in the past
        If newAppointmentDateTime < DateTime.Now Then
            MessageBox.Show("You cannot schedule an appointment in the past!", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if there are already 4 appointments on the selected date
        Dim selectedDate As Date = newAppointmentDateTime.Date
        Dim appointmentCount As Integer = 0

        Dim countQuery As String = "SELECT COUNT(*) FROM Appointment WHERE CAST(AppointmentDateTime AS DATE) = @selectedDate"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim countCommand As New SqlCommand(countQuery, conn)
                countCommand.Parameters.AddWithValue("@selectedDate", selectedDate)
                appointmentCount = CInt(countCommand.ExecuteScalar())
            Catch ex As Exception
                MessageBox.Show("Error checking appointments: " & ex.Message)
                Return
            End Try
        End Using

        If appointmentCount >= 4 Then
            MessageBox.Show("Only 4 appointments can be scheduled for each day.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Update the appointment details in the database
        Dim updateQuery As String = "UPDATE Appointment SET ServiceID = @ServiceID, AppointmentDateTime = @AppointmentDateTime WHERE AppointmentID = @AppointmentID"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim updateCommand As New SqlCommand(updateQuery, conn)
                updateCommand.Parameters.AddWithValue("@ServiceID", newServiceID)
                updateCommand.Parameters.AddWithValue("@AppointmentDateTime", newAppointmentDateTime)
                updateCommand.Parameters.AddWithValue("@AppointmentID", id) ' Assuming appointmentID is the ID of the appointment being rescheduled
                updateCommand.ExecuteNonQuery()

                MessageBox.Show("Appointment rescheduled successfully!")
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("Error rescheduling appointment: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Guna2CirclePictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox1.Click
        Me.Close()
    End Sub
End Class