Imports MySql.Data.MySqlClient

Public Class CategoryList

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub CategoryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGrid()
    End Sub
    Private Sub BindGrid()
        Try
            DataGridView1.Columns.Clear()
            Dim cmdString As String = "SELECT CategoryId As 'Category Id',CategoryName As 'Category Name' FROM CategoryMaster"
            Using con As New MySqlConnection(StaticData.ConnectionString)
                Using cmd As New MySqlCommand(cmdString, con)
                    cmd.CommandType = CommandType.Text
                    con.Open()
                    Using sda As New MySqlDataAdapter(cmd)
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            DataGridView1.DataSource = dt
                            'CreateUnboundButtonColumn()
                            DataGridView1.Columns(0).Width = 100
                            DataGridView1.Columns(1).Width = 450
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
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 350
            DataGridView1.Columns(2).Width = 100
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Category List", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then

                Dim rowdata As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                CategoryMaster.EditMode = 1
                CategoryMaster.txtCategoryName.Text = rowdata.Cells("Category Name").Value
                Integer.TryParse(rowdata.Cells("Category Id").Value, CategoryMaster.CategoryId)
                CategoryMaster.ShowDialog()
                BindGrid()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class