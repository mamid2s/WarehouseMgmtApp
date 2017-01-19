Imports MySql.Data.MySqlClient

Public Class Transactions

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnGet.Click
        Try
            If cmbMonth.SelectedIndex >= 0 And cmbYear.SelectedIndex >= 0 Then
                BindGrid(CInt(cmbMonth.SelectedItem), CInt(cmbYear.SelectedItem))
            Else
                MessageBox.Show("Please Select Month & Year", "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BindGrid(month As Integer, year As Integer)
        Try
            DataGridView1.Columns.Clear()
            Dim cmdString As String = "SELECT T.TransactionId As 'Transaction Id'," &
                                              "T.TicketId As 'Ticket Id'," &
                                              "E.EmpName As 'Employee Name'," &
                                              "S.ProductName As 'Product Name'," &
                                              "S.Units As 'Available Units'," &
                                              "T.SoldUnits As 'Sold Units'," &
                                              "T.SoldPrice As 'Sold Price'," &
                                              "T.TransactionDate As 'Transaction Date'," &
                                              "T.TransactionUpdatedDate As 'Updated Date'," &
                                              "T.ReasonForEdit As 'Reason'," &
                                              "T.StockId " &
                                    "FROM transactionhistory T,employee E,stockdetails S " &
                                    "WHERE T.EmpId = E.EmpId AND T.StockId = S.StockId AND " &
                                    "MONTH(T.TransactionDate) =" & month & " AND YEAR(T.TransactionDate) = " & year
            If StaticData.LoginMode = 1 Then 'emp
                cmdString = cmdString + " AND T.EmpId =" & StaticData.UserId
            End If

            Using con As New MySqlConnection(StaticData.ConnectionString)
                Using cmd As New MySqlCommand(cmdString, con)
                    cmd.CommandType = CommandType.Text
                    con.Open()
                    Using sda As New MySqlDataAdapter(cmd)
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            DataGridView1.DataSource = dt
                            'Disable the stockid column
                            DataGridView1.Columns(DataGridView1.Columns.Count - 1).Visible = False
                            'If StaticData.LoginMode = 1 Then
                            '    CreateUnboundButtonColumn()
                            'End If

                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CreateUnboundButtonColumn()
        Try
            ' Initialize the button column.
            Dim buttonColumn As New DataGridViewButtonColumn

            With buttonColumn
                .HeaderText = "Mode"
                .Name = "Mode"
                .Text = "Edit"

                ' Use the Text property for the button text for all cells rather
                ' than using each cell's value as the text for its own button.
                .UseColumnTextForButtonValue = True
            End With

            ' Add the button column to the control.
            DataGridView1.Columns.Insert(DataGridView1.Columns.Count, buttonColumn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
       
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                If StaticData.LoginMode = 1 Then
                    Dim rowdata As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                    Dim date1 As DateTime = rowdata.Cells("Transaction Date").Value
                    Dim date2 As DateTime = DateTime.Now  'rowdata.Cells("Updated Date").Value
                    Dim date3 As DateTime = rowdata.Cells("Updated Date").Value
                    If (date2 - date1).TotalMinutes <= 1440 Then
                        If (date3 - date1).TotalMinutes > 0 Then
                            MessageBox.Show("Already Transaction is updated.", "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            InTakeOrder.TransactionMode = 1
                            InTakeOrder.txtProductName.Text = rowdata.Cells("Product Name").Value
                            InTakeOrder.txtAvailableUnits.Text = rowdata.Cells("Available Units").Value
                            InTakeOrder.txtUnitPrice.Text = rowdata.Cells("Sold Price").Value
                            InTakeOrder.txtTicketId.Text = rowdata.Cells("Ticket Id").Value
                            InTakeOrder.txtSoldUnits.Text = rowdata.Cells("Sold Units").Value
                            InTakeOrder.txtReason.Text = If(IsDBNull(rowdata.Cells("Reason").Value), "", rowdata.Cells("Reason").Value)
                            Integer.TryParse(rowdata.Cells("Transaction Id").Value, InTakeOrder.TransactionId)
                            Integer.TryParse(rowdata.Cells("StockId").Value, InTakeOrder.PrvStockId)
                            Integer.TryParse(InTakeOrder.txtSoldUnits.Text.Trim(), InTakeOrder.PrvSoldUnits)
                            InTakeOrder.ShowDialog()
                            BindGrid(CInt(cmbMonth.SelectedItem), CInt(cmbYear.SelectedItem))
                        End If
                    Else
                        MessageBox.Show("You can not edit the transaction.Transaction time out.", "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ExportToExcel()

        Dim excel As Microsoft.Office.Interop.Excel._Application = New Microsoft.Office.Interop.Excel.Application()
        Dim workbook As Microsoft.Office.Interop.Excel._Workbook = excel.Workbooks.Add(Type.Missing)
        Dim worksheet As Microsoft.Office.Interop.Excel._Worksheet = Nothing

        worksheet = DirectCast(workbook.Sheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet)
        worksheet = DirectCast(workbook.ActiveSheet, Microsoft.Office.Interop.Excel.Worksheet)
        Try


            For i As Integer = 1 To DataGridView1.Columns.Count
                worksheet.Cells(1, i) = DataGridView1.Columns(i - 1).HeaderText
                worksheet.Cells.Font.Bold = True
            Next
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                For j As Integer = 0 To DataGridView1.Columns.Count - 1
                    worksheet.Cells(i + 2, j + 1) = DataGridView1.Rows(i).Cells(j).Value.ToString()
                Next
            Next



            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            saveDialog.FilterIndex = 2

            If saveDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                workbook.SaveAs(saveDialog.FileName)
                MessageBox.Show("Export Successful")
            End If
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        Finally
            excel.Quit()
            workbook = Nothing
            excel = Nothing
        End Try
    End Sub

    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        ExportToExcel()
    End Sub
End Class