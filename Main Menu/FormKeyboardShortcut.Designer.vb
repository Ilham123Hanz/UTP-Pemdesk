<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormKeyboardShortcut
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
        pnlStatus = New Panel()
        lblCurrentStatus = New Label()
        lblStatusValue = New Label()
        lblTurnOff = New Label()
        btnToggle = New Button()
        lvShortcuts = New ListView()
        colAction = New ColumnHeader()
        colShortcut = New ColumnHeader()
        btnChange = New Button()
        btnRemove = New Button()
        btnSave = New Button()
        picKeyboard = New PictureBox()
        btnReset = New Button()
        lblCurrentAction = New Label()
        txtCurrentAction = New TextBox()
        pnlStatus.SuspendLayout()
        CType(picKeyboard, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlStatus (Header Hitam)
        ' 
        pnlStatus.BackColor = Color.FromArgb(CByte(33), CByte(33), CByte(33))
        pnlStatus.Controls.Add(lblCurrentStatus)
        pnlStatus.Controls.Add(lblStatusValue)
        pnlStatus.Controls.Add(lblTurnOff)
        pnlStatus.Controls.Add(btnToggle)
        pnlStatus.Dock = DockStyle.Top
        pnlStatus.Location = New Point(0, 0)
        pnlStatus.Name = "pnlStatus"
        pnlStatus.Size = New Size(710, 50)
        pnlStatus.TabIndex = 0
        ' 
        ' lblCurrentStatus
        ' 
        lblCurrentStatus.AutoSize = True
        lblCurrentStatus.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        lblCurrentStatus.ForeColor = Color.White
        lblCurrentStatus.Location = New Point(12, 14)
        lblCurrentStatus.Name = "lblCurrentStatus"
        lblCurrentStatus.Size = New Size(100, 19)
        lblCurrentStatus.TabIndex = 0
        lblCurrentStatus.Text = "Current Status"
        ' 
        ' lblStatusValue (Teks Cyan)
        ' 
        lblStatusValue.AutoSize = True
        lblStatusValue.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblStatusValue.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(239))
        lblStatusValue.Location = New Point(135, 11)
        lblStatusValue.Name = "lblStatusValue"
        lblStatusValue.Size = New Size(41, 25)
        lblStatusValue.TabIndex = 1
        lblStatusValue.Text = "ON"
        ' 
        ' lblTurnOff
        ' 
        lblTurnOff.AutoSize = True
        lblTurnOff.Font = New Font("Segoe UI", 10.0F)
        lblTurnOff.ForeColor = Color.White
        lblTurnOff.Location = New Point(570, 15)
        lblTurnOff.Name = "lblTurnOff"
        lblTurnOff.Size = New Size(57, 19)
        lblTurnOff.TabIndex = 2
        lblTurnOff.Text = "Turn off"
        ' 
        ' btnToggle (Switch Biru)
        ' 
        btnToggle.BackColor = Color.FromArgb(CByte(0), CByte(120), CByte(215))
        btnToggle.FlatAppearance.BorderSize = 0
        btnToggle.FlatStyle = FlatStyle.Flat
        btnToggle.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        btnToggle.ForeColor = Color.White
        btnToggle.Location = New Point(640, 10)
        btnToggle.Name = "btnToggle"
        btnToggle.Size = New Size(50, 30)
        btnToggle.TabIndex = 3
        btnToggle.Text = "●"
        btnToggle.TextAlign = ContentAlignment.MiddleRight
        btnToggle.UseVisualStyleBackColor = False
        ' 
        ' lvShortcuts (Tabel Utama)
        ' 
        lvShortcuts.BorderStyle = BorderStyle.FixedSingle
        lvShortcuts.Columns.AddRange(New ColumnHeader() {colAction, colShortcut})
        lvShortcuts.Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Bold)
        lvShortcuts.FullRowSelect = True
        lvShortcuts.HeaderStyle = ColumnHeaderStyle.None
        lvShortcuts.Location = New Point(15, 65)
        lvShortcuts.MultiSelect = False
        lvShortcuts.Name = "lvShortcuts"
        lvShortcuts.OwnerDraw = True
        lvShortcuts.Size = New Size(480, 360)
        lvShortcuts.TabIndex = 1
        lvShortcuts.UseCompatibleStateImageBehavior = False
        lvShortcuts.View = View.Details
        ' 
        ' colAction & colShortcut
        ' 
        colAction.Width = 280
        colShortcut.Width = 180
        ' 
        ' btnChange
        ' 
        btnChange.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnChange.Location = New Point(515, 65)
        btnChange.Name = "btnChange"
        btnChange.Size = New Size(170, 35)
        btnChange.TabIndex = 2
        btnChange.Text = "Change  ✏"
        btnChange.UseVisualStyleBackColor = True
        ' 
        ' btnRemove
        ' 
        btnRemove.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnRemove.Location = New Point(515, 110)
        btnRemove.Name = "btnRemove"
        btnRemove.Size = New Size(170, 35)
        btnRemove.TabIndex = 3
        btnRemove.Text = "Romove  🚫"
        btnRemove.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.White
        btnSave.Enabled = False
        btnSave.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnSave.ForeColor = Color.DarkGray
        btnSave.Location = New Point(515, 170)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(170, 35)
        btnSave.TabIndex = 4
        btnSave.Text = "Save  💾"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' picKeyboard
        ' 
        picKeyboard.Location = New Point(545, 230)
        picKeyboard.Name = "picKeyboard"
        picKeyboard.Size = New Size(110, 80)
        picKeyboard.SizeMode = PictureBoxSizeMode.Zoom
        picKeyboard.TabIndex = 5
        picKeyboard.TabStop = False
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.FromArgb(CByte(245), CByte(140), CByte(100))
        btnReset.FlatAppearance.BorderSize = 0
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        btnReset.ForeColor = Color.White
        btnReset.Location = New Point(515, 380)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(170, 42)
        btnReset.TabIndex = 6
        btnReset.Text = "Reset"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' lblCurrentAction
        ' 
        lblCurrentAction.AutoSize = True
        lblCurrentAction.Location = New Point(15, 440)
        lblCurrentAction.Name = "lblCurrentAction"
        lblCurrentAction.Size = New Size(103, 15)
        lblCurrentAction.TabIndex = 7
        lblCurrentAction.Text = "Current Action :  –"
        ' 
        ' txtCurrentAction
        ' 
        txtCurrentAction.BackColor = Color.White
        txtCurrentAction.Location = New Point(15, 465)
        txtCurrentAction.Multiline = True
        txtCurrentAction.Name = "txtCurrentAction"
        txtCurrentAction.ReadOnly = True
        txtCurrentAction.Size = New Size(670, 60)
        txtCurrentAction.TabIndex = 8
        ' 
        ' FormKeyboardShortcut
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        ClientSize = New Size(710, 550)
        Controls.Add(txtCurrentAction)
        Controls.Add(lblCurrentAction)
        Controls.Add(btnReset)
        Controls.Add(picKeyboard)
        Controls.Add(btnSave)
        Controls.Add(btnRemove)
        Controls.Add(btnChange)
        Controls.Add(lvShortcuts)
        Controls.Add(pnlStatus)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FormKeyboardShortcut"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Keyboard Shortcut Setup"
        pnlStatus.ResumeLayout(False)
        pnlStatus.PerformLayout()
        CType(picKeyboard, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    ' Deklarasi Friend tetap sama di bawah...
    Friend WithEvents pnlStatus As Panel
    Friend WithEvents lblCurrentStatus As Label
    Friend WithEvents lblStatusValue As Label
    Friend WithEvents lblTurnOff As Label
    Friend WithEvents btnToggle As Button
    Friend WithEvents lvShortcuts As ListView
    Friend WithEvents colAction As ColumnHeader
    Friend WithEvents colShortcut As ColumnHeader
    Friend WithEvents btnChange As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents picKeyboard As PictureBox
    Friend WithEvents btnReset As Button
    Friend WithEvents lblCurrentAction As Label
    Friend WithEvents txtCurrentAction As TextBox
End Class