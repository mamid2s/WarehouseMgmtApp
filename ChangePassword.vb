Imports MySql.Data.MySqlClient

Public Class ChangePassword

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtPassword.Text.Trim()) Then
                MessageBox.Show("Please enter Password", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Using con As New MySqlConnection(StaticData.ConnectionString)
                    'try
                    'if txtPassword1.Text.Trim() = txtPassword2.Text.Trim()
                    'else
                    'catch exception
                    'msgbox ----password not matched 

                    Using cmd As New MySqlCommand("UPDATE Employee SET Password='" & txtPassword.Text.Trim() & "' WHERE EmpId=" & StaticData.UserId)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Password Change Successfully", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Dispose()
                        Me.Close()
                    End Using

                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class