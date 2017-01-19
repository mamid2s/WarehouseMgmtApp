Imports MySql.Data.MySqlClient

Public Class CategoryMaster
    Public EditMode As Integer = 0
    Public CategoryId As Integer = 0
    Private Sub CategoryMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtCategoryName.Text.Trim()) Then
                MessageBox.Show("Please enter Category Name", "Category Master", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Using con As New MySqlConnection(StaticData.ConnectionString)
                    Dim query As String
                    If EditMode = 1 Then
                        query = "UPDATE CategoryMaster SET CategoryName='" & txtCategoryName.Text.Trim & "' WHERE CategoryId = " & CategoryId
                    Else
                        query = "INSERT INTO CategoryMaster(CategoryName,RecordDate) VALUES('" & txtCategoryName.Text.Trim & "',NOW())"
                    End If
                    Using cmd As New MySqlCommand(query)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Data Saved Successfully", "Category Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Dispose()
                        Me.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Category Master", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class