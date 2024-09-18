Public Class Form3
    Sub childform(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        panel.Dock = DockStyle.Fill
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    ' Form3_Load: Set the default form (Dashboard) when Form3 loads
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Automatically show Dashboard form when Form3 loads
        childform(New Dashboard)
    End Sub

    Private Sub DashboardBtn_Click(sender As Object, e As EventArgs) Handles DashboardBtn.Click
        childform(New Dashboard)
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
        childform(New Appointment)
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
        childform(New Services)
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
        childform(New Customer)
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
        childform(New Inventory)
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
        childform(New Employee)
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
        childform(New ManageUser)
    End Sub
    Private Sub ManageUserBtn_MouseEnter(sender As Object, e As EventArgs) Handles ManageUserBtn.MouseEnter
        ManageUserBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Change background color to white
        ManageUserBtn.BackColor = Color.FromArgb(228, 219, 245)  ' Change foreground color to (57, 74, 214)
    End Sub

    Private Sub ManageUserBtn_MouseLeave(sender As Object, e As EventArgs) Handles ManageUserBtn.MouseLeave
        ManageUserBtn.ForeColor = Color.FromArgb(57, 74, 214) ' Revert background color to original
        ManageUserBtn.BackColor = Color.White ' Revert foreground color to white
    End Sub

    Private Sub Guna2CirclePictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox1.Click
        Me.Close()
        Login.Close()
    End Sub

End Class
