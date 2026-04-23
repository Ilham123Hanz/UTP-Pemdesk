<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Log_Activity
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Log_Activity))
        Label1 = New Label()
        Label2 = New Label()
        DateTimePicker1 = New DateTimePicker()
        Label3 = New Label()
        cmbCategories = New ComboBox()
        chkFilter = New CheckBox()
        chkTop100 = New CheckBox()
        DataGridView1 = New DataGridView()
        colCategories = New DataGridViewTextBoxColumn()
        colActivity = New DataGridViewTextBoxColumn()
        colActivityType = New DataGridViewTextBoxColumn()
        colDateTime = New DataGridViewTextBoxColumn()
        colMatchTime = New DataGridViewTextBoxColumn()
        colUserName = New DataGridViewTextBoxColumn()
        btnExport = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(336, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(466, 48)
        Label1.TabIndex = 0
        Label1.Text = "Tatami Admin Log Activity"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 100)
        Label2.Name = "Label2"
        Label2.Size = New Size(49, 25)
        Label2.TabIndex = 1
        Label2.Text = "Date"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.Location = New Point(210, 100)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(164, 31)
        DateTimePicker1.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 159)
        Label3.Name = "Label3"
        Label3.Size = New Size(160, 25)
        Label3.TabIndex = 3
        Label3.Text = "Match (Categories)"
        ' 
        ' cmbCategories
        ' 
        cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCategories.FormattingEnabled = True
        cmbCategories.Items.AddRange(New Object() {"KUMITE Blank ScoreBoard", "", "KATA Individual", "", "KUMITE Team"})
        cmbCategories.Location = New Point(210, 159)
        cmbCategories.Name = "cmbCategories"
        cmbCategories.Size = New Size(306, 33)
        cmbCategories.TabIndex = 4
        ' 
        ' chkFilter
        ' 
        chkFilter.AutoSize = True
        chkFilter.Location = New Point(596, 163)
        chkFilter.Name = "chkFilter"
        chkFilter.Size = New Size(190, 29)
        chkFilter.TabIndex = 5
        chkFilter.Text = "Filter by Categories"
        chkFilter.UseVisualStyleBackColor = True
        ' 
        ' chkTop100
        ' 
        chkTop100.AutoSize = True
        chkTop100.Location = New Point(210, 218)
        chkTop100.Name = "chkTop100"
        chkTop100.Size = New Size(201, 29)
        chkTop100.TabIndex = 6
        chkTop100.Text = "Top 100 Last Activity"
        chkTop100.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {colCategories, colActivity, colActivityType, colDateTime, colMatchTime, colUserName})
        DataGridView1.Location = New Point(1, 254)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.Size = New Size(1112, 349)
        DataGridView1.TabIndex = 7
        ' 
        ' colCategories
        ' 
        colCategories.HeaderText = "Categories"
        colCategories.MinimumWidth = 8
        colCategories.Name = "colCategories"
        colCategories.ReadOnly = True
        ' 
        ' colActivity
        ' 
        colActivity.HeaderText = "Activity"
        colActivity.MinimumWidth = 8
        colActivity.Name = "colActivity"
        colActivity.ReadOnly = True
        ' 
        ' colActivityType
        ' 
        colActivityType.HeaderText = "ActivityType"
        colActivityType.MinimumWidth = 8
        colActivityType.Name = "colActivityType"
        colActivityType.ReadOnly = True
        ' 
        ' colDateTime
        ' 
        colDateTime.HeaderText = "Date Time"
        colDateTime.MinimumWidth = 8
        colDateTime.Name = "colDateTime"
        colDateTime.ReadOnly = True
        ' 
        ' colMatchTime
        ' 
        colMatchTime.HeaderText = "MatchTime"
        colMatchTime.MinimumWidth = 8
        colMatchTime.Name = "colMatchTime"
        colMatchTime.ReadOnly = True
        ' 
        ' colUserName
        ' 
        colUserName.HeaderText = "UserName"
        colUserName.MinimumWidth = 8
        colUserName.Name = "colUserName"
        colUserName.ReadOnly = True
        ' 
        ' btnExport
        ' 
        btnExport.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnExport.Image = CType(resources.GetObject("btnExport.Image"), Image)
        btnExport.ImageAlign = ContentAlignment.MiddleRight
        btnExport.Location = New Point(961, 667)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(134, 39)
        btnExport.TabIndex = 8
        btnExport.Text = "Export"
        btnExport.TextAlign = ContentAlignment.MiddleLeft
        btnExport.TextImageRelation = TextImageRelation.TextBeforeImage
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' Log_Activity
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1107, 718)
        Controls.Add(btnExport)
        Controls.Add(DataGridView1)
        Controls.Add(chkTop100)
        Controls.Add(chkFilter)
        Controls.Add(cmbCategories)
        Controls.Add(Label3)
        Controls.Add(DateTimePicker1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Log_Activity"
        Text = "Log_Activity"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCategories As ComboBox
    Friend WithEvents chkFilter As CheckBox
    Friend WithEvents chkTop100 As CheckBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents colCategories As DataGridViewTextBoxColumn
    Friend WithEvents colActivity As DataGridViewTextBoxColumn
    Friend WithEvents colActivityType As DataGridViewTextBoxColumn
    Friend WithEvents colDateTime As DataGridViewTextBoxColumn
    Friend WithEvents colMatchTime As DataGridViewTextBoxColumn
    Friend WithEvents colUserName As DataGridViewTextBoxColumn
    Friend WithEvents btnExport As Button
End Class