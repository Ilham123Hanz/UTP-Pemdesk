Public Class FormKeyboardShortcut
    ' Variabel untuk menandai kita sedang merekam tombol keyboard
    Private isRecording As Boolean = False

    Private Sub FormKeyboardShortcut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        ' PENTING: Form harus bisa menangkap tombol keyboard sebelum fokus ke kontrol lain
        Me.KeyPreview = True

        If lvShortcuts IsNot Nothing Then
            lvShortcuts.OwnerDraw = True
            isiDataShortcut()
        End If
    End Sub

    ' --- FUNGSI UTAMA: MENDETEKSI TOMBOL KEYBOARD ---
    Private Sub FormKeyboardShortcut_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If isRecording Then
            ' Jangan rekam jika hanya menekan tombol modifier sendirian
            If e.KeyCode = Keys.ControlKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.Menu Then
                Exit Sub
            End If

            ' Susun nama shortcut secara otomatis
            Dim strShortcut As String = ""
            If e.Control Then strShortcut &= "Control+"
            If e.Shift Then strShortcut &= "Shift+"
            If e.Alt Then strShortcut &= "Alt+"
            strShortcut &= e.KeyCode.ToString()

            ' Masukkan ke kolom shortcut yang dipilih
            If lvShortcuts.SelectedItems.Count > 0 Then
                lvShortcuts.SelectedItems(0).SubItems(1).Text = strShortcut

                ' Selesai merekam, kembalikan tampilan
                isRecording = False
                txtCurrentAction.Text = lvShortcuts.SelectedItems(0).Text
                txtCurrentAction.ForeColor = Color.Black
                btnChange.Enabled = True
                btnSave.Enabled = True
                btnSave.ForeColor = Color.Black
            End If

            ' Hentikan fungsi tombol asli windows agar tidak konflik
            e.Handled = True
        End If
    End Sub

    ' --- PERBAIKAN TOMBOL CHANGE ---
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If lvShortcuts.SelectedItems.Count > 0 Then
            ' Aktifkan mode mendengarkan keyboard
            isRecording = True
            txtCurrentAction.Text = ">>> SEKARANG TEKAN TOMBOL DI KEYBOARD ANDA... <<<"
            txtCurrentAction.ForeColor = Color.Red
            btnChange.Enabled = False
        Else
            MessageBox.Show("Pilih salah satu item di tabel terlebih dahulu!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' --- SISA KODE (ISI DATA & DRAW ITEM) TETAP SAMA ---
    Private Sub isiDataShortcut()
        If lvShortcuts Is Nothing Then Exit Sub
        lvShortcuts.Items.Clear()
        ' Group General
        tambahItem("Start-Close Scoreboard", "Control+B")
        tambahItem("Timer Waiting Start-Stop", "Control+W")
        tambahItem("Match Timer Start-Stop", "Space")
        tambahItem("Next Match", "Control+N")
        tambahItem("Save Match Result", "Control+S")
        tambahItem("Match Timer Reset", "Control+R")
        tambahItem("Show Winner", "Control+E")
        ' Group AKA (Merah)
        tambahItem("AKA - Yuko(1)", "Shift+A")
        tambahItem("AKA - Wazaari(2)", "Shift+S")
        tambahItem("AKA - Ippon(3)", "Shift+D")
        tambahItem("AKA - SENSHU", "Shift+Q")
        ' Group AO (Biru)
        tambahItem("AO - Yuko(1)", "Shift+J")
        tambahItem("AO - Wazaari(2)", "Shift+K")
        tambahItem("AO - Ippon(3)", "Shift+L")
        tambahItem("AO - SENSHU", "Shift+P")
    End Sub

    Private Sub tambahItem(action As String, shortcut As String)
        Dim lvi As New ListViewItem(action)
        lvi.SubItems.Add(shortcut)
        lvShortcuts.Items.Add(lvi)
    End Sub

    Private Sub lvShortcuts_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles lvShortcuts.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub lvShortcuts_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles lvShortcuts.DrawSubItem
        If e.Item Is Nothing Then Exit Sub
        If e.Item.Selected Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(135, 206, 250)), e.Bounds)
        Else
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        End If
        Dim textColor As Color = Color.Black
        If Not String.IsNullOrEmpty(e.Item.Text) Then
            If e.Item.Text.StartsWith("AKA") Then textColor = Color.Red
            If e.Item.Text.StartsWith("AO") Then textColor = Color.Blue
        End If
        If e.ColumnIndex = 1 Then textColor = Color.Black
        Dim sf As New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near}
        Dim textRect As New Rectangle(e.Bounds.X + 5, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
        e.Graphics.DrawString(e.SubItem.Text, lvShortcuts.Font, New SolidBrush(textColor), textRect, sf)
    End Sub

    Private Sub lvShortcuts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvShortcuts.SelectedIndexChanged
        If lvShortcuts.SelectedItems.Count > 0 Then
            Dim actionName As String = lvShortcuts.SelectedItems(0).Text
            lblCurrentAction.Text = "Current Action : " & actionName
            txtCurrentAction.Text = actionName
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        isiDataShortcut()
        btnSave.Enabled = False
    End Sub
End Class