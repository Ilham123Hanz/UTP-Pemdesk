Public Class dashboard
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel15_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    ' ✅ Klik Competitors
    Private Sub picCompetitors_Click(sender As Object, e As EventArgs) Handles picCompetitors.Click
        Dim f As New Competitor
        f.Show()
    End Sub

    ' ✅ Klik Kumite
    Private Sub picKumite_Click(sender As Object, e As EventArgs) Handles picKumite.Click
        Dim f As New KumiteMainControl
        f.Show()
        Me.Hide()
    End Sub

    Private Sub lblTatamiID_Click(sender As Object, e As EventArgs) Handles lblTatamiID.Click

    End Sub

    Private Sub lblTatamiTitle_Click(sender As Object, e As EventArgs) Handles lblTatamiTitle.Click

    End Sub

    Private Sub pnlKumite_Paint(sender As Object, e As PaintEventArgs) Handles pnlKumite.Paint

    End Sub
End Class