' ============================================================
' Kumite Main Control - VB.NET
' Fixed: BC36918 lambda errors, BC30429 End Sub errors
' Cara pakai: Windows Forms App (.NET Framework 4.x)
' Set Startup Object = KumiteMainControl
' ============================================================
Imports System.Drawing
Imports System.Windows.Forms

Public Class KumiteMainControl
    Inherits Form

    ' ── AKA score state ──
    Private akaIppon As Integer = 0
    Private akaWaza As Integer = 0
    Private akaYuko As Integer = 0

    ' ── AO score state ──
    Private aoIppon As Integer = 0
    Private aoWaza As Integer = 0
    Private aoYuko As Integer = 0

    ' ── Timer state ──
    Private WithEvents tmrMatch As Timer
    Private matchSeconds As Integer = 120
    Private timerRunning As Boolean = False

    ' ── Key controls ──
    Private lblAkaScore As Label
    Private lblAoScore As Label
    Private lblAkaIpponV As Label
    Private lblAkaWazaV As Label
    Private lblAkaYukoV As Label
    Private lblAoIpponV As Label
    Private lblAoWazaV As Label
    Private lblAoYukoV As Label
    Private lblTimerDisp As Label
    Private nudMatchMin As NumericUpDown
    Private nudMatchSec As NumericUpDown
    Private btnStartTimer As Button

    ' ── Nama pemain (untuk Show Winner) ──
    Private txtAkaNameRef As TextBox
    Private txtAoNameRef As TextBox

    ' ============================================================
    Public Sub New()
        Me.Text = "Kumite Main Control"
        Me.Size = New Size(1170, 780)
        Me.MinimumSize = New Size(1050, 680)
        Me.BackColor = Color.FromArgb(236, 236, 236)
        Me.Font = New Font("Segoe UI", 8.5F)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.Sizable

        tmrMatch = New Timer With {.Interval = 1000}
        BuildUI()
    End Sub

    ' ============================================================
    '  BUILD UI
    ' ============================================================
    Private Sub BuildUI()
        Me.SuspendLayout()
        Me.Controls.Add(BuildRightPanel())
        Me.Controls.Add(BuildBottomBar())
        Me.Controls.Add(BuildTopBar())
        Me.Controls.Add(BuildCenterPanel())
        Me.ResumeLayout(False)
    End Sub

    ' ============================================================
    '  TOP BAR
    ' ============================================================
    Private Function BuildTopBar() As Panel
        Dim p As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 50,
            .BackColor = Color.FromArgb(255, 200, 0)
        }

        Dim btnNext As New Button With {
            .Text = "Next Match",
            .Location = New Point(6, 11),
            .Size = New Size(105, 28),
            .BackColor = Color.FromArgb(255, 200, 0),
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
        }
        btnNext.FlatAppearance.BorderColor = Color.FromArgb(160, 120, 0)
        btnNext.FlatAppearance.BorderSize = 2

        ' AKA textbox dengan border merah
        Dim txtAka As New TextBox With {
            .Location = New Point(2, 2),
            .Size = New Size(201, 22),
            .Font = New Font("Segoe UI", 10),
            .BackColor = Color.White
        }
        txtAkaNameRef = txtAka
        Dim pAkaBorder As New Panel With {
            .Location = New Point(118, 12),
            .Size = New Size(205, 26),
            .BackColor = Color.Red,
            .Padding = New Padding(2)
        }
        pAkaBorder.Controls.Add(txtAka)

        Dim btnArrowL As New Button With {
            .Text = "▲▼",
            .Location = New Point(328, 12),
            .Size = New Size(26, 26),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(220, 220, 220),
            .Font = New Font("Segoe UI", 7)
        }
        btnArrowL.FlatAppearance.BorderColor = Color.Gray

        Dim lblVS As New Label With {
            .Text = "VS",
            .Location = New Point(360, 14),
            .Size = New Size(30, 22),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .ForeColor = Color.Black
        }

        Dim btnArrowR As New Button With {
            .Text = "▲▼",
            .Location = New Point(396, 12),
            .Size = New Size(26, 26),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(220, 220, 220),
            .Font = New Font("Segoe UI", 7)
        }
        btnArrowR.FlatAppearance.BorderColor = Color.Gray

        ' AO textbox dengan border biru
        Dim txtAo As New TextBox With {
            .Location = New Point(2, 2),
            .Size = New Size(201, 22),
            .Font = New Font("Segoe UI", 10),
            .BackColor = Color.White
        }
        txtAoNameRef = txtAo
        Dim pAoBorder As New Panel With {
            .Location = New Point(426, 12),
            .Size = New Size(205, 26),
            .BackColor = Color.FromArgb(0, 100, 210),
            .Padding = New Padding(2)
        }
        pAoBorder.Controls.Add(txtAo)

        Dim btnDots As New Button With {
            .Text = "...",
            .Location = New Point(636, 12),
            .Size = New Size(26, 26),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(200, 200, 200),
            .Font = New Font("Segoe UI", 9)
        }
        btnDots.FlatAppearance.BorderColor = Color.Gray

        Dim btnLoad As New Button With {
            .Text = "Load Next Match",
            .Location = New Point(668, 11),
            .Size = New Size(140, 28),
            .BackColor = Color.FromArgb(255, 200, 0),
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
        }
        btnLoad.FlatAppearance.BorderColor = Color.FromArgb(160, 120, 0)
        btnLoad.FlatAppearance.BorderSize = 2

        p.Controls.AddRange({btnNext, pAkaBorder, btnArrowL, lblVS, btnArrowR, pAoBorder, btnDots, btnLoad})
        Return p
    End Function

    ' ============================================================
    '  BOTTOM BAR
    ' ============================================================
    Private Function BuildBottomBar() As Panel
        Dim p As New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 42,
            .BackColor = Color.FromArgb(210, 210, 210)
        }

        Dim x As Integer = 5
        Dim bSettings As Button = MakeGrayBtn("Settings", New Point(x, 7), 90) : x += 95
        Dim bLog As Button = MakeGrayBtn("Log Activity", New Point(x, 7), 98) : x += 103
        Dim bShort As Button = MakeGrayBtn("Shortcut", New Point(x, 7), 85) : x += 90

        Dim bMon As New Button With {
            .Text = "[]",
            .Location = New Point(x, 7),
            .Size = New Size(32, 28),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(210, 210, 210),
            .Font = New Font("Segoe UI", 9)
        }
        bMon.FlatAppearance.BorderColor = Color.Gray
        x += 36

        Dim bSpk As New Button With {
            .Text = "(((",
            .Location = New Point(x, 7),
            .Size = New Size(32, 28),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(210, 210, 210),
            .Font = New Font("Segoe UI", 9)
        }
        bSpk.FlatAppearance.BorderColor = Color.Gray
        x += 36

        Dim bRH As Button = MakeGrayBtn("Reset Hantei", New Point(x, 7), 108) : x += 113

        Dim bHantei As New Button With {
            .Text = "Hantei",
            .Location = New Point(x, 7),
            .Size = New Size(80, 28),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(0, 100, 200),
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 8.5F)
        }
        bHantei.FlatAppearance.BorderColor = Color.DarkBlue
        x += 85

        Dim bHiki As New Button With {
            .Text = "Hikiwake/Draw",
            .Location = New Point(x, 7),
            .Size = New Size(118, 28),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(0, 100, 200),
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 8.5F)
        }
        bHiki.FlatAppearance.BorderColor = Color.DarkBlue

        Dim bReset As New Button With {
            .Text = "Reset Match",
            .Location = New Point(820, 7),
            .Size = New Size(108, 28),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(200, 200, 200),
            .Font = New Font("Segoe UI", 8.0F)
        }
        bReset.FlatAppearance.BorderColor = Color.Gray

        Dim bSave As New Button With {
            .Text = "Save Match Result",
            .Location = New Point(932, 7),
            .Size = New Size(140, 28),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(200, 200, 200),
            .Font = New Font("Segoe UI", 8.0F)
        }
        bSave.FlatAppearance.BorderColor = Color.Gray

        p.Controls.AddRange({bSettings, bLog, bShort, bMon, bSpk, bRH, bHantei, bHiki, bReset, bSave})
        Return p
    End Function

    ' ============================================================
    '  CENTER PANEL
    ' ============================================================
    Private Function BuildCenterPanel() As Panel
        Dim p As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.FromArgb(200, 200, 200),
            .Padding = New Padding(3)
        }

        Dim pAka As Panel = BuildPlayerPanel(True)
        Dim pAo As Panel = BuildPlayerPanel(False)
        pAka.Location = New Point(3, 3)
        pAo.Location = New Point(3, 3)

        AddHandler p.Resize,
            Sub(s As Object, e As EventArgs)
                Dim W As Integer = p.ClientSize.Width - 6
                Dim H As Integer = (p.ClientSize.Height - 9) \ 2
                pAka.Size = New Size(W, H)
                pAo.Location = New Point(3, H + 6)
                pAo.Size = New Size(W, H)
            End Sub

        p.Controls.Add(pAka)
        p.Controls.Add(pAo)
        Return p
    End Function

    ' ============================================================
    '  PLAYER PANEL (AKA atau AO)
    ' ============================================================
    Private Function BuildPlayerPanel(isAka As Boolean) As Panel
        Dim side As String = If(isAka, "AKA", "AO")

        Dim pMain As New Panel With {
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }

        ' Header berwarna
        Dim pHdr As New Panel With {
            .BackColor = If(isAka, Color.FromArgb(204, 0, 0), Color.FromArgb(30, 120, 220)),
            .Dock = DockStyle.Top,
            .Height = 26
        }
        pHdr.Controls.Add(New Label With {
            .Text = side,
            .Dock = DockStyle.Fill,
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleCenter
        })
        pMain.Controls.Add(pHdr)

        ' ── LEFT SECTION ──
        Dim pL As New Panel With {.Location = New Point(2, 28), .BackColor = Color.White}

        ' Foto
        Dim pPhoto As New Panel With {
            .Location = New Point(4, 4),
            .Size = New Size(62, 78),
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }
        pPhoto.Controls.Add(New Label With {
            .Text = "O",
            .Dock = DockStyle.Fill,
            .ForeColor = Color.FromArgb(180, 100, 180),
            .Font = New Font("Segoe UI", 22),
            .TextAlign = ContentAlignment.MiddleCenter
        })

        ' Info
        Dim txtName As New TextBox With {
            .Location = New Point(135, 4),
            .Size = New Size(185, 20),
            .Text = If(isAka, "Wahyu Hidayat", "Farhan Nugraha"),
            .Font = New Font("Segoe UI", 8.5F)
        }
        Dim txtTeam As New TextBox With {
            .Location = New Point(135, 28),
            .Size = New Size(185, 20),
            .Text = "Dojo Rajawali",
            .Font = New Font("Segoe UI", 8.5F)
        }
        Dim txtInfo As New TextBox With {
            .Location = New Point(135, 52),
            .Size = New Size(185, 20),
            .Text = "INKAI",
            .Font = New Font("Segoe UI", 8.5F)
        }

        ' Simpan referensi nama
        If isAka Then
            txtAkaNameRef = txtName
        Else
            txtAoNameRef = txtName
        End If

        pL.Controls.Add(New Label With {.Text = "Name", .Location = New Point(72, 6), .Size = New Size(60, 16), .Font = New Font("Segoe UI", 8.5F)})
        pL.Controls.Add(New Label With {.Text = "Team", .Location = New Point(72, 30), .Size = New Size(60, 16), .Font = New Font("Segoe UI", 8.5F)})
        pL.Controls.Add(New Label With {.Text = "Team Info", .Location = New Point(72, 54), .Size = New Size(60, 16), .Font = New Font("Segoe UI", 8.5F)})
        pL.Controls.AddRange({txtName, txtTeam, txtInfo})

        ' Tombol kecil kanan info
        Dim btnPerson As New Button With {
            .Text = "P",
            .Location = New Point(326, 4),
            .Size = New Size(26, 20),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(230, 230, 230),
            .Font = New Font("Segoe UI", 8)
        }
        btnPerson.FlatAppearance.BorderColor = Color.Gray

        Dim btnSearch As New Button With {
            .Text = "S",
            .Location = New Point(326, 28),
            .Size = New Size(26, 20),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(230, 230, 230),
            .Font = New Font("Segoe UI", 8)
        }
        btnSearch.FlatAppearance.BorderColor = Color.Gray

        Dim pColorSq As New Panel With {
            .Location = New Point(326, 52),
            .Size = New Size(26, 20),
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim btnUpd As New Button With {
            .Text = "+ Update Info",
            .Location = New Point(135, 76),
            .Size = New Size(150, 22),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(220, 220, 220),
            .Font = New Font("Segoe UI", 8.0F)
        }
        btnUpd.FlatAppearance.BorderColor = Color.Gray

        Dim btnSwp As New Button With {
            .Text = "TT",
            .Location = New Point(292, 76),
            .Size = New Size(28, 22),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(220, 220, 220),
            .Font = New Font("Segoe UI", 8)
        }
        btnSwp.FlatAppearance.BorderColor = Color.Gray

        pL.Controls.AddRange({pPhoto, btnPerson, btnSearch, pColorSq, btnUpd, btnSwp})

        ' Kiken label + penalty buttons
        Dim lblKiken As New Label With {
            .Text = "Kiken",
            .Location = New Point(4, 104),
            .Size = New Size(62, 22),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 8.5F),
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.FromArgb(228, 228, 228)
        }

        Dim px As Integer = 70
        Dim btnP As Button = MakePenBtn("P", New Point(px, 104)) : px += 38
        Dim b1C As Button = MakePenBtn("1C", New Point(px, 104)) : px += 38
        Dim b2C As Button = MakePenBtn("2C", New Point(px, 104)) : px += 38
        Dim b3C As Button = MakePenBtn("3C", New Point(px, 104)) : px += 38
        Dim bHC As Button = MakePenBtn("HC", New Point(px, 104)) : px += 38
        Dim bH As Button = MakePenBtn("H", New Point(px, 104))

        Dim lblShik As New Label With {
            .Text = "Shikkaku",
            .Location = New Point(4, 130),
            .Size = New Size(62, 22),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 7.5F),
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.FromArgb(228, 228, 228)
        }

        Dim lblKO As New Label With {
            .Text = "Knocked Out",
            .Location = New Point(4, 156),
            .Size = New Size(62, 30),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 7.5F),
            .BorderStyle = BorderStyle.FixedSingle,
            .BackColor = Color.FromArgb(228, 228, 228)
        }

        pL.Controls.AddRange({lblKiken, btnP, b1C, b2C, b3C, bHC, bH, lblShik, lblKO})

        ' Score Summary
        Dim grp As New GroupBox With {
            .Text = "Score Summary",
            .Location = New Point(70, 130),
            .Size = New Size(265, 60),
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        }
        Dim lIL As New Label With {.Text = "Ippon", .Location = New Point(6, 16), .Size = New Size(36, 15), .Font = New Font("Segoe UI", 8.0F)}
        Dim lIV As New Label With {.Text = "0", .Location = New Point(44, 16), .Size = New Size(20, 15), .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)}
        Dim lWL As New Label With {.Text = "Waza-ari", .Location = New Point(72, 16), .Size = New Size(52, 15), .Font = New Font("Segoe UI", 8.0F)}
        Dim lWV As New Label With {.Text = "0", .Location = New Point(126, 16), .Size = New Size(20, 15), .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)}
        Dim lYL As New Label With {.Text = "Yuko", .Location = New Point(6, 36), .Size = New Size(36, 15), .Font = New Font("Segoe UI", 8.0F)}
        Dim lYV As New Label With {.Text = "0", .Location = New Point(44, 36), .Size = New Size(20, 15), .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)}
        grp.Controls.AddRange({lIL, lIV, lWL, lWV, lYL, lYV})
        pL.Controls.Add(grp)

        If isAka Then
            lblAkaIpponV = lIV : lblAkaWazaV = lWV : lblAkaYukoV = lYV
        Else
            lblAoIpponV = lIV : lblAoWazaV = lWV : lblAoYukoV = lYV
        End If

        ' VR button
        Dim btnVR As New Button With {
            .Text = "VR",
            .Location = New Point(345, 130),
            .Size = New Size(55, 36),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(248, 248, 220),
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
        }
        btnVR.FlatAppearance.BorderColor = Color.Gray

        Dim lblVRR As New Label With {
            .Text = side & " VR Requested",
            .Location = New Point(335, 170),
            .Size = New Size(82, 22),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 7.0F)
        }
        pL.Controls.AddRange({btnVR, lblVRR})

        ' ── MIDDLE SECTION: ListView log ──
        Dim pM As New Panel With {.BackColor = Color.White}
        Dim lv As New ListView With {
            .Dock = DockStyle.Fill,
            .View = View.Details,
            .FullRowSelect = True,
            .GridLines = True,
            .Font = New Font("Segoe UI", 8.0F),
            .BackColor = Color.White
        }
        lv.Columns.Add("No", 32)
        lv.Columns.Add("Timer", 58)
        lv.Columns.Add("Type", 90)
        pM.Controls.Add(lv)

        ' ── RIGHT SECTION: skor besar + tombol ──
        Dim pR As New Panel With {.BackColor = Color.White}

        Dim lblBig As New Label With {
            .Text = "0",
            .Location = New Point(0, 8),
            .Size = New Size(130, 110),
            .Font = New Font("Segoe UI", 70, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.Black
        }

        If isAka Then : lblAkaScore = lblBig
        Else : lblAoScore = lblBig
        End If

        Dim clr As Color = If(isAka, Color.FromArgb(230, 110, 110), Color.FromArgb(90, 170, 255))
        Dim clrBrd As Color = If(isAka, Color.DarkRed, Color.DarkBlue)

        Dim btnIppon As New Button With {
            .Text = "Ippon 3",
            .Location = New Point(135, 8),
            .Size = New Size(115, 35),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = clr,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
        }
        btnIppon.FlatAppearance.BorderColor = clrBrd

        Dim btnWaza As New Button With {
            .Text = "Waza-ari 2",
            .Location = New Point(135, 47),
            .Size = New Size(115, 35),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = clr,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
        }
        btnWaza.FlatAppearance.BorderColor = clrBrd

        Dim btnYuko As New Button With {
            .Text = "Yuko 1",
            .Location = New Point(135, 86),
            .Size = New Size(115, 35),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = clr,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
        }
        btnYuko.FlatAppearance.BorderColor = clrBrd

        Dim btnShowW As New Button With {
            .Text = "Show Winner",
            .Location = New Point(0, 130),
            .Size = New Size(86, 40),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(222, 222, 222),
            .Font = New Font("Segoe UI", 8.0F)
        }
        btnShowW.FlatAppearance.BorderColor = Color.Gray

        Dim btnReset As New Button With {
            .Text = "Reset Score",
            .Location = New Point(90, 130),
            .Size = New Size(88, 40),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(222, 222, 222),
            .Font = New Font("Segoe UI", 8.0F)
        }
        btnReset.FlatAppearance.BorderColor = Color.Gray

        Dim btnSenshu As New Button With {
            .Text = "Senshu",
            .Location = New Point(182, 130),
            .Size = New Size(72, 40),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(222, 222, 222),
            .Font = New Font("Segoe UI", 8.0F)
        }
        btnSenshu.FlatAppearance.BorderColor = Color.Gray

        pR.Controls.AddRange({lblBig, btnIppon, btnWaza, btnYuko, btnShowW, btnReset, btnSenshu})

        ' ── Wire events (multi-line lambda = BENAR) ──
        If isAka Then
            AddHandler btnIppon.Click,
                Sub(s As Object, e As EventArgs)
                    akaIppon += 1
                    UpdateAkaScore()
                End Sub

            AddHandler btnWaza.Click,
                Sub(s As Object, e As EventArgs)
                    akaWaza += 1
                    UpdateAkaScore()
                End Sub

            AddHandler btnYuko.Click,
                Sub(s As Object, e As EventArgs)
                    akaYuko += 1
                    UpdateAkaScore()
                End Sub

            AddHandler btnReset.Click,
                Sub(s As Object, e As EventArgs)
                    akaIppon = 0
                    akaWaza = 0
                    akaYuko = 0
                    UpdateAkaScore()
                End Sub

            AddHandler btnShowW.Click,
                Sub(s As Object, e As EventArgs)
                    ShowWinner("AKA", txtAkaNameRef.Text)
                End Sub
        Else
            AddHandler btnIppon.Click,
                Sub(s As Object, e As EventArgs)
                    aoIppon += 1
                    UpdateAoScore()
                End Sub

            AddHandler btnWaza.Click,
                Sub(s As Object, e As EventArgs)
                    aoWaza += 1
                    UpdateAoScore()
                End Sub

            AddHandler btnYuko.Click,
                Sub(s As Object, e As EventArgs)
                    aoYuko += 1
                    UpdateAoScore()
                End Sub

            AddHandler btnReset.Click,
                Sub(s As Object, e As EventArgs)
                    aoIppon = 0
                    aoWaza = 0
                    aoYuko = 0
                    UpdateAoScore()
                End Sub

            AddHandler btnShowW.Click,
                Sub(s As Object, e As EventArgs)
                    ShowWinner("AO", txtAoNameRef.Text)
                End Sub
        End If

        ' ── Resize layout handler ──
        AddHandler pMain.Resize,
            Sub(s As Object, e As EventArgs)
                Dim W As Integer = pMain.ClientSize.Width
                Dim H As Integer = pMain.ClientSize.Height
                Dim leftW As Integer = 430
                Dim rightW As Integer = 260
                Dim midW As Integer = Math.Max(W - leftW - rightW - 4, 80)

                pL.Size = New Size(leftW, H - 28)
                pM.Location = New Point(leftW + 2, 28)
                pM.Size = New Size(midW, H - 28)
                pR.Location = New Point(leftW + midW + 4, 28)
                pR.Size = New Size(rightW, H - 28)
            End Sub

        pMain.Controls.AddRange({pHdr, pL, pM, pR})
        Return pMain
    End Function

    ' ============================================================
    '  RIGHT PANEL (Settings)
    ' ============================================================
    Private Function BuildRightPanel() As Panel
        Dim p As New Panel With {
            .Dock = DockStyle.Right,
            .Width = 202,
            .BackColor = Color.FromArgb(236, 236, 236)
        }

        Dim y As Integer = 6

        ' SCBoard Type / Senshu Style
        p.Controls.Add(New Label With {.Text = "SCBoard Type", .Location = New Point(6, y), .Size = New Size(88, 16), .Font = New Font("Segoe UI", 7.5F)})
        p.Controls.Add(New Label With {.Text = "Senshu Style", .Location = New Point(104, y), .Size = New Size(88, 16), .Font = New Font("Segoe UI", 7.5F)})
        y += 17

        p.Controls.Add(MakeSwatch(Color.FromArgb(200, 0, 0), Color.FromArgb(0, 0, 200), New Point(6, y), 52, 22))
        p.Controls.Add(MakeSwatch(Color.FromArgb(0, 0, 180), Color.White, New Point(62, y), 22, 22))
        p.Controls.Add(MakeSwatch(Color.Black, Color.Gray, New Point(88, y), 14, 22))
        p.Controls.Add(MakeSwatch(Color.FromArgb(40, 40, 40), Color.FromArgb(220, 170, 0), New Point(108, y), 22, 22))
        p.Controls.Add(MakeSwatch(Color.Black, Color.FromArgb(50, 50, 200), New Point(134, y), 22, 22))
        y += 28

        y = AddSepR(p, y)

        ' Adjust Scboard Text Size
        p.Controls.Add(New Label With {.Text = "Adjust Scboard Text Size", .Location = New Point(6, y), .Size = New Size(190, 16), .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)})
        y += 18

        Dim cmbPN As New ComboBox With {
            .Location = New Point(6, y),
            .Size = New Size(82, 22),
            .Font = New Font("Segoe UI", 7.5F),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmbPN.Items.AddRange({"Player Name", "Team", "Team Info"})
        cmbPN.SelectedIndex = 0

        Dim nudTS As New NumericUpDown With {
            .Location = New Point(92, y),
            .Size = New Size(46, 22),
            .Value = 1.5D,
            .Minimum = 0.5D,
            .Maximum = 5,
            .Increment = 0.1D,
            .DecimalPlaces = 1,
            .Font = New Font("Segoe UI", 8.0F)
        }
        Dim bR As Button = MakeSmBtn("R", New Point(141, y), 18)
        Dim bMinus As Button = MakeSmBtn("-", New Point(162, y), 16)
        Dim bPlus As Button = MakeSmBtn("+", New Point(180, y), 16)
        p.Controls.AddRange({cmbPN, nudTS, bR, bMinus, bPlus})
        y += 28

        y = AddSepR(p, y)

        ' Match Detail / Logo tabs
        Dim btnMD As New Button With {
            .Text = "Match Detail",
            .Location = New Point(6, y),
            .Size = New Size(88, 22),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.White,
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        }
        btnMD.FlatAppearance.BorderColor = Color.Gray

        Dim btnML As New Button With {
            .Text = "Match Logo",
            .Location = New Point(97, y),
            .Size = New Size(80, 22),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(218, 218, 218),
            .Font = New Font("Segoe UI", 7.5F)
        }
        btnML.FlatAppearance.BorderColor = Color.Gray
        y += 24

        Dim txtDesc As New TextBox With {
            .Location = New Point(6, y),
            .Size = New Size(172, 58),
            .Multiline = True,
            .Text = "Match Description...",
            .ForeColor = Color.Gray,
            .Font = New Font("Segoe UI", 8.0F),
            .ScrollBars = ScrollBars.Vertical
        }
        Dim btnX As New Button With {
            .Text = "X",
            .Location = New Point(180, y),
            .Size = New Size(16, 16),
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 7.0F)
        }
        btnX.FlatAppearance.BorderColor = Color.Gray

        Dim btnGo As New Button With {
            .Text = ">",
            .Location = New Point(170, y + 42),
            .Size = New Size(26, 18),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(200, 200, 200),
            .Font = New Font("Segoe UI", 8.0F)
        }
        btnGo.FlatAppearance.BorderColor = Color.Gray

        p.Controls.AddRange({btnMD, btnML, txtDesc, btnX, btnGo})
        y += 64

        y = AddSepR(p, y)

        ' Win Point
        p.Controls.Add(New Label With {.Text = "Win. Point", .Location = New Point(6, y + 3), .Size = New Size(60, 16), .Font = New Font("Segoe UI", 8.0F)})
        Dim nudWP As New NumericUpDown With {.Location = New Point(68, y), .Size = New Size(42, 22), .Minimum = 1, .Maximum = 99, .Value = 8, .Font = New Font("Segoe UI", 8.0F)}
        Dim bEd As Button = MakeSmBtn("Edit", New Point(114, y), 40)
        p.Controls.AddRange({nudWP, bEd})
        y += 28

        ' Tatami
        p.Controls.Add(New Label With {.Text = "Tatami", .Location = New Point(6, y + 3), .Size = New Size(46, 16), .Font = New Font("Segoe UI", 8.0F)})
        Dim nudTat As New NumericUpDown With {.Location = New Point(54, y), .Size = New Size(42, 22), .Minimum = 1, .Maximum = 20, .Value = 1, .Font = New Font("Segoe UI", 8.0F)}

        Dim btnSwitchPos As New Button With {
    .Text = "Switch Position",
    .Location = New Point(100, y),
    .Size = New Size(88, 22),
    .FlatStyle = FlatStyle.Flat,
    .BackColor = Color.FromArgb(200, 50, 50),
    .ForeColor = Color.White,
    .Font = New Font("Segoe UI", 7.5F)
}
        btnSwitchPos.FlatAppearance.BorderColor = Color.DarkRed

        Dim pRSq As New Panel With {
    .Location = New Point(190, y + 2),
    .Size = New Size(8, 18),
    .BackColor = Color.Red
}
        p.Controls.AddRange({nudTat, btnSwitchPos, pRSq})
        y += 28

        y = AddSepR(p, y)

        ' Waiting Timer
        p.Controls.Add(New Label With {
    .Text = "Waiting Timer (minute:second)",
    .Location = New Point(4, y),
    .Size = New Size(192, 18),
    .BackColor = Color.FromArgb(255, 230, 80),
    .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
    .TextAlign = ContentAlignment.MiddleCenter
})
        y += 20

        Dim nudWM As New NumericUpDown With {
    .Location = New Point(6, y),
    .Size = New Size(40, 22),
    .Minimum = 0,
    .Maximum = 99,
    .Value = 2,
    .Font = New Font("Segoe UI", 8.0F)
}

        p.Controls.Add(New Label With {
    .Text = ":",
    .Location = New Point(49, y + 4),
    .Size = New Size(10, 14),
    .TextAlign = ContentAlignment.MiddleCenter
})

        Dim nudWS As New NumericUpDown With {
    .Location = New Point(61, y),
    .Size = New Size(40, 22),
    .Minimum = 0,
    .Maximum = 59,
    .Value = 0,
    .Font = New Font("Segoe UI", 8.0F)
}

        Dim btnStartWaiting As New Button With {
    .Text = "Start",
    .Location = New Point(108, y),
    .Size = New Size(46, 22),
    .FlatStyle = FlatStyle.Flat,
    .BackColor = Color.LightGreen,
    .Font = New Font("Segoe UI", 8.0F)
}
        btnStartWaiting.FlatAppearance.BorderColor = Color.Green

        p.Controls.AddRange({nudWM, nudWS, btnStartWaiting})
        y += 28
        y = AddSepR(p, y)

        ' Match Timer header
        p.Controls.Add(New Label With {
            .Text = "Match Timer (minute:second)",
            .Location = New Point(4, y),
            .Size = New Size(192, 18),
            .BackColor = Color.FromArgb(255, 200, 0),
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleCenter
        })
        y += 20

        ' Preset tombol
        Dim b130 As New Button With {.Text = "1:30", .Location = New Point(4, y), .Size = New Size(48, 20), .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 7.5F)}
        b130.FlatAppearance.BorderColor = Color.Gray
        Dim b200 As New Button With {.Text = "2:00", .Location = New Point(58, y), .Size = New Size(48, 20), .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 7.5F)}
        b200.FlatAppearance.BorderColor = Color.Gray
        Dim b300 As New Button With {.Text = "3:00", .Location = New Point(112, y), .Size = New Size(48, 20), .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 7.5F)}
        b300.FlatAppearance.BorderColor = Color.Gray
        p.Controls.AddRange({b130, b200, b300})
        y += 24

        nudMatchMin = New NumericUpDown With {.Location = New Point(4, y), .Size = New Size(40, 22), .Minimum = 0, .Maximum = 99, .Value = 2, .Font = New Font("Segoe UI", 8.0F)}
        p.Controls.Add(New Label With {.Text = ":", .Location = New Point(47, y + 4), .Size = New Size(10, 14), .TextAlign = ContentAlignment.MiddleCenter})
        nudMatchSec = New NumericUpDown With {.Location = New Point(59, y), .Size = New Size(40, 22), .Minimum = 0, .Maximum = 59, .Value = 0, .Font = New Font("Segoe UI", 8.0F)}
        p.Controls.AddRange({nudMatchMin, nudMatchSec})
        y += 28

        ' Adjust Timer display
        p.Controls.Add(New Label With {.Text = "Adjust Timer", .Location = New Point(4, y + 7), .Size = New Size(72, 16), .Font = New Font("Segoe UI", 7.5F)})
        lblTimerDisp = New Label With {
            .Text = "2:00",
            .Location = New Point(78, y),
            .Size = New Size(72, 32),
            .Font = New Font("Segoe UI", 16, FontStyle.Bold),
            .BackColor = Color.FromArgb(255, 200, 0),
            .TextAlign = ContentAlignment.MiddleCenter,
            .BorderStyle = BorderStyle.FixedSingle
        }
        p.Controls.Add(New Label With {.Text = ".0", .Location = New Point(152, y + 8), .Size = New Size(18, 14), .Font = New Font("Segoe UI", 8.0F)})
        Dim bTM As Button = MakeSmBtn("-", New Point(153, y), 18)
        Dim bTP As Button = MakeSmBtn("+", New Point(173, y), 18)
        p.Controls.AddRange({lblTimerDisp, bTM, bTP})
        y += 36

        y = AddSepR(p, y)

        ' Start Scoreboard
        Dim btnSB As New Button With {
            .Text = "Start Scoreboard",
            .Location = New Point(4, y),
            .Size = New Size(158, 28),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(0, 185, 75),
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
        }
        btnSB.FlatAppearance.BorderColor = Color.DarkGreen

        Dim pSBIco As New Panel With {
            .Location = New Point(164, y + 4),
            .Size = New Size(32, 20),
            .BackColor = Color.FromArgb(10, 40, 130),
            .BorderStyle = BorderStyle.FixedSingle
        }
        pSBIco.Controls.Add(New Label With {
            .Text = "10",
            .Dock = DockStyle.Fill,
            .ForeColor = Color.White,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        })
        y += 32

        ' Start Timer
        btnStartTimer = New Button With {
            .Text = "Start Timer",
            .Location = New Point(4, y),
            .Size = New Size(158, 28),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(255, 200, 0),
            .ForeColor = Color.Black,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
        }
        btnStartTimer.FlatAppearance.BorderColor = Color.FromArgb(160, 120, 0)

        Dim pTIco As New Panel With {
            .Location = New Point(164, y + 4),
            .Size = New Size(32, 20),
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }
        pTIco.Controls.Add(New Label With {
            .Text = "O",
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 10)
        })

        p.Controls.AddRange({btnSB, pSBIco, btnStartTimer, pTIco})

        ' Wire timer events
        AddHandler b130.Click,
            Sub(s As Object, e As EventArgs)
                SetMatchTime(1, 30)
            End Sub

        AddHandler b200.Click,
            Sub(s As Object, e As EventArgs)
                SetMatchTime(2, 0)
            End Sub

        AddHandler b300.Click,
            Sub(s As Object, e As EventArgs)
                SetMatchTime(3, 0)
            End Sub

        AddHandler nudMatchMin.ValueChanged, AddressOf NudTimer_Changed
        AddHandler nudMatchSec.ValueChanged, AddressOf NudTimer_Changed
        AddHandler btnStartTimer.Click, AddressOf StartTimer_Click

        Return p
    End Function

    ' ============================================================
    '  HELPER FUNCTIONS
    ' ============================================================
    Private Function MakeGrayBtn(txt As String, loc As Point, w As Integer) As Button
        Dim b As New Button With {
            .Text = txt,
            .Location = loc,
            .Size = New Size(w, 28),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(210, 210, 210),
            .Font = New Font("Segoe UI", 8.0F)
        }
        b.FlatAppearance.BorderColor = Color.Gray
        Return b
    End Function

    Private Function MakePenBtn(txt As String, loc As Point) As Button
        Dim b As New Button With {
            .Text = txt,
            .Location = loc,
            .Size = New Size(34, 22),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(232, 232, 232),
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        }
        b.FlatAppearance.BorderColor = Color.Gray
        Return b
    End Function

    Private Function MakeSmBtn(txt As String, loc As Point, w As Integer) As Button
        Dim b As New Button With {
            .Text = txt,
            .Location = loc,
            .Size = New Size(w, 22),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(222, 222, 222),
            .Font = New Font("Segoe UI", 8.0F)
        }
        b.FlatAppearance.BorderColor = Color.Gray
        Return b
    End Function

    Private Function MakeSwatch(c1 As Color, c2 As Color, loc As Point, w As Integer, h As Integer) As Panel
        Dim pnl As New Panel With {
            .Location = loc,
            .Size = New Size(w, h),
            .BorderStyle = BorderStyle.FixedSingle
        }
        AddHandler pnl.Paint,
            Sub(s As Object, e As PaintEventArgs)
                Dim pw As Integer = CType(s, Panel).Width
                Dim ph As Integer = CType(s, Panel).Height
                Dim half As Integer = pw \ 2
                e.Graphics.FillRectangle(New SolidBrush(c1), 0, 0, half, ph)
                e.Graphics.FillRectangle(New SolidBrush(c2), half, 0, pw - half, ph)
            End Sub
        Return pnl
    End Function

    Private Function AddSepR(p As Panel, y As Integer) As Integer
        p.Controls.Add(New Label With {
            .BorderStyle = BorderStyle.Fixed3D,
            .Height = 2,
            .Location = New Point(4, y),
            .Width = 192
        })
        Return y + 6
    End Function

    ' ============================================================
    '  SCORE LOGIC
    ' ============================================================
    Private Sub UpdateAkaScore()
        Dim total As Integer = akaIppon * 3 + akaWaza * 2 + akaYuko
        If lblAkaScore IsNot Nothing Then lblAkaScore.Text = total.ToString()
        If lblAkaIpponV IsNot Nothing Then lblAkaIpponV.Text = akaIppon.ToString()
        If lblAkaWazaV IsNot Nothing Then lblAkaWazaV.Text = akaWaza.ToString()
        If lblAkaYukoV IsNot Nothing Then lblAkaYukoV.Text = akaYuko.ToString()
    End Sub

    Private Sub UpdateAoScore()
        Dim total As Integer = aoIppon * 3 + aoWaza * 2 + aoYuko
        If lblAoScore IsNot Nothing Then lblAoScore.Text = total.ToString()
        If lblAoIpponV IsNot Nothing Then lblAoIpponV.Text = aoIppon.ToString()
        If lblAoWazaV IsNot Nothing Then lblAoWazaV.Text = aoWaza.ToString()
        If lblAoYukoV IsNot Nothing Then lblAoYukoV.Text = aoYuko.ToString()
    End Sub

    Private Sub ShowWinner(side As String, name As String)
        MessageBox.Show("Pemenang: " & name & vbCrLf & "Sisi: " & side,
                        "Hasil Pertandingan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub

    ' ============================================================
    '  TIMER LOGIC
    ' ============================================================
    Private Sub SetMatchTime(m As Integer, s As Integer)
        nudMatchMin.Value = m
        nudMatchSec.Value = s
        matchSeconds = m * 60 + s
        UpdateTimerLabel()
    End Sub

    Private Sub NudTimer_Changed(sender As Object, e As EventArgs)
        matchSeconds = CInt(nudMatchMin.Value) * 60 + CInt(nudMatchSec.Value)
        UpdateTimerLabel()
    End Sub

    Private Sub StartTimer_Click(sender As Object, e As EventArgs)
        If timerRunning Then
            tmrMatch.Stop()
            timerRunning = False
            btnStartTimer.Text = "Start Timer"
            btnStartTimer.BackColor = Color.FromArgb(255, 200, 0)
            btnStartTimer.ForeColor = Color.Black
        Else
            tmrMatch.Start()
            timerRunning = True
            btnStartTimer.Text = "Stop Timer"
            btnStartTimer.BackColor = Color.OrangeRed
            btnStartTimer.ForeColor = Color.White
        End If
    End Sub

    Private Sub tmrMatch_Tick(sender As Object, e As EventArgs) Handles tmrMatch.Tick
        If matchSeconds > 0 Then
            matchSeconds -= 1
            UpdateTimerLabel()
        Else
            tmrMatch.Stop()
            timerRunning = False
            btnStartTimer.Text = "Start Timer"
            btnStartTimer.BackColor = Color.FromArgb(255, 200, 0)
            btnStartTimer.ForeColor = Color.Black
            MessageBox.Show("Waktu Habis!",
                            "Pertandingan Selesai",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub UpdateTimerLabel()
        If lblTimerDisp IsNot Nothing Then
            lblTimerDisp.Text = CStr(matchSeconds \ 60) & ":" & (matchSeconds Mod 60).ToString("D2")
        End If
    End Sub

    ' ============================================================
    '  ENTRY POINT
    ' ============================================================
    <STAThread>
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New KumiteMainControl())
    End Sub

End Class