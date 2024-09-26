Imports System.Data.SqlClient

Public Class Services
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;TrustServerCertificate=True"

    ' Define a class to store cart items
    Private ProfilePicture As Byte()
    Private role As String
    Public Class CartItem
        Public Property ServiceID As Integer
        Public Property ServiceName As String
        Public Property Price As Decimal
        Public Property ServicePicture As Image
    End Class

    Public Sub New(ProfilePicture As Byte(), role As String)
        InitializeComponent()
        Me.ProfilePicture = ProfilePicture
        Me.role = role
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

    Private Sub RoundButton(btn As Button)

        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.ForeColor = Color.White
        btn.Cursor = Cursors.Hand

        Dim Raduis As New Drawing2D.GraphicsPath

        Raduis.StartFigure()
        'appends an elliptical arc to the current figure
        'left corner top
        Raduis.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(10, 0, btn.Width - 20, 0)
        'appends an elliptical arc to the current figure
        'right corner top
        Raduis.AddArc(New Rectangle(btn.Width - 20, 0, 20, 20), -90, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(btn.Width, 20, btn.Width, btn.Height - 10)
        'appends an elliptical arc to the current figure
        'right corner buttom
        Raduis.AddArc(New Rectangle(btn.Width - 25, btn.Height - 25, 25, 25), 0, 90)
        'appends a line segment to the current figure
        'left corner bottom
        Raduis.AddLine(btn.Width - 10, btn.Width, 20, btn.Height)
        'appends an elliptical arc to the current figure
        Raduis.AddArc(New Rectangle(0, btn.Height - 20, 20, 20), 90, 90)
        'Close the current figure and start a new one.
        Raduis.CloseFigure()
        'set the window associated with the control
        btn.Region = New Region(Raduis)
    End Sub

    Private Sub Services_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlowLayoutPanel1.Padding = New Padding(0, 0, 0, 0)
        RoundButton(btnHaircut)
        RoundButton(btnHaircolor)
        RoundButton(btnFacial)
        RoundButton(btnManicure)
        Dim profileImg As Image = ConvertByteArrayToImage(ProfilePicture)
        Guna2CirclePictureBox1.Image = profileImg
        btnHaircut.PerformClick()
    End Sub

    Private Sub btnNew_Click_1(sender As Object, e As EventArgs) Handles btnNew.Click
        ' Open the AddServices form when the +New button is clicked
        Dim addServiceForm As New AddServices
        addServiceForm.ShowDialog()
    End Sub

    Private Function ConvertByteArrayToImage(byteArray As Byte()) As Image
        Using ms As New IO.MemoryStream(byteArray)
            Return Image.FromStream(ms)
        End Using
    End Function


    Private Sub btnHaircut_Click(sender As Object, e As EventArgs) Handles btnHaircut.Click
        ' Clear the FlowLayoutPanel
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel1.Padding = New Padding(20, 50, 0, 0)


        ' Retrieve Haircut services from the database
        Dim query As String = "SELECT * FROM Service WHERE ServiceGenre = 'Hair Cut'"
        Using con As New SqlConnection(connectionString),
          cmd As New SqlCommand(query, con)
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                ' Create a new Panel for each service
                Dim servicePanel As New Panel()
                servicePanel.Size = New Size(357, 174)
                servicePanel.BorderStyle = BorderStyle.None
                servicePanel.BackColor = Color.White

                ' Convert the service picture from binary to image
                Dim pbService As New PictureBox()
                pbService.SizeMode = PictureBoxSizeMode.StretchImage
                pbService.Size = New Size(153, 168)
                pbService.Location = New Point(0, 3)

                ' Check if the ServicePicture column has an image
                If Not IsDBNull(reader("ServicePicture")) Then
                    Dim imageBytes As Byte() = CType(reader("ServicePicture"), Byte())
                    pbService.Image = ConvertByteArrayToImage(imageBytes)
                End If

                ' Add Label for Service Name
                Dim lblName As New Label()
                lblName.Text = reader("ServiceName").ToString()
                lblName.Font = New Font("Arial", 12, FontStyle.Bold)
                lblName.Location = New Point(181, 12)

                ' Add Label for Price
                Dim lblPrice As New Label()
                lblPrice.Text = "Rs. " & reader("Price").ToString()
                lblPrice.Location = New Point(182, 77)

                ' Add Button for Add to Cart
                Dim btnAddToCart As New Button()
                btnAddToCart.Text = "Add to cart"
                btnAddToCart.Size = New Size(125, 40)
                btnAddToCart.Location = New Point(186, 119)
                btnAddToCart.BackColor = Color.FromArgb(0, 192, 0)
                AddHandler btnAddToCart.Click, AddressOf AddToCart_Click

                ' Add Button for removing service (X button)
                If role = "Admin" Then
                    Dim btnRemove As New Button()
                    btnRemove.Text = "X"
                    btnRemove.Size = New Size(35, 40)
                    btnRemove.Location = New Point(322, 0) ' Place it in the top right corner
                    btnRemove.BackColor = Color.Red ' Set the background color to red
                    btnRemove.ForeColor = Color.Black ' Set the text color to white
                    btnRemove.Tag = reader("ServiceID") ' Store the ServiceID in the Tag
                    AddHandler btnRemove.Click, AddressOf RemoveService_Click
                    servicePanel.Controls.Add(btnRemove)
                End If

                ' Add controls to servicePanel
                servicePanel.Controls.Add(pbService)
                servicePanel.Controls.Add(lblName)
                servicePanel.Controls.Add(lblPrice)
                servicePanel.Controls.Add(btnAddToCart)

                ' Add servicePanel to FlowLayoutPanel
                FlowLayoutPanel1.Controls.Add(servicePanel)
            End While
            con.Close()
        End Using
    End Sub

    ' Declare a global list to hold cart items
    Private cart As New List(Of CartItem)()

    Private Sub AddToCart_Click(sender As Object, e As EventArgs)
        ' Get the button that was clicked
        Dim btnAddToCart As Button = DirectCast(sender, Button)
        Dim servicePanel As Panel = DirectCast(btnAddToCart.Parent, Panel)

        ' Retrieve service details from the panel controls
        Dim lblName As Label = servicePanel.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Location = New Point(181, 12))
        Dim lblPrice As Label = servicePanel.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Location = New Point(182, 77))
        Dim pbService As PictureBox = servicePanel.Controls.OfType(Of PictureBox).FirstOrDefault()

        ' Retrieve the ServiceID from the panel (using the Tag property of the "X" button)
        Dim btnRemove As Button = servicePanel.Controls.OfType(Of Button).FirstOrDefault(Function(btn) btn.Text = "X")
        Dim serviceID As Integer = CInt(btnRemove.Tag)

        ' Get service details
        Dim serviceName As String = lblName.Text
        Dim price As Decimal = Decimal.Parse(lblPrice.Text.Replace("Rs. ", ""))

        ' Add the service to the cart
        cart.Add(New CartItem With {
        .ServiceID = serviceID,
        .ServiceName = serviceName,
        .Price = price,
        .ServicePicture = pbService.Image
    })

        ' Show "Added to cart!" message
        MessageBox.Show("Added to cart!", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub



    Private Sub btnHaircolor_Click(sender As Object, e As EventArgs) Handles btnHaircolor.Click
        ' Enable the FlowLayoutPanel and clear its contents
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel1.Padding = New Padding(20, 50, 0, 0)

        ' Retrieve Haircolor services from the database
        Dim query As String = "SELECT * FROM Service WHERE ServiceGenre = 'Hair Color'"
        Using con As New SqlConnection(connectionString),
        cmd As New SqlCommand(query, con)
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                ' Create a new Panel for each service
                Dim servicePanel As New Panel()
                servicePanel.Size = New Size(357, 174)
                servicePanel.BorderStyle = BorderStyle.None
                servicePanel.BackColor = Color.White

                ' Convert the service picture from binary to image
                Dim pbService As New PictureBox()
                pbService.SizeMode = PictureBoxSizeMode.StretchImage
                pbService.Size = New Size(153, 168)
                pbService.Location = New Point(0, 3)

                ' Check if the ServicePicture column has an image
                If Not IsDBNull(reader("ServicePicture")) Then
                    Dim imageBytes As Byte() = CType(reader("ServicePicture"), Byte())
                    pbService.Image = ConvertByteArrayToImage(imageBytes)
                End If

                ' Add Label for Service Name
                Dim lblName As New Label()
                lblName.Text = reader("ServiceName").ToString()
                lblName.Font = New Font("Arial", 12, FontStyle.Bold)
                lblName.Location = New Point(181, 12)

                ' Add Label for Price
                Dim lblPrice As New Label()
                lblPrice.Text = "Rs. " & reader("Price").ToString()
                lblPrice.Location = New Point(182, 77)

                ' Add Button for Add to Cart
                Dim btnAddToCart As New Button()
                btnAddToCart.Text = "Add to cart"
                btnAddToCart.Size = New Size(125, 40)
                btnAddToCart.Location = New Point(186, 119)
                btnAddToCart.BackColor = Color.FromArgb(0, 192, 0)
                AddHandler btnAddToCart.Click, AddressOf AddToCart_Click

                ' Add Button for removing service (X button)
                If role = "Admin" Then
                    Dim btnRemove As New Button()
                    btnRemove.Text = "X"
                    btnRemove.Size = New Size(35, 40)
                    btnRemove.Location = New Point(322, 0) ' Place it in the top right corner
                    btnRemove.BackColor = Color.Red ' Set the background color to red
                    btnRemove.ForeColor = Color.Black ' Set the text color to white
                    btnRemove.Tag = reader("ServiceID") ' Store the ServiceID in the Tag
                    AddHandler btnRemove.Click, AddressOf RemoveService_Click
                    servicePanel.Controls.Add(btnRemove)
                End If

                ' Add controls to servicePanel
                servicePanel.Controls.Add(pbService)
                servicePanel.Controls.Add(lblName)
                servicePanel.Controls.Add(lblPrice)
                servicePanel.Controls.Add(btnAddToCart)
                ' Add servicePanel to FlowLayoutPanel
                FlowLayoutPanel1.Controls.Add(servicePanel)
            End While
            con.Close()
        End Using
    End Sub


    Private Sub btnFacial_Click(sender As Object, e As EventArgs) Handles btnFacial.Click
        ' Clear the FlowLayoutPanel
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel1.Padding = New Padding(20, 50, 0, 0)

        ' Retrieve Haircut services from the database
        Dim query As String = "SELECT * FROM Service WHERE ServiceGenre = 'Facial'"
        Using con As New SqlConnection(connectionString),
          cmd As New SqlCommand(query, con)
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                ' Create a new Panel for each service
                Dim servicePanel As New Panel()
                servicePanel.Size = New Size(357, 174)
                servicePanel.BorderStyle = BorderStyle.None
                servicePanel.BackColor = Color.White

                ' Convert the service picture from binary to image
                Dim pbService As New PictureBox()
                pbService.SizeMode = PictureBoxSizeMode.StretchImage
                pbService.Size = New Size(153, 168)
                pbService.Location = New Point(0, 3)

                ' Check if the ServicePicture column has an image
                If Not IsDBNull(reader("ServicePicture")) Then
                    Dim imageBytes As Byte() = CType(reader("ServicePicture"), Byte())
                    pbService.Image = ConvertByteArrayToImage(imageBytes)
                End If

                ' Add Label for Service Name
                Dim lblName As New Label()
                lblName.Text = reader("ServiceName").ToString()
                lblName.Font = New Font("Arial", 12, FontStyle.Bold)
                lblName.Location = New Point(181, 12)

                ' Add Label for Price
                Dim lblPrice As New Label()
                lblPrice.Text = "Rs. " & reader("Price").ToString()
                lblPrice.Location = New Point(182, 77)

                ' Add Button for Add to Cart
                Dim btnAddToCart As New Button()
                btnAddToCart.Text = "Add to cart"
                btnAddToCart.Size = New Size(125, 40)
                btnAddToCart.Location = New Point(186, 119)
                btnAddToCart.BackColor = Color.FromArgb(0, 192, 0)
                AddHandler btnAddToCart.Click, AddressOf AddToCart_Click

                ' Add Button for removing service (X button)
                If role = "Admin" Then
                    Dim btnRemove As New Button()
                    btnRemove.Text = "X"
                    btnRemove.Size = New Size(35, 40)
                    btnRemove.Location = New Point(322, 0) ' Place it in the top right corner
                    btnRemove.BackColor = Color.Red ' Set the background color to red
                    btnRemove.ForeColor = Color.Black ' Set the text color to white
                    btnRemove.Tag = reader("ServiceID") ' Store the ServiceID in the Tag
                    AddHandler btnRemove.Click, AddressOf RemoveService_Click
                    servicePanel.Controls.Add(btnRemove)
                End If

                ' Add controls to servicePanel
                servicePanel.Controls.Add(pbService)
                servicePanel.Controls.Add(lblName)
                servicePanel.Controls.Add(lblPrice)
                servicePanel.Controls.Add(btnAddToCart)

                ' Add servicePanel to FlowLayoutPanel
                FlowLayoutPanel1.Controls.Add(servicePanel)
            End While
            con.Close()
        End Using
    End Sub

    Private Sub btnManicure_Click(sender As Object, e As EventArgs) Handles btnManicure.Click
        ' Clear the FlowLayoutPanel
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel1.Padding = New Padding(20, 50, 0, 0)

        ' Retrieve Haircut services from the database
        Dim query As String = "SELECT * FROM Service WHERE ServiceGenre = 'Manicure'"
        Using con As New SqlConnection(connectionString),
          cmd As New SqlCommand(query, con)
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                ' Create a new Panel for each service
                Dim servicePanel As New Panel()
                servicePanel.Size = New Size(357, 174)
                servicePanel.BorderStyle = BorderStyle.None
                servicePanel.BackColor = Color.White

                ' Convert the service picture from binary to image
                Dim pbService As New PictureBox()
                pbService.SizeMode = PictureBoxSizeMode.StretchImage
                pbService.Size = New Size(153, 168)
                pbService.Location = New Point(0, 3)

                ' Check if the ServicePicture column has an image
                If Not IsDBNull(reader("ServicePicture")) Then
                    Dim imageBytes As Byte() = CType(reader("ServicePicture"), Byte())
                    pbService.Image = ConvertByteArrayToImage(imageBytes)
                End If

                ' Add Label for Service Name
                Dim lblName As New Label()
                lblName.Text = reader("ServiceName").ToString()
                lblName.Font = New Font("Arial", 12, FontStyle.Bold)
                lblName.Location = New Point(181, 12)

                ' Add Label for Price
                Dim lblPrice As New Label()
                lblPrice.Text = "Rs. " & reader("Price").ToString()
                lblPrice.Location = New Point(182, 77)

                ' Add Button for Add to Cart
                Dim btnAddToCart As New Button()
                btnAddToCart.Text = "Add to cart"
                btnAddToCart.Size = New Size(125, 40)
                btnAddToCart.Location = New Point(186, 119)
                btnAddToCart.BackColor = Color.FromArgb(0, 192, 0)
                AddHandler btnAddToCart.Click, AddressOf AddToCart_Click

                ' Add Button for removing service (X button)
                If role = "Admin" Then
                    Dim btnRemove As New Button()
                    btnRemove.Text = "X"
                    btnRemove.Size = New Size(35, 40)
                    btnRemove.Location = New Point(322, 0) ' Place it in the top right corner
                    btnRemove.BackColor = Color.Red ' Set the background color to red
                    btnRemove.ForeColor = Color.Black ' Set the text color to white
                    btnRemove.Tag = reader("ServiceID") ' Store the ServiceID in the Tag
                    AddHandler btnRemove.Click, AddressOf RemoveService_Click
                    servicePanel.Controls.Add(btnRemove)
                End If

                ' Add controls to servicePanel
                servicePanel.Controls.Add(pbService)
                servicePanel.Controls.Add(lblName)
                servicePanel.Controls.Add(lblPrice)
                servicePanel.Controls.Add(btnAddToCart)

                ' Add servicePanel to FlowLayoutPanel
                FlowLayoutPanel1.Controls.Add(servicePanel)
            End While
            con.Close()
        End Using
    End Sub

    Private Sub RemoveService_Click(sender As Object, e As EventArgs)
        ' Get the remove button and corresponding service panel
        Dim btnRemove As Button = DirectCast(sender, Button)
        Dim servicePanel As Panel = DirectCast(btnRemove.Parent, Panel)

        ' Get the ServiceID from the button's Tag property
        Dim serviceID As Integer = CInt(btnRemove.Tag)

        ' Delete the service from the database
        Dim query As String = "DELETE FROM Service WHERE ServiceID = @ServiceID"
        Using con As New SqlConnection(connectionString),
          cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@ServiceID", serviceID)
            Try
                con.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                con.Close()

                ' Check if the service was successfully deleted
                If rowsAffected > 0 Then
                    ' Remove the service panel from the FlowLayoutPanel
                    FlowLayoutPanel1.Controls.Remove(servicePanel)
                End If
            Catch ex As Exception
                MessageBox.Show("Failed to delete service from the database.")
            End Try

        End Using
    End Sub

    Private Sub btnCart_Click(sender As Object, e As EventArgs) Handles btnCart.Click
        ' Create a new form for the cart
        Dim cartForm As New Form()
        cartForm.Text = "Your Cart"
        cartForm.Size = New Size(480, 600) ' Increased by 20%
        cartForm.StartPosition = FormStartPosition.CenterScreen ' Center the form

        ' Create a FlowLayoutPanel to hold the cart items
        Dim flpCart As New FlowLayoutPanel()
        flpCart.Dock = DockStyle.Top
        flpCart.AutoScroll = True
        flpCart.FlowDirection = FlowDirection.TopDown
        flpCart.WrapContents = False
        flpCart.Size = New Size(cartForm.Width - 40, 400) ' Adjusted size
        cartForm.Controls.Add(flpCart)

        ' Add each item in the cart to the FlowLayoutPanel
        Dim totalPrice As Decimal = 0
        For Each item As CartItem In cart
            ' Create a panel for each item
            Dim itemPanel As New Panel()
            itemPanel.Size = New Size(flpCart.Width - 10, 100) ' Adjusted size
            itemPanel.BorderStyle = BorderStyle.FixedSingle

            ' Add a PictureBox for the service picture
            Dim pbCartService As New PictureBox()
            pbCartService.Image = item.ServicePicture
            pbCartService.SizeMode = PictureBoxSizeMode.StretchImage
            pbCartService.Size = New Size(60, 60) ' Adjusted size
            pbCartService.Location = New Point(10, 10)
            itemPanel.Controls.Add(pbCartService)

            ' Add a label for the service name
            Dim lblCartName As New Label()
            lblCartName.Text = item.ServiceName
            lblCartName.Font = New Font("Arial", 12, FontStyle.Bold) ' Adjusted font size
            lblCartName.Location = New Point(80, 10)
            itemPanel.Controls.Add(lblCartName)

            ' Add a label for the service price
            Dim lblCartPrice As New Label()
            lblCartPrice.Text = "Rs. " & item.Price.ToString("F2")
            lblCartPrice.Font = New Font("Arial", 10) ' Adjusted font size
            lblCartPrice.Location = New Point(80, 50)
            itemPanel.Controls.Add(lblCartPrice)

            ' Add "X" button to remove the service from the cart
            Dim btnRemoveFromCart As New Button()
            btnRemoveFromCart.Text = "X"
            btnRemoveFromCart.Size = New Size(30, 30)
            btnRemoveFromCart.Location = New Point(itemPanel.Width - 40, 10) ' Adjust position
            btnRemoveFromCart.BackColor = Color.Red
            btnRemoveFromCart.Tag = item.ServiceID ' Store the ServiceID in the Tag
            AddHandler btnRemoveFromCart.Click, AddressOf RemoveFromCart_Click
            itemPanel.Controls.Add(btnRemoveFromCart)

            ' Add the itemPanel to the FlowLayoutPanel
            flpCart.Controls.Add(itemPanel)

            ' Calculate the total price
            totalPrice += item.Price
        Next

        ' Add a label to show the total price
        Dim lblTotal As New Label()
        lblTotal.Text = "Total: Rs. " & totalPrice.ToString("F2")
        lblTotal.Font = New Font("Arial", 14, FontStyle.Bold) ' Adjusted font size
        lblTotal.Location = New Point(10, flpCart.Bottom + 10)
        lblTotal.AutoSize = True ' Make sure the label resizes based on the content
        cartForm.Controls.Add(lblTotal)

        ' Add a "Checkout" button
        Dim btnCheckout As New Button()
        btnCheckout.Text = "Check out"
        btnCheckout.Size = New Size(120, 40) ' Adjusted size
        btnCheckout.Location = New Point(10, lblTotal.Bottom + 20) ' Adjusted position
        AddHandler btnCheckout.Click, AddressOf Checkout_Click
        cartForm.Controls.Add(btnCheckout)

        ' Show the cart form
        cartForm.ShowDialog()
    End Sub

    ' Function for the Checkout button
    Private Sub Checkout_Click(sender As Object, e As EventArgs)
        Dim paymentDetailsForm As New PaymentDetail(cart, role)
        paymentDetailsForm.ShowDialog() 
    End Sub



    ' Function to remove the service from the cart
    Private Sub RemoveFromCart_Click(sender As Object, e As EventArgs)
        Dim btnRemove As Button = DirectCast(sender, Button)
        Dim serviceID As Integer = CInt(btnRemove.Tag)

        ' Remove the item from the cart
        Dim itemToRemove As CartItem = cart.FirstOrDefault(Function(c) c.ServiceID = serviceID)
        If itemToRemove IsNot Nothing Then
            cart.Remove(itemToRemove)
        End If

        ' Remove the item panel from the FlowLayoutPanel
        Dim itemPanel As Panel = DirectCast(btnRemove.Parent, Panel)
        Dim flpCart As FlowLayoutPanel = DirectCast(itemPanel.Parent, FlowLayoutPanel)
        flpCart.Controls.Remove(itemPanel)

        ' Update total price after removal
        Dim totalPrice As Decimal = cart.Sum(Function(c) c.Price)
        Dim lblTotal As Label = DirectCast(flpCart.Parent.Controls.OfType(Of Label)().FirstOrDefault(Function(lbl) lbl.Text.StartsWith("Total:")), Label)
        lblTotal.Text = "Total: Rs. " & totalPrice.ToString("F2")
    End Sub

End Class