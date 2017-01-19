Imports MySql.Data.MySqlClient

Public Class StockList

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub StockList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGrid()
    End Sub
    Private Sub BindGrid()
        Try
            
            Dim cmdString As String = "SELECT S.StockId As 'Stock Id',C.CategoryName As 'Category Name',S.ProductName as 'Product Name',S.Units,S.UnitPrice  as 'Unit Price in dollars',E.EmpName as 'Manager Name',S.RecordDate as 'Record Date',S.WarehouseId as 'Warehouse Id' FROM StockDetails S,CategoryMaster C,Employee E WHERE S.CategoryId = C.CategoryId AND S.ManagerId = E.EmpId"

            If txtSearch.Text.Trim() <> "" Then
                cmdString += " and S.ProductName like '%" + txtSearch.Text.Trim() + "%'"
            End If
            Using con As New MySqlConnection(StaticData.ConnectionString)
                Using cmd As New MySqlCommand(cmdString, con)
                    cmd.CommandType = CommandType.Text
                    con.Open()
                    Using sda As New MySqlDataAdapter(cmd)
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            DataGridView1.DataSource = dt
                            'CreateUnboundButtonColumn()
                            DataGridView1.Columns(0).Width = 58
                            DataGridView1.Columns(1).Width = 200
                            DataGridView1.Columns(2).Width = 200
                            DataGridView1.Columns(3).Width = 100
                            DataGridView1.Columns(4).Width = 100
                            DataGridView1.Columns(5).Width = 100
                            DataGridView1.Columns(6).Width = 125
                            Dim results As List(Of DataGridViewRow) = DataGridView1.Rows.Cast(Of DataGridViewRow)().Where(Function(x) x.Cells("Units").Value < 25).ToList()

                            DataGridView1.CurrentCell = Nothing
                            For Each dr As DataGridViewRow In results
                                dr.DefaultCellStyle.BackColor = Color.Yellow
                            Next
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Category List", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            DataGridView1.Columns(0).Width = 58
            DataGridView1.Columns(1).Width = 200
            DataGridView1.Columns(2).Width = 200
            DataGridView1.Columns(3).Width = 70
            DataGridView1.Columns(4).Width = 70
            DataGridView1.Columns(5).Width = 60
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Category List", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                'If e.ColumnIndex + 1 = DataGridView1.Columns.Count Then
                Dim rowdata As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                StockMaster.EditMode = 1
                StockMaster.llbAvailabelUnits.Text = "Available Unit(s):"
                StockMaster.txtUnits.ReadOnly = True
                StockMaster.lblNewUnits.Visible = True
                StockMaster.txtNewUnits.Visible = True
                StockMaster.txtNewUnits.Text = 0
                StockMaster.txtCategoryName.Text = rowdata.Cells("Category Name").Value
                StockMaster.txtProduct.Text = rowdata.Cells("Product Name").Value
                StockMaster.txtUnits.Text = rowdata.Cells("Units").Value
                StockMaster.txtPrice.Text = rowdata.Cells("Unit Price in dollars").Value
                StockMaster.txtWarehouseId.Text = If(IsDBNull(rowdata.Cells("Warehouse Id").Value), 0, rowdata.Cells("Warehouse Id").Value)


                StockMaster.txtWarehouseId.Enabled = False
                StockMaster.chkGenerate.Enabled = False
                Integer.TryParse(rowdata.Cells("Stock Id").Value, StockMaster.StockId)
                StockMaster.ShowDialog()
                BindGrid()
                'End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            BindGrid()
        Catch ex As Exception

        End Try
    End Sub
End Class