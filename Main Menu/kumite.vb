Public Class kumite

    Dim lblScoreAKA As New Label
    Dim lblScoreAO As New Label

    Dim scoreAKA As Integer = 0
    Dim scoreAO As Integer = 0

    Private Sub kumite_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Kumite"
        Me.WindowState = FormWindowState.Maximized

        ' ================= PANEL AKA =================
        Dim panelAKA As New Panel
        panelAKA.BackColor = Color.Red
        panelAKA.Dock = DockStyle.Top
        panelAKA.Height = 250
        Me.Controls.Add(panelAKA)

        ' Label Score AKA
        lblScoreAKA.Text = "0"
        lblScoreAKA.Font = New Font("Arial", 30, FontStyle.Bold)
        lblScoreAKA.ForeColor = Color.White
        lblScoreAKA.Location = New Point(50, 50)
        panelAKA.Controls.Add(lblScoreAKA)

        ' Button AKA
        Dim btnIpponAKA As New Button
        btnIpponAKA.Text = "Ippon"
        btnIpponAKA.Location = New Point(50, 120)
        AddHandler btnIpponAKA.Click, AddressOf btnIpponAKA_Click
        panelAKA.Controls.Add(btnIpponAKA)

        Dim btnWazaAKA As New Button
        btnWazaAKA.Text = "Waza-ari"
        btnWazaAKA.Location = New Point(150, 120)
        AddHandler btnWazaAKA.Click, AddressOf btnWazaAKA_Click
        panelAKA.Controls.Add(btnWazaAKA)

        Dim btnYukoAKA As New Button
        btnYukoAKA.Text = "Yuko"
        btnYukoAKA.Location = New Point(270, 120)
        AddHandler btnYukoAKA.Click, AddressOf btnYukoAKA_Click
        panelAKA.Controls.Add(btnYukoAKA)

        ' ================= PANEL AO =================
        Dim panelAO As New Panel
        panelAO.BackColor = Color.Blue
        panelAO.Dock = DockStyle.Bottom
        panelAO.Height = 250
        Me.Controls.Add(panelAO)

        ' Label Score AO
        lblScoreAO.Text = "0"
        lblScoreAO.Font = New Font("Arial", 30, FontStyle.Bold)
        lblScoreAO.ForeColor = Color.White
        lblScoreAO.Location = New Point(50, 50)
        panelAO.Controls.Add(lblScoreAO)

        ' Button AO
        Dim btnIpponAO As New Button
        btnIpponAO.Text = "Ippon"
        btnIpponAO.Location = New Point(50, 120)
        AddHandler btnIpponAO.Click, AddressOf btnIpponAO_Click
        panelAO.Controls.Add(btnIpponAO)

        Dim btnWazaAO As New Button
        btnWazaAO.Text = "Waza-ari"
        btnWazaAO.Location = New Point(150, 120)
        AddHandler btnWazaAO.Click, AddressOf btnWazaAO_Click
        panelAO.Controls.Add(btnWazaAO)

        Dim btnYukoAO As New Button
        btnYukoAO.Text = "Yuko"
        btnYukoAO.Location = New Point(270, 120)
        AddHandler btnYukoAO.Click, AddressOf btnYukoAO_Click
        panelAO.Controls.Add(btnYukoAO)

        ' ================= RESET =================
        Dim btnReset As New Button
        btnReset.Text = "Reset"
        btnReset.Location = New Point(400, 300)
        AddHandler btnReset.Click, AddressOf btnReset_Click
        Me.Controls.Add(btnReset)

    End Sub

    ' ================= LOGIC =================
    Private Sub btnIpponAKA_Click(sender As Object, e As EventArgs)
        scoreAKA += 3
        lblScoreAKA.Text = scoreAKA
    End Sub

    Private Sub btnWazaAKA_Click(sender As Object, e As EventArgs)
        scoreAKA += 2
        lblScoreAKA.Text = scoreAKA
    End Sub

    Private Sub btnYukoAKA_Click(sender As Object, e As EventArgs)
        scoreAKA += 1
        lblScoreAKA.Text = scoreAKA
    End Sub

    Private Sub btnIpponAO_Click(sender As Object, e As EventArgs)
        scoreAO += 3
        lblScoreAO.Text = scoreAO
    End Sub

    Private Sub btnWazaAO_Click(sender As Object, e As EventArgs)
        scoreAO += 2
        lblScoreAO.Text = scoreAO
    End Sub

    Private Sub btnYukoAO_Click(sender As Object, e As EventArgs)
        scoreAO += 1
        lblScoreAO.Text = scoreAO
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs)
        scoreAKA = 0
        scoreAO = 0
        lblScoreAKA.Text = "0"
        lblScoreAO.Text = "0"
    End Sub

End Class