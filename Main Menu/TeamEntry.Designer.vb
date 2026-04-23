<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TeamEntry
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTitle = New Label()
        pnlInput = New Panel()
        lblTeam = New Label()
        txtTeam = New TextBox()
        lblInfo = New Label()
        txtTeamInfo = New TextBox()
        chkUseFlag = New CheckBox()
        lblCountry = New Label()
        cmbCountry = New ComboBox()
        lblTeamPic = New Label()
        picTeam = New PictureBox()
        btnSelect = New Button()
        btnAdd = New Button()
        btnClear = New Button()
        lblStatusNew = New Label()
        pnlAction = New Panel()
        lblTotalRecords = New Label()
        btnExport = New Button()
        btnImport = New Button()
        dgvTeams = New DataGridView()
        pnlFooter = New Panel()
        txtSearch = New TextBox()
        btnSearch = New Button()
        btnClearSearch = New Button()
        btnDeleteAll = New Button()
        pnlInput.SuspendLayout()
        CType(picTeam, ComponentModel.ISupportInitialize).BeginInit()
        pnlAction.SuspendLayout()
        CType(dgvTeams, ComponentModel.ISupportInitialize).BeginInit()
        pnlFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.Dock = DockStyle.Top
        lblTitle.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblTitle.Location = New Point(0, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(1122, 40)
        lblTitle.TabIndex = 4
        lblTitle.Text = "Team Entries"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlInput
        ' 
        pnlInput.BackColor = Color.FromArgb(CByte(242), CByte(242), CByte(242))
        pnlInput.Controls.Add(lblTeam)
        pnlInput.Controls.Add(txtTeam)
        pnlInput.Controls.Add(lblInfo)
        pnlInput.Controls.Add(txtTeamInfo)
        pnlInput.Controls.Add(chkUseFlag)
        pnlInput.Controls.Add(lblCountry)
        pnlInput.Controls.Add(cmbCountry)
        pnlInput.Controls.Add(lblTeamPic)
        pnlInput.Controls.Add(picTeam)
        pnlInput.Controls.Add(btnSelect)
        pnlInput.Controls.Add(btnAdd)
        pnlInput.Controls.Add(btnClear)
        pnlInput.Controls.Add(lblStatusNew)
        pnlInput.Dock = DockStyle.Top
        pnlInput.Location = New Point(0, 40)
        pnlInput.Name = "pnlInput"
        pnlInput.Size = New Size(1122, 145)
        pnlInput.TabIndex = 3
        ' 
        ' lblTeam
        ' 
        lblTeam.AutoSize = True
        lblTeam.Location = New Point(40, 15)
        lblTeam.Name = "lblTeam"
        lblTeam.Size = New Size(61, 25)
        lblTeam.TabIndex = 0
        lblTeam.Text = "Team*"
        ' 
        ' txtTeam
        ' 
        txtTeam.Location = New Point(120, 12)
        txtTeam.Name = "txtTeam"
        txtTeam.Size = New Size(320, 31)
        txtTeam.TabIndex = 1
        ' 
        ' lblInfo
        ' 
        lblInfo.AutoSize = True
        lblInfo.Location = New Point(20, 45)
        lblInfo.Name = "lblInfo"
        lblInfo.Size = New Size(90, 25)
        lblInfo.TabIndex = 2
        lblInfo.Text = "Team Info"
        ' 
        ' txtTeamInfo
        ' 
        txtTeamInfo.Location = New Point(120, 42)
        txtTeamInfo.Name = "txtTeamInfo"
        txtTeamInfo.Size = New Size(320, 31)
        txtTeamInfo.TabIndex = 3
        ' 
        ' chkUseFlag
        ' 
        chkUseFlag.AutoSize = True
        chkUseFlag.Location = New Point(120, 75)
        chkUseFlag.Name = "chkUseFlag"
        chkUseFlag.Size = New Size(229, 29)
        chkUseFlag.TabIndex = 4
        chkUseFlag.Text = "Use Country Flag (Logo)"
        ' 
        ' lblCountry
        ' 
        lblCountry.AutoSize = True
        lblCountry.Location = New Point(45, 105)
        lblCountry.Name = "lblCountry"
        lblCountry.Size = New Size(75, 25)
        lblCountry.TabIndex = 5
        lblCountry.Text = "Country"
        ' 
        ' cmbCountry
        ' 
        cmbCountry.Location = New Point(120, 102)
        cmbCountry.Name = "cmbCountry"
        cmbCountry.Size = New Size(200, 33)
        cmbCountry.TabIndex = 6
        ' 
        ' lblTeamPic
        ' 
        lblTeamPic.AutoSize = True
        lblTeamPic.Location = New Point(475, 4)
        lblTeamPic.Name = "lblTeamPic"
        lblTeamPic.Size = New Size(111, 25)
        lblTeamPic.TabIndex = 7
        lblTeamPic.Text = "Team Picture"
        ' 
        ' picTeam
        ' 
        picTeam.BorderStyle = BorderStyle.FixedSingle
        picTeam.Location = New Point(475, 25)
        picTeam.Name = "picTeam"
        picTeam.Size = New Size(75, 75)
        picTeam.SizeMode = PictureBoxSizeMode.Zoom
        picTeam.TabIndex = 8
        picTeam.TabStop = False
        ' 
        ' btnSelect
        ' 
        btnSelect.Location = New Point(475, 105)
        btnSelect.Name = "btnSelect"
        btnSelect.Size = New Size(75, 34)
        btnSelect.TabIndex = 9
        btnSelect.Text = "Select"
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.DeepSkyBlue
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Location = New Point(580, 20)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(160, 35)
        btnAdd.TabIndex = 10
        btnAdd.Text = "Add"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.LightGreen
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Location = New Point(580, 60)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(160, 35)
        btnClear.TabIndex = 11
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' lblStatusNew
        ' 
        lblStatusNew.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblStatusNew.Location = New Point(580, 100)
        lblStatusNew.Name = "lblStatusNew"
        lblStatusNew.Size = New Size(160, 25)
        lblStatusNew.TabIndex = 12
        lblStatusNew.Text = "NEW"
        lblStatusNew.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlAction
        ' 
        pnlAction.BackColor = Color.WhiteSmoke
        pnlAction.BorderStyle = BorderStyle.FixedSingle
        pnlAction.Controls.Add(lblTotalRecords)
        pnlAction.Controls.Add(btnExport)
        pnlAction.Controls.Add(btnImport)
        pnlAction.Dock = DockStyle.Top
        pnlAction.Location = New Point(0, 185)
        pnlAction.Name = "pnlAction"
        pnlAction.Size = New Size(1122, 52)
        pnlAction.TabIndex = 2
        ' 
        ' lblTotalRecords
        ' 
        lblTotalRecords.AutoSize = True
        lblTotalRecords.Location = New Point(10, 12)
        lblTotalRecords.Name = "lblTotalRecords"
        lblTotalRecords.Size = New Size(141, 25)
        lblTotalRecords.TabIndex = 0
        lblTotalRecords.Text = "Total Records : 0"
        ' 
        ' btnExport
        ' 
        btnExport.Location = New Point(442, 5)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(201, 38)
        btnExport.TabIndex = 1
        btnExport.Text = "Export to Excel 🗃"
        ' 
        ' btnImport
        ' 
        btnImport.Location = New Point(649, 7)
        btnImport.Name = "btnImport"
        btnImport.Size = New Size(197, 38)
        btnImport.TabIndex = 2
        btnImport.Text = "Import from Excel 🗃"
        ' 
        ' dgvTeams
        ' 
        dgvTeams.AllowUserToAddRows = False
        dgvTeams.BackgroundColor = Color.White
        dgvTeams.ColumnHeadersHeight = 34
        dgvTeams.Dock = DockStyle.Fill
        dgvTeams.Location = New Point(0, 237)
        dgvTeams.Name = "dgvTeams"
        dgvTeams.RowHeadersVisible = False
        dgvTeams.RowHeadersWidth = 62
        dgvTeams.Size = New Size(1122, 318)
        dgvTeams.TabIndex = 0
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.Crimson
        pnlFooter.Controls.Add(txtSearch)
        pnlFooter.Controls.Add(btnSearch)
        pnlFooter.Controls.Add(btnClearSearch)
        pnlFooter.Controls.Add(btnDeleteAll)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(0, 555)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(1122, 45)
        pnlFooter.TabIndex = 1
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(15, 12)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(250, 31)
        txtSearch.TabIndex = 0
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(270, 11)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(30, 25)
        btnSearch.TabIndex = 1
        btnSearch.Text = "🔍"
        ' 
        ' btnClearSearch
        ' 
        btnClearSearch.Location = New Point(305, 11)
        btnClearSearch.Name = "btnClearSearch"
        btnClearSearch.Size = New Size(30, 25)
        btnClearSearch.TabIndex = 2
        btnClearSearch.Text = "✖"
        ' 
        ' btnDeleteAll
        ' 
        btnDeleteAll.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        btnDeleteAll.FlatStyle = FlatStyle.Flat
        btnDeleteAll.Location = New Point(670, 8)
        btnDeleteAll.Name = "btnDeleteAll"
        btnDeleteAll.Size = New Size(110, 30)
        btnDeleteAll.TabIndex = 3
        btnDeleteAll.Text = "Delete All"
        btnDeleteAll.UseVisualStyleBackColor = False
        ' 
        ' TeamEntry
        ' 
        ClientSize = New Size(1122, 600)
        Controls.Add(dgvTeams)
        Controls.Add(pnlFooter)
        Controls.Add(pnlAction)
        Controls.Add(pnlInput)
        Controls.Add(lblTitle)
        Name = "TeamEntry"
        Text = "Team Entries"
        pnlInput.ResumeLayout(False)
        pnlInput.PerformLayout()
        CType(picTeam, ComponentModel.ISupportInitialize).EndInit()
        pnlAction.ResumeLayout(False)
        pnlAction.PerformLayout()
        CType(dgvTeams, ComponentModel.ISupportInitialize).EndInit()
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' DEKLARASI MEMBER (Wajib ada di paling bawah file Designer)
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlInput As System.Windows.Forms.Panel
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents txtTeam As System.Windows.Forms.TextBox
    Friend WithEvents txtTeamInfo As System.Windows.Forms.TextBox
    Friend WithEvents chkUseFlag As System.Windows.Forms.CheckBox
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents cmbCountry As System.Windows.Forms.ComboBox
    Friend WithEvents lblTeamPic As System.Windows.Forms.Label
    Friend WithEvents picTeam As System.Windows.Forms.PictureBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lblStatusNew As System.Windows.Forms.Label
    Friend WithEvents pnlAction As System.Windows.Forms.Panel
    Friend WithEvents lblTotalRecords As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents dgvTeams As System.Windows.Forms.DataGridView
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClearSearch As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button

End Class