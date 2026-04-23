<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListOfCompetitor
    Inherits System.Windows.Forms.Form

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
        PanelLeft = New Panel()
        ListBoxTeam = New ListBox()
        PanelBottomLeft = New Panel()
        BtnClear = New Button()
        PanelLeftHeader = New Panel()
        LabelTeam = New Label()
        PanelRight = New Panel()
        DataGridView1 = New DataGridView()
        PanelBottomRight = New Panel()
        TxtSearch = New TextBox()
        BtnSearch = New Button()
        BtnClearSearch = New Button()
        BtnClose = New Button()
        BtnSelect = New Button()
        PanelLeft.SuspendLayout()
        PanelBottomLeft.SuspendLayout()
        PanelLeftHeader.SuspendLayout()
        PanelRight.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        PanelBottomRight.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelLeft
        ' 
        PanelLeft.Controls.Add(ListBoxTeam)
        PanelLeft.Controls.Add(PanelBottomLeft)
        PanelLeft.Controls.Add(PanelLeftHeader)
        PanelLeft.Dock = DockStyle.Left
        PanelLeft.Location = New Point(0, 0)
        PanelLeft.Name = "PanelLeft"
        PanelLeft.Size = New Size(200, 493)
        PanelLeft.TabIndex = 1
        ' 
        ' ListBoxTeam
        ' 
        ListBoxTeam.BorderStyle = BorderStyle.FixedSingle
        ListBoxTeam.BackColor = Color.Gainsboro
        ListBoxTeam.BorderStyle = BorderStyle.None
        ListBoxTeam.Dock = DockStyle.Fill
        ListBoxTeam.Font = New Font("Segoe UI", 10.0F)
        ListBoxTeam.Location = New Point(0, 40)
        ListBoxTeam.Name = "ListBoxTeam"
        ListBoxTeam.Size = New Size(200, 403)
        ListBoxTeam.TabIndex = 0
        ' 
        ' PanelBottomLeft
        ' 
        PanelBottomLeft.Controls.Add(BtnClear)
        PanelBottomLeft.Dock = DockStyle.Bottom
        PanelBottomLeft.Location = New Point(0, 443)
        PanelBottomLeft.Name = "PanelBottomLeft"
        PanelBottomLeft.Size = New Size(200, 50)
        PanelBottomLeft.TabIndex = 1
        ' 
        ' BtnClear
        ' 
        BtnClear.BackColor = Color.LightGreen
        BtnClear.Dock = DockStyle.Fill
        BtnClear.Location = New Point(0, 0)
        BtnClear.Name = "BtnClear"
        BtnClear.Size = New Size(200, 50)
        BtnClear.TabIndex = 0
        BtnClear.Text = "Clear Select Team"
        BtnClear.UseVisualStyleBackColor = False
        ' 
        ' PanelLeftHeader
        ' 
        PanelLeftHeader.BackColor = Color.Crimson
        PanelLeftHeader.Controls.Add(LabelTeam)
        PanelLeftHeader.Dock = DockStyle.Top
        PanelLeftHeader.Location = New Point(0, 0)
        PanelLeftHeader.Name = "PanelLeftHeader"
        PanelLeftHeader.Size = New Size(200, 40)
        PanelLeftHeader.TabIndex = 2
        ' 
        ' LabelTeam
        ' 
        LabelTeam.Dock = DockStyle.Fill
        LabelTeam.ForeColor = Color.White
        LabelTeam.Location = New Point(0, 0)
        LabelTeam.Name = "LabelTeam"
        LabelTeam.Size = New Size(200, 40)
        LabelTeam.TabIndex = 0
        LabelTeam.Text = "Team"
        LabelTeam.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PanelRight
        ' 
        PanelRight.Controls.Add(DataGridView1)
        PanelRight.Controls.Add(PanelBottomRight)
        PanelRight.Dock = DockStyle.Fill
        PanelRight.Location = New Point(200, 0)
        PanelRight.Name = "PanelRight"
        PanelRight.Size = New Size(645, 493)
        PanelRight.TabIndex = 0
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.BorderStyle = BorderStyle.FixedSingle
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single
        DataGridView1.GridColor = Color.Black
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersHeight = 29
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(645, 433)
        DataGridView1.TabIndex = 0
        ' 
        ' PanelBottomRight
        ' 
        PanelBottomRight.BackColor = Color.Crimson
        PanelBottomRight.Controls.Add(TxtSearch)
        PanelBottomRight.Controls.Add(BtnSearch)
        PanelBottomRight.Controls.Add(BtnClearSearch)
        PanelBottomRight.Controls.Add(BtnClose)
        PanelBottomRight.Controls.Add(BtnSelect)
        PanelBottomRight.Dock = DockStyle.Bottom
        PanelBottomRight.Location = New Point(0, 433)
        PanelBottomRight.Name = "PanelBottomRight"
        PanelBottomRight.Size = New Size(645, 60)
        PanelBottomRight.TabIndex = 1
        ' 
        ' TxtSearch
        ' 
        TxtSearch.Location = New Point(10, 18)
        TxtSearch.Name = "TxtSearch"
        TxtSearch.Size = New Size(200, 27)
        TxtSearch.TabIndex = 0
        ' 
        ' BtnSearch
        ' 
        BtnSearch.Location = New Point(220, 15)
        BtnSearch.Name = "BtnSearch"
        BtnSearch.Size = New Size(40, 30)
        BtnSearch.TabIndex = 1
        BtnSearch.Text = "🔍"
        ' 
        ' BtnClearSearch
        ' 
        BtnClearSearch.Location = New Point(270, 15)
        BtnClearSearch.Name = "BtnClearSearch"
        BtnClearSearch.Size = New Size(40, 30)
        BtnClearSearch.TabIndex = 2
        BtnClearSearch.Text = "X"
        ' 
        ' BtnClose
        ' 
        BtnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnClose.BackColor = Color.Orange
        BtnClose.Location = New Point(420, 12)
        BtnClose.Name = "BtnClose"
        BtnClose.Size = New Size(90, 30)
        BtnClose.TabIndex = 3
        BtnClose.Text = "Close"
        BtnClose.UseVisualStyleBackColor = False
        ' 
        ' BtnSelect
        ' 
        BtnSelect.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnSelect.BackColor = Color.DeepSkyBlue
        BtnSelect.Location = New Point(529, 12)
        BtnSelect.Name = "BtnSelect"
        BtnSelect.Size = New Size(90, 30)
        BtnSelect.TabIndex = 4
        BtnSelect.Text = "Select"
        BtnSelect.UseVisualStyleBackColor = False
        ' 
        ' ListOfCompetitor
        ' 
        ClientSize = New Size(845, 493)
        Controls.Add(PanelRight)
        Controls.Add(PanelLeft)
        Name = "ListOfCompetitor"
        Text = "List of Competitors"
        PanelLeft.ResumeLayout(False)
        PanelBottomLeft.ResumeLayout(False)
        PanelLeftHeader.ResumeLayout(False)
        PanelRight.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        PanelBottomRight.ResumeLayout(False)
        PanelBottomRight.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents PanelLeft As Panel
    Friend WithEvents ListBoxTeam As ListBox
    Friend WithEvents PanelLeftHeader As Panel
    Friend WithEvents LabelTeam As Label
    Friend WithEvents PanelBottomLeft As Panel
    Friend WithEvents BtnClear As Button

    Friend WithEvents PanelRight As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PanelBottomRight As Panel
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSelect As Button
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents BtnSearch As Button
    Friend WithEvents BtnClearSearch As Button
End Class