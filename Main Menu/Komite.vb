Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class KumiteMainControl
    Inherits Form

    ' --- Palet Warna Professional ---
    Private ReadOnly COLOR_AKA As Color = Color.FromArgb(215, 25, 50)
    Private ReadOnly COLOR_AO As Color = Color.FromArgb(50, 150, 250)
    Private ReadOnly COLOR_GOLD As Color = Color.FromArgb(255, 204, 0)
    Private ReadOnly COLOR_BG As Color = Color.FromArgb(235, 236, 239)
    Private ReadOnly COLOR_DARK_BAR As Color = Color.FromArgb(45, 45, 45)
    Private ReadOnly COLOR_WAITING As Color = Color.FromArgb(255, 235, 200)

    Public Sub New()
        ' Setup Form Utama
        Me.Text = "Kumite Main Control"
        Me.Size = New Size(1160, 780)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = COLOR_BG
        Me.Font = New Font("Segoe UI", 9.0F)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        InitializeComponentManual()
    End Sub

    Private Sub InitializeComponentManual()
        Me.Controls.Clear()

        ' 1. TOP BAR
        Dim pnlTop As New Panel With {.Dock = DockStyle.Top, .Height = 55, .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle}
        BuildTopBar(pnlTop)
        Me.Controls.Add(pnlTop)

        ' 2. AKA PANEL
        Dim pnlAka As New Panel With {.Location = New Point(12, 65), .Size = New Size(855, 280), .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle}
        BuildAthletePanel(pnlAka, "AKA", COLOR_AKA, "Siti Aminah", "Harimau Putih", "KKI")
        Me.Controls.Add(pnlAka)

        ' 3. AO PANEL
        Dim pnlAo As New Panel With {.Location = New Point(12, 355), .Size = New Size(855, 280), .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle}
        BuildAthletePanel(pnlAo, "AO", COLOR_AO, "Anisa Rahmawati", "Dojo Rajawali", "INKAI")
        Me.Controls.Add(pnlAo)

        ' 4. RIGHT PANEL
        Dim pnlRight As New Panel With {.Location = New Point(875, 65), .Size = New Size(255, 570), .BackColor = Color.FromArgb(248, 248, 248), .BorderStyle = BorderStyle.FixedSingle}
        BuildRightPanel(pnlRight)
        Me.Controls.Add(pnlRight)

        ' 5. FOOTER
        Dim pnlFooter As New Panel With {.Dock = DockStyle.Bottom, .Height = 65, .BackColor = COLOR_DARK_BAR}
        BuildFooter(pnlFooter)
        Me.Controls.Add(pnlFooter)
    End Sub

    ' --- BUILD TOP BAR ---
    Private Sub BuildTopBar(p As Panel)
        p.Controls.Add(CreateBtn("Next Match", 10, 10, 90, 32, COLOR_GOLD, Color.Black))

        Dim txtAka As New TextBox With {.Location = New Point(105, 12), .Size = New Size(180, 25), .BorderStyle = BorderStyle.FixedSingle}
        p.Controls.Add(txtAka)
        p.Controls.Add(CreateBtn("👤", 288, 12, 35, 25, Color.WhiteSmoke, Color.Black))

        Dim lblVs As New Label With {.Text = "VS", .Location = New Point(325, 12), .Size = New Size(40, 28), .BackColor = COLOR_GOLD, .TextAlign = ContentAlignment.MiddleCenter, .Font = New Font("Arial Black", 10)}
        p.Controls.Add(lblVs)

        p.Controls.Add(CreateBtn("👤", 368, 12, 35, 25, Color.WhiteSmoke, Color.Black))
        Dim txtAo As New TextBox With {.Location = New Point(405, 12), .Size = New Size(180, 25), .BorderStyle = BorderStyle.FixedSingle}
        p.Controls.Add(txtAo)

        p.Controls.Add(CreateBtn("Load Next Match", 600, 10, 120, 32, COLOR_GOLD, Color.Black))
    End Sub

    ' --- BUILD ATHLETE PANEL ---
    Private Sub BuildAthletePanel(p As Panel, side As String, clr As Color, n As String, t As String, info As String)
        Dim h As New Panel With {.Dock = DockStyle.Top, .Height = 30, .BackColor = clr}
        h.Controls.Add(New Label With {.Text = side, .ForeColor = Color.White, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleCenter, .Font = New Font("Segoe UI Black", 11)})
        p.Controls.Add(h)

        ' Left Info
        Dim pic As New Panel With {.Location = New Point(15, 45), .Size = New Size(65, 65), .BorderStyle = BorderStyle.FixedSingle, .BackColor = Color.WhiteSmoke}
        p.Controls.Add(pic)
        p.Controls.Add(New Panel With {.Location = New Point(88, 45), .Size = New Size(4, 100), .BackColor = COLOR_GOLD})

        p.Controls.Add(CreateBtn("Kiken", 15, 120, 70, 25, Color.White, Color.Black, 8))
        p.Controls.Add(CreateBtn("Shikkaku", 15, 148, 70, 25, Color.White, Color.Black, 8))
        p.Controls.Add(CreateBtn("Knocked Out", 15, 176, 70, 35, Color.White, Color.Black, 7.5))

        ' Fields
        AddInput(p, "Name", 100, 45, n)
        AddInput(p, "Team", 100, 72, t)
        AddInput(p, "Team Info", 100, 99, info)
        p.Controls.Add(CreateBtn("Update Info", 215, 128, 90, 25, Color.WhiteSmoke, Color.Black, 8))
        p.Controls.Add(CreateBtn("⇅", 310, 128, 30, 25, Color.WhiteSmoke, Color.Black))

        ' Penalties
        Dim pens() As String = {"P", "1C", "2C", "3C", "HC", "H"}
        For i As Integer = 0 To pens.Length - 1
            p.Controls.Add(CreateBtn(pens(i), 110 + (i * 45), 170, 42, 40, Color.White, Color.Black, 9))
        Next

        ' Score Summary Box
        Dim pSum As New Panel With {.Location = New Point(110, 220), .Size = New Size(185, 45), .BackColor = Color.FromArgb(245, 245, 245), .BorderStyle = BorderStyle.FixedSingle}
        pSum.Controls.Add(New Label With {.Text = "Score Summary", .Dock = DockStyle.Top, .Height = 15, .Font = New Font("Segoe UI", 7, FontStyle.Bold), .TextAlign = ContentAlignment.MiddleCenter})
        pSum.Controls.Add(New Label With {.Text = "Ippon: 0  Waza-ari: 0  Yuko: 0", .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleCenter, .Font = New Font("Segoe UI", 8)})
        p.Controls.Add(pSum)

        p.Controls.Add(CreateBtn("VR", 305, 220, 90, 25, Color.White, Color.Black, 8))
        p.Controls.Add(New Label With {.Text = side & " VR Requested", .Location = New Point(305, 248), .AutoSize = True, .Font = New Font("Segoe UI", 7)})

        ' Log Table
        Dim lv As New ListView With {.View = View.Details, .Location = New Point(440, 45), .Size = New Size(220, 165), .GridLines = True}
        lv.Columns.Add("No", 35) : lv.Columns.Add("Timer", 60) : lv.Columns.Add("Type", 120)
        p.Controls.Add(lv)

        p.Controls.Add(CreateBtn("Show Winner", 440, 220, 90, 35, Color.White, Color.Black, 8))
        p.Controls.Add(CreateBtn("Reset Score", 535, 220, 90, 35, Color.White, Color.Black, 8))
        p.Controls.Add(CreateBtn("Senshu", 630, 220, 65, 35, Color.White, Color.Black, 8))

        ' Score Big
        Dim lblSc As New Label With {.Text = "0", .Location = New Point(680, 45), .Size = New Size(100, 100), .Font = New Font("Impact", 75), .TextAlign = ContentAlignment.MiddleCenter}
        p.Controls.Add(lblSc)

        p.Controls.Add(CreateBtn("Ippon 3", 775, 45, 70, 40, Color.FromArgb(255, 210, 210), Color.DarkRed, 8.5))
        p.Controls.Add(CreateBtn("Waza-ari 2", 775, 90, 70, 40, Color.FromArgb(210, 230, 255), Color.DarkBlue, 8.5))
        p.Controls.Add(CreateBtn("Yuko 1", 775, 135, 70, 40, Color.WhiteSmoke, Color.Black, 8.5))
    End Sub

    ' --- BUILD RIGHT PANEL ---
    Private Sub BuildRightPanel(p As Panel)
        ' Styles
        p.Controls.Add(New Label With {.Text = "SCBoard Type   Senshu Style", .Location = New Point(10, 5), .AutoSize = True, .Font = New Font("Segoe UI", 7)})
        p.Controls.Add(CreateColorBox(10, 20, Color.Red, Color.Blue))
        p.Controls.Add(CreateColorBox(42, 20, Color.Gold, Color.Blue))
        p.Controls.Add(CreateSenshuBox(135, 20, Color.Green))
        p.Controls.Add(CreateSenshuBox(165, 20, Color.Black))

        ' Text Size
        p.Controls.Add(New Label With {.Text = "Adjust Scboard Text Size", .Location = New Point(10, 55), .AutoSize = True, .Font = New Font("Segoe UI", 7)})
        Dim cmb As New ComboBox With {.Location = New Point(10, 70), .Width = 85, .Font = New Font("Segoe UI", 8)}
        cmb.Items.Add("Player Name") : cmb.SelectedIndex = 0
        p.Controls.Add(cmb)
        Dim numSize As New NumericUpDown With {.Location = New Point(100, 70), .Width = 40, .Value = 1.5}
        p.Controls.Add(numSize)
        p.Controls.Add(CreateBtn("R", 145, 69, 25, 24, Color.White, Color.Black, 7))
        p.Controls.Add(CreateBtn("-", 175, 69, 25, 24, Color.White, Color.Black, 7))
        p.Controls.Add(CreateBtn("+", 205, 69, 25, 24, Color.White, Color.Black, 7))

        ' Match Detail
        p.Controls.Add(New Label With {.Text = "Match Detail", .Location = New Point(10, 105), .AutoSize = True, .Font = New Font("Segoe UI", 8, FontStyle.Bold)})
        Dim txtDet As New TextBox With {.Multiline = True, .Location = New Point(10, 125), .Size = New Size(230, 60), .Text = "Match Description...", .ForeColor = Color.Gray}
        p.Controls.Add(txtDet)

        ' Settings 2
        p.Controls.Add(New Label With {.Text = "Win. Point", .Location = New Point(10, 200), .AutoSize = True})
        p.Controls.Add(New NumericUpDown With {.Location = New Point(75, 198), .Width = 40, .Value = 8})
        p.Controls.Add(CreateBtn("Edit", 125, 198, 45, 24, Color.White, Color.Black, 7))

        p.Controls.Add(New Label With {.Text = "Tatami", .Location = New Point(10, 230), .AutoSize = True})
        p.Controls.Add(New NumericUpDown With {.Location = New Point(75, 228), .Width = 40, .Value = 1})
        p.Controls.Add(CreateBtn("Switch Position", 125, 228, 115, 30, Color.WhiteSmoke, Color.Black, 7.5))

        ' Waiting Timer
        Dim lblWait As New Label With {.Text = "Waiting Timer (minute:second)", .Location = New Point(0, 265), .Size = New Size(255, 20), .BackColor = COLOR_WAITING, .TextAlign = ContentAlignment.MiddleCenter, .Font = New Font("Segoe UI", 7.5)}
        p.Controls.Add(lblWait)
        p.Controls.Add(New NumericUpDown With {.Location = New Point(10, 290), .Width = 40, .Value = 2})
        p.Controls.Add(New Label With {.Text = ":", .Location = New Point(52, 290), .AutoSize = True})
        p.Controls.Add(New NumericUpDown With {.Location = New Point(65, 290), .Width = 40, .Value = 0})
        p.Controls.Add(CreateBtn("Start", 125, 288, 115, 28, COLOR_GOLD, Color.Black))

        ' Match Timer (Gold)
        p.Controls.Add(New Label With {.Text = "Match Timer (minute:second)", .Location = New Point(0, 330), .Size = New Size(255, 22), .BackColor = COLOR_GOLD, .TextAlign = ContentAlignment.MiddleCenter, .Font = New Font("Segoe UI", 8, FontStyle.Bold)})
        p.Controls.Add(CreateBtn("1:30", 15, 360, 65, 25, Color.White, Color.Black, 8))
        p.Controls.Add(CreateBtn("2:00", 85, 360, 65, 25, Color.White, Color.Black, 8))
        p.Controls.Add(CreateBtn("3:00", 155, 360, 65, 25, Color.White, Color.Black, 8))

        p.Controls.Add(New NumericUpDown With {.Location = New Point(50, 395), .Width = 45, .Value = 0})
        p.Controls.Add(New Label With {.Text = ":", .Location = New Point(100, 395), .AutoSize = True})
        p.Controls.Add(New NumericUpDown With {.Location = New Point(115, 395), .Width = 45, .Value = 5})

        Dim pTmr As New Panel With {.Location = New Point(70, 425), .Size = New Size(100, 45), .BackColor = COLOR_GOLD, .BorderStyle = BorderStyle.FixedSingle}
        pTmr.Controls.Add(New Label With {.Text = "0:05 .0", .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleCenter, .Font = New Font("Consolas", 18, FontStyle.Bold)})
        p.Controls.Add(pTmr)
        p.Controls.Add(CreateBtn("-", 180, 430, 25, 35, Color.White, Color.Black, 10))
        p.Controls.Add(CreateBtn("+", 210, 430, 25, 35, Color.White, Color.Black, 10))

        ' Buttons Main
        p.Controls.Add(CreateBtn("Start Scoreboard  📊", 10, 485, 235, 35, Color.SpringGreen, Color.Black, 10))
        p.Controls.Add(CreateBtn("Start Timer  ⏱", 10, 525, 235, 35, COLOR_GOLD, Color.Black, 10))
    End Sub

    ' --- BUILD FOOTER ---
    Private Sub BuildFooter(p As Panel)
        p.Controls.Add(CreateBtn("Settings ⚙", 10, 12, 90, 40, Color.White, Color.Black))
        p.Controls.Add(CreateBtn("Log Activity", 105, 12, 90, 40, Color.White, Color.Black))
        p.Controls.Add(CreateBtn("Shortcut ⌨", 200, 12, 90, 40, Color.White, Color.Black))

        p.Controls.Add(CreateBtn("🖥", 300, 12, 35, 40, Color.White, Color.Black, 12))
        p.Controls.Add(CreateBtn("🔊", 340, 12, 35, 40, Color.White, Color.Black, 12))

        p.Controls.Add(CreateBtn("Reset Hantei", 400, 12, 100, 40, Color.White, Color.Black))
        p.Controls.Add(CreateBtn("Hantei 🚩", 505, 12, 90, 40, Color.White, Color.Black))
        p.Controls.Add(CreateBtn("Hikiwake/Draw", 600, 12, 130, 40, Color.White, Color.Black))

        p.Controls.Add(CreateBtn("Reset Match", 780, 12, 90, 40, Color.White, Color.Black))
        p.Controls.Add(CreateBtn("Save Match Result 💾", 880, 12, 250, 40, Color.White, Color.Black, 10))
    End Sub

    ' --- HELPERS ---
    Private Function CreateBtn(t As String, x As Integer, y As Integer, w As Integer, h As Integer, bg As Color, fg As Color, Optional fs As Single = 9) As Button
        Dim btn As New Button With {.Text = t, .Location = New Point(x, y), .Size = New Size(w, h), .BackColor = bg, .ForeColor = fg, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI Semibold", fs)}
        btn.FlatAppearance.BorderColor = Color.Gray
        Return btn
    End Function

    Private Sub AddInput(p As Panel, t As String, x As Integer, y As Integer, val As String)
        p.Controls.Add(New Label With {.Text = t, .Location = New Point(x, y + 3), .AutoSize = True, .Font = New Font("Segoe UI", 8)})
        p.Controls.Add(New TextBox With {.Text = val, .Location = New Point(x + 70, y), .Size = New Size(150, 23), .BorderStyle = BorderStyle.FixedSingle})
        p.Controls.Add(CreateBtn("🔍", x + 222, y, 25, 23, Color.WhiteSmoke, Color.Black, 7))
    End Sub

    Private Function CreateColorBox(x As Integer, y As Integer, c1 As Color, c2 As Color) As Panel
        Dim p As New Panel With {.Location = New Point(x, y), .Size = New Size(28, 20), .BorderStyle = BorderStyle.FixedSingle}
        Dim t As New Panel With {.Dock = DockStyle.Top, .Height = 10, .BackColor = c1}
        Dim b As New Panel With {.Dock = DockStyle.Bottom, .Height = 10, .BackColor = c2}
        p.Controls.Add(t) : p.Controls.Add(b)
        Return p
    End Function

    Private Function CreateSenshuBox(x As Integer, y As Integer, bg As Color) As Panel
        Dim p As New Panel With {.Location = New Point(x, y), .Size = New Size(25, 25), .BackColor = bg, .BorderStyle = BorderStyle.FixedSingle}
        p.Controls.Add(New Label With {.Text = "S", .ForeColor = Color.Yellow, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleCenter, .Font = New Font("Arial Black", 9)})
        Return p
    End Function
End Class