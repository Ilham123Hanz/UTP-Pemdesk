<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Competitor
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        lblTitle = New Label()
        pnlInput = New Panel()
        lblNew = New Label()
        lblName = New Label()
        lblTeam = New Label()
        lblTeamInfo = New Label()
        lblProfilePic = New Label()
        btnAdd = New Button()
        btnClear = New Button()
        txtName = New TextBox()
        cmbTeam = New ComboBox()
        btnEditTeam = New Button()
        txtTeamInfo = New TextBox()
        btnSelect = New Button()
        picProfile = New PictureBox()
        pnlToolbar = New Panel()
        txtSearch = New TextBox()
        btnSearch = New Button()
        btnClearSearch = New Button()
        btnExport = New Button()
        btnImport = New Button()
        pnlMainGridContainer = New Panel()
        dgvCompetitors = New DataGridView()
        colEmpty1 = New DataGridViewTextBoxColumn()
        colEmpty2 = New DataGridViewTextBoxColumn()
        colEmpty3 = New DataGridViewTextBoxColumn()
        colName = New DataGridViewTextBoxColumn()
        colTeam = New DataGridViewTextBoxColumn()
        colTeamInfo = New DataGridViewTextBoxColumn()
        colCompPict = New DataGridViewImageColumn()
        pnlLeftTeam = New Panel()
        lblTeamHeader = New Label()
        pnlFooter = New Panel()
        lblTotalRecords = New Label()
        btnDeleteAll = New Button()
        pnlHeader.SuspendLayout()
        pnlInput.SuspendLayout()
        CType(picProfile, ComponentModel.ISupportInitialize).BeginInit()
        pnlToolbar.SuspendLayout()
        pnlMainGridContainer.SuspendLayout()
        CType(dgvCompetitors, ComponentModel.ISupportInitialize).BeginInit()
        pnlLeftTeam.SuspendLayout()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pnlHeader.BorderStyle = BorderStyle.FixedSingle
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Margin = New Padding(4)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1538, 43)
        pnlHeader.TabIndex = 5
        ' 
        ' lblTitle
        ' 
        lblTitle.Dock = DockStyle.Fill
        lblTitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblTitle.Location = New Point(0, 0)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(1536, 41)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Competitor Entries"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlInput
        ' 
        pnlInput.BackColor = Color.FromArgb(CByte(235), CByte(235), CByte(235))
        pnlInput.BorderStyle = BorderStyle.FixedSingle
        pnlInput.Controls.Add(lblNew)
        pnlInput.Controls.Add(lblName)
        pnlInput.Controls.Add(lblTeam)
        pnlInput.Controls.Add(lblTeamInfo)
        pnlInput.Controls.Add(lblProfilePic)
        pnlInput.Controls.Add(btnAdd)
        pnlInput.Controls.Add(btnClear)
        pnlInput.Controls.Add(txtName)
        pnlInput.Controls.Add(cmbTeam)
        pnlInput.Controls.Add(btnEditTeam)
        pnlInput.Controls.Add(txtTeamInfo)
        pnlInput.Controls.Add(btnSelect)
        pnlInput.Controls.Add(picProfile)
        pnlInput.Dock = DockStyle.Top
        pnlInput.Location = New Point(0, 43)
        pnlInput.Margin = New Padding(4)
        pnlInput.Name = "pnlInput"
        pnlInput.Size = New Size(1538, 200)
        pnlInput.TabIndex = 1
        ' 
        ' lblNew
        ' 
        lblNew.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblNew.Location = New Point(938, 125)
        lblNew.Margin = New Padding(4, 0, 4, 0)
        lblNew.Name = "lblNew"
        lblNew.Size = New Size(225, 38)
        lblNew.TabIndex = 12
        lblNew.Text = "NEW"
        lblNew.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblName.Location = New Point(62, 19)
        lblName.Margin = New Padding(4, 0, 4, 0)
        lblName.Name = "lblName"
        lblName.Size = New Size(70, 25)
        lblName.TabIndex = 0
        lblName.Text = "Name*"
        ' 
        ' lblTeam
        ' 
        lblTeam.AutoSize = True
        lblTeam.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblTeam.Location = New Point(62, 60)
        lblTeam.Margin = New Padding(4, 0, 4, 0)
        lblTeam.Name = "lblTeam"
        lblTeam.Size = New Size(65, 25)
        lblTeam.TabIndex = 1
        lblTeam.Text = "Team*"
        ' 
        ' lblTeamInfo
        ' 
        lblTeamInfo.AutoSize = True
        lblTeamInfo.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblTeamInfo.Location = New Point(62, 101)
        lblTeamInfo.Margin = New Padding(4, 0, 4, 0)
        lblTeamInfo.Name = "lblTeamInfo"
        lblTeamInfo.Size = New Size(97, 25)
        lblTeamInfo.TabIndex = 2
        lblTeamInfo.Text = "Team Info"
        ' 
        ' lblProfilePic
        ' 
        lblProfilePic.AutoSize = True
        lblProfilePic.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblProfilePic.Location = New Point(62, 144)
        lblProfilePic.Margin = New Padding(4, 0, 4, 0)
        lblProfilePic.Name = "lblProfilePic"
        lblProfilePic.Size = New Size(133, 25)
        lblProfilePic.TabIndex = 3
        lblProfilePic.Text = "Profile Picture"
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.DeepSkyBlue
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnAdd.ForeColor = Color.Black
        btnAdd.Location = New Point(938, 19)
        btnAdd.Margin = New Padding(4)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(225, 44)
        btnAdd.TabIndex = 10
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.LightGreen
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnClear.ForeColor = Color.Black
        btnClear.Location = New Point(938, 69)
        btnClear.Margin = New Padding(4)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(225, 44)
        btnClear.TabIndex = 11
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(225, 15)
        txtName.Margin = New Padding(4)
        txtName.Name = "txtName"
        txtName.Size = New Size(436, 31)
        txtName.TabIndex = 4
        ' 
        ' cmbTeam
        ' 
        cmbTeam.FormattingEnabled = True
        cmbTeam.Location = New Point(225, 56)
        cmbTeam.Margin = New Padding(4)
        cmbTeam.Name = "cmbTeam"
        cmbTeam.Size = New Size(436, 33)
        cmbTeam.TabIndex = 5
        ' 
        ' btnEditTeam
        ' 
        btnEditTeam.BackColor = Color.White
        btnEditTeam.FlatStyle = FlatStyle.Flat
        btnEditTeam.Location = New Point(669, 56)
        btnEditTeam.Margin = New Padding(4)
        btnEditTeam.Name = "btnEditTeam"
        btnEditTeam.Size = New Size(44, 35)
        btnEditTeam.TabIndex = 6
        btnEditTeam.Text = "📝"
        btnEditTeam.UseVisualStyleBackColor = False
        ' 
        ' txtTeamInfo
        ' 
        txtTeamInfo.Location = New Point(225, 98)
        txtTeamInfo.Margin = New Padding(4)
        txtTeamInfo.Name = "txtTeamInfo"
        txtTeamInfo.Size = New Size(436, 31)
        txtTeamInfo.TabIndex = 7
        ' 
        ' btnSelect
        ' 
        btnSelect.Location = New Point(288, 144)
        btnSelect.Margin = New Padding(4)
        btnSelect.Name = "btnSelect"
        btnSelect.Size = New Size(94, 38)
        btnSelect.TabIndex = 9
        btnSelect.Text = "Select"
        btnSelect.UseVisualStyleBackColor = True
        ' 
        ' picProfile
        ' 
        picProfile.BackColor = Color.Transparent
        picProfile.Location = New Point(225, 138)
        picProfile.Margin = New Padding(4)
        picProfile.Name = "picProfile"
        picProfile.Size = New Size(50, 50)
        picProfile.SizeMode = PictureBoxSizeMode.Zoom
        picProfile.TabIndex = 8
        picProfile.TabStop = False
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.White
        pnlToolbar.BorderStyle = BorderStyle.FixedSingle
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Controls.Add(btnSearch)
        pnlToolbar.Controls.Add(btnClearSearch)
        pnlToolbar.Controls.Add(btnExport)
        pnlToolbar.Controls.Add(btnImport)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 243)
        pnlToolbar.Margin = New Padding(4)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(1538, 56)
        pnlToolbar.TabIndex = 2
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(12, 10)
        txtSearch.Margin = New Padding(4)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(249, 31)
        txtSearch.TabIndex = 0
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(269, 10)
        btnSearch.Margin = New Padding(4)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(38, 34)
        btnSearch.TabIndex = 1
        btnSearch.Text = "🔍"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnClearSearch
        ' 
        btnClearSearch.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnClearSearch.ForeColor = Color.DeepSkyBlue
        btnClearSearch.Location = New Point(312, 10)
        btnClearSearch.Margin = New Padding(4)
        btnClearSearch.Name = "btnClearSearch"
        btnClearSearch.Size = New Size(38, 34)
        btnClearSearch.TabIndex = 2
        btnClearSearch.Text = "❌"
        btnClearSearch.UseVisualStyleBackColor = True
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.White
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Location = New Point(907, 6)
        btnExport.Margin = New Padding(4)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(181, 38)
        btnExport.TabIndex = 3
        btnExport.Text = "Export to Excel ☒"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' btnImport
        ' 
        btnImport.BackColor = Color.White
        btnImport.FlatStyle = FlatStyle.Flat
        btnImport.Location = New Point(1096, 6)
        btnImport.Margin = New Padding(4)
        btnImport.Name = "btnImport"
        btnImport.Size = New Size(200, 38)
        btnImport.TabIndex = 4
        btnImport.Text = "Import from Excel ☒"
        btnImport.UseVisualStyleBackColor = False
        ' 
        ' pnlMainGridContainer
        ' 
        pnlMainGridContainer.Controls.Add(dgvCompetitors)
        pnlMainGridContainer.Controls.Add(pnlLeftTeam)
        pnlMainGridContainer.Dock = DockStyle.Fill
        pnlMainGridContainer.Location = New Point(0, 299)
        pnlMainGridContainer.Margin = New Padding(4)
        pnlMainGridContainer.Name = "pnlMainGridContainer"
        pnlMainGridContainer.Size = New Size(1538, 463)
        pnlMainGridContainer.TabIndex = 3
        ' 
        ' dgvCompetitors
        ' 
        dgvCompetitors.BackgroundColor = Color.White
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvCompetitors.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvCompetitors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCompetitors.Columns.AddRange(New DataGridViewColumn() {colEmpty1, colEmpty2, colEmpty3, colName, colTeam, colTeamInfo, colCompPict})
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvCompetitors.DefaultCellStyle = DataGridViewCellStyle2
        dgvCompetitors.Dock = DockStyle.Fill
        dgvCompetitors.Location = New Point(224, 0)
        dgvCompetitors.Margin = New Padding(4)
        dgvCompetitors.Name = "dgvCompetitors"
        dgvCompetitors.RowHeadersVisible = False
        dgvCompetitors.RowHeadersWidth = 62
        dgvCompetitors.RowTemplate.Height = 60
        dgvCompetitors.Size = New Size(1314, 463)
        dgvCompetitors.TabIndex = 1
        ' 
        ' colEmpty1
        ' 
        colEmpty1.HeaderText = ""
        colEmpty1.MinimumWidth = 8
        colEmpty1.Name = "colEmpty1"
        colEmpty1.Width = 35
        ' 
        ' colEmpty2
        ' 
        colEmpty2.HeaderText = ""
        colEmpty2.MinimumWidth = 8
        colEmpty2.Name = "colEmpty2"
        colEmpty2.Width = 35
        ' 
        ' colEmpty3
        ' 
        colEmpty3.HeaderText = ""
        colEmpty3.MinimumWidth = 8
        colEmpty3.Name = "colEmpty3"
        colEmpty3.Width = 35
        ' 
        ' colName
        ' 
        colName.HeaderText = "Name"
        colName.MinimumWidth = 8
        colName.Name = "colName"
        colName.Width = 200
        ' 
        ' colTeam
        ' 
        colTeam.HeaderText = "Team"
        colTeam.MinimumWidth = 8
        colTeam.Name = "colTeam"
        colTeam.Width = 150
        ' 
        ' colTeamInfo
        ' 
        colTeamInfo.HeaderText = "Team Info"
        colTeamInfo.MinimumWidth = 8
        colTeamInfo.Name = "colTeamInfo"
        colTeamInfo.Width = 200
        ' 
        ' colCompPict
        ' 
        colCompPict.HeaderText = "Comp. Pict"
        colCompPict.ImageLayout = DataGridViewImageCellLayout.Zoom
        colCompPict.MinimumWidth = 8
        colCompPict.Name = "colCompPict"
        colCompPict.Width = 120
        ' 
        ' pnlLeftTeam
        ' 
        pnlLeftTeam.BorderStyle = BorderStyle.FixedSingle
        pnlLeftTeam.Controls.Add(lblTeamHeader)
        pnlLeftTeam.Dock = DockStyle.Left
        pnlLeftTeam.Location = New Point(0, 0)
        pnlLeftTeam.Margin = New Padding(4)
        pnlLeftTeam.Name = "pnlLeftTeam"
        pnlLeftTeam.Size = New Size(224, 463)
        pnlLeftTeam.TabIndex = 0
        ' 
        ' lblTeamHeader
        ' 
        lblTeamHeader.BackColor = Color.Crimson
        lblTeamHeader.Dock = DockStyle.Top
        lblTeamHeader.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblTeamHeader.ForeColor = Color.White
        lblTeamHeader.Location = New Point(0, 0)
        lblTeamHeader.Margin = New Padding(4, 0, 4, 0)
        lblTeamHeader.Name = "lblTeamHeader"
        lblTeamHeader.Size = New Size(222, 38)
        lblTeamHeader.TabIndex = 0
        lblTeamHeader.Text = "Team"
        lblTeamHeader.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.FromArgb(CByte(245), CByte(245), CByte(245))
        pnlFooter.Controls.Add(lblTotalRecords)
        pnlFooter.Controls.Add(btnDeleteAll)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 762)
        pnlFooter.Margin = New Padding(4)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(1538, 50)
        pnlFooter.TabIndex = 4
        ' 
        ' lblTotalRecords
        ' 
        lblTotalRecords.AutoSize = True
        lblTotalRecords.Location = New Point(12, 12)
        lblTotalRecords.Margin = New Padding(4, 0, 4, 0)
        lblTotalRecords.Name = "lblTotalRecords"
        lblTotalRecords.Size = New Size(141, 25)
        lblTotalRecords.TabIndex = 0
        lblTotalRecords.Text = "Total Records : 0"
        ' 
        ' btnDeleteAll
        ' 
        btnDeleteAll.BackColor = Color.LightSalmon
        btnDeleteAll.Dock = DockStyle.Right
        btnDeleteAll.FlatStyle = FlatStyle.Flat
        btnDeleteAll.Location = New Point(1350, 0)
        btnDeleteAll.Margin = New Padding(4)
        btnDeleteAll.Name = "btnDeleteAll"
        btnDeleteAll.Size = New Size(188, 50)
        btnDeleteAll.TabIndex = 1
        btnDeleteAll.Text = "Delete All"
        btnDeleteAll.UseVisualStyleBackColor = False
        ' 
        ' Competitor
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1538, 812)
        Controls.Add(pnlMainGridContainer)
        Controls.Add(pnlToolbar)
        Controls.Add(pnlInput)
        Controls.Add(pnlFooter)
        Controls.Add(pnlHeader)
        Font = New Font("Segoe UI", 9.0F)
        Margin = New Padding(4)
        Name = "Competitor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Competitor Entries"
        pnlHeader.ResumeLayout(False)
        pnlInput.ResumeLayout(False)
        pnlInput.PerformLayout()
        CType(picProfile, ComponentModel.ISupportInitialize).EndInit()
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        pnlMainGridContainer.ResumeLayout(False)
        CType(dgvCompetitors, ComponentModel.ISupportInitialize).EndInit()
        pnlLeftTeam.ResumeLayout(False)
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlInput As System.Windows.Forms.Panel
    Friend WithEvents lblNew As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents lblTeamInfo As System.Windows.Forms.Label
    Friend WithEvents lblProfilePic As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cmbTeam As System.Windows.Forms.ComboBox
    Friend WithEvents btnEditTeam As System.Windows.Forms.Button
    Friend WithEvents txtTeamInfo As System.Windows.Forms.TextBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents picProfile As System.Windows.Forms.PictureBox
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClearSearch As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents pnlMainGridContainer As System.Windows.Forms.Panel
    Friend WithEvents dgvCompetitors As System.Windows.Forms.DataGridView
    Friend WithEvents pnlLeftTeam As System.Windows.Forms.Panel
    Friend WithEvents lblTeamHeader As System.Windows.Forms.Label
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents lblTotalRecords As System.Windows.Forms.Label
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button

    ' Kolom Kosong (Delete, Edit, No)
    Friend WithEvents colEmpty1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmpty2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmpty3 As System.Windows.Forms.DataGridViewTextBoxColumn

    ' Kolom Data
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTeam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTeamInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCompPict As System.Windows.Forms.DataGridViewImageColumn  ' <-- DIUBAH

End Class