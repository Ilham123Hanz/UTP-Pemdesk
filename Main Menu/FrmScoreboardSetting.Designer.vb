Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D ' Diperlukan untuk efek gradient warna skor

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class FrmScoreboardSetting
    Inherits System.Windows.Forms.Form

    ' Variabel untuk menyimpan mode warna skor yang dipilih
    Private _currentScoreMode As String = "Original"

    ' 1. Deklarasi root
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Friend WithEvents root As TableLayoutPanel

    ' 3. InitializeComponent
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.root = New System.Windows.Forms.TableLayoutPanel()
        Me.SuspendLayout()

        Me.root.ColumnCount = 1
        Me.root.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
        Me.root.Dock = System.Windows.Forms.DockStyle.Fill
        Me.root.Location = New System.Drawing.Point(0, 0)
        Me.root.Name = "root"
        Me.root.Padding = New System.Windows.Forms.Padding(10)
        Me.root.RowCount = 2
        Me.root.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115.0F))
        Me.root.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
        Me.root.Size = New System.Drawing.Size(1060, 840)
        Me.root.TabIndex = 0

        Me.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
        Me.ClientSize = New System.Drawing.Size(1060, 840)
        Me.Controls.Add(Me.root)
        ' Font form dibuat Bold agar teks utama ComboBox terlihat tegas
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0F, FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmScoreboardSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scoreboard Setting"
        Me.ResumeLayout(False)
    End Sub

    ' 4. Pindahkan logika build UI ke sub terpisah
    ' 4. Susun UI Utama
    Public Sub SetupAdditionalUI()
        ' Kita bagi area utama menjadi 3 baris: Header, TabContent, Footer
        root.RowCount = 3
        root.RowStyles.Clear()
        root.RowStyles.Add(New RowStyle(SizeType.Absolute, 115.0F)) ' Baris 0: Header
        root.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))   ' Baris 1: TabControl (Kumite & Kata)
        root.RowStyles.Add(New RowStyle(SizeType.Absolute, 250.0F))  ' Baris 2: Footer (Match Info & Logo)

        ' Tambahkan Header
        root.Controls.Add(BuildTopHeader(), 0, 0)

        ' Tambahkan TabControl (KUMITE & KATA)
        root.Controls.Add(BuildMainTab(), 0, 1)

        ' --- FOOTER AREA (Match Info, Logo, Save, Close) ---
        ' Pindahkan bagian ini keluar dari tab agar selalu muncul di bawah
        Dim footer As New TableLayoutPanel()
        footer.Dock = DockStyle.Fill
        footer.ColumnCount = 2
        footer.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 510)) ' Kolom Match Info
        footer.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))  ' Kolom Logo & Buttons

        ' 1. Match Round Info
        Dim gpR As New GroupBox() : gpR.Text = "Round Info" : gpR.Dock = DockStyle.Fill
        AddRoundInfo(gpR)
        footer.Controls.Add(gpR, 0, 0)

        ' 2. Logo & Buttons (Save/Close)
        Dim pnlRightFooter As New Panel() : pnlRightFooter.Dock = DockStyle.Fill
        FillBottomRight(pnlRightFooter)
        footer.Controls.Add(pnlRightFooter, 1, 0)

        ' Masukkan footer ke baris paling bawah root
        root.Controls.Add(footer, 0, 2)
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

        Dim gpP As New GroupBox() : gpP.Text = "Penalties" : gpP.Size = New Size(490, 130)
        gpP.Controls.Add(BuildPenaltySub("Penalties - AKA (Kumite)", Color.Crimson, 5))
        gpP.Controls.Add(BuildPenaltySub("Penalties - AO (Kumite)", Color.DodgerBlue, 245))

        Dim gpT As New GroupBox() : gpT.Text = "Kumite Timer & Score" : gpT.Size = New Size(490, 95)
        Dim lblT1 As New Label() : lblT1.Text = "Font (Timer)" : lblT1.Location = New Point(10, 25) : lblT1.AutoSize = True
        Dim cbT1 As ComboBox = MakeCombo("Arial") : cbT1.Location = New Point(100, 22) : cbT1.Width = 150
        Dim chkT1 As New CheckBox() : chkT1.Text = "Bold" : chkT1.Checked = True : chkT1.Location = New Point(260, 24) : chkT1.AutoSize = True

        Dim lblT2 As New Label() : lblT2.Text = "Font (Score)" : lblT2.Location = New Point(10, 55) : lblT2.AutoSize = True
        Dim cbT2 As ComboBox = MakeCombo("Microsoft Sans Serif") : cbT2.Location = New Point(100, 52) : cbT2.Width = 150
        Dim chkT2 As New CheckBox() : chkT2.Text = "Bold" : chkT2.Checked = True : chkT2.Location = New Point(260, 54) : chkT2.AutoSize = True
        gpT.Controls.AddRange(New Control() {lblT1, cbT1, chkT1, lblT2, cbT2, chkT2})

        Dim gpD As New GroupBox() : gpD.Text = "Kumite Match Detail" : gpD.Size = New Size(490, 140)
        Dim lblDf As New Label() : lblDf.Text = "Font" : lblDf.Location = New Point(10, 25) : lblDf.AutoSize = True
        Dim cbDf As ComboBox = MakeCombo("Microsoft Sans Serif") : cbDf.Location = New Point(100, 22) : cbDf.Width = 150

        Dim lblDc As New Label() : lblDc.Text = "Font Color" : lblDc.Location = New Point(10, 55) : lblDc.AutoSize = True
        Dim cpD As Panel = MakeColorPicker(Color.Yellow) : cpD.Location = New Point(100, 52)
        Dim chkDb As New CheckBox() : chkDb.Text = "Bold" : chkDb.Checked = True : chkDb.Location = New Point(260, 54) : chkDb.AutoSize = True

        Dim chkD1 As New CheckBox() : chkD1.Text = "Display Score Popup" : chkD1.Checked = True : chkD1.Location = New Point(10, 85) : chkD1.AutoSize = True
        Dim chkD2 As New CheckBox() : chkD2.Text = "Knocked Out Countdown" : chkD2.Checked = True : chkD2.Location = New Point(10, 105) : chkD2.AutoSize = True
        gpD.Controls.AddRange(New Control() {lblDf, cbDf, lblDc, cpD, chkDb, chkD1, chkD2})

        Dim gpR As New GroupBox() : gpR.Size = New Size(490, 200) : gpR.Text = "Round Info"
        AddRoundInfo(gpR)

        left.Controls.AddRange(New Control() {gpP, gpT, gpD, gpR})



        ' --- RIGHT COLUMN ---
        Dim right As New FlowLayoutPanel() : right.Dock = DockStyle.Fill : right.FlowDirection = FlowDirection.TopDown : right.WrapContents = False

        Dim gpH As New GroupBox() : gpH.Text = "Horizontal Mode (Left-Right)" : gpH.Size = New Size(520, 110)
        Dim lblHa As New Label() : lblHa.Text = "Player Name Alignment" : lblHa.Location = New Point(10, 25) : lblHa.AutoSize = True
        Dim cbHa As ComboBox = New ComboBox() : cbHa.Items.AddRange({"Left-Right", "Center"}) : cbHa.SelectedIndex = 0 : cbHa.Location = New Point(160, 22) : cbHa.Width = 180 : cbHa.DropDownStyle = ComboBoxStyle.DropDownList

        Dim lblHm As New Label() : lblHm.Text = "Score Color Mode" : lblHm.Location = New Point(10, 60) : lblHm.AutoSize = True

        ' ComboBox Score Mode
        Dim cbHm As ComboBox = New ComboBox()
        cbHm.Items.AddRange({"Original", "Soft Darken", "TopDown Darken", "Top Darken"})
        cbHm.SelectedIndex = 0 : cbHm.Location = New Point(160, 57) : cbHm.Width = 180 : cbHm.DropDownStyle = ComboBoxStyle.DropDownList

        ' Label Skor AKA (3)
        Dim p3 As New Label() : p3.Text = "3" : p3.Tag = Color.Crimson
        p3.ForeColor = Color.White : p3.Size = New Size(35, 30) : p3.Location = New Point(350, 55)
        p3.TextAlign = ContentAlignment.MiddleCenter : p3.Font = New Font("Arial", 12, FontStyle.Bold)

        ' Label Skor AO (2)
        Dim p2 As New Label() : p2.Text = "2" : p2.Tag = Color.DodgerBlue
        p2.ForeColor = Color.White : p2.Size = New Size(35, 30) : p2.Location = New Point(387, 55)
        p2.TextAlign = ContentAlignment.MiddleCenter : p2.Font = New Font("Arial", 12, FontStyle.Bold)

        ' Handler untuk update mode warna
        AddHandler cbHm.SelectedIndexChanged, Sub(sender, e)
                                                  _currentScoreMode = cbHm.SelectedItem.ToString()
                                                  p3.Invalidate() : p2.Invalidate()
                                              End Sub

        ' Logika Paint Gradient untuk efek visual skor
        Dim paintScore = Sub(sender As Object, e As PaintEventArgs)
                             Dim lbl = DirectCast(sender, Label)
                             Dim baseColor As Color = DirectCast(lbl.Tag, Color)
                             Dim rect = lbl.ClientRectangle
                             Dim g = e.Graphics
                             g.SmoothingMode = SmoothingMode.AntiAlias

                             Select Case _currentScoreMode
                                 Case "Original"
                                     g.FillRectangle(New SolidBrush(baseColor), rect)
                                 Case "Soft Darken"
                                     Using br As New LinearGradientBrush(rect, baseColor, Color.FromArgb(60, 0, 0, 0), LinearGradientMode.Vertical)
                                         g.FillRectangle(br, rect)
                                     End Using
                                 Case "TopDown Darken"
                                     Dim blend As New ColorBlend(3)
                                     blend.Colors = {Color.Black, baseColor, Color.Black}
                                     blend.Positions = {0.0F, 0.5F, 1.0F}
                                     Using br As New LinearGradientBrush(rect, Color.Black, Color.Black, LinearGradientMode.Vertical)
                                         br.InterpolationColors = blend
                                         g.FillRectangle(br, rect)
                                     End Using
                                 Case "Top Darken"
                                     Using br As New LinearGradientBrush(rect, Color.Black, baseColor, LinearGradientMode.Vertical)
                                         g.FillRectangle(br, rect)
                                     End Using
                             End Select
                             TextRenderer.DrawText(g, lbl.Text, lbl.Font, rect, lbl.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
                         End Sub

        AddHandler p3.Paint, paintScore
        AddHandler p2.Paint, paintScore

        gpH.Controls.AddRange(New Control() {lblHa, cbHa, lblHm, cbHm, p3, p2})

        Dim gpA As New GroupBox() : gpA.Text = "Alert" : gpA.Size = New Size(520, 295)
        FillAlerts(gpA)

        Dim pnlBottom As New Panel() : pnlBottom.Size = New Size(520, 180)
        FillBottomRight(pnlBottom)

        right.Controls.AddRange(New Control() {gpH, gpA, pnlBottom})

        split.Controls.Add(left, 0, 0)
        split.Controls.Add(right, 1, 0)
        pg.Controls.Add(split)

        ' --- GANTI BARIS 208-213 DI GAMBAR KAMU DENGAN INI ---
        Dim pgKata As New TabPage("KATA") : pgKata.BackColor = Color.White

        ' Panggil fungsi desain yang baru kita buat tadi
        pgKata.Controls.Add(BuildKataTabContent())

        ' Tambahkan ke TabControl
        tc.TabPages.Add(pg)
        tc.TabPages.Add(pgKata)
        Return tc
    End Function

    ' --- HELPERS ---
    Private Function MakeColorPicker(clr As Color) As Panel
        Dim p As New Panel() : p.Size = New Size(120, 28) : p.BorderStyle = BorderStyle.FixedSingle : p.BackColor = clr
        Dim btn As New Button() : btn.Text = "Change" : btn.Size = New Size(70, 22) : btn.Location = New Point(46, 2)
        btn.BackColor = Color.White : btn.FlatStyle = FlatStyle.Flat : btn.Font = New Font("Segoe UI", 7)

        Dim localP As Panel = p
        AddHandler btn.Click, Sub()
                                  Dim cd As New ColorDialog() : cd.Color = localP.BackColor
                                  If cd.ShowDialog() = DialogResult.OK Then localP.BackColor = cd.Color
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
        ' 1. Header & Radio Yes/No
        Dim lblM As New Label() : lblM.Text = "Match Round-Pool Info" : lblM.Font = New Font("Segoe UI", 9, FontStyle.Bold) : lblM.Location = New Point(10, 18) : lblM.AutoSize = True
        Dim rbY As New RadioButton() : rbY.Text = "Yes" : rbY.Checked = True : rbY.Location = New Point(160, 15) : rbY.Width = 50
        Dim rbN As New RadioButton() : rbN.Text = "No" : rbN.Location = New Point(210, 15) : rbN.Width = 50

        ' 2. Kontainer Utama (Panel Abu-abu)
        Dim pG As New Panel() : pG.BackColor = Color.FromArgb(230, 230, 230) : pG.Location = New Point(10, 45) : pG.Size = New Size(470, 110)

        ' --- GRUP 1: ROUND (Bungkus dalam Panel agar jadi satu grup terpisah) ---
        Dim pnlRound As New Panel() : pnlRound.Location = New Point(5, 5) : pnlRound.Size = New Size(460, 35)
        Dim rbF As New RadioButton() : rbF.Text = "Full (ex :Round of 16)" : rbF.Checked = True : rbF.Location = New Point(5, 5) : rbF.Width = 150
        Dim rbS As New RadioButton() : rbS.Text = "Short (ex :R16)" : rbS.Location = New Point(165, 5) : rbS.Width = 120
        Dim rbNoneR As New RadioButton() : rbNoneR.Text = "None" : rbNoneR.Location = New Point(295, 5) : rbNoneR.Width = 70
        pnlRound.Controls.AddRange(New Control() {rbF, rbS, rbNoneR})

        ' Label Separator & Pool Info
        Dim lblSep As New Label() : lblSep.Text = "Separator" : lblSep.Font = New Font("Segoe UI", 8, FontStyle.Bold) : lblSep.Location = New Point(10, 45) : lblSep.AutoSize = True
        Dim lblPol As New Label() : lblPol.Text = "Pool Info" : lblPol.Font = New Font("Segoe UI", 8, FontStyle.Bold) : lblPol.Location = New Point(250, 45) : lblPol.AutoSize = True

        ' --- GRUP 2: SEPARATOR (Bungkus dalam Panel) ---
        Dim pnlSep As New Panel() : pnlSep.Location = New Point(5, 60) : pnlSep.Size = New Size(230, 40)
        Dim r1 As New RadioButton() : r1.Text = "-" : r1.Checked = True : r1.Location = New Point(5, 5) : r1.Width = 35
        Dim r2 As New RadioButton() : r2.Text = "|" : r2.Location = New Point(45, 5) : r2.Width = 35
        Dim r3 As New RadioButton() : r3.Text = "/" : r3.Location = New Point(85, 5) : r3.Width = 35
        Dim r4 As New RadioButton() : r4.Text = "Space" : r4.Location = New Point(125, 5) : r4.Width = 60
        pnlSep.Controls.AddRange(New Control() {r1, r2, r3, r4})

        ' --- GRUP 3: POOL INFO (Bungkus dalam Panel) ---
        Dim pnlPool As New Panel() : pnlPool.Location = New Point(245, 60) : pnlPool.Size = New Size(220, 40)
        Dim p1 As New RadioButton() : p1.Text = "Pool 1" : p1.Checked = True : p1.Location = New Point(5, 5) : p1.Width = 70
        Dim p2 As New RadioButton() : p2.Text = "P1" : p2.Location = New Point(85, 5) : p2.Width = 50
        Dim p3 As New RadioButton() : p3.Text = "None" : p3.Location = New Point(145, 5) : p3.Width = 60
        pnlPool.Controls.AddRange(New Control() {p1, p2, p3})

        ' Preview Area
        Dim lblPrv As New Label() : lblPrv.Text = "Preview" : lblPrv.Location = New Point(10, 168) : lblPrv.AutoSize = True
        Dim txtPrv As New TextBox() : txtPrv.Location = New Point(80, 165) : txtPrv.Width = 380 : txtPrv.ReadOnly = True : txtPrv.BackColor = Color.White

        ' --- LOGIKA DINAMIS UPDATE PREVIEW ---
        Dim updatePreview = Sub()
                                If rbN.Checked Then
                                    txtPrv.Text = "" : pG.Enabled = False : Return
                                Else
                                    pG.Enabled = True
                                End If

                                Dim strRound As String = If(rbF.Checked, "Round of 16", If(rbS.Checked, "R16", ""))
                                Dim strSep As String = If(r1.Checked, "-", If(r2.Checked, "|", If(r3.Checked, "/", " ")))
                                Dim strPool As String = If(p1.Checked, "Pool 1", If(p2.Checked, "P1", ""))

                                If strRound = "" And strPool = "" Then
                                    txtPrv.Text = ""
                                ElseIf strRound = "" Then
                                    txtPrv.Text = strPool
                                ElseIf strPool = "" Then
                                    txtPrv.Text = strRound
                                Else
                                    txtPrv.Text = strRound & strSep & strPool
                                End If
                            End Sub

        ' Daftarkan Event ke semua RadioButton
        Dim allRbs As RadioButton() = {rbY, rbN, rbF, rbS, rbNoneR, r1, r2, r3, r4, p1, p2, p3}
        For Each rb In allRbs
            AddHandler rb.CheckedChanged, Sub() updatePreview()
        Next

        updatePreview() ' Inisialisasi awal

        ' Masukkan ke Kontrol
        pG.Controls.AddRange(New Control() {pnlRound, lblSep, lblPol, pnlSep, pnlPool})
        gb.Controls.AddRange(New Control() {lblM, rbY, rbN, pG, lblPrv, txtPrv})
    End Sub

    Private Sub FillAlerts(gb As GroupBox)
        Dim a() As String = {"End of Timer", "15 Second Timer", "Winner by Point", "Get Point", "Get Penalties", "Hantei", "Knocked Out", "VAR Alert", "Manual Alert"}
        Dim y As Integer = 22
        For Each s In a
            Dim lbl As New Label() : lbl.Text = s : lbl.Location = New Point(5, y + 3) : lbl.Size = New Size(100, 20) : lbl.TextAlign = ContentAlignment.MiddleRight
            Dim tx As New TextBox() : tx.Text = "" : tx.Location = New Point(110, y) : tx.Width = 220 : tx.ReadOnly = True
            Dim bS As New Button() : bS.Text = "Select" : bS.Location = New Point(335, y) : bS.Width = 55 : bS.BackColor = Color.White
            Dim bX As New Button() : bX.Text = "X" : bX.Location = New Point(395, y) : bX.Width = 25 : bX.BackColor = Color.White
            Dim bP As New Button() : bP.Text = "Play" : bP.Location = New Point(425, y) : bP.Width = 55 : bP.BackColor = Color.White

            ' Fungsionalitas Tombol Alert
            AddHandler bS.Click, Sub()
                                     Dim ofd As New OpenFileDialog() : ofd.Filter = "Wave Files (*.wav)|*.wav"
                                     If ofd.ShowDialog() = DialogResult.OK Then tx.Text = ofd.FileName
                                 End Sub
            AddHandler bX.Click, Sub() tx.Text = ""
            AddHandler bP.Click, Sub()
                                     If String.IsNullOrWhiteSpace(tx.Text) Then
                                         ' Tambahan Pop-up Error sesuai gambar yang kamu minta
                                         MessageBox.Show("File not found or path is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                         Return
                                     End If
                                     Try : Dim player As New System.Media.SoundPlayer(tx.Text) : player.Play()
                                     Catch : End Try
                                 End Sub

            gb.Controls.AddRange(New Control() {lbl, tx, bS, bX, bP})
            y += 28
        Next
    End Sub

    Private Sub FillBottomRight(p As Panel)
        Dim lblL As New Label() : lblL.Text = "Logo" : lblL.Location = New Point(10, 10) : lblL.AutoSize = True
        Dim pbL As New PictureBox() : pbL.BorderStyle = BorderStyle.FixedSingle : pbL.Size = New Size(70, 70) : pbL.Location = New Point(10, 30) : pbL.BackColor = Color.White
        pbL.SizeMode = PictureBoxSizeMode.Zoom ' Penting agar gambar logo tidak gepeng

        Dim btnS As New Button() : btnS.Text = "Select" : btnS.Location = New Point(90, 30) : btnS.Size = New Size(80, 30) : btnS.BackColor = Color.White
        Dim btnR As New Button() : btnR.Text = "Remove" : btnR.Location = New Point(90, 65) : btnR.Size = New Size(80, 30) : btnR.BackColor = Color.White

        ' --- LOGIKA FUNGSI LOGO ---
        AddHandler btnS.Click, Sub()
                                   Dim ofd As New OpenFileDialog()
                                   ofd.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp"
                                   If ofd.ShowDialog() = DialogResult.OK Then
                                       pbL.Image = Image.FromFile(ofd.FileName)
                                   End If
                               End Sub

        AddHandler btnR.Click, Sub()
                                   If pbL.Image IsNot Nothing Then
                                       pbL.Image.Dispose()
                                       pbL.Image = Nothing
                                   End If
                               End Sub

        Dim pbUser As New PictureBox() : pbUser.Size = New Size(32, 32) : pbUser.Location = New Point(10, 115)
        pbUser.BorderStyle = BorderStyle.FixedSingle : pbUser.BackColor = Color.White
        Dim lblIcon As New Label() : lblIcon.Text = "👤" : lblIcon.Font = New Font("Segoe UI", 14)
        lblIcon.Dock = DockStyle.Fill : lblIcon.TextAlign = ContentAlignment.MiddleCenter
        pbUser.Controls.Add(lblIcon)

        Dim chkL As New CheckBox() : chkL.Text = "Show Competitor Picture" : chkL.Location = New Point(50, 115) : chkL.AutoSize = True
        Dim lblN As New Label() : lblN.Text = "(Display athlete image if available)" : lblN.Font = New Font("Segoe UI", 7) : lblN.Location = New Point(50, 135) : lblN.AutoSize = True : lblN.ForeColor = Color.Gray

        Dim btnClose As New Button() : btnClose.Text = "Close" : btnClose.Size = New Size(110, 35) : btnClose.Location = New Point(380, 80) : btnClose.BackColor = Color.White
        AddHandler btnClose.Click, Sub() Me.Close()

        Dim btnSave As New Button() : btnSave.Text = "Save" : btnSave.Size = New Size(110, 35) : btnSave.Location = New Point(380, 125) : btnSave.BackColor = Color.White

        p.Controls.AddRange(New Control() {lblL, pbL, btnS, btnR, pbUser, chkL, lblN, btnClose, btnSave})
    End Sub

    ' Shared font list agar tidak di-load ulang setiap MakeCombo dipanggil
    Private Shared _fontNames As List(Of String) = Nothing

    Private Shared Function GetFontNames() As List(Of String)
        If _fontNames Is Nothing Then
            _fontNames = New List(Of String)
            Try
                For Each family As FontFamily In FontFamily.Families
                    _fontNames.Add(family.Name)
                Next
            Catch
                _fontNames.AddRange(New String() {"Arial", "Consolas", "Calibri", "Segoe UI", "Times New Roman"})
            End Try
        End If
        Return _fontNames
    End Function

    Private Function MakeCombo(defFont As String) As ComboBox
        Dim c As New ComboBox()
        c.DropDownStyle = ComboBoxStyle.DropDownList
        c.DrawMode = DrawMode.OwnerDrawFixed
        c.ItemHeight = 20 ' Beri ruang lebih tinggi agar font tidak terpotong

        ' Gunakan shared list agar tidak reload font setiap saat
        c.Items.AddRange(GetFontNames().ToArray())

        ' Set index tanpa trigger handler dengan BeginUpdate/EndUpdate
        c.BeginUpdate()
        If c.Items.Contains(defFont) Then
            c.SelectedIndex = c.Items.IndexOf(defFont)
        ElseIf c.Items.Count > 0 Then
            c.SelectedIndex = 0
        End If
        c.EndUpdate()

        ' Handler untuk menggambar item font di dalam daftar pilihan
        AddHandler c.DrawItem, Sub(sender, e)
                                   If e.Index < 0 Then Return
                                   Dim cb = DirectCast(sender, ComboBox)
                                   Dim fontName = cb.Items(e.Index).ToString()

                                   e.DrawBackground()
                                   Try
                                       ' Kita gunakan font sementara untuk menggambar item list
                                       Using sampleFont As New Font(fontName, 10)
                                           e.Graphics.DrawString(fontName, sampleFont, New SolidBrush(e.ForeColor), e.Bounds)
                                       End Using
                                   Catch
                                       ' Jika font gagal load, gunakan font default
                                       e.Graphics.DrawString(fontName, cb.Font, New SolidBrush(e.ForeColor), e.Bounds)
                                   End Try
                                   e.DrawFocusRectangle()
                               End Sub

        Return c
    End Function

    ' --- FUNGSI BARU UNTUK DESAIN TAB KATA ---
    ' --- ISI KONTEN TAB KATA (PERSIS GAMBAR 2) ---
    Private Function BuildKataTabContent() As Control
        Dim mainPanel As New Panel() : mainPanel.Dock = DockStyle.Fill : mainPanel.AutoScroll = True

        ' 1. GroupBox Atas (Sounds & Formats)
        Dim gpTop As New GroupBox() : gpTop.Text = "" : gpTop.Location = New Point(20, 10) : gpTop.Size = New Size(930, 185)

        ' --- Row: End of Performance ---
        Dim lblEOP As New Label() : lblEOP.Text = "End of Performance" : lblEOP.Location = New Point(20, 30) : lblEOP.AutoSize = True
        Dim txEOP As New TextBox() : txEOP.Location = New Point(180, 27) : txEOP.Width = 350 : txEOP.ReadOnly = True
        Dim btnSEOP As New Button() : btnSEOP.Text = "Select" : btnSEOP.Location = New Point(540, 25) : btnSEOP.BackColor = Color.White
        Dim btnXEOP As New Button() : btnXEOP.Text = "X" : btnXEOP.Location = New Point(620, 25) : btnXEOP.Width = 30 : btnXEOP.BackColor = Color.White
        Dim btnPEOP As New Button() : btnPEOP.Text = "Play" : btnPEOP.Location = New Point(660, 25) : btnPEOP.BackColor = Color.White

        ' --- Row: Judge Completed Score ---
        Dim lblJCS As New Label() : lblJCS.Text = "Judge Completed Score" : lblJCS.Location = New Point(20, 60) : lblJCS.AutoSize = True
        Dim txJCS As New TextBox() : txJCS.Location = New Point(180, 57) : txJCS.Width = 350 : txJCS.ReadOnly = True
        Dim btnSJCS As New Button() : btnSJCS.Text = "Select" : btnSJCS.Location = New Point(540, 55) : btnSJCS.BackColor = Color.White
        Dim btnXJCS As New Button() : btnXJCS.Text = "X" : btnXJCS.Location = New Point(620, 55) : btnXJCS.Width = 30 : btnXJCS.BackColor = Color.White
        Dim btnPJCS As New Button() : btnPJCS.Text = "Play" : btnPJCS.Location = New Point(660, 55) : btnPJCS.BackColor = Color.White

        ' --- LOGIKA ALERT KATA (EOP & JCS) ---
        Dim setupSoundLogic = Sub(btnSelect As Button, btnClear As Button, btnPlay As Button, txtPath As TextBox)
                                  ' Fungsi Select
                                  AddHandler btnSelect.Click, Sub()
                                                                  Dim ofd As New OpenFileDialog() : ofd.Filter = "Wave Files (*.wav)|*.wav"
                                                                  If ofd.ShowDialog() = DialogResult.OK Then txtPath.Text = ofd.FileName
                                                              End Sub
                                  ' Fungsi X (Clear)
                                  AddHandler btnClear.Click, Sub() txtPath.Text = ""
                                  ' Fungsi Play (dengan Pop-up Error)
                                  AddHandler btnPlay.Click, Sub()
                                                                If String.IsNullOrWhiteSpace(txtPath.Text) Then
                                                                    MessageBox.Show("File not found or path is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                    Return
                                                                End If
                                                                Try : Dim player As New System.Media.SoundPlayer(txtPath.Text) : player.Play()
                                                                Catch : MessageBox.Show("Cannot play file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : End Try
                                                            End Sub
                              End Sub

        ' Jalankan Logika untuk kedua baris
        setupSoundLogic(btnSEOP, btnXEOP, btnPEOP, txEOP)
        setupSoundLogic(btnSJCS, btnXJCS, btnPJCS, txJCS)

        ' --- Formats & Combo ---
        Dim lblFmt As New Label() : lblFmt.Text = "KATA Format" : lblFmt.Location = New Point(20, 95) : lblFmt.AutoSize = True
        Dim cbFmt As New ComboBox()
        cbFmt.Items.AddRange({"Code - KATA", "Code. KATA", "KATA (Code)", "KATA"})
        cbFmt.SelectedIndex = 3
        cbFmt.Location = New Point(180, 92) : cbFmt.Width = 350 : cbFmt.DropDownStyle = ComboBoxStyle.DropDownList

        Dim lblSize As New Label() : lblSize.Text = "KATA Text Size" : lblSize.Location = New Point(20, 125) : lblSize.AutoSize = True
        Dim cbSize As ComboBox = New ComboBox() : cbSize.Items.AddRange({"Small", "Medium", "Large"}) : cbSize.SelectedIndex = 2 : cbSize.Location = New Point(180, 122) : cbSize.Width = 350 : cbSize.DropDownStyle = ComboBoxStyle.DropDownList

        Dim lblSelFmt As New Label() : lblSelFmt.Text = "KATA Select Format" & vbCrLf & "(Form Control)" : lblSelFmt.Location = New Point(20, 150) : lblSelFmt.AutoSize = True : lblSelFmt.Font = New Font("Segoe UI", 7, FontStyle.Bold)
        Dim cbSelFmt As New ComboBox()
        cbSelFmt.Items.AddRange({"KATAName - Code", "Code - KATAName"})
        cbSelFmt.SelectedIndex = 0
        cbSelFmt.Location = New Point(180, 155) : cbSelFmt.Width = 350 : cbSelFmt.DropDownStyle = ComboBoxStyle.DropDownList

        gpTop.Controls.AddRange(New Control() {lblEOP, txEOP, btnSEOP, btnXEOP, btnPEOP, lblJCS, txJCS, btnSJCS, btnXJCS, btnPJCS, lblFmt, cbFmt, lblSize, cbSize, lblSelFmt, cbSelFmt})

        ' 2. Score Display Mode
        Dim gpScoreMode As New GroupBox() : gpScoreMode.Text = "Score Display Mode (Score Voting)" : gpScoreMode.Location = New Point(20, 205) : gpScoreMode.Size = New Size(280, 210)

        ' Panel untuk grup Animasi (Supaya terpisah)
        Dim pnlAnim As New Panel() : pnlAnim.Location = New Point(10, 20) : pnlAnim.Size = New Size(260, 85) : pnlAnim.BorderStyle = BorderStyle.FixedSingle
        Dim lblAnim As New Label() : lblAnim.Text = "Animation Mode" : lblAnim.Font = New Font("Segoe UI", 9, FontStyle.Bold) : lblAnim.Location = New Point(5, 5) : lblAnim.AutoSize = True
        Dim rbAnim1 As New RadioButton() : rbAnim1.Text = "Animated Score Reveal" : rbAnim1.Checked = True : rbAnim1.Location = New Point(10, 25) : rbAnim1.AutoSize = True
        Dim rbAnim2 As New RadioButton() : rbAnim2.Text = "Instant Score Display" : rbAnim2.Location = New Point(10, 50) : rbAnim2.AutoSize = True
        pnlAnim.Controls.AddRange(New Control() {lblAnim, rbAnim1, rbAnim2})

        ' Panel untuk grup Warna Teks (Supaya terpisah)
        Dim pnlTxtClr As New Panel() : pnlTxtClr.Location = New Point(10, 110) : pnlTxtClr.Size = New Size(260, 85) : pnlTxtClr.BorderStyle = BorderStyle.FixedSingle
        Dim lblTxtClr As New Label() : lblTxtClr.Text = "Score Text Color" : lblTxtClr.Font = New Font("Segoe UI", 9, FontStyle.Bold) : lblTxtClr.Location = New Point(5, 5) : lblTxtClr.AutoSize = True
        Dim rbClr1 As New RadioButton() : rbClr1.Text = "White" : rbClr1.Location = New Point(10, 25) : rbClr1.AutoSize = True
        Dim rbClr2 As New RadioButton() : rbClr2.Text = "Match AKA / AO Color" : rbClr2.Checked = True : rbClr2.Location = New Point(10, 50) : rbClr2.AutoSize = True
        pnlTxtClr.Controls.AddRange(New Control() {lblTxtClr, rbClr1, rbClr2})

        ' Masukkan kedua panel ke GroupBox utama
        gpScoreMode.Controls.AddRange(New Control() {pnlAnim, pnlTxtClr})

        ' 3. KATA Name
        Dim gpKataName As New GroupBox() : gpKataName.Text = "KATA Name" : gpKataName.Location = New Point(310, 205) : gpKataName.Size = New Size(280, 95)
        Dim cbKNM = MakeCombo("Microsoft Sans Serif") : cbKNM.Location = New Point(70, 25) : cbKNM.Width = 160
        Dim cpKNM = MakeColorPicker(Color.LightGreen) : cpKNM.Location = New Point(70, 55)
        Dim chkBNM As New CheckBox() : chkBNM.Text = "Bold" : chkBNM.Checked = True : chkBNM.Location = New Point(235, 58) : chkBNM.AutoSize = True
        gpKataName.Controls.AddRange(New Control() {cbKNM, cpKNM, chkBNM})

        ' 4. KATA Match Detail
        Dim gpKataDetail As New GroupBox() : gpKataDetail.Text = "KATA Match Detail" : gpKataDetail.Location = New Point(310, 310) : gpKataDetail.Size = New Size(280, 95)
        Dim cbKDT = MakeCombo("Microsoft Sans Serif") : cbKDT.Location = New Point(70, 25) : cbKDT.Width = 160
        Dim cpKDT = MakeColorPicker(Color.Yellow) : cpKDT.Location = New Point(70, 55)
        Dim chkBDT As New CheckBox() : chkBDT.Text = "Bold" : chkBDT.Checked = True : chkBDT.Location = New Point(235, 58) : chkBDT.AutoSize = True
        gpKataDetail.Controls.AddRange(New Control() {cbKDT, cpKDT, chkBDT})

        ' 5. KATA Timer
        Dim gpKataTimer As New GroupBox() : gpKataTimer.Text = "KATA Timer" : gpKataTimer.Location = New Point(600, 205) : gpKataTimer.Size = New Size(300, 80)
        Dim cpBC = MakeColorPicker(Color.Maroon) : cpBC.Location = New Point(10, 40)
        Dim cpTC = MakeColorPicker(Color.White) : cpTC.Location = New Point(140, 40)
        gpKataTimer.Controls.AddRange(New Control() {cpBC, cpTC})

        mainPanel.Controls.AddRange(New Control() {gpTop, gpScoreMode, gpKataName, gpKataDetail, gpKataTimer})
        Return mainPanel
    End Function

End Class