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
            Catch ex As Exception
                MessageBox.Show("Error loading inventory: " & ex.Message)
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
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgInventory.SelectedRows.Count > 0 Then
            Dim productID As Integer = CInt(dgInventory.SelectedRows(0).Cells("product_id").Value)

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

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgInventory.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgInventory.SelectedRows(0)
            txtProductID.Text = selectedRow.Cells("product_id").Value.ToString()
            txtProductName.Text = selectedRow.Cells("product_name").Value.ToString()
            txtQuantity.Text = selectedRow.Cells("quantity").Value.ToString()
            txtPrice.Text = selectedRow.Cells("price").Value.ToString()
            txtSupplier.Text = selectedRow.Cells("supplier").Value.ToString()
            txtCategory.Text = selectedRow.Cells("category").Value.ToString()
            dtpExpiryDate.Value = Convert.ToDateTime(selectedRow.Cells("expiration_date").Value)
        Else
            MessageBox.Show("Please select a product to edit.")
        End If
    End Sub


End Class
