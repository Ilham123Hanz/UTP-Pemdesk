Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmScoreboardSetting
    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()

        ' ===== FORM SETTINGS =====
        Me.ClientSize = New Size(1060, 840)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmScoreboardSetting"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Scoreboard Setting"
        Me.BackColor = Color.FromArgb(240, 240, 240)
        Me.Font = New Font("Segoe UI", 9)

        ' Root Layout
        Dim root As New TableLayoutPanel()
        root.Dock = DockStyle.Fill
        root.ColumnCount = 1
        root.RowCount = 2
        root.Padding = New Padding(10)
        root.RowStyles.Add(New RowStyle(SizeType.Absolute, 115))
        root.RowStyles.Add(New RowStyle(SizeType.Percent, 100))

        root.Controls.Add(BuildTopHeader(), 0, 0)
        root.Controls.Add(BuildMainTab(), 0, 1)

        Me.Controls.Add(root)
        Me.ResumeLayout(False)
    End Sub

    ' --- HEADER AREA ---
    Private Function BuildTopHeader() As TableLayoutPanel
        Dim t As New TableLayoutPanel()
        t.Dock = DockStyle.Fill
        t.ColumnCount = 3
        t.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3))
        t.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3))
        t.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.4))

        t.Controls.Add(MakeFontGroup("Player Name", "Consolas", False, Color.White), 0, 0)
        t.Controls.Add(MakeFontGroup("Team", "Arial", True, Color.Yellow), 1, 0)
        t.Controls.Add(MakeFontGroup("Team Info", "Calibri", True, Color.White), 2, 0)
        Return t
    End Function

    Private Function MakeFontGroup(title As String, defFont As String, isBold As Boolean, clr As Color) As GroupBox
        Dim g As New GroupBox() : g.Text = title : g.Dock = DockStyle.Fill : g.Margin = New Padding(3)
        Dim lblF As New Label() : lblF.Text = "Font" : lblF.Location = New Point(10, 25) : lblF.AutoSize = True
        Dim cb As ComboBox = MakeCombo(defFont) : cb.Location = New Point(75, 22) : cb.Width = 140
        Dim lblC As New Label() : lblC.Text = "Font Color" : lblC.Location = New Point(10, 58) : lblC.AutoSize = True
        Dim cp As Panel = MakeColorPicker(clr) : cp.Location = New Point(75, 54)
        Dim chk As New CheckBox() : chk.Text = "Bold" : chk.Checked = isBold : chk.Location = New Point(225, 56) : chk.AutoSize = True
        g.Controls.AddRange(New Control() {lblF, cb, lblC, cp, chk})
        Return g
    End Function

    ' --- MAIN TAB (KUMITE) ---
    Private Function BuildMainTab() As TabControl
        Dim tc As New TabControl() : tc.Dock = DockStyle.Fill
        Dim pg As New TabPage("KUMITE") : pg.BackColor = Color.White

        Dim split As New TableLayoutPanel()
        split.Dock = DockStyle.Fill : split.ColumnCount = 2 : split.Padding = New Padding(5)
        split.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 500))
        split.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))

        ' --- LEFT COLUMN ---
        Dim left As New FlowLayoutPanel() : left.Dock = DockStyle.Fill : left.FlowDirection = FlowDirection.TopDown : left.WrapContents = False

        ' Penalties
        Dim gpP As New GroupBox() : gpP.Text = "Penalties" : gpP.Size = New Size(490, 130)
        gpP.Controls.Add(BuildPenaltySub("Penalties - AKA (Kumite)", Color.Crimson, 5))
        gpP.Controls.Add(BuildPenaltySub("Penalties - AO (Kumite)", Color.DodgerBlue, 245))

        ' Kumite Timer & Score
        Dim gpT As New GroupBox() : gpT.Text = "Kumite Timer & Score" : gpT.Size = New Size(490, 95)
        Dim lblT1 As New Label() : lblT1.Text = "Font (Timer)" : lblT1.Location = New Point(10, 25) : lblT1.AutoSize = True
        Dim cbT1 As ComboBox = MakeCombo("Arial") : cbT1.Location = New Point(100, 22) : cbT1.Width = 150
        Dim chkT1 As New CheckBox() : chkT1.Text = "Bold" : chkT1.Checked = True : chkT1.Location = New Point(260, 24)
        Dim lblT2 As New Label() : lblT2.Text = "Font (Score)" : lblT2.Location = New Point(10, 55) : lblT2.AutoSize = True
        Dim cbT2 As ComboBox = MakeCombo("Microsoft Sans S") : cbT2.Location = New Point(100, 52) : cbT2.Width = 150
        Dim chkT2 As New CheckBox() : chkT2.Text = "Bold" : chkT2.Checked = True : chkT2.Location = New Point(260, 54)
        gpT.Controls.AddRange(New Control() {lblT1, cbT1, chkT1, lblT2, cbT2, chkT2})

        ' Kumite Match Detail (LENGKAP)
        Dim gpD As New GroupBox() : gpD.Text = "Kumite Match Detail" : gpD.Size = New Size(490, 140)
        Dim lblDf As New Label() : lblDf.Text = "Font" : lblDf.Location = New Point(10, 25) : lblDf.AutoSize = True
        Dim cbDf As ComboBox = MakeCombo("Microsoft Sans Serif") : cbDf.Location = New Point(100, 22) : cbDf.Width = 180
        Dim lblDc As New Label() : lblDc.Text = "Font Color" : lblDc.Location = New Point(10, 55) : lblDc.AutoSize = True
        Dim cpD As Panel = MakeColorPicker(Color.Yellow) : cpD.Location = New Point(100, 52)
        Dim chkDb As New CheckBox() : chkDb.Text = "Bold" : chkDb.Checked = True : chkDb.Location = New Point(230, 54)
        Dim chkD1 As New CheckBox() : chkD1.Text = "Display Score Popup" : chkD1.Checked = True : chkD1.Location = New Point(10, 85) : chkD1.AutoSize = True
        Dim chkD2 As New CheckBox() : chkD2.Text = "Knocked Out Countdown" : chkD2.Checked = True : chkD2.Location = New Point(10, 105) : chkD2.AutoSize = True
        gpD.Controls.AddRange(New Control() {lblDf, cbDf, lblDc, cpD, chkDb, chkD1, chkD2})

        ' Match Round-Pool Info
        Dim gpR As New GroupBox() : gpR.Size = New Size(490, 200)
        AddRoundInfo(gpR)

        left.Controls.AddRange(New Control() {gpP, gpT, gpD, gpR})

        ' --- RIGHT COLUMN ---
        Dim right As New FlowLayoutPanel() : right.Dock = DockStyle.Fill : right.FlowDirection = FlowDirection.TopDown : right.WrapContents = False

        ' Horizontal Mode (LENGKAP)
        Dim gpH As New GroupBox() : gpH.Text = "Horizontal Mode (Left-Right)" : gpH.Size = New Size(520, 110)
        Dim lblHa As New Label() : lblHa.Text = "Player Name Alignment" : lblHa.Location = New Point(10, 25) : lblHa.AutoSize = True
        Dim cbHa As ComboBox = MakeCombo("Center") : cbHa.Location = New Point(160, 22) : cbHa.Width = 180
        Dim lblHm As New Label() : lblHm.Text = "Score Color Mode" : lblHm.Location = New Point(10, 60) : lblHm.AutoSize = True
        Dim cbHm As ComboBox = MakeCombo("Top Darken") : cbHm.Location = New Point(160, 57) : cbHm.Width = 180
        ' Preview 3-2
        Dim p3 As New Label() : p3.Text = "3" : p3.BackColor = Color.Crimson : p3.ForeColor = Color.White : p3.Size = New Size(30, 30) : p3.Location = New Point(350, 55) : p3.TextAlign = ContentAlignment.MiddleCenter : p3.Font = New Font("Arial", 12, FontStyle.Bold)
        Dim p2 As New Label() : p2.Text = "2" : p2.BackColor = Color.DodgerBlue : p2.ForeColor = Color.White : p2.Size = New Size(30, 30) : p2.Location = New Point(382, 55) : p2.TextAlign = ContentAlignment.MiddleCenter : p2.Font = New Font("Arial", 12, FontStyle.Bold)
        gpH.Controls.AddRange(New Control() {lblHa, cbHa, lblHm, cbHm, p3, p2})

        ' Alert
        Dim gpA As New GroupBox() : gpA.Text = "Alert" : gpA.Size = New Size(520, 295)
        FillAlerts(gpA)

        ' Bottom Right (Logo & Buttons)
        Dim pnlBottom As New Panel() : pnlBottom.Size = New Size(520, 180)
        FillBottomRight(pnlBottom)

        right.Controls.AddRange(New Control() {gpH, gpA, pnlBottom})

        split.Controls.Add(left, 0, 0)
        split.Controls.Add(right, 1, 0)
        pg.Controls.Add(split) : tc.TabPages.Add(pg)
        Return tc
    End Function

    ' --- HELPERS ---
    Private Function MakeColorPicker(clr As Color) As Panel
        Dim p As New Panel() : p.Size = New Size(120, 28) : p.BorderStyle = BorderStyle.FixedSingle : p.BackColor = clr
        Dim btn As New Button() : btn.Text = "Change" : btn.Size = New Size(70, 22) : btn.Location = New Point(46, 2)
        btn.BackColor = Color.White : btn.FlatStyle = FlatStyle.Flat : btn.Font = New Font("Segoe UI", 7)
        AddHandler btn.Click, Sub()
                                  Dim cd As New ColorDialog() : cd.Color = p.BackColor
                                  If cd.ShowDialog() = DialogResult.OK Then p.BackColor = cd.Color
                              End Sub
        p.Controls.Add(btn)
        Return p
    End Function

    Private Function BuildPenaltySub(title As String, clr As Color, x As Integer) As Panel
        Dim p As New Panel() : p.Location = New Point(x, 20) : p.Size = New Size(235, 100)
        Dim lblT As New Label() : lblT.Text = title : lblT.Font = New Font("Segoe UI", 8.5, FontStyle.Bold) : lblT.Location = New Point(5, 0) : lblT.AutoSize = True
        Dim lblB As New Label() : lblB.Text = "BackColor" : lblB.Location = New Point(5, 28) : lblB.AutoSize = True
        Dim cp1 As Panel = MakeColorPicker(clr) : cp1.Location = New Point(100, 25)
        Dim lblS As New Label() : lblS.Text = "Selected" & vbCrLf & "Text Color" : lblS.Location = New Point(5, 58) : lblS.AutoSize = True
        Dim cp2 As Panel = MakeColorPicker(Color.White) : cp2.Location = New Point(100, 60)
        p.Controls.AddRange(New Control() {lblT, lblB, cp1, lblS, cp2})
        Return p
    End Function

    Private Sub AddRoundInfo(gb As GroupBox)
        Dim lblM As New Label() : lblM.Text = "Match Round-Pool Info" : lblM.Font = New Font("Segoe UI", 9, FontStyle.Bold) : lblM.Location = New Point(10, 18) : lblM.AutoSize = True
        Dim rbY As New RadioButton() : rbY.Text = "Yes" : rbY.Checked = True : rbY.Location = New Point(160, 15) : rbY.Width = 50
        Dim rbN As New RadioButton() : rbN.Text = "No" : rbN.Location = New Point(210, 15) : rbN.Width = 50
        Dim pG As New Panel() : pG.BackColor = Color.FromArgb(230, 230, 230) : pG.Location = New Point(10, 45) : pG.Size = New Size(470, 110)
        Dim rbF As New RadioButton() : rbF.Text = "Full (ex :Round of 16)" : rbF.Checked = True : rbF.Location = New Point(10, 10) : rbF.Width = 150
        Dim rbS As New RadioButton() : rbS.Text = "Short (ex :R16)" : rbS.Location = New Point(170, 10) : rbS.Width = 120
        Dim rbNon As New RadioButton() : rbNon.Text = "None" : rbNon.Location = New Point(300, 10) : rbNon.Width = 70
        Dim lblSep As New Label() : lblSep.Text = "Separator" : lblSep.Font = New Font("Segoe UI", 8, FontStyle.Bold) : lblSep.Location = New Point(10, 45)
        Dim r1 As New RadioButton() : r1.Text = "-" : r1.Checked = True : r1.Location = New Point(10, 65) : r1.Width = 35
        Dim r2 As New RadioButton() : r2.Text = "|" : r2.Location = New Point(50, 65) : r2.Width = 35
        Dim r3 As New RadioButton() : r3.Text = "/" : r3.Location = New Point(90, 65) : r3.Width = 35
        Dim r4 As New RadioButton() : r4.Text = "Space" : r4.Location = New Point(130, 65) : r4.Width = 60
        Dim lblPol As New Label() : lblPol.Text = "Pool Info" : lblPol.Font = New Font("Segoe UI", 8, FontStyle.Bold) : lblPol.Location = New Point(250, 45)
        Dim p1 As New RadioButton() : p1.Text = "Pool 1" : p1.Checked = True : p1.Location = New Point(250, 65) : p1.Width = 70
        Dim p2 As New RadioButton() : p2.Text = "P1" : p2.Location = New Point(330, 65) : p2.Width = 50
        Dim p3 As New RadioButton() : p3.Text = "None" : p3.Location = New Point(390, 65) : p3.Width = 60
        pG.Controls.AddRange(New Control() {rbF, rbS, rbNon, lblSep, r1, r2, r3, r4, lblPol, p1, p2, p3})
        Dim lblPrv As New Label() : lblPrv.Text = "Preview" : lblPrv.Location = New Point(10, 168) : lblPrv.AutoSize = True
        Dim txtPrv As New TextBox() : txtPrv.Text = "Round of 16-Pool 1" : txtPrv.Location = New Point(80, 165) : txtPrv.Width = 380 : txtPrv.ReadOnly = True
        gb.Controls.AddRange(New Control() {lblM, rbY, rbN, pG, lblPrv, txtPrv})
    End Sub

    Private Sub FillAlerts(gb As GroupBox)
        Dim a() As String = {"End of Timer", "15 Second Timer", "Winner by Point", "Get Point", "Get Penalties", "Hantei", "Knocked Out", "VAR Alert", "Manual Alert"}
        Dim y As Integer = 22
        For Each s In a
            Dim lbl As New Label() : lbl.Text = s : lbl.Location = New Point(5, y + 3) : lbl.Size = New Size(100, 20) : lbl.TextAlign = ContentAlignment.MiddleRight
            Dim tx As New TextBox() : tx.Text = "C:\Yabinya_KarateScore..." : tx.Location = New Point(110, y) : tx.Width = 220
            Dim bS As New Button() : bS.Text = "Select" : bS.Location = New Point(335, y) : bS.Width = 55 : bS.BackColor = Color.White
            Dim bX As New Button() : bX.Text = "X" : bX.Location = New Point(395, y) : bX.Width = 25 : bX.BackColor = Color.White
            Dim bP As New Button() : bP.Text = "Play" : bP.Location = New Point(425, y) : bP.Width = 55 : bP.BackColor = Color.White
            gb.Controls.AddRange(New Control() {lbl, tx, bS, bX, bP})
            y += 28
        Next
    End Sub

    Private Sub FillBottomRight(p As Panel)
        Dim lblL As New Label() : lblL.Text = "Logo" : lblL.Location = New Point(10, 10) : lblL.AutoSize = True
        Dim pbL As New PictureBox() : pbL.BorderStyle = BorderStyle.FixedSingle : pbL.Size = New Size(70, 70) : pbL.Location = New Point(10, 30) : pbL.BackColor = Color.White
        Dim btnS As New Button() : btnS.Text = "Select" : btnS.Location = New Point(90, 30) : btnS.Size = New Size(80, 30) : btnS.BackColor = Color.White
        Dim btnR As New Button() : btnR.Text = "Remove" : btnR.Location = New Point(90, 65) : btnR.Size = New Size(80, 30) : btnR.BackColor = Color.White

        Dim pbUser As New PictureBox() : pbUser.Size = New Size(32, 32) : pbUser.Location = New Point(10, 115)
        pbUser.BorderStyle = BorderStyle.FixedSingle : pbUser.BackColor = Color.White
        Dim lblIcon As New Label() : lblIcon.Text = "👤" : lblIcon.Font = New Font("Segoe UI", 14)
        lblIcon.Dock = DockStyle.Fill : lblIcon.TextAlign = ContentAlignment.MiddleCenter
        pbUser.Controls.Add(lblIcon)

        Dim chkL As New CheckBox() : chkL.Text = "Show Competitor Picture" : chkL.Location = New Point(50, 115) : chkL.AutoSize = True
        Dim lblN As New Label() : lblN.Text = "(Display athlete image if available)" : lblN.Font = New Font("Segoe UI", 7) : lblN.Location = New Point(50, 135) : lblN.AutoSize = True : lblN.ForeColor = Color.Gray

        ' TOMBOL CLOSE & SAVE
        Dim btnClose As New Button() : btnClose.Text = "Close" : btnClose.Size = New Size(110, 35) : btnClose.Location = New Point(380, 80) : btnClose.BackColor = Color.White
        AddHandler btnClose.Click, Sub() Me.Close() ' FUNGSI CLOSE

        Dim btnSave As New Button() : btnSave.Text = "Save" : btnSave.Size = New Size(110, 35) : btnSave.Location = New Point(380, 125) : btnSave.BackColor = Color.White

        p.Controls.AddRange(New Control() {lblL, pbL, btnS, btnR, pbUser, chkL, lblN, btnClose, btnSave})
    End Sub

    Private Function MakeCombo(t As String) As ComboBox
        Dim c As New ComboBox() : c.DropDownStyle = ComboBoxStyle.DropDownList : c.Items.Add(t) : c.SelectedIndex = 0
        Return c
    End Function
End Class