Imports MySql.Data.MySqlClient

Public Class InTakeOrder
    Public TransactionMode As Integer = 0
    Public TransactionId As Integer = 0
    Public PrvStockId As Integer = 0
    Public PrvSoldUnits As Integer = 0

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim stockid As Integer = cmbProduct.SelectedValue
            If cmbCategory.SelectedIndex < 0 And TransactionMode = 0 Then
                MessageBox.Show("Please select Category", "Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf cmbProduct.SelectedIndex < 0 And TransactionMode = 0 Then
                MessageBox.Show("Please select Product", "Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf String.IsNullOrEmpty(txtTicketId.Text.Trim()) Then
                MessageBox.Show("Please enter Ticket Id", "Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf String.IsNullOrEmpty(txtSoldUnits.Text.Trim()) Then
                MessageBox.Show("Please enter sold units", "Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf String.IsNullOrEmpty(txtReason.Text.Trim()) And TransactionMode = 1 Then
                MessageBox.Show("Please enter Reason", "Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf CInt(txtAvailableUnits.Text.Trim()) + PrvSoldUnits < CInt(txtSoldUnits.Text.Trim()) Then
                MessageBox.Show("Stock is not available.", "Order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Using con As New MySqlConnection(StaticData.ConnectionString)
                    Dim query1 As String = "UPDATE StockDetails SET Units=" & (CInt(txtAvailableUnits.Text.Trim()) - CInt(txtSoldUnits.Text.Trim())) & " WHERE StockId=" & stockid
                    'Edit Mode Query
                    Dim query2 As String = "UPDATE StockDetails SET Units=" & (CInt(txtAvailableUnits.Text.Trim()) + PrvSoldUnits - CInt(txtSoldUnits.Text.Trim())) & " WHERE StockId=" & PrvStockId
                    Dim finalstockquery As String
                    Dim finaltransactionquery As String

                    Dim query3 As String = "INSERT INTO TransactionHistory(TicketId,EmpId,StockId,SoldUnits,SoldPrice,TransactionDate,TransactionUpdatedDate,RecordDate) VALUES('" &
                                                 txtTicketId.Text.Trim() & "'," & StaticData.UserId & "," & stockid & "," & CInt(txtSoldUnits.Text.Trim()) & "," & CInt(txtUnitPrice.Text.Trim()) & ",NOW(),NOW(),NOW());"

                    Dim query4 As String = "UPDATE TransactionHistory SET SoldUnits=" & CInt(txtSoldUnits.Text.Trim()) & ",TransactionUpdatedDate=NOW(),ReasonForEdit ='" & txtReason.Text.Trim() & "' WHERE TransactionId=" & TransactionId & ";"

                    If TransactionMode = 1 Then
                        finalstockquery = query2
                        finaltransactionquery = query4
                    Else
                        finalstockquery = query1
                        finaltransactionquery = query3
                    End If



                    Using cmd As New MySqlCommand(finalstockquery)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        Using cmd1 As New MySqlCommand(finaltransactionquery)
                            cmd1.Connection = con
                            cmd1.ExecuteNonQuery()
                        End Using
                        MessageBox.Show("Data Saved Successfully", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Dispose()
                        Me.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Orders", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InTakeOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If TransactionMode = 1 Then
                lblCategory.Visible = False
                cmbCategory.Visible = False
                cmbProduct.Visible = False
                txtTicketId.ReadOnly = True
                txtProductName.Visible = True
                lblReason.Visible = True
                txtReason.Visible = True
            Else
                lblCategory.Visible = True
                cmbCategory.Visible = True
                cmbProduct.Visible = True
                txtTicketId.ReadOnly = False
                txtProductName.Visible = False
                lblReason.Visible = False
                txtReason.Visible = False

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
            MessageBox.Show(ex.Message, "Orders", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        Try
            Dim CategoryId As Integer = 0
            Dim item As DataRowView = TryCast(Me.cmbCategory.SelectedItem, DataRowView)
            If (Not item Is Nothing) Then
                With item.Row
                    'You have now access to the row of your table.
                    Integer.TryParse(.Item(0).ToString(), CategoryId)
                    'Dim columnValue2 As String = .Item(1).ToString()
                End With
            End If
            Using con As New MySqlConnection(StaticData.ConnectionString)
                Using cmd As New MySqlCommand("SELECT StockId,ProductName FROM StockDetails WHERE CategoryId =" & CategoryId)
                    cmd.Connection = con
                    con.Open()
                    Dim Dt As New DataTable
                    Dim adapter As New MySqlDataAdapter()
                    adapter.SelectCommand = cmd
                    adapter.Fill(Dt)
                    cmbProduct.DataSource = Dt
                    cmbProduct.DisplayMember = Dt.Columns(1).ColumnName
                    cmbProduct.ValueMember = Dt.Columns(0).ColumnName
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Orders", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProduct.SelectedIndexChanged
        Try
            Dim StockId As Integer = 0
            Dim item As DataRowView = TryCast(Me.cmbProduct.SelectedItem, DataRowView)
            If (Not item Is Nothing) Then
                With item.Row
                    'You have now access to the row of your table.
                    Integer.TryParse(.Item(0).ToString(), StockId)
                    'Dim columnValue2 As String = .Item(1).ToString()
                End With
            End If
            Using con As New MySqlConnection(StaticData.ConnectionString)
                Using cmd As New MySqlCommand("SELECT Units,UnitPrice FROM StockDetails WHERE StockId=" & StockId)
                    cmd.Connection = con
                    con.Open()
                    Dim rd As MySqlDataReader
                    rd = cmd.ExecuteReader
                    If rd.Read Then
                        txtAvailableUnits.Text = rd.GetString(0)
                        txtUnitPrice.Text = rd.GetString(1)
                    End If
                    rd.Close()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Orders", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSoldUnits_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSoldUnits.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub
End Class