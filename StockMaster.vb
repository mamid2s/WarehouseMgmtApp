Imports MySql.Data.MySqlClient

Public Class StockMaster
    Public EditMode As Integer = 0
    Public StockId As Integer = 0
    Private Sub StockMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If EditMode = 1 Then
                txtCategoryName.Visible = True
                cmbCategory.Visible = False
            Else
                txtCategoryName.Visible = False
                cmbCategory.Visible = True
                Using con As New MySqlConnection(StaticData.ConnectionString)
                    Using cmd As New MySqlCommand("SELECT CategoryId,CategoryName FROM CategoryMaster")
                        cmd.Connection = con
                        con.Open()
                        Dim Dt As New DataTable
                        Dim adapter As New MySqlDataAdapter()
                        adapter.SelectCommand = cmd
                        adapter.Fill(Dt)
                        cmbCategory.DataSource = Dt
                        cmbCategory.DisplayMember = Dt.Columns(1).ColumnName
                        cmbCategory.ValueMember = Dt.Columns(0).ColumnName

                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Stock Master", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim val As Integer = cmbCategory.SelectedValue
            If String.IsNullOrEmpty(txtProduct.Text.Trim()) Then
                MessageBox.Show("Please enter Product Name", "Product Master", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf String.IsNullOrEmpty(txtUnits.Text.Trim()) Then
                MessageBox.Show("Please enter Units", "Product Master", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf String.IsNullOrEmpty(txtPrice.Text.Trim()) Then
                MessageBox.Show("Please enter Price", "Product Master", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

                If EditMode <> 1 Then
                    Using con As New MySqlConnection(StaticData.ConnectionString)
                        Dim chkWhareHouse As String = "SELECT count(*) FROM warehousedb.stockdetails where WarehouseId='" + txtWarehouseId.Text.Trim() + "'"
                        Using cmd As New MySqlCommand(chkWhareHouse)
                            cmd.Connection = con
                            con.Open()

                            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                            If (count > 0) Then
                                MessageBox.Show("Wharehouse ID already exists...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If

                        End Using
                    End Using
                End If
                Using con As New MySqlConnection(StaticData.ConnectionString)
                    Dim query As String
                    If EditMode = 1 Then


                        Dim newunits As Integer = 0
                        Integer.TryParse(txtNewUnits.Text.Trim(), newunits)

                        query = "UPDATE StockDetails SET ProductName='" & txtProduct.Text.Trim() & "',Units=" & CInt(txtUnits.Text.Trim()) + newunits &
                            ",UnitPrice=" & CInt(txtPrice.Text.Trim()) & ",ManagerId=" & StaticData.ManagerId & ",WarehouseId=" & CInt(txtWarehouseId.Text.Trim()) & ",RecordDate=NOW() WHERE StockId = " & StockId
                    Else
                        query = "INSERT INTO StockDetails(CategoryId,ProductName,Units,UnitPrice,ManagerId,WarehouseId,RecordDate) VALUES(" &
                                                  cmbCategory.SelectedValue & ",'" & txtProduct.Text.Trim() & "'," & CInt(txtUnits.Text.Trim()) & "," & CInt(txtPrice.Text.Trim()) &
                                                  "," & StaticData.ManagerId & "," & CInt(txtWarehouseId.Text.Trim()) & ",NOW());"
                    End If

                    Using cmd1 As New MySqlCommand(query)
                        cmd1.Connection = con
                        con.Open()
                        cmd1.ExecuteNonQuery()
                        MessageBox.Show("Data Saved Successfully", "Product Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Dispose()
                        Me.Close()
                    End Using
                End Using

               
            End If

                        

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Stock Master", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtUnits_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnits.KeyPress, txtNewUnits.KeyPress, txtWarehouseId.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Asc(e.KeyChar) = 46 Then e.KeyChar = ""
    End Sub

    Private Sub chkGenerate_CheckedChanged(sender As Object, e As EventArgs) Handles chkGenerate.CheckedChanged
        Try
            If chkGenerate.Checked = False Then
                txtWarehouseId.Text = ""
            Else
                Using con As New MySqlConnection(StaticData.ConnectionString)
                    Dim query As String = "SELECT (max(StockId)+1) FROM warehousedb.stockdetails"
                    Using cmd As New MySqlCommand(query)
                        cmd.Connection = con
                        con.Open()
                        txtWarehouseId.Text = cmd.ExecuteScalar()

                    End Using
                End Using
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class