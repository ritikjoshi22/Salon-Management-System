Imports System.Data.SqlClient
Imports Guna.UI2.WinForms.Suite

Public Class AddAppoinment
    ' Connection string to your database
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' Load event for the form
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpAppointment.MinDate = DateTime.Today

        ' Load customers and services into ComboBoxes when form loads
        LoadCustomers()
        LoadServices()
    End Sub

    ' Add this at the beginning of Form4
    Public Event AppointmentAdded As EventHandler

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Get the selected values from the ComboBoxes and DateTimePicker
        Dim customerID As Integer = CInt(cbCustomer.SelectedValue)
        Dim serviceID As Integer = CInt(cbService.SelectedValue)
        Dim appointmentDateTime As DateTime = dtpAppointment.Value
        dtpAppointment.Format = DateTimePickerFormat.Custom
        dtpAppointment.CustomFormat = "MM/dd/yyyy hh:mm tt" ' Adjust the format as needed
        dtpAppointment.ShowUpDown = True ' Display an up-down control for time selection

        ' Check if the selected date is in the past
        If appointmentDateTime.Date < DateTime.Today Then
            MessageBox.Show("Cannot schedule an appointment in the past.")
            Exit Sub
        End If

        ' Check if there are already 4 appointments for the selected date
        Dim countQuery As String = "SELECT COUNT(*) FROM Appointment WHERE CAST(AppointmentDateTime AS DATE) = @SelectedDate"
        Dim appointmentCount As Integer = 0

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Using cmd As New SqlCommand(countQuery, conn)
                    cmd.Parameters.AddWithValue("@SelectedDate", appointmentDateTime.Date)
                    appointmentCount = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            Catch ex As Exception
                MessageBox.Show("Error checking appointment limit: " & ex.Message)
                Exit Sub
            End Try
        End Using

        ' Check if the limit has been reached
        If appointmentCount >= 4 Then
            MessageBox.Show("Only 4 appointments can be scheduled for each day.")
            Exit Sub
        End If

        ' SQL Insert Query
        Dim query As String = "INSERT INTO Appointment (CustomerID, ServiceID, AppointmentDateTime) " &
                          "VALUES (@CustomerID, @ServiceID, @AppointmentDateTime)"

        ' Execute the query to insert data into the Appointment table
        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                ' Create a SqlCommand
                Dim command As New SqlCommand(query, conn)
                command.Parameters.AddWithValue("@CustomerID", customerID)
                command.Parameters.AddWithValue("@ServiceID", serviceID)
                command.Parameters.AddWithValue("@AppointmentDateTime", appointmentDateTime)

                ' Execute the query
                command.ExecuteNonQuery()

                MessageBox.Show("Appointment successfully added!")

                ' Raise the event to notify the main form
                RaiseEvent AppointmentAdded(Me, EventArgs.Empty)

                ' Optionally close the form after saving
                Me.Close()

            Catch ex As Exception
                MessageBox.Show("Error saving appointment: " & ex.Message)
            End Try
        End Using
    End Sub

    ' Load Customers into ComboBox
    Private Sub LoadCustomers()
        Dim query As String = "SELECT CustomerID, Name FROM Customer"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                Dim command As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Clear current items
                cbCustomer.Items.Clear()

                ' Create a list of items to bind
                Dim customers As New List(Of Object)

                ' Add customers to the list
                While reader.Read()
                    customers.Add(New With {
                    .CustomerID = reader("CustomerID"),
                    .Name = reader("Name").ToString()
                })
                End While

                ' Set display and value members
                cbCustomer.DisplayMember = "Name"
                cbCustomer.ValueMember = "CustomerID"

                ' Bind list to ComboBox
                cbCustomer.DataSource = customers

                ' Close the reader
                reader.Close()

            Catch ex As Exception
                MessageBox.Show("Error loading customers: " & ex.Message)
            End Try
        End Using
    End Sub


    ' Load Services into ComboBox
    ' Load Services into ComboBox
    Private Sub LoadServices()
        Dim query As String = "SELECT ServiceID, ServiceName FROM Service"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                Dim command As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Clear current items
                cbService.Items.Clear()

                ' Create a list of items to bind
                Dim services As New List(Of Object)

                ' Add services to the list
                While reader.Read()
                    services.Add(New With {
                    .ServiceID = reader("ServiceID"),
                    .ServiceName = reader("ServiceName").ToString()
                })
                End While

                ' Set display and value members
                cbService.DisplayMember = "ServiceName"
                cbService.ValueMember = "ServiceID"

                ' Bind list to ComboBox
                cbService.DataSource = services

                ' Close the reader
                reader.Close()

            Catch ex As Exception
                MessageBox.Show("Error loading services: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Guna2CirclePictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox1.Click
        Me.Close()
    End Sub
End Class