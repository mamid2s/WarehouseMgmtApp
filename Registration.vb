Imports MySql.Data.MySqlClient

Public Class Registration
    Public ProfileEditMode As Integer = 0
    Public ManagerId As Integer = 0 ' Only use in edit mode
    Public EditMode As Integer = 0
    Public EditUserId As Integer = 0
    Private Sub Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If StaticData.LoginMode = 1 Then 'emp
                rbnEmployee.Visible = False
                rbnManager.Visible = False
            Else
                rbnEmployee.Visible = True
                rbnManager.Visible = True
            End If

            txtManagerName.Text = StaticData.UserName

            If ProfileEditMode = 1 Then ' Edit Mode

                txtManagerName.Visible = False
                lblManager.Visible = False
                rbnEmployee.Visible = False
                rbnManager.Visible = False
                ' btnDeactive.Visible = False  ' to make deactive button in

                Using con As New MySqlConnection(StaticData.ConnectionString)
                    Dim _UserId As Integer
                    If EditMode = 1 Then
                        _UserId = EditUserId
                    Else
                        _UserId = StaticData.UserId
                    End If
                    Using cmd As New MySqlCommand("SELECT EmpName,EmpFName,UserName,Password,EmailAddress,PhoneNumber,DateOfJoining,City,State,Street,ZIPCode,ManagerId FROM employee WHERE EmpId=" & _UserId)
                        cmd.Connection = con
                        con.Open()
                        Dim rd As MySqlDataReader
                        rd = cmd.ExecuteReader
                        If rd.Read Then
                            txtEmpName.Text = rd.GetString(0)
                            txtEmpFName.Text = rd.GetString(1)
                            txtUserName.Text = rd.GetString(2)
                            txtPassword.Text = rd.GetString(3)
                            txtxemail.Text = If(rd.IsDBNull(4), "", rd.GetString(4))
                            txtMobile.Text = If(rd.IsDBNull(5), "", rd.GetString(5))
                            'Date parsing
                            Dim format() = {"MM/dd/yyyy", "M/d/yyyy"}
                            'Dim expenddt As Date
                            Date.TryParseExact(rd.GetString(6), format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, dtpDate.Value)
                            'dtpDate.Value = Date.ParseExact(rd.GetString(5), "MM/dd/yyyy", Nothing)
                            txtCity.Text = If(rd.IsDBNull(7), "", rd.GetString(7))
                            ComboBox1.SelectedItem = If(rd.IsDBNull(8), "", rd.GetString(8))
                            txtStreet.Text = If(rd.IsDBNull(9), "", rd.GetString(9))
                            txtZipCode.Text = If(rd.IsDBNull(10), "", rd.GetString(10))
                            Integer.TryParse(rd.GetString(11), ManagerId)

                        End If
                        rd.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Registration", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If String.IsNullOrEmpty(txtEmpName.Text.Trim()) Then
                MessageBox.Show("Please enter Name", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf String.IsNullOrEmpty(txtUserName.Text.Trim()) Then
                MessageBox.Show("Please User Name", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf String.IsNullOrEmpty(txtPassword.Text.Trim()) Then
                MessageBox.Show("Please enter Password", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Using con As New MySqlConnection(StaticData.ConnectionString)
                    Dim _UserId As Integer
                    If EditMode = 1 Then

                        txtUserName.ReadOnly = True  'to make username read only while editing
                        _UserId = EditUserId
                    Else
                        _UserId = StaticData.UserId
                    End If
                    Dim insertquery As String = "INSERT INTO Employee(EmpName,EmpFName,UserName,Password,EmailAddress,PhoneNumber,State,City,Street,ZIPCode,DateOfJoining,ManagerId,RecordDate) VALUES('" &
                                                  txtEmpName.Text.Trim() & "','" & txtEmpFName.Text.Trim() & "','" & txtUserName.Text.Trim() & "','" & txtPassword.Text.Trim() & "','" &
                                                  txtxemail.Text.Trim() & "','" & txtMobile.Text.Trim() & "','" & ComboBox1.SelectedItem() & "','" &
                                                  txtCity.Text.Trim() & "','" & txtStreet.Text.Trim() & "','" & txtZipCode.Text.Trim() & "','" &
                                                  dtpDate.Value.Date.ToString("yyyy-MM-dd") & "'," & ManagerId & ",NOW());"

                    Dim updatequery As String = "UPDATE Employee SET EmpName = '" & txtEmpName.Text.Trim() & "',EmpFName = '" & txtEmpFName.Text.Trim() &
                        "',UserName = '" & txtUserName.Text.Trim() &
                        "',Password = '" & txtPassword.Text.Trim() &
                        "',EmailAddress='" & txtxemail.Text.Trim() &
                        "',PhoneNumber='" & txtMobile.Text.Trim() &
                        "',State='" & ComboBox1.SelectedItem() &
                        "',City='" & txtCity.Text.Trim() &
                        "',Street='" & txtStreet.Text.Trim() &
                        "',DateOfJoining='" & dtpDate.Value.Date.ToString("yyyy-MM-dd") &
                        "',ZIPCode='" & txtZipCode.Text.Trim() & "' WHERE EmpId =" & _UserId
                    Dim finalquery As String
                    If ProfileEditMode = 1 Then
                        btnDeactive.Visible = False
                        finalquery = updatequery
                    Else
                        finalquery = insertquery
                    End If

                    'if insert mode check for userid exist
                    Dim IsUserExist = False
                    If ProfileEditMode = 0 Then
                        Using cmd1 As New MySqlCommand("SELECT EmpId from Employee WHERE UserName='" & txtUserName.Text.Trim() & "';")
                            cmd1.Connection = con
                            con.Open()
                            Dim rd As MySqlDataReader
                            rd = cmd1.ExecuteReader
                            If rd.Read Then
                                IsUserExist = True
                                MessageBox.Show("User Name already exist.!!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                            rd.Close()
                        End Using
                    End If
                    If (IsUserExist = False) Then
                        Using cmd As New MySqlCommand(finalquery)
                            cmd.Connection = con
                            If (con.State = ConnectionState.Closed) Then
                                con.Open()
                            End If
                            cmd.ExecuteNonQuery()
                            MessageBox.Show("Data Saved Successfully", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Dispose()
                            Me.Close()
                        End Using
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Registration", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbnEmployee_CheckedChanged(sender As Object, e As EventArgs) Handles rbnEmployee.CheckedChanged
        txtManagerName.Visible = True
        lblManager.Visible = True
        ManagerId = StaticData.ManagerId
    End Sub

    Private Sub rbnManager_CheckedChanged(sender As Object, e As EventArgs) Handles rbnManager.CheckedChanged
        txtManagerName.Visible = False
        lblManager.Visible = False
        ManagerId = 0
    End Sub

    Private Sub btnDeactive_Click(sender As Object, e As EventArgs) Handles btnDeactive.Click
        Try
            Using con As New MySqlConnection(StaticData.ConnectionString)
                Dim query As String = "update employee set Active=0 where UserName='" + txtUserName.Text.Trim() + "'"
                Using cmd As New MySqlCommand(query)
                    cmd.Connection = con
                    con.Open()
                    Dim res As Integer = cmd.ExecuteNonQuery()
                    If res > 0 Then
                        MessageBox.Show("User Deactivated successfully !!!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Dispose()
                        Me.Close()
                    End If
                End Using

            End Using


        Catch ex As Exception

        End Try
    End Sub


