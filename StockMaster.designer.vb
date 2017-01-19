<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockMaster
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtUnits = New System.Windows.Forms.TextBox()
        Me.llbAvailabelUnits = New System.Windows.Forms.Label()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.txtCategoryName = New System.Windows.Forms.TextBox()
        Me.txtNewUnits = New System.Windows.Forms.TextBox()
        Me.lblNewUnits = New System.Windows.Forms.Label()
        Me.txtWarehouseId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkGenerate = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(383, 295)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(276, 295)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(217, 218)
        Me.txtPrice.MaxLength = 7
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(87, 20)
        Me.txtPrice.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(110, 222)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Price in Dollars:"
        '
        'txtUnits
        '
        Me.txtUnits.Location = New System.Drawing.Point(217, 174)
        Me.txtUnits.MaxLength = 5
        Me.txtUnits.Name = "txtUnits"
        Me.txtUnits.Size = New System.Drawing.Size(87, 20)
        Me.txtUnits.TabIndex = 5
        '
        'llbAvailabelUnits
        '
        Me.llbAvailabelUnits.AutoSize = True
        Me.llbAvailabelUnits.Location = New System.Drawing.Point(110, 177)
        Me.llbAvailabelUnits.Name = "llbAvailabelUnits"
        Me.llbAvailabelUnits.Size = New System.Drawing.Size(40, 13)
        Me.llbAvailabelUnits.TabIndex = 4
        Me.llbAvailabelUnits.Text = "Unit(s):"
        '
        'txtProduct
        '
        Me.txtProduct.Location = New System.Drawing.Point(217, 126)
        Me.txtProduct.MaxLength = 50
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(240, 20)
        Me.txtProduct.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(109, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Product Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(110, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Category Name:"
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(217, 84)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(240, 21)
        Me.cmbCategory.TabIndex = 1
        '
        'txtCategoryName
        '
        Me.txtCategoryName.Location = New System.Drawing.Point(218, 85)
        Me.txtCategoryName.MaxLength = 50
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.ReadOnly = True
        Me.txtCategoryName.Size = New System.Drawing.Size(240, 20)
        Me.txtCategoryName.TabIndex = 10
        Me.txtCategoryName.Visible = False
        '
        'txtNewUnits
        '
        Me.txtNewUnits.Location = New System.Drawing.Point(371, 174)
        Me.txtNewUnits.MaxLength = 5
        Me.txtNewUnits.Name = "txtNewUnits"
        Me.txtNewUnits.Size = New System.Drawing.Size(86, 20)
        Me.txtNewUnits.TabIndex = 12
        Me.txtNewUnits.Visible = False
        '
        'lblNewUnits
        '
        Me.lblNewUnits.AutoSize = True
        Me.lblNewUnits.Location = New System.Drawing.Point(315, 177)
        Me.lblNewUnits.Name = "lblNewUnits"
        Me.lblNewUnits.Size = New System.Drawing.Size(40, 13)
        Me.lblNewUnits.TabIndex = 11
        Me.lblNewUnits.Text = "Unit(s):"
        Me.lblNewUnits.Visible = False
        '
        'txtWarehouseId
        '
        Me.txtWarehouseId.Location = New System.Drawing.Point(217, 256)
        Me.txtWarehouseId.MaxLength = 7
        Me.txtWarehouseId.Name = "txtWarehouseId"
        Me.txtWarehouseId.Size = New System.Drawing.Size(134, 20)
        Me.txtWarehouseId.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(110, 260)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Warehouse Id"
        '
        'chkGenerate
        '
        Me.chkGenerate.AutoSize = True
        Me.chkGenerate.Location = New System.Drawing.Point(362, 258)
        Me.chkGenerate.Name = "chkGenerate"
        Me.chkGenerate.Size = New System.Drawing.Size(95, 17)
        Me.chkGenerate.TabIndex = 15
        Me.chkGenerate.Text = "Auto Generate"
        Me.chkGenerate.UseVisualStyleBackColor = True
        '
        'StockMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(568, 361)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkGenerate)
        Me.Controls.Add(Me.txtWarehouseId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNewUnits)
        Me.Controls.Add(Me.lblNewUnits)
        Me.Controls.Add(Me.txtCategoryName)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtProduct)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUnits)
        Me.Controls.Add(Me.llbAvailabelUnits)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label11)
        Me.Name = "StockMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "StockMaster"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtUnits As System.Windows.Forms.TextBox
    Friend WithEvents llbAvailabelUnits As System.Windows.Forms.Label
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents txtNewUnits As System.Windows.Forms.TextBox
    Friend WithEvents lblNewUnits As System.Windows.Forms.Label
    Friend WithEvents txtWarehouseId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkGenerate As System.Windows.Forms.CheckBox
End Class
