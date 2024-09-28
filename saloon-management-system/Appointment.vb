Imports System.Data.SqlClient
Imports System.IO

Public Class Appointment
    ' Connection string to your database
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    Private listFlDay As New List(Of FlowLayoutPanel)
    Private currentDate As DateTime = DateTime.Today
    Private Sub Appointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateDayPanel(38)
        DisplayCurrentDate()
    End Sub

    Private Sub AddAppointmentToFlDay(ByVal startDayAtFlNumber As Integer)
        Dim startDate As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
        Dim endDate As DateTime = startDate.AddMonths(1).AddDays(-1)
        Dim query As String = "SELECT * FROM Appointment WHERE AppointmentDateTime BETWEEN @start AND @end"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@start", startDate)
                    cmd.Parameters.AddWithValue("@end", endDate)

                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    adapter.Fill(ds, "result")
                    Dim dt As DataTable = ds.Tables("result")

                    For Each row As DataRow In dt.Rows
                        Dim appDay As DateTime = DateTime.Parse(row("AppointmentDateTime"))
                        Dim link As New LinkLabel
                        link.Name = $"link{row("AppointmentID")}"

                        ' Assuming your table has a column "CustomerID"
                        Dim customerId As Integer = CInt(row("CustomerID"))

                        link.Text = GetCustomerNameById(customerId)

                        ' Set the color to red if the appointment date is in the past
                        If appDay.Date < DateTime.Today Then
                            link.LinkColor = Color.Red
                        End If

                        AddHandler link.Click, Sub(sender As Object, e As EventArgs)
                                                   Dim appointmentID As Integer = CInt(row("AppointmentID"))
                                                   Dim detailsForm As New AppointmentDetailsForm(appointmentID)
                                                   detailsForm.ShowDialog()
                                               End Sub

                        listFlDay(appDay.Day + (startDayAtFlNumber)).Controls.Add(link)
                    Next
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading customers: " & ex.Message)
            End Try
        End Using
    End Sub



    Private Function GetCustomerNameById(customerId As Integer) As String
        Dim customerName As String = String.Empty
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT Name FROM Customer WHERE CustomerID = @CustomerID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CustomerID", customerId)

                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        customerName = result.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving customer name: " & ex.Message)
        End Try

        Return customerName
    End Function

    Private Function GetFirstDayOfWeekOfCurrentDate() As Integer
        Dim firstDayOfMonth As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
        Return firstDayOfMonth.DayOfWeek - 1
    End Function

    Private Function GetTotalDaysOfCurrentDate() As Integer
        Dim firstDayOfCurrentDate As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
        Return firstDayOfCurrentDate.AddMonths(1).AddDays(-1).Day
    End Function

    Private Sub DisplayCurrentDate()
        lblMonthAndYear.Text = currentDate.ToString("MMMM, yyyy")
        Dim firstDayAtFlNumber As Integer = GetFirstDayOfWeekOfCurrentDate()
        Dim totalDay As Integer = GetTotalDaysOfCurrentDate()
        AddLabelDayToFlDay(firstDayAtFlNumber, totalDay)
        AddAppointmentToFlDay(firstDayAtFlNumber)
    End Sub

    Private Sub PrevMonth()
        currentDate = currentDate.AddMonths(-1)
        DisplayCurrentDate()
    End Sub

    Private Sub NextMonth()
        currentDate = currentDate.AddMonths(1)
        DisplayCurrentDate()
    End Sub

    Private Sub Today()
        currentDate = DateTime.Now
        DisplayCurrentDate()
    End Sub

    Private Sub GenerateDayPanel(ByVal totalDays As Integer)
        flDays.Controls.Clear()
        listFlDay.Clear()

        For i = 1 To totalDays
            Dim fl As New FlowLayoutPanel
            fl.Name = $"flDay{i}"
            fl.Size = New Size(190, 112)
            fl.BackColor = Color.White
            fl.BorderStyle = BorderStyle.FixedSingle
            flDays.Controls.Add(fl)
            listFlDay.Add(fl)
        Next
    End Sub

    Private Sub AddLabelDayToFlDay(ByVal startDayAtFlNumber As Integer, ByVal totalDaysInMonth As Integer)
        For Each fl As FlowLayoutPanel In listFlDay
            fl.Controls.Clear()
        Next

        For i As Integer = 1 To totalDaysInMonth
            Dim lbl As New Label
            lbl.Name = $"lblDay{i}"
            lbl.AutoSize = False
            lbl.TextAlign = ContentAlignment.MiddleRight
            lbl.Size = New Size(160, 22)
            lbl.Text = i
            lbl.Font = New Font("Microsoft Sans Serif", 12)
            listFlDay((i - 1) + startDayAtFlNumber + 1).Controls.Add(lbl)
        Next
    End Sub

    Private Sub btnPrevMonth_Click(sender As Object, e As EventArgs) Handles btnPrevMonth.Click
        PrevMonth()
    End Sub

    Private Sub btnNextMonth_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        NextMonth()
    End Sub

    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        Today()
    End Sub

    Private Sub btnAddAppointment_Click(sender As Object, e As EventArgs) Handles btnAddAppointment.Click
        Dim addAppointment As New AddAppoinment()
        addAppointment.ShowDialog()
    End Sub

End Class