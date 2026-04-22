Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel

Public Class TeamEntry
    Dim isEditMode As Boolean = False
    Dim selectedRowIndex As Integer = -1

    Private Sub TeamEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeGrid()
        UpdateTotalRecords()
    End Sub

    ' --- INISIALISASI KOLOM GRID ---
    Private Sub InitializeGrid()
        With dgvTeams
            .Columns.Clear()
            .Columns.Add("No", "No") : .Columns("No").Width = 40

            ' Kolom Tombol Delete
            Dim btnDel As New DataGridViewButtonColumn()
            btnDel.Name = "Delete" : btnDel.HeaderText = "" : btnDel.Text = "❌"
            btnDel.UseColumnTextForButtonValue = True : btnDel.Width = 40
            .Columns.Add(btnDel)

            ' Kolom Tombol Edit
            Dim btnEdit As New DataGridViewButtonColumn()
            btnEdit.Name = "Edit" : btnEdit.HeaderText = "" : btnEdit.Text = "📝"
            btnEdit.UseColumnTextForButtonValue = True : btnEdit.Width = 40
            .Columns.Add(btnEdit)

            ' Kolom Data (Indeks 3: Team Name)
            .Columns.Add("Team", "Team Name") : .Columns("Team").Width = 150
            .Columns.Add("Info", "Info") : .Columns("Info").Width = 200

            ' Kolom Gambar
            Dim colImg As New DataGridViewImageColumn()
            colImg.Name = "Pict" : colImg.HeaderText = "Logo"
            colImg.ImageLayout = DataGridViewImageCellLayout.Zoom : colImg.Width = 100
            .Columns.Add(colImg)

            .RowTemplate.Height = 50
        End With
    End Sub

    ' --- TOMBOL ADD / UPDATE ---
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtTeam.Text.Trim = "" Then Exit Sub

        Dim img As Image = Nothing
        If picTeam.Image IsNot Nothing Then img = New Bitmap(picTeam.Image)

        If isEditMode Then
            ' Logika Update
            With dgvTeams.Rows(selectedRowIndex)
                .Cells("Team").Value = txtTeam.Text
                .Cells("Info").Value = txtTeamInfo.Text
                .Cells("Pict").Value = img
            End With
            ResetForm()
        Else
            ' Logika Simpan Baru
            dgvTeams.Rows.Add(dgvTeams.Rows.Count + 1, "❌", "📝", txtTeam.Text, txtTeamInfo.Text, img)
        End If

        ' === SINKRONISASI KE COMPETITOR ===
        ' Memanggil fungsi refresh pada Form Competitor agar ComboBox terupdate
        Competitor.RefreshTeamCombo()

        UpdateTotalRecords()
        ClearInput()
    End Sub

    ' --- TOMBOL SELECT GAMBAR ---
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.png;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                picTeam.Image = New Bitmap(ofd.FileName) ' Gunakan New Bitmap agar file tidak lock
            End If
        End Using
    End Sub

    ' --- EXPORT KE EXCEL ---
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim xlApp As New Excel.Application
            Dim xlBook = xlApp.Workbooks.Add
            Dim xlSheet = xlBook.Worksheets(1)

            xlSheet.Cells(1, 1) = "No"
            xlSheet.Cells(1, 2) = "Team Name"
            xlSheet.Cells(1, 3) = "Info"

            For i As Integer = 0 To dgvTeams.Rows.Count - 1
                xlSheet.Cells(i + 2, 1) = dgvTeams.Rows(i).Cells("No").Value
                xlSheet.Cells(i + 2, 2) = dgvTeams.Rows(i).Cells("Team").Value
                xlSheet.Cells(i + 2, 3) = dgvTeams.Rows(i).Cells("Info").Value
            Next

            xlApp.Visible = True
        Catch ex As Exception
            MessageBox.Show("Export Gagal: " & ex.Message)
        End Try
    End Sub

    ' --- IMPORT DARI EXCEL ---
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Using ofd As New OpenFileDialog() With {.Filter = "Excel Files|*.xlsx;*.xls"}
            If ofd.ShowDialog() = DialogResult.OK Then
                Dim xlApp As New Excel.Application
                Try
                    Dim xlBook = xlApp.Workbooks.Open(ofd.FileName)
                    Dim xlSheet = xlBook.Worksheets(1)
                    Dim range = xlSheet.UsedRange

                    For r As Integer = 2 To range.Rows.Count
                        Dim teamName As String = range.Cells(r, 2).Value?.ToString()
                        Dim info As String = range.Cells(r, 3).Value?.ToString()

                        If Not String.IsNullOrEmpty(teamName) Then
                            dgvTeams.Rows.Add(dgvTeams.Rows.Count + 1, "❌", "📝", teamName, info, Nothing)
                        End If
                    Next

                    xlBook.Close(False) : xlApp.Quit()

                    ' === SINKRONISASI SETELAH IMPORT ===
                    Competitor.RefreshTeamCombo()

                    UpdateTotalRecords()
                Catch ex As Exception
                    MessageBox.Show("Import Gagal: " & ex.Message)
                End Try
            End If
        End Using
    End Sub

    ' --- KLIK GRID (DELETE / EDIT) ---
    Private Sub dgvTeams_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTeams.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        If dgvTeams.Columns(e.ColumnIndex).Name = "Delete" Then
            If MessageBox.Show("Hapus tim ini?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                dgvTeams.Rows.RemoveAt(e.RowIndex)
                RenumberRows()
                Competitor.RefreshTeamCombo() ' Update ComboBox setelah hapus
            End If
        ElseIf dgvTeams.Columns(e.ColumnIndex).Name = "Edit" Then
            isEditMode = True
            selectedRowIndex = e.RowIndex
            With dgvTeams.Rows(e.RowIndex)
                txtTeam.Text = .Cells("Team").Value.ToString()
                txtTeamInfo.Text = .Cells("Info").Value.ToString()
                If .Cells("Pict").Value IsNot Nothing Then
                    picTeam.Image = CType(.Cells("Pict").Value, Image)
                End If
            End With
            btnAdd.Text = "Update"
            lblStatusNew.Text = "EDITING" : lblStatusNew.ForeColor = Color.Red
        End If
        UpdateTotalRecords()
    End Sub

    ' --- FUNGSI HELPER ---
    Private Sub RenumberRows()
        For i As Integer = 0 To dgvTeams.Rows.Count - 1
            dgvTeams.Rows(i).Cells("No").Value = i + 1
        Next
    End Sub

    Private Sub UpdateTotalRecords()
        lblTotalRecords.Text = "Total Records : " & dgvTeams.Rows.Count
    End Sub

    Private Sub ClearInput()
        txtTeam.Clear() : txtTeamInfo.Clear() : picTeam.Image = Nothing
    End Sub

    Private Sub ResetForm()
        isEditMode = False : btnAdd.Text = "Add"
        lblStatusNew.Text = "NEW" : lblStatusNew.ForeColor = Color.Black
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInput() : ResetForm()
    End Sub
End Class