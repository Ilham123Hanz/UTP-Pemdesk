Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Linq

Public Class Competitor

    Private selectedImage As Image = Nothing

    ' =========================================================
    ' ✅ INISIALISASI FORM
    ' =========================================================
    Private Sub Competitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. HAPUS GAMBAR SILANG (X) di kolom Comp. Pict
        colCompPict.DefaultCellStyle.NullValue = Nothing

        ' 2. CEGAH BARIS KOSONG OTOMATIS (Mencegah silang muncul di baris paling bawah)
        dgvCompetitors.AllowUserToAddRows = False

        lblTotalRecords.Text = "Total Records : 0"
        RefreshTeamCombo()
    End Sub

    ' ✅ OTOMATISASI TEAM INFO
    Private Sub cmbTeam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTeam.SelectedIndexChanged
        If cmbTeam.SelectedIndex > 0 Then
            Dim selectedName As String = cmbTeam.SelectedItem.ToString()
            ' Mencari info di GlobalFullTeams berdasarkan nama tim
            Dim teamData = GlobalFullTeams.FirstOrDefault(Function(t) t.Name = selectedName)

            If teamData IsNot Nothing Then
                txtTeamInfo.Text = teamData.Info
            End If
        Else
            txtTeamInfo.Clear()
        End If
    End Sub

    ' ✅ REFRESH COMBOBOX
    Public Sub RefreshTeamCombo()
        cmbTeam.Items.Clear()
        cmbTeam.Items.Add("-- Select Team --")

        If GlobalModule.SharedTeamList IsNot Nothing AndAlso GlobalModule.SharedTeamList.Count > 0 Then
            For Each teamName As String In GlobalModule.SharedTeamList
                cmbTeam.Items.Add(teamName)
            Next
        Else
            ' Data Default Jika List Kosong
            cmbTeam.Items.Add("Elang Biru - INKANAS")
            cmbTeam.Items.Add("Naga Hitam - Lemkari")
            cmbTeam.Items.Add("Garuda Sakti - BKC")
        End If

        cmbTeam.SelectedIndex = 0
    End Sub

    ' =========================================================
    ' ✅ TOMBOL ADD (TAMBAH PESERTA)
    ' =========================================================
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtName.Text.Trim() = "" Or cmbTeam.SelectedIndex <= 0 Then
            MessageBox.Show("Name dan Team harus diisi!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Menyiapkan thumbnail agar grid tetap ringan
        Dim imgThumb As Image = Nothing
        If selectedImage IsNot Nothing Then
            Try
                imgThumb = New Bitmap(selectedImage, New Size(40, 40))
            Catch ex As Exception
                imgThumb = Nothing ' Jika gambar bermasalah, biarkan kosong (bukan silang X)
            End Try
        End If

        ' Mengisi Baris Sesuai Desain Designer (7 Kolom)
        ' No, Del, Edit, Name, Team, Team Info, Comp. Pict
        dgvCompetitors.Rows.Add(
            dgvCompetitors.Rows.Count + 1,
            "❌",
            "📝",
            txtName.Text,
            cmbTeam.Text,
            txtTeamInfo.Text,
            imgThumb
        )

        UpdateTotal()
        ClearForm()
    End Sub

    ' =========================================================
    ' ✅ SELECT FOTO (DENGAN PROTEKSI FILE)
    ' =========================================================
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.png;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                ' Gunakan FileStream agar file asli tidak terkunci (bisa dihapus/pindah nantinya)
                Try
                    Using fs As New System.IO.FileStream(ofd.FileName, IO.FileMode.Open, IO.FileAccess.Read)
                        selectedImage = Image.FromStream(fs)
                    End Using
                    picProfile.Image = selectedImage
                    picProfile.SizeMode = PictureBoxSizeMode.Zoom
                Catch ex As Exception
                    MessageBox.Show("Gagal memuat gambar: " & ex.Message)
                End Try
            End If
        End Using
    End Sub

    ' =========================================================
    ' ✅ FITUR PENCARIAN & EXPORT
    ' =========================================================
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim searchTerm As String = txtSearch.Text.ToLower()

        ' Suspend binding jika perlu untuk performa
        dgvCompetitors.CurrentCell = Nothing

        For Each row As DataGridViewRow In dgvCompetitors.Rows
            If row.IsNewRow Then Continue For

            Dim nameVal As String = If(row.Cells(3).Value IsNot Nothing, row.Cells(3).Value.ToString().ToLower(), "")
            Dim teamVal As String = If(row.Cells(4).Value IsNot Nothing, row.Cells(4).Value.ToString().ToLower(), "")

            ' Sembunyikan baris jika tidak cocok
            row.Visible = (nameVal.Contains(searchTerm) Or teamVal.Contains(searchTerm))
        Next
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If dgvCompetitors.Rows.Count = 0 Then Exit Sub
        Try
            Dim xlApp As New Excel.Application
            Dim xlBook = xlApp.Workbooks.Add
            Dim xlSheet = xlBook.Worksheets(1)

            ' Header
            xlSheet.Cells(1, 1) = "Name"
            xlSheet.Cells(1, 2) = "Team"
            xlSheet.Cells(1, 3) = "Info"

            ' Data
            For i As Integer = 0 To dgvCompetitors.Rows.Count - 1
                xlSheet.Cells(i + 2, 1) = dgvCompetitors.Rows(i).Cells(3).Value
                xlSheet.Cells(i + 2, 2) = dgvCompetitors.Rows(i).Cells(4).Value
                xlSheet.Cells(i + 2, 3) = dgvCompetitors.Rows(i).Cells(5).Value
            Next

            xlApp.Visible = True
        Catch ex As Exception
            MessageBox.Show("Gagal Export: " & ex.Message)
        End Try
    End Sub

    ' =========================================================
    ' ✅ UI CUSTOMIZATION & HELPERS
    ' =========================================================
    Private Sub picProfile_Paint(sender As Object, e As PaintEventArgs) Handles picProfile.Paint
        ' Membuat tampilan foto profil bulat dengan border
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim path As New Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, picProfile.Width - 1, picProfile.Height - 1)
        picProfile.Region = New Region(path)

        Using pen As New Pen(Color.Plum, 2)
            g.DrawEllipse(pen, 1, 1, picProfile.Width - 3, picProfile.Height - 3)
        End Using
    End Sub

    Private Sub btnEditTeam_Click(sender As Object, e As EventArgs) Handles btnEditTeam.Click
        TeamEntry.ShowDialog()
        RefreshTeamCombo()
    End Sub

    Private Sub ClearForm()
        txtName.Clear()
        txtTeamInfo.Clear()
        cmbTeam.SelectedIndex = 0
        picProfile.Image = Nothing
        selectedImage = Nothing
        txtName.Focus()
    End Sub

    Private Sub UpdateTotal()
        lblTotalRecords.Text = "Total Records : " & dgvCompetitors.Rows.Count
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Clear()
    End Sub

    Private Sub btnDeleteAll_Click(sender As Object, e As EventArgs) Handles btnDeleteAll.Click
        If dgvCompetitors.Rows.Count > 0 Then
            If MessageBox.Show("Hapus semua data peserta?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                dgvCompetitors.Rows.Clear()
                UpdateTotal()
            End If
        End If
    End Sub

End Class