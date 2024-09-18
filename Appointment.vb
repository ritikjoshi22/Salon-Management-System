Imports System.Data.SqlClient

Public Class Appointment
    ' Connection string to your database
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    Private Sub btnAddAppointment_Click(sender As Object, e As EventArgs) Handles btnAddAppointment.Click
        ' Create and show the child form
        Dim childForm As New AddAppoinment()

        ' Subscribe to the AppointmentAdded event
        AddHandler childForm.AppointmentAdded, AddressOf OnAppointmentAdded

        ' Show the child form
        childForm.ShowDialog()
    End Sub

    ' Event handler to refresh the DataGridView when a new appointment is added
    Private Sub OnAppointmentAdded(sender As Object, e As EventArgs)
        ' Reload the appointments in the DataGridView
        LoadAppointments()
    End Sub

    ' Method to load appointments into DataGridView
    Private Sub LoadAppointments()
        Dim query As String = "SELECT a.AppointmentID, c.Name AS CustomerName, s.ServiceName, s.Price, a.AppointmentDateTime " &
                              "FROM Appointment a " &
                              "JOIN Customer c ON a.CustomerID = c.CustomerID " &
                              "JOIN Service s ON a.ServiceID = s.ServiceID"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                Dim command As New SqlCommand(query, conn)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()

                ' Fill the DataTable with the result
                adapter.Fill(table)

                ' Bind the DataTable to the DataGridView
                DataGridView1.DataSource = table

            Catch ex As Exception
                MessageBox.Show("Error loading appointments: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Appointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAppointments()
    End Sub
End Class