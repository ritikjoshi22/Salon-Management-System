Public Class Form3

    Private userRole As String
    Private userFirstName As String
    Private ProfilePicture As Byte()

    ' Constructor to initialize the form with the user's role
    Public Sub New(role As String, firstName As String, ProfilePicture As Byte())
        InitializeComponent()
        userRole = role
        userFirstName = firstName
        Me.ProfilePicture = ProfilePicture
    End Sub

    Private Sub RoundPanel(pnl As Panel)

        ' Define the radius for the top-right corner
        Dim radius As Integer = 30

        ' Create a GraphicsPath to draw the panel with rounded top-right corner
        Dim path As New Drawing2D.GraphicsPath()
        path.StartFigure()

        ' Top-left corner (no rounding)
        path.AddLine(0, 0, pnl.Width - radius, 0)

        ' Top-right corner (rounded)
        path.AddArc(New Rectangle(pnl.Width - radius, 0, radius, radius), 270, 90)

        ' Continue to the right edge
        path.AddLine(pnl.Width, radius, pnl.Width, pnl.Height + 300)

        ' Bottom-right corner (no rounding)
        path.AddLine(pnl.Width, pnl.Height + 300, 0, pnl.Height + 300)

        ' Bottom-left corner (no rounding)
        path.AddLine(0, pnl.Height + 300, 0, 0)

        path.CloseFigure()

        ' Set the Region property to apply the rounded effect
        pnl.Region = New Region(path)
    End Sub

    ' Form3_Load: Set the default form (Dashboard) when Form3 loads
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set buttons visibility and default panel based on role
        ConfigureAccessBasedOnRole()
        RoundPanel(Panel2)

    End Sub

    ' Subroutine to handle role-based access control
    Private Sub ConfigureAccessBasedOnRole()
        Select Case userRole
            Case "Admin"
                ' Admin can access all features; default form is Dashboard
                childform(New Dashboard(userFirstName, ProfilePicture))

            Case "Manager"
                ' Manager cannot access Dashboard and Manage Users
                DashboardBtn.Enabled = False
                ManageUserBtn.Enabled = False
                childform(New Appointment) ' Manager's default form is Appointment

            Case "User"
                ' User can only access Services
                DashboardBtn.Enabled = False
                AppointmentBtn.Enabled = False
                CustomerBtn.Enabled = False
                InventoryBtn.Enabled = False
                EmployeeBtn.Enabled = False
                ManageUserBtn.Enabled = False
                childform(New Services(ProfilePicture, userRole)) ' User's default form is Services

            Case Else
                ' Default case if role is undefined
                MessageBox.Show("Invalid role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close() ' Close form if the role is invalid
        End Select
    End Sub

    ' Function to show child form inside Panel1
    Sub childform(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        panel.Dock = DockStyle.Fill
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub


    Private Sub DashboardBtn_Click(sender As Object, e As EventArgs) Handles DashboardBtn.Click
        If userRole = "Admin" Then
            childform(New Dashboard(userFirstName, ProfilePicture))
        Else
            MessageBox.Show("This feature is not available in your current role.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub btnDashboard_MouseEnter(sender As Object, e As EventArgs) Handles DashboardBtn.MouseEnter
        DashboardBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Change background color to white
        DashboardBtn.BackColor = Color.FromArgb(228, 219, 245) ' Change foreground color to (57, 74, 214)
    End Sub

    Private Sub btnDashboard_MouseLeave(sender As Object, e As EventArgs) Handles DashboardBtn.MouseLeave
        DashboardBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Revert background color to original
        DashboardBtn.BackColor = Color.White ' Revert foreground color to white
    End Sub

    Private Sub AppointmentBtn_Click(sender As Object, e As EventArgs) Handles AppointmentBtn.Click
        If userRole = "Admin" Or userRole = "Manager" Then
            childform(New Appointment)
        Else
            MessageBox.Show("This feature is not available in your current role.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub AppointmentBtn_MouseEnter(sender As Object, e As EventArgs) Handles AppointmentBtn.MouseEnter
        AppointmentBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Change background color to white
        AppointmentBtn.BackColor = Color.FromArgb(228, 219, 245)  ' Change foreground color to (57, 74, 214)
    End Sub

    Private Sub AppointmentBtn_MouseLeave(sender As Object, e As EventArgs) Handles AppointmentBtn.MouseLeave
        AppointmentBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Revert background color to original
        AppointmentBtn.BackColor = Color.White ' Revert foreground color to white
    End Sub

    Private Sub ServicesBtn_Click(sender As Object, e As EventArgs) Handles ServicesBtn.Click
        ' All roles can access Services
        childform(New Services(ProfilePicture, userRole))
    End Sub
    Private Sub ServicesBtn_MouseEnter(sender As Object, e As EventArgs) Handles ServicesBtn.MouseEnter
        ServicesBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Change background color to white
        ServicesBtn.BackColor = Color.FromArgb(228, 219, 245)  ' Change foreground color to (57, 74, 214)
    End Sub

    Private Sub ServicesBtn_MouseLeave(sender As Object, e As EventArgs) Handles ServicesBtn.MouseLeave
        ServicesBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Revert background color to original
        ServicesBtn.BackColor = Color.White ' Revert foreground color to white
    End Sub

    Private Sub CustomerBtn_Click(sender As Object, e As EventArgs) Handles CustomerBtn.Click
        If userRole = "Admin" Or userRole = "Manager" Then
            childform(New Customer)
        Else
            MessageBox.Show("This feature is not available in your current role.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub CustomerBtn_MouseEnter(sender As Object, e As EventArgs) Handles CustomerBtn.MouseEnter
        CustomerBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Change background color to white
        CustomerBtn.BackColor = Color.FromArgb(228, 219, 245)  ' Change foreground color to (57, 74, 214)
    End Sub

    Private Sub CustomerBtn_MouseLeave(sender As Object, e As EventArgs) Handles CustomerBtn.MouseLeave
        CustomerBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Revert background color to original
        CustomerBtn.BackColor = Color.White ' Revert foreground color to white
    End Sub

    Private Sub InventoryBtn_Click(sender As Object, e As EventArgs) Handles InventoryBtn.Click
        If userRole = "Admin" Or userRole = "Manager" Then
            childform(New Inventory)
        Else
            MessageBox.Show("This feature is not available in your current role.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub InventoryBtn_MouseEnter(sender As Object, e As EventArgs) Handles InventoryBtn.MouseEnter
        InventoryBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Change background color to white
        InventoryBtn.BackColor = Color.FromArgb(228, 219, 245)  ' Change foreground color to (57, 74, 214)
    End Sub

    Private Sub InventoryBtn_MouseLeave(sender As Object, e As EventArgs) Handles InventoryBtn.MouseLeave
        InventoryBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Revert background color to original
        InventoryBtn.BackColor = Color.White ' Revert foreground color to white
    End Sub

    Private Sub EmployeeBtn_Click(sender As Object, e As EventArgs) Handles EmployeeBtn.Click
        If userRole = "Admin" Or userRole = "Manager" Then
            childform(New Employee)
        Else
            MessageBox.Show("This feature is not available in your current role.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub EmployeeBtn_MouseEnter(sender As Object, e As EventArgs) Handles EmployeeBtn.MouseEnter
        EmployeeBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Change background color to white
        EmployeeBtn.BackColor = Color.FromArgb(228, 219, 245)  ' Change foreground color to (57, 74, 214)
    End Sub

    Private Sub EmployeeBtn_MouseLeave(sender As Object, e As EventArgs) Handles EmployeeBtn.MouseLeave
        EmployeeBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Revert background color to original
        EmployeeBtn.BackColor = Color.White ' Revert foreground color to white
    End Sub

    Private Sub ManageUserBtn_Click(sender As Object, e As EventArgs) Handles ManageUserBtn.Click
        If userRole = "Admin" Then
            childform(New ManageUser)
        Else
            MessageBox.Show("This feature is not available in your current role.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub ManageUserBtn_MouseEnter(sender As Object, e As EventArgs) Handles ManageUserBtn.MouseEnter
        ManageUserBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Change background color to white
        ManageUserBtn.BackColor = Color.FromArgb(228, 219, 245)  ' Change foreground color to (57, 74, 214)
    End Sub

    Private Sub ManageUserBtn_MouseLeave(sender As Object, e As EventArgs) Handles ManageUserBtn.MouseLeave
        ManageUserBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Revert background color to original
        ManageUserBtn.BackColor = Color.White ' Revert foreground color to white
    End Sub
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
        Login.Show()
    End Sub
End Class