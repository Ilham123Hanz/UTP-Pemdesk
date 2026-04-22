<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashboard))
        pnlTopBanner = New Panel()
        picLogo = New PictureBox()
        btnEnterCode = New Button()
        lblActivationReq = New Label()
        lblTatamiID = New Label()
        lblTatamiTitle = New Label()
        pnlCompetitors = New Panel()
        lblCompetitors = New Label()
        picCompetitors = New PictureBox()
        pnlKumite = New Panel()
        lblKumite = New Label()
        picKumite = New PictureBox()
        pnlKata = New Panel()
        lblKata = New Label()
        picKata = New PictureBox()
        pnlMatchResult = New Panel()
        lblMatchResult = New Label()
        picMatchResult = New PictureBox()
        pnlServerStatus = New Panel()
        lblLocalUnreg = New Label()
        lblLocalServer = New Label()
        lblYabinyaUnreg = New Label()
        lblYabinyaServer = New Label()
        lblStatusHeader = New Label()
        btnKataServer = New Button()
        btnManageJudge = New Button()
        lblWebsite = New Label()
        linkAboutUs = New LinkLabel()
        pnlTopBanner.SuspendLayout()
        CType(picLogo, ComponentModel.ISupportInitialize).BeginInit()
        pnlCompetitors.SuspendLayout()
        CType(picCompetitors, ComponentModel.ISupportInitialize).BeginInit()
        pnlKumite.SuspendLayout()
        CType(picKumite, ComponentModel.ISupportInitialize).BeginInit()
        pnlKata.SuspendLayout()
        CType(picKata, ComponentModel.ISupportInitialize).BeginInit()
        pnlMatchResult.SuspendLayout()
        CType(picMatchResult, ComponentModel.ISupportInitialize).BeginInit()
        pnlServerStatus.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlTopBanner
        ' 
        pnlTopBanner.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(45))
        pnlTopBanner.Controls.Add(picLogo)
        pnlTopBanner.Controls.Add(btnEnterCode)
        pnlTopBanner.Controls.Add(lblActivationReq)
        pnlTopBanner.Controls.Add(lblTatamiID)
        pnlTopBanner.Controls.Add(lblTatamiTitle)
        pnlTopBanner.Dock = DockStyle.Top
        pnlTopBanner.Location = New Point(0, 0)
        pnlTopBanner.Name = "pnlTopBanner"
        pnlTopBanner.Size = New Size(1107, 140)
        pnlTopBanner.TabIndex = 0
        ' 
        ' picLogo
        ' 
        picLogo.Location = New Point(982, 17)
        picLogo.Name = "picLogo"
        picLogo.Size = New Size(100, 100)
        picLogo.SizeMode = PictureBoxSizeMode.Zoom
        picLogo.TabIndex = 4
        picLogo.TabStop = False
        ' 
        ' btnEnterCode
        ' 
        btnEnterCode.FlatAppearance.BorderColor = Color.White
        btnEnterCode.FlatAppearance.BorderSize = 2
        btnEnterCode.FlatStyle = FlatStyle.Flat
        btnEnterCode.Font = New Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEnterCode.ForeColor = Color.Cyan
        btnEnterCode.Location = New Point(565, 75)
        btnEnterCode.Name = "btnEnterCode"
        btnEnterCode.Size = New Size(232, 40)
        btnEnterCode.TabIndex = 3
        btnEnterCode.Text = "Enter Activation Code"
        btnEnterCode.UseVisualStyleBackColor = True
        ' 
        ' lblActivationReq
        ' 
        lblActivationReq.AutoSize = True
        lblActivationReq.Font = New Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblActivationReq.ForeColor = Color.Red
        lblActivationReq.Location = New Point(520, 8)
        lblActivationReq.Name = "lblActivationReq"
        lblActivationReq.Size = New Size(319, 34)
        lblActivationReq.TabIndex = 2
        lblActivationReq.Text = "Activation Required"
        ' 
        ' lblTatamiID
        ' 
        lblTatamiID.AutoSize = True
        lblTatamiID.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTatamiID.ForeColor = Color.White
        lblTatamiID.Location = New Point(12, 65)
        lblTatamiID.Name = "lblTatamiID"
        lblTatamiID.Size = New Size(309, 48)
        lblTatamiID.TabIndex = 1
        lblTatamiID.Text = "TT-24525677267"
        ' 
        ' lblTatamiTitle
        ' 
        lblTatamiTitle.AutoSize = True
        lblTatamiTitle.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTatamiTitle.ForeColor = Color.Gold
        lblTatamiTitle.Location = New Point(12, 34)
        lblTatamiTitle.Name = "lblTatamiTitle"
        lblTatamiTitle.Size = New Size(168, 31)
        lblTatamiTitle.TabIndex = 0
        lblTatamiTitle.Text = "Tatakan Malay"
        ' 
        ' pnlCompetitors
        ' 
        pnlCompetitors.BackColor = Color.White
        pnlCompetitors.BorderStyle = BorderStyle.FixedSingle
        pnlCompetitors.Controls.Add(lblCompetitors)
        pnlCompetitors.Controls.Add(picCompetitors)
        pnlCompetitors.Cursor = Cursors.Hand
        pnlCompetitors.Location = New Point(85, 180)
        pnlCompetitors.Name = "pnlCompetitors"
        pnlCompetitors.Size = New Size(160, 160)
        pnlCompetitors.TabIndex = 1
        ' 
        ' lblCompetitors
        ' 
        lblCompetitors.Dock = DockStyle.Bottom
        lblCompetitors.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCompetitors.Location = New Point(0, 128)
        lblCompetitors.Name = "lblCompetitors"
        lblCompetitors.Size = New Size(158, 30)
        lblCompetitors.TabIndex = 1
        lblCompetitors.Text = "Competitors"
        lblCompetitors.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' picCompetitors
        ' 
        picCompetitors.Image = CType(resources.GetObject("picCompetitors.Image"), Image)
        picCompetitors.Location = New Point(25, 15)
        picCompetitors.Name = "picCompetitors"
        picCompetitors.Size = New Size(110, 110)
        picCompetitors.SizeMode = PictureBoxSizeMode.Zoom
        picCompetitors.TabIndex = 0
        picCompetitors.TabStop = False
        ' 
        ' pnlKumite
        ' 
        pnlKumite.BackColor = Color.White
        pnlKumite.BorderStyle = BorderStyle.FixedSingle
        pnlKumite.Controls.Add(lblKumite)
        pnlKumite.Controls.Add(picKumite)
        pnlKumite.Cursor = Cursors.Hand
        pnlKumite.Location = New Point(462, 179)
        pnlKumite.Name = "pnlKumite"
        pnlKumite.Size = New Size(160, 160)
        pnlKumite.TabIndex = 2
        ' 
        ' lblKumite
        ' 
        lblKumite.Dock = DockStyle.Bottom
        lblKumite.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblKumite.Location = New Point(0, 128)
        lblKumite.Name = "lblKumite"
        lblKumite.Size = New Size(158, 30)
        lblKumite.TabIndex = 1
        lblKumite.Text = "KUMITE"
        lblKumite.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' picKumite
        ' 
        picKumite.Image = CType(resources.GetObject("picKumite.Image"), Image)
        picKumite.Location = New Point(25, 15)
        picKumite.Name = "picKumite"
        picKumite.Size = New Size(110, 110)
        picKumite.SizeMode = PictureBoxSizeMode.Zoom
        picKumite.TabIndex = 0
        picKumite.TabStop = False
        ' 
        ' pnlKata
        ' 
        pnlKata.BackColor = Color.White
        pnlKata.BorderStyle = BorderStyle.FixedSingle
        pnlKata.Controls.Add(lblKata)
        pnlKata.Controls.Add(picKata)
        pnlKata.Cursor = Cursors.Hand
        pnlKata.Location = New Point(813, 179)
        pnlKata.Name = "pnlKata"
        pnlKata.Size = New Size(160, 160)
        pnlKata.TabIndex = 3
        ' 
        ' lblKata
        ' 
        lblKata.Dock = DockStyle.Bottom
        lblKata.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblKata.Location = New Point(0, 128)
        lblKata.Name = "lblKata"
        lblKata.Size = New Size(158, 30)
        lblKata.TabIndex = 1
        lblKata.Text = "KATA"
        lblKata.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' picKata
        ' 
        picKata.Image = CType(resources.GetObject("picKata.Image"), Image)
        picKata.Location = New Point(25, 15)
        picKata.Name = "picKata"
        picKata.Size = New Size(110, 110)
        picKata.SizeMode = PictureBoxSizeMode.Zoom
        picKata.TabIndex = 0
        picKata.TabStop = False
        ' 
        ' pnlMatchResult
        ' 
        pnlMatchResult.BackColor = Color.White
        pnlMatchResult.BorderStyle = BorderStyle.FixedSingle
        pnlMatchResult.Controls.Add(lblMatchResult)
        pnlMatchResult.Controls.Add(picMatchResult)
        pnlMatchResult.Cursor = Cursors.Hand
        pnlMatchResult.Location = New Point(85, 370)
        pnlMatchResult.Name = "pnlMatchResult"
        pnlMatchResult.Size = New Size(160, 160)
        pnlMatchResult.TabIndex = 4
        ' 
        ' lblMatchResult
        ' 
        lblMatchResult.Dock = DockStyle.Bottom
        lblMatchResult.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMatchResult.Location = New Point(0, 128)
        lblMatchResult.Name = "lblMatchResult"
        lblMatchResult.Size = New Size(158, 30)
        lblMatchResult.TabIndex = 1
        lblMatchResult.Text = "List of Match Result"
        lblMatchResult.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' picMatchResult
        ' 
        picMatchResult.Image = CType(resources.GetObject("picMatchResult.Image"), Image)
        picMatchResult.Location = New Point(25, 15)
        picMatchResult.Name = "picMatchResult"
        picMatchResult.Size = New Size(110, 110)
        picMatchResult.SizeMode = PictureBoxSizeMode.Zoom
        picMatchResult.TabIndex = 0
        picMatchResult.TabStop = False
        ' 
        ' pnlServerStatus
        ' 
        pnlServerStatus.BackColor = Color.White
        pnlServerStatus.BorderStyle = BorderStyle.FixedSingle
        pnlServerStatus.Controls.Add(lblLocalUnreg)
        pnlServerStatus.Controls.Add(lblLocalServer)
        pnlServerStatus.Controls.Add(lblYabinyaUnreg)
        pnlServerStatus.Controls.Add(lblYabinyaServer)
        pnlServerStatus.Controls.Add(lblStatusHeader)
        pnlServerStatus.Location = New Point(386, 400)
        pnlServerStatus.Name = "pnlServerStatus"
        pnlServerStatus.Size = New Size(307, 95)
        pnlServerStatus.TabIndex = 5
        ' 
        ' lblLocalUnreg
        ' 
        lblLocalUnreg.AutoSize = True
        lblLocalUnreg.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblLocalUnreg.ForeColor = Color.Crimson
        lblLocalUnreg.Location = New Point(135, 62)
        lblLocalUnreg.Name = "lblLocalUnreg"
        lblLocalUnreg.Size = New Size(148, 28)
        lblLocalUnreg.TabIndex = 4
        lblLocalUnreg.Text = "[Unregistered]"
        ' 
        ' lblLocalServer
        ' 
        lblLocalServer.AutoSize = True
        lblLocalServer.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLocalServer.Location = New Point(5, 62)
        lblLocalServer.Name = "lblLocalServer"
        lblLocalServer.Size = New Size(117, 28)
        lblLocalServer.TabIndex = 3
        lblLocalServer.Text = "Local Server"
        ' 
        ' lblYabinyaUnreg
        ' 
        lblYabinyaUnreg.AutoSize = True
        lblYabinyaUnreg.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblYabinyaUnreg.ForeColor = Color.Crimson
        lblYabinyaUnreg.Location = New Point(135, 35)
        lblYabinyaUnreg.Name = "lblYabinyaUnreg"
        lblYabinyaUnreg.Size = New Size(148, 28)
        lblYabinyaUnreg.TabIndex = 2
        lblYabinyaUnreg.Text = "[Unregistered]"
        ' 
        ' lblYabinyaServer
        ' 
        lblYabinyaServer.AutoSize = True
        lblYabinyaServer.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblYabinyaServer.Location = New Point(4, 35)
        lblYabinyaServer.Name = "lblYabinyaServer"
        lblYabinyaServer.Size = New Size(136, 28)
        lblYabinyaServer.TabIndex = 1
        lblYabinyaServer.Text = "Yabisaa Server"
        ' 
        ' lblStatusHeader
        ' 
        lblStatusHeader.BackColor = Color.Crimson
        lblStatusHeader.Dock = DockStyle.Top
        lblStatusHeader.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatusHeader.ForeColor = Color.White
        lblStatusHeader.Location = New Point(0, 0)
        lblStatusHeader.Name = "lblStatusHeader"
        lblStatusHeader.Size = New Size(305, 25)
        lblStatusHeader.TabIndex = 0
        lblStatusHeader.Text = "Kata Scoring Server Status"
        lblStatusHeader.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnKataServer
        ' 
        btnKataServer.BackColor = Color.White
        btnKataServer.FlatAppearance.BorderColor = Color.LightGray
        btnKataServer.FlatStyle = FlatStyle.Flat
        btnKataServer.Font = New Font("Consolas", 10.0F, FontStyle.Bold)
        btnKataServer.ForeColor = Color.SaddleBrown
        btnKataServer.ImageAlign = ContentAlignment.MiddleRight
        btnKataServer.Location = New Point(796, 400)
        btnKataServer.Name = "btnKataServer"
        btnKataServer.Padding = New Padding(10, 0, 10, 0)
        btnKataServer.Size = New Size(242, 42)
        btnKataServer.TabIndex = 6
        btnKataServer.Text = "Kata Scoring Server"
        btnKataServer.TextAlign = ContentAlignment.MiddleLeft
        btnKataServer.UseVisualStyleBackColor = False
        ' 
        ' btnManageJudge
        ' 
        btnManageJudge.BackColor = Color.White
        btnManageJudge.FlatAppearance.BorderColor = Color.LightGray
        btnManageJudge.FlatStyle = FlatStyle.Flat
        btnManageJudge.Font = New Font("Consolas", 10.0F, FontStyle.Bold)
        btnManageJudge.ForeColor = Color.SaddleBrown
        btnManageJudge.ImageAlign = ContentAlignment.MiddleRight
        btnManageJudge.Location = New Point(796, 453)
        btnManageJudge.Name = "btnManageJudge"
        btnManageJudge.Padding = New Padding(10, 0, 10, 0)
        btnManageJudge.Size = New Size(242, 42)
        btnManageJudge.TabIndex = 7
        btnManageJudge.Text = "Manage KATA Judge"
        btnManageJudge.TextAlign = ContentAlignment.MiddleLeft
        btnManageJudge.UseVisualStyleBackColor = False
        ' 
        ' lblWebsite
        ' 
        lblWebsite.AutoSize = True
        lblWebsite.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblWebsite.ForeColor = Color.DimGray
        lblWebsite.Location = New Point(442, 538)
        lblWebsite.Name = "lblWebsite"
        lblWebsite.Size = New Size(203, 25)
        lblWebsite.TabIndex = 8
        lblWebsite.Text = "www.yabisaastudio.com"
        ' 
        ' linkAboutUs
        ' 
        linkAboutUs.AutoSize = True
        linkAboutUs.Location = New Point(953, 538)
        linkAboutUs.Name = "linkAboutUs"
        linkAboutUs.Size = New Size(85, 25)
        linkAboutUs.TabIndex = 9
        linkAboutUs.TabStop = True
        linkAboutUs.Text = "About us"
        ' 
        ' dashboard
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        ClientSize = New Size(1107, 571)
        Controls.Add(linkAboutUs)
        Controls.Add(lblWebsite)
        Controls.Add(btnManageJudge)
        Controls.Add(btnKataServer)
        Controls.Add(pnlServerStatus)
        Controls.Add(pnlMatchResult)
        Controls.Add(pnlKata)
        Controls.Add(pnlKumite)
        Controls.Add(pnlCompetitors)
        Controls.Add(pnlTopBanner)
        Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "dashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Yabinya ScoringBoard Karate v3.0 | 2026"
        pnlTopBanner.ResumeLayout(False)
        pnlTopBanner.PerformLayout()
        CType(picLogo, ComponentModel.ISupportInitialize).EndInit()
        pnlCompetitors.ResumeLayout(False)
        CType(picCompetitors, ComponentModel.ISupportInitialize).EndInit()
        pnlKumite.ResumeLayout(False)
        CType(picKumite, ComponentModel.ISupportInitialize).EndInit()
        pnlKata.ResumeLayout(False)
        CType(picKata, ComponentModel.ISupportInitialize).EndInit()
        pnlMatchResult.ResumeLayout(False)
        CType(picMatchResult, ComponentModel.ISupportInitialize).EndInit()
        pnlServerStatus.ResumeLayout(False)
        pnlServerStatus.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents pnlTopBanner As Panel
    Friend WithEvents lblTatamiTitle As Label
    Friend WithEvents lblTatamiID As Label
    Friend WithEvents lblActivationReq As Label
    Friend WithEvents btnEnterCode As Button
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents pnlCompetitors As Panel
    Friend WithEvents picCompetitors As PictureBox
    Friend WithEvents lblCompetitors As Label
    Friend WithEvents pnlKumite As Panel
    Friend WithEvents lblKumite As Label
    Friend WithEvents picKumite As PictureBox
    Friend WithEvents pnlKata As Panel
    Friend WithEvents lblKata As Label
    Friend WithEvents picKata As PictureBox
    Friend WithEvents pnlMatchResult As Panel
    Friend WithEvents lblMatchResult As Label
    Friend WithEvents picMatchResult As PictureBox
    Friend WithEvents pnlServerStatus As Panel
    Friend WithEvents lblStatusHeader As Label
    Friend WithEvents lblYabinyaServer As Label
    Friend WithEvents lblYabinyaUnreg As Label
    Friend WithEvents lblLocalUnreg As Label
    Friend WithEvents lblLocalServer As Label
    Friend WithEvents btnKataServer As Button
    Friend WithEvents btnManageJudge As Button
    Friend WithEvents lblWebsite As Label
    Friend WithEvents linkAboutUs As LinkLabel

End Class