Imports MySql.Data.MySqlClient

Public Class EmployeeList

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub EmployeeList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGrid()
    End Sub
    Private Sub BindGrid()
        Try
            DataGridView1.Columns.Clear()
            Dim cmdString As String = "SELECT EmpId As 'Id',EmpName as 'Employee Last Name',EmpName as 'Employee Last Name',UserName as 'User Name',EmailAddress as 'e-Mail',PhoneNumber as 'Phone Number',DateOfJoining as 'Date Of Joining',City,State,Street,ZIPCode,ManagerId as 'Created By',RecordDate as 'Created On',(case when Active=0 then 'InActive' else 'Active' end) as Status FROM Employee"
            Using con As New MySqlConnection(StaticData.ConnectionString)
                Using cmd As New MySqlCommand(cmdString, con)
                    cmd.CommandType = CommandType.Text
                    con.Open()
                    Using sda As New MySqlDataAdapter(cmd)
                        Using dt As New DataTable()
                            sda.Fill(dt)
                            DataGridView1.DataSource = dt
                            'CreateUnboundButtonColumn()
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
            'DataGridView1.Columns(0).Width = 58
            'DataGridView1.Columns(1).Width = 200
            'DataGridView1.Columns(2).Width = 200
            'DataGridView1.Columns(3).Width = 70
            'DataGridView1.Columns(4).Width = 70
            'DataGridView1.Columns(5).Width = 60
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
                Registration.EditMode = 1
                Registration.ProfileEditMode = 1
                If rowdata.Cells("Status").Value = "InActive" Then
                    Registration.btnSave.Visible = False
                    Registration.btnDeactive.Visible = False
                Else
                    Registration.btnSave.Visible = True
                    Registration.btnDeactive.Visible = True
                End If
                'StockMaster.txtCategoryName.Text = rowdata.Cells("Category Name").Value
                'StockMaster.txtProduct.Text = rowdata.Cells("Product Name").Value
                'StockMaster.txtUnits.Text = rowdata.Cells("Units").Value
                'StockMaster.txtPrice.Text = rowdata.Cells("Unit Price").Value
                Integer.TryParse(rowdata.Cells("Id").Value, Registration.EditUserId)
                Registration.ShowDialog()
                BindGrid()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Transactions", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class