Imports System.Data
Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class Login

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        StaticData.LoginMode = -1
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            If String.IsNullOrEmpty(txtUserName.Text.Trim()) Then
                MessageBox.Show("Please enter Username", "LogIn", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf String.IsNullOrEmpty(txtPassword.Text.Trim()) Then
                MessageBox.Show("Please enter Password", "LogIn", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Using con As New MySqlConnection(StaticData.ConnectionString)
                    Using cmd As New MySqlCommand("SELECT ManagerId,UserName,EmpId FROM employee WHERE active=1 and UserName='" & txtUserName.Text.Trim() & "' AND Password='" & txtPassword.Text.Trim() & "'")
                        cmd.Connection = con
                        con.Open()
                        Dim rd As MySqlDataReader
                        rd = cmd.ExecuteReader
                        If rd.Read Then
                            Integer.TryParse(rd.GetString(0), StaticData.ManagerId)
                            StaticData.UserName = rd.GetString(1)
                            Integer.TryParse(rd.GetString(2), StaticData.UserId)
                            If StaticData.ManagerId > 0 Then
                                StaticData.LoginMode = 1 'Emp
                            Else
                                StaticData.LoginMode = 0 'Manager
                                StaticData.ManagerId = StaticData.UserId

                            End If

                            Me.Dispose()
                            Me.Close()
                        Else
                            MessageBox.Show("Invalid UserName/Password..", "LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        rd.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            StaticData.ConnectionString = ConfigurationManager.ConnectionStrings("connectionstr").ConnectionString
        Catch ex As Exception
            MessageBox.Show("Error while reading connection string from configuration file :" + ex.Message)
        End Try
    End Sub
End Class