Imports LiveCharts
Imports LiveCharts.Wpf
Imports System.Data.SqlClient

Public Class Dashboard
    ' Connection string to your database
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' Load event for the form
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRevenueData("1Y")
        LoadPieChart()
    End Sub

    ' Method to load the pie chart with product data
    Private Sub LoadPieChart()
        ' SQL Query to fetch product category and their quantities
        Dim query As String = "SELECT Category, SUM(Quantity) AS TotalQuantity FROM Product GROUP BY Category"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                Dim command As New SqlCommand(query, conn)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Initialize pie chart series
                Dim pieSeries As New SeriesCollection()

                ' Iterate through the data and add to the pie chart
                While reader.Read()
                    Dim category As String = reader("Category").ToString()
                    Dim quantity As Integer = CInt(reader("TotalQuantity"))

                    ' Add a pie chart slice for each product category
                    pieSeries.Add(New PieSeries With {
                        .Title = category,
                        .Values = New ChartValues(Of Integer)({quantity}),
                        .DataLabels = True,   ' Display the value
                        .LabelPoint = Function(chartPoint) String.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation)
                    })
                End While

                ' Close the reader
                reader.Close()

                ' Set the series to the pie chart control
                PieChart1.Series = pieSeries

            Catch ex As Exception
                MessageBox.Show("Error loading pie chart data: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub LoadRevenueData(dateRange As String)
        ' Debugging: Check which date range is being passed

        ' Dynamic query based on the selected date range
        Dim query As String = "SELECT DateOfPayment, SUM(TotalRevenue) AS TotalRevenue " &
                          "FROM Revenue WHERE DateOfPayment >= @startDate " &
                          "GROUP BY DateOfPayment ORDER BY DateOfPayment"

        ' Get the start date based on the selected range
        Dim startDate As Date = GetStartDate(dateRange)

        ' Debugging: Check if the startDate is calculated correctly

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                Dim command As New SqlCommand(query, conn)
                command.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate

                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Initialize chart values
                Dim revenueValues As New ChartValues(Of Double)()
                Dim dateLabels As New List(Of String)()

                ' Read data from the database
                While reader.Read()
                    revenueValues.Add(CDbl(reader("TotalRevenue")))
                    dateLabels.Add(CDate(reader("DateOfPayment")).ToString("yyyy-MM-dd"))
                End While

                ' Debugging: Check if any data was retrieved
                If revenueValues.Count = 0 Then
                    MessageBox.Show("No data retrieved for this range.")
                End If

                ' Close the reader
                reader.Close()

                ' Set the chart data
                revenueChart.Series = New SeriesCollection From {
                New LineSeries With {
                    .Title = "Revenue",
                    .Values = revenueValues
                }
            }

                ' Set the axis labels
                revenueChart.AxisX.Clear()
                revenueChart.AxisX.Add(New Axis With {
                .Title = "Date",
                .Labels = dateLabels
            })

                revenueChart.AxisY.Clear()
                revenueChart.AxisY.Add(New Axis With {
                .Title = "Total Revenue",
                .LabelFormatter = Function(value) "Rs. " & value.ToString("N2") ' Format in Nepali Rupees
            })

            Catch ex As Exception
                MessageBox.Show("Error loading revenue data: " & ex.Message)
            End Try
        End Using
    End Sub


    ' Function to get the start date based on the selected range
    Private Function GetStartDate(dateRange As String) As Date
        Dim today As Date = Date.Today
        Dim startDate As Date

        Select Case dateRange
            Case "1W"
                startDate = today.AddDays(-7) ' 1 week ago
            Case "1M"
                startDate = today.AddMonths(-1) ' 1 month ago
            Case "1Y"
                startDate = today.AddYears(-1) ' 1 year ago
            Case "10Y"
                startDate = today.AddYears(-10) ' 10 years ago
            Case Else
                startDate = today ' Default to today if something unexpected happens
        End Select

        Return startDate
    End Function


    ' Button click event handlers
    Private Sub btn1W_Click(sender As Object, e As EventArgs) Handles btn1W.Click
        LoadRevenueData("1W") ' Load 1 week of revenue data
    End Sub

    Private Sub btn1M_Click(sender As Object, e As EventArgs) Handles btn1M.Click
        LoadRevenueData("1M") ' Load 1 month of revenue data
    End Sub

    Private Sub btn1Y_Click(sender As Object, e As EventArgs) Handles btn1Y.Click
        LoadRevenueData("1Y") ' Load 1 year of revenue data
    End Sub

    Private Sub btn10Y_Click(sender As Object, e As EventArgs) Handles btn10Y.Click
        LoadRevenueData("10Y") ' Load 10 years of revenue data
    End Sub

End Class
