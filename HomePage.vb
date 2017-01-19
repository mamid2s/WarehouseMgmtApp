
Public Class HomePage

    Private Sub HomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Login.ShowDialog()
        Dim LoginMode As Integer = StaticData.LoginMode
        GroupBox1.Visible = False
        If LoginMode >= 0 Then
            GroupBox1.Visible = True
            If LoginMode = 0 Then
                lblLoginMode.Text = "Manager"
                PictureBox1.ImageLocation = "..\..\images\manager.png"
                PictureBox1.Visible = True
                PictureBox2.Visible = False
                PictureBox3.Visible = False
                PictureBox4.Visible = False
                btnCategory.Visible = True
                btnChangePassword.Visible = True
                btnTransactions.Visible = True
                btnStockMgmt.Visible = True
                btnEmpMgmt.Visible = True
                btnProfile.Visible = True
                btnEmpChangePwd.Visible = False
                btnEmpProfile.Visible = False
                btnOrders.Visible = False
                btnEmpTransactions.Visible = False
                btnlstCategory.Visible = True
                btnlstEmployee.Visible = True
                btnlststock.Visible = True
            Else
                lblLoginMode.Text = "Employee"
                PictureBox2.ImageLocation = "..\..\images\employee.png"
                PictureBox2.Visible = True
                PictureBox3.ImageLocation = "..\..\images\order.png"
                PictureBox3.Visible = True
                PictureBox4.ImageLocation = "..\..\images\stock.png"
                PictureBox4.Visible = True
                btnCategory.Visible = False
                btnChangePassword.Visible = False
                btnTransactions.Visible = False
                btnStockMgmt.Visible = False
                btnEmpMgmt.Visible = False
                btnProfile.Visible = False
                btnEmpChangePwd.Visible = True
                btnEmpProfile.Visible = True
                btnOrders.Visible = True
                btnEmpTransactions.Visible = True
                btnlstCategory.Visible = False
                btnlstEmployee.Visible = False
                btnlststock.Visible = False
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnCategory_Click(sender As Object, e As EventArgs) Handles btnCategory.Click
        Try
            CategoryMaster.EditMode = 0
            CategoryMaster.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub brnClose_Click(sender As Object, e As EventArgs) Handles brnClose.Click
        Me.Close()
    End Sub

    Private Sub btnStockMgmt_Click(sender As Object, e As EventArgs) Handles btnStockMgmt.Click
        Try
            StockMaster.EditMode = 0
            StockMaster.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEmpMgmt_Click(sender As Object, e As EventArgs) Handles btnEmpMgmt.Click
        Try
            Registration.ProfileEditMode = 0 'Registration Add Mode
            Registration.btnDeactive.Visible = False
            Registration.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        Try
            InTakeOrder.TransactionMode = 0
            InTakeOrder.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEmpProfile_Click(sender As Object, e As EventArgs) Handles btnEmpProfile.Click
        Try
            Registration.ProfileEditMode = 1 'My Profile Edit Mode
            Registration.btnDeactive.Visible = False    ''''to disable employe deactive button in emp screen
            Registration.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTransactions_Click(sender As Object, e As EventArgs) Handles btnTransactions.Click
        Try
            Transactions.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Try
            Registration.ProfileEditMode = 1 'My Profile Edit Mode
            Registration.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEmpChangePwd_Click(sender As Object, e As EventArgs) Handles btnEmpChangePwd.Click
        Try
            ChangePassword.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Try
            ChangePassword.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEmpTransactions_Click(sender As Object, e As EventArgs) Handles btnEmpTransactions.Click
        Try
            Transactions.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnlstEmployee_Click(sender As Object, e As EventArgs) Handles btnlstEmployee.Click
        Try
            EmployeeList.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnlststock_Click(sender As Object, e As EventArgs) Handles btnlststock.Click
        Try
            StockList.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnlstCategory_Click(sender As Object, e As EventArgs) Handles btnlstCategory.Click
        Try
            CategoryList.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Try
            HomePage_Load(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Home Page", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class