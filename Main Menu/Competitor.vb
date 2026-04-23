Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Competitor

    Private selectedImage As Image = Nothing  ' ← TAMBAHAN

    ' --- INISIALISASI FORM ---
    Private Sub Competitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTotalRecords.Text = "Total Records : 0"
        RefreshTeamCombo()
    End Sub

    Public Sub RefreshTeamCombo()
        cmbTeam.Items.Clear()
        cmbTeam.Items.Add("-- Select Team --")

        Try
            If TeamEntry.dgvTeams.Rows.Count > 0 Then
                For Each row As DataGridViewRow In TeamEntry.dgvTeams.Rows
                    If Not row.IsNewRow Then
                        Dim teamName As String = If(row.Cells(3).Value IsNot Nothing, row.Cells(3).Value.ToString(), "")
                        If teamName <> "" AndAlso Not cmbTeam.Items.Contains(teamName) Then
                            cmbTeam.Items.Add(teamName)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

        If cmbTeam.Items.Count = 1 Then
            cmbTeam.Items.Add("Elang Biru - INKANAS")
            cmbTeam.Items.Add("Naga Hitam - Lemkari")
            cmbTeam.Items.Add("Garuda Sakti - BKC")
            cmbTeam.Items.Add("Harimau Putih - KKI")
            cmbTeam.Items.Add("Dojo Rajawali - INKAI")
        End If

        cmbTeam.SelectedIndex = 0
    End Sub

    ' --- LOGIKA TOMBOL ADD ---
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtName.Text.Trim() = "" Or cmbTeam.SelectedIndex <= 0 Then
            MessageBox.Show("Name dan Team harus diisi!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' ← DIUBAH: pakai selectedImage bukan picProfile.Image langsung
        Dim imgThumb As Image = Nothing
        If selectedImage IsNot Nothing Then
            imgThumb = New Bitmap(selectedImage, New Size(40, 40))
        End If

        dgvCompetitors.Rows.Add(dgvCompetitors.Rows.Count + 1, "❌", "📝", txtName.Text, cmbTeam.Text, txtTeamInfo.Text, imgThumb)

        UpdateTotal()
        ClearForm()
    End Sub

    ' --- PICTUREBOX BULAT ---
    Private Sub picProfile_Paint(sender As Object, e As PaintEventArgs) Handles picProfile.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim path As New Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, picProfile.Width - 1, picProfile.Height - 1)
        picProfile.Region = New Region(path)
        Using pen As New Pen(Color.Plum, 2)
            g.DrawEllipse(pen, 1, 1, picProfile.Width - 3, picProfile.Height - 3)
        End Using
    End Sub

    ' ← DIUBAH: simpan ke selectedImage dulu
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.png;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                selectedImage = New Bitmap(ofd.FileName)  ' ← simpan ke variabel
                picProfile.Image = selectedImage           ' ← tampilkan ke PictureBox
                picProfile.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        End Using
    End Sub

    ' --- IMPORT EXCEL ---
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Excel Files|*.xlsx;*.xls"
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim xlApp As New Excel.Application
            Dim xlWorkbook As Excel.Workbook = Nothing
            Try
                xlWorkbook = xlApp.Workbooks.Open(ofd.FileName)
                Dim xlWorksheet As Excel.Worksheet = xlWorkbook.Sheets(1)
                Dim xlRange As Excel.Range = xlWorksheet.UsedRange
                For row As Integer = 2 To xlRange.Rows.Count
                    Dim nameVal As String = If(xlRange.Cells(row, 1).Value IsNot Nothing, xlRange.Cells(row, 1).Value.ToString(), "")
                    Dim teamVal As String = If(xlRange.Cells(row, 2).Value IsNot Nothing, xlRange.Cells(row, 2).Value.ToString(), "")
                    Dim infoVal As String = If(xlRange.Cells(row, 3).Value IsNot Nothing, xlRange.Cells(row, 3).Value.ToString(), "")
                    If Not String.IsNullOrEmpty(nameVal) Then
                        dgvCompetitors.Rows.Add(dgvCompetitors.Rows.Count + 1, "❌", "📝", nameVal, teamVal, infoVal, Nothing)
                    End If
                Next
                MessageBox.Show("Import data berhasil!", "Success")
            Catch ex As Exception
                MessageBox.Show("Gagal Import: " & ex.Message)
            Finally
                If xlWorkbook IsNot Nothing Then xlWorkbook.Close(False)
                xlApp.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
                UpdateTotal()
            End Try
        End If
    End Sub

    ' --- EXPORT EXCEL ---
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If dgvCompetitors.Rows.Count = 0 Then Return
        Dim xlApp As New Excel.Application
        Try
            Dim xlBook = xlApp.Workbooks.Add
            Dim xlSheet = xlBook.Worksheets(1)
            xlSheet.Cells(1, 1) = "Name" : xlSheet.Cells(1, 2) = "Team" : xlSheet.Cells(1, 3) = "Info"
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

    ' --- SEARCH ---
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim searchTerm As String = txtSearch.Text.ToLower()
        dgvCompetitors.CurrentCell = Nothing
        For Each row As DataGridViewRow In dgvCompetitors.Rows
            If row.IsNewRow Then Continue For
            Dim nameVal As String = If(row.Cells(3).Value IsNot Nothing, row.Cells(3).Value.ToString().ToLower(), "")
            Dim teamVal As String = If(row.Cells(4).Value IsNot Nothing, row.Cells(4).Value.ToString().ToLower(), "")
            row.Visible = (nameVal.Contains(searchTerm) Or teamVal.Contains(searchTerm))
        Next
    End Sub

    ' --- TOOLS ---
    Private Sub ClearForm()
        txtName.Clear() : txtTeamInfo.Clear() : cmbTeam.SelectedIndex = 0
        picProfile.Image = Nothing
        selectedImage = Nothing  ' ← TAMBAHAN: reset variabel gambar
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
        If MessageBox.Show("Hapus semua data?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            dgvCompetitors.Rows.Clear() : UpdateTotal()
        End If
    End Sub

    Private Sub btnEditTeam_Click(sender As Object, e As EventArgs) Handles btnEditTeam.Click
        TeamEntry.ShowDialog()
        RefreshTeamCombo()
    End Sub

End Class