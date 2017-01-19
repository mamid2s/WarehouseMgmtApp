<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomePage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblLoginMode = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnlstCategory = New System.Windows.Forms.Button()
        Me.btnlststock = New System.Windows.Forms.Button()
        Me.btnlstEmployee = New System.Windows.Forms.Button()
        Me.btnEmpTransactions = New System.Windows.Forms.Button()
        Me.btnEmpChangePwd = New System.Windows.Forms.Button()
        Me.btnEmpProfile = New System.Windows.Forms.Button()
        Me.btnOrders = New System.Windows.Forms.Button()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.btnCategory = New System.Windows.Forms.Button()
        Me.btnTransactions = New System.Windows.Forms.Button()
        Me.btnStockMgmt = New System.Windows.Forms.Button()
        Me.btnEmpMgmt = New System.Windows.Forms.Button()
        Me.brnClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLoginMode
        '
        Me.lblLoginMode.AutoSize = True
        Me.lblLoginMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginMode.Location = New System.Drawing.Point(12, 9)
        Me.lblLoginMode.Name = "lblLoginMode"
        Me.lblLoginMode.Size = New System.Drawing.Size(0, 20)
        Me.lblLoginMode.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.btnlstCategory)
        Me.GroupBox1.Controls.Add(Me.btnlststock)
        Me.GroupBox1.Controls.Add(Me.btnlstEmployee)
        Me.GroupBox1.Controls.Add(Me.btnEmpTransactions)
        Me.GroupBox1.Controls.Add(Me.btnEmpChangePwd)
        Me.GroupBox1.Controls.Add(Me.btnEmpProfile)
        Me.GroupBox1.Controls.Add(Me.btnOrders)
        Me.GroupBox1.Controls.Add(Me.btnChangePassword)
        Me.GroupBox1.Controls.Add(Me.btnProfile)
        Me.GroupBox1.Controls.Add(Me.btnCategory)
        Me.GroupBox1.Controls.Add(Me.btnTransactions)
        Me.GroupBox1.Controls.Add(Me.btnStockMgmt)
        Me.GroupBox1.Controls.Add(Me.btnEmpMgmt)
        Me.GroupBox1.Location = New System.Drawing.Point(203, 135)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(632, 410)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Location = New System.Drawing.Point(41, 48)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(169, 150)
        Me.PictureBox4.TabIndex = 13
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(240, 48)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(169, 150)
        Me.PictureBox3.TabIndex = 9
        Me.PictureBox3.TabStop = False
        '
        'btnlstCategory
        '
        Me.btnlstCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlstCategory.Location = New System.Drawing.Point(440, 54)
        Me.btnlstCategory.Name = "btnlstCategory"
        Me.btnlstCategory.Size = New System.Drawing.Size(160, 60)
        Me.btnlstCategory.TabIndex = 12
        Me.btnlstCategory.Text = "Category List"
        Me.btnlstCategory.UseVisualStyleBackColor = True
        '
        'btnlststock
        '
        Me.btnlststock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlststock.Location = New System.Drawing.Point(240, 54)
        Me.btnlststock.Name = "btnlststock"
        Me.btnlststock.Size = New System.Drawing.Size(160, 60)
        Me.btnlststock.TabIndex = 11
        Me.btnlststock.Text = "Stock List"
        Me.btnlststock.UseVisualStyleBackColor = True
        '
        'btnlstEmployee
        '
        Me.btnlstEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlstEmployee.Location = New System.Drawing.Point(41, 54)
        Me.btnlstEmployee.Name = "btnlstEmployee"
        Me.btnlstEmployee.Size = New System.Drawing.Size(160, 60)
        Me.btnlstEmployee.TabIndex = 10
        Me.btnlstEmployee.Text = "Employee List"
        Me.btnlstEmployee.UseVisualStyleBackColor = True
        '
        'btnEmpTransactions
        '
        Me.btnEmpTransactions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpTransactions.Location = New System.Drawing.Point(240, 216)
        Me.btnEmpTransactions.Name = "btnEmpTransactions"
        Me.btnEmpTransactions.Size = New System.Drawing.Size(160, 60)
        Me.btnEmpTransactions.TabIndex = 9
        Me.btnEmpTransactions.Text = "Transactions"
        Me.btnEmpTransactions.UseVisualStyleBackColor = True
        '
        'btnEmpChangePwd
        '
        Me.btnEmpChangePwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpChangePwd.Location = New System.Drawing.Point(440, 216)
        Me.btnEmpChangePwd.Name = "btnEmpChangePwd"
        Me.btnEmpChangePwd.Size = New System.Drawing.Size(160, 60)
        Me.btnEmpChangePwd.TabIndex = 8
        Me.btnEmpChangePwd.Text = "Change Password"
        Me.btnEmpChangePwd.UseVisualStyleBackColor = True
        '
        'btnEmpProfile
        '
        Me.btnEmpProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpProfile.Location = New System.Drawing.Point(240, 295)
        Me.btnEmpProfile.Name = "btnEmpProfile"
        Me.btnEmpProfile.Size = New System.Drawing.Size(160, 60)
        Me.btnEmpProfile.TabIndex = 7
        Me.btnEmpProfile.Text = "Profile"
        Me.btnEmpProfile.UseVisualStyleBackColor = True
        '
        'btnOrders
        '
        Me.btnOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrders.Location = New System.Drawing.Point(41, 216)
        Me.btnOrders.Name = "btnOrders"
        Me.btnOrders.Size = New System.Drawing.Size(160, 60)
        Me.btnOrders.TabIndex = 6
        Me.btnOrders.Text = "Orders"
        Me.btnOrders.UseVisualStyleBackColor = True
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePassword.Location = New System.Drawing.Point(440, 215)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(160, 60)
        Me.btnChangePassword.TabIndex = 5
        Me.btnChangePassword.Text = "Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'btnProfile
        '
        Me.btnProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProfile.Location = New System.Drawing.Point(240, 216)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Size = New System.Drawing.Size(160, 60)
        Me.btnProfile.TabIndex = 4
        Me.btnProfile.Text = "Profile"
        Me.btnProfile.UseVisualStyleBackColor = True
        '
        'btnCategory
        '
        Me.btnCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategory.Location = New System.Drawing.Point(41, 215)
        Me.btnCategory.Name = "btnCategory"
        Me.btnCategory.Size = New System.Drawing.Size(160, 60)
        Me.btnCategory.TabIndex = 3
        Me.btnCategory.Text = "Category Master"
        Me.btnCategory.UseVisualStyleBackColor = True
        '
        'btnTransactions
        '
        Me.btnTransactions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransactions.Location = New System.Drawing.Point(440, 138)
        Me.btnTransactions.Name = "btnTransactions"
        Me.btnTransactions.Size = New System.Drawing.Size(160, 60)
        Me.btnTransactions.TabIndex = 2
        Me.btnTransactions.Text = "Transactions"
        Me.btnTransactions.UseVisualStyleBackColor = True
        '
        'btnStockMgmt
        '
        Me.btnStockMgmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockMgmt.Location = New System.Drawing.Point(240, 138)
        Me.btnStockMgmt.Name = "btnStockMgmt"
        Me.btnStockMgmt.Size = New System.Drawing.Size(160, 60)
        Me.btnStockMgmt.TabIndex = 1
        Me.btnStockMgmt.Text = "Stock " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Master"
        Me.btnStockMgmt.UseVisualStyleBackColor = True
        '
        'btnEmpMgmt
        '
        Me.btnEmpMgmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpMgmt.Location = New System.Drawing.Point(41, 138)
        Me.btnEmpMgmt.Name = "btnEmpMgmt"
        Me.btnEmpMgmt.Size = New System.Drawing.Size(160, 60)
        Me.btnEmpMgmt.TabIndex = 0
        Me.btnEmpMgmt.Text = "User Master"
        Me.btnEmpMgmt.UseVisualStyleBackColor = True
        '
        'brnClose
        '
        Me.brnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.brnClose.Location = New System.Drawing.Point(773, 589)
        Me.brnClose.Name = "brnClose"
        Me.brnClose.Size = New System.Drawing.Size(124, 29)
        Me.brnClose.TabIndex = 6
        Me.brnClose.Text = "&Close"
        Me.brnClose.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(28, 38)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(169, 150)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(28, 38)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(169, 150)
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'btnLogout
        '
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(634, 589)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(124, 29)
        Me.btnLogout.TabIndex = 9
        Me.btnLogout.Text = "&Log Out"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'HomePage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.brnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblLoginMode)
        Me.MaximizeBox = False
        Me.Name = "HomePage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HomePage"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLoginMode As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStockMgmt As System.Windows.Forms.Button
    Friend WithEvents btnEmpMgmt As System.Windows.Forms.Button
    Friend WithEvents btnTransactions As System.Windows.Forms.Button
    Friend WithEvents btnChangePassword As System.Windows.Forms.Button
    Friend WithEvents btnProfile As System.Windows.Forms.Button
    Friend WithEvents btnCategory As System.Windows.Forms.Button
    Friend WithEvents btnEmpChangePwd As System.Windows.Forms.Button
    Friend WithEvents btnEmpProfile As System.Windows.Forms.Button
    Friend WithEvents btnOrders As System.Windows.Forms.Button
    Friend WithEvents brnClose As System.Windows.Forms.Button
    Friend WithEvents btnEmpTransactions As System.Windows.Forms.Button
    Friend WithEvents btnlstCategory As System.Windows.Forms.Button
    Friend WithEvents btnlststock As System.Windows.Forms.Button
    Friend WithEvents btnlstEmployee As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents btnLogout As System.Windows.Forms.Button
End Class
