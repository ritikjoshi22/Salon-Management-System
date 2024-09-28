Imports System.Data.SqlClient

Public Class Inventory
    Dim connectionString As String = "Data Source=RITIKJOSHI22\SQLEXPRESS;Initial Catalog=saloonManagementSystem;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"

    ' Load inventory data when form loads
    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInventory()
    End Sub

    ' Function to load inventory into DataGridView
    Private Sub LoadInventory()
        Dim query As String = "SELECT product_id, product_name, quantity, price, supplier, category, expiration_date FROM product"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim adapter As New SqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgInventory.DataSource = dt

                ' Add Edit button column only if it hasn't been added yet
                If dgInventory.Columns("Edit") Is Nothing Then
                    Dim btnEdit As New DataGridViewButtonColumn()
                    btnEdit.HeaderText = "Edit"
                    btnEdit.Name = "Edit"
                    btnEdit.Text = "Edit"
                    btnEdit.UseColumnTextForButtonValue = True
                    dgInventory.Columns.Add(btnEdit)
                    dgInventory.AllowUserToAddRows = False
                End If

                ' Add Delete button column only if it hasn't been added yet
                If dgInventory.Columns("Delete") Is Nothing Then
                    Dim deleteBtn As New DataGridViewButtonColumn()
                    deleteBtn.HeaderText = "Delete"
                    deleteBtn.Name = "Delete"
                    deleteBtn.Text = "Delete"
                    deleteBtn.UseColumnTextForButtonValue = True
                    dgInventory.Columns.Add(deleteBtn)
                End If
            Catch ex As Exception
                MessageBox.Show("Error loading customers: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate inputs
        If String.IsNullOrEmpty(txtProductName.Text) OrElse String.IsNullOrEmpty(txtQuantity.Text) OrElse String.IsNullOrEmpty(txtPrice.Text) OrElse
       String.IsNullOrEmpty(txtSupplier.Text) OrElse String.IsNullOrEmpty(txtCategory.Text) Then
            MessageBox.Show("Please fill all fields before saving.")
            Return
        End If

        ' Additional validation for numeric fields
        Dim quantity As Integer
        Dim price As Decimal
        If Not Integer.TryParse(txtQuantity.Text, quantity) Then
            MessageBox.Show("Please enter a valid quantity.")
            Return
        End If
        If Not Decimal.TryParse(txtPrice.Text, price) Then
            MessageBox.Show("Please enter a valid price.")
            Return
        End If

        ' Extract other input values
        Dim productName As String = txtProductName.Text
        Dim supplier As String = txtSupplier.Text
        Dim category As String = txtCategory.Text
        Dim expirationDate As Date = dtpExpiryDate.Value

        ' This block handles INSERT (new product)
        If txtProductID.Text = "" Then
            ' Insert new product query
            Dim query As String = "INSERT INTO product (product_name, quantity, price, supplier, category, expiration_date) VALUES (@Name, @Quantity, @Price, @Supplier, @Category, @ExpiryDate)"

            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()

                    ' Execute the query
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", productName)
                    cmd.Parameters.AddWithValue("@Quantity", quantity)
                    cmd.Parameters.AddWithValue("@Price", price)
                    cmd.Parameters.AddWithValue("@Supplier", supplier)
                    cmd.Parameters.AddWithValue("@Category", category)
                    cmd.Parameters.AddWithValue("@ExpiryDate", expirationDate)

                    Dim result As Integer = cmd.ExecuteNonQuery()

                    ' Check if the insertion was successful
                    If result > 0 Then
                        MessageBox.Show("Product added successfully!")
                    Else
                        MessageBox.Show("Product was not added. Please try again.")
                    End If

                    ' Reload data and clear fields
                    LoadInventory()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("Error adding product: " & ex.Message)
                End Try
            End Using
        Else
            Dim productID As Integer = CInt(txtProductID.Text)
            Dim query As String = "UPDATE product SET product_name=@Name, quantity=@Quantity, price=@Price, supplier=@Supplier, category=@Category, expiration_date=@ExpiryDate WHERE product_id=@ProductID"
            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", productName)
                    cmd.Parameters.AddWithValue("@Quantity", quantity)
                    cmd.Parameters.AddWithValue("@Price", price)
                    cmd.Parameters.AddWithValue("@Supplier", supplier)
                    cmd.Parameters.AddWithValue("@Category", category)
                    cmd.Parameters.AddWithValue("@ExpiryDate", expirationDate)
                    cmd.Parameters.AddWithValue("@ProductID", productID)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Product updated successfully!")
                    LoadInventory()
                    ClearFields()
                Catch ex As Exception
                    MessageBox.Show("Error updating product: " & ex.Message)
                End Try
            End Using
        End If
    End Sub

    Private Sub ClearFields()
        txtProductID.Text = ""
        txtProductName.Text = ""
        txtQuantity.Text = ""
        txtPrice.Text = ""
        txtSupplier.Text = ""
        txtCategory.Text = ""
        dtpExpiryDate.Value = DateTime.Now
    End Sub

    Private Sub dgInventory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgInventory.CellContentClick
        ' Check if the click is on a valid cell and not the header row
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgInventory.Rows(e.RowIndex)
            Dim productID As Integer = CInt(selectedRow.Cells("product_id").Value)

            ' Handle the Edit button click
            If dgInventory.Columns(e.ColumnIndex).Name = "Edit" Then
                txtProductID.Text = selectedRow.Cells("product_id").Value.ToString()
                txtProductName.Text = selectedRow.Cells("product_name").Value.ToString()
                txtQuantity.Text = selectedRow.Cells("quantity").Value.ToString()
                txtPrice.Text = selectedRow.Cells("price").Value.ToString()
                txtSupplier.Text = selectedRow.Cells("supplier").Value.ToString()
                txtCategory.Text = selectedRow.Cells("category").Value.ToString()
                dtpExpiryDate.Value = Convert.ToDateTime(selectedRow.Cells("expiration_date").Value)
            End If

            ' Handle the Delete button click
            If dgInventory.Columns(e.ColumnIndex).Name = "Delete" Then
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    deleteInventory(productID)
                    LoadInventory()
                End If
            End If
        End If
    End Sub

    Private Sub deleteInventory(productID As Integer)
        If dgInventory.SelectedRows.Count > 0 Then
            Dim query As String = "DELETE FROM product WHERE product_id=@ProductID"
            Using conn As New SqlConnection(connectionString)
                Try
                    conn.Open()
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ProductID", productID)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Product deleted successfully!")
                    LoadInventory()
                Catch ex As Exception
                    MessageBox.Show("Error deleting product: " & ex.Message)
                End Try
            End Using
        Else
            MessageBox.Show("Please select a product to delete.")
        End If
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchText As String = txtSearch.Text

        Dim query As String = "SELECT product_id, product_name, quantity, price, supplier, category, expiration_date FROM product WHERE product_name LIKE @Search OR supplier LIKE @Search"

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim adapter As New SqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" & searchText & "%")
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgInventory.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error searching product: " & ex.Message)
            End Try
        End Using
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim printDialog As New PrintDialog()
        Dim printDoc As New Printing.PrintDocument()

        AddHandler printDoc.PrintPage, AddressOf Me.PrintDocument_PrintPage

        printDialog.Document = printDoc

        If printDialog.ShowDialog() = DialogResult.OK Then
            printDoc.Print()
        End If
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        ' Print DataGridView content
        Dim bm As New Bitmap(Me.dgInventory.Width, Me.dgInventory.Height)
        dgInventory.DrawToBitmap(bm, New Rectangle(0, 0, Me.dgInventory.Width, Me.dgInventory.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub


    Private Sub dgCustomers_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgInventory.CellPainting
        If e.ColumnIndex = dgInventory.Columns("Delete").Index AndAlso e.RowIndex >= 0 Then
            e.Handled = True
            e.Graphics.FillRectangle(New SolidBrush(Color.White), e.CellBounds)

            Dim buttonWidth As Integer = 80
            Dim buttonHeight As Integer = 20
            Dim buttonX As Integer = e.CellBounds.Left + (e.CellBounds.Width - buttonWidth) / 2
            Dim buttonY As Integer = e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2

            Dim buttonBounds As Rectangle = New Rectangle(buttonX, buttonY, buttonWidth, buttonHeight)

            Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
            Dim radius As Integer = 20
            path.AddArc(buttonBounds.Left, buttonBounds.Top, radius, radius, 180, 90)
            path.AddArc(buttonBounds.Right - radius, buttonBounds.Top, radius, radius, 270, 90)
            path.AddArc(buttonBounds.Right - radius, buttonBounds.Bottom - radius, radius, radius, 0, 90)
            path.AddArc(buttonBounds.Left, buttonBounds.Bottom - radius, radius, radius, 90, 90)
            path.CloseAllFigures()

            e.Graphics.FillPath(New SolidBrush(ColorTranslator.FromHtml("#FF6969")), path) ' Red color for Delete button

            TextRenderer.DrawText(e.Graphics, "Delete", dgInventory.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If

        If e.ColumnIndex = dgInventory.Columns("Edit").Index AndAlso e.RowIndex >= 0 Then
            e.Handled = True
            e.Graphics.FillRectangle(New SolidBrush(Color.White), e.CellBounds)

            Dim buttonWidth As Integer = 80
            Dim buttonHeight As Integer = 20
            Dim buttonX As Integer = e.CellBounds.Left + (e.CellBounds.Width - buttonWidth) / 2
            Dim buttonY As Integer = e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2

            Dim buttonBounds As Rectangle = New Rectangle(buttonX, buttonY, buttonWidth, buttonHeight)

            Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
            Dim radius As Integer = 20
            path.AddArc(buttonBounds.Left, buttonBounds.Top, radius, radius, 180, 90)
            path.AddArc(buttonBounds.Right - radius, buttonBounds.Top, radius, radius, 270, 90)
            path.AddArc(buttonBounds.Right - radius, buttonBounds.Bottom - radius, radius, radius, 0, 90)
            path.AddArc(buttonBounds.Left, buttonBounds.Bottom - radius, radius, radius, 90, 90)
            path.CloseAllFigures()

            e.Graphics.FillPath(New SolidBrush(ColorTranslator.FromHtml("#1E90FF")), path) ' Blue color for Edit button

            TextRenderer.DrawText(e.Graphics, "Edit", dgInventory.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If
    End Sub

End Class