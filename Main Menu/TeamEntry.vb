Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class TeamEntry
    Dim isEditMode As Boolean = False
    Dim selectedRowIndex As Integer = -1
    Dim flagPath As String = Path.Combine(Application.StartupPath, "flags")

    Private Sub TeamEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeGrid()

        ' --- ISI DAFTAR NEGARA ---
        cmbCountry.Items.Clear()
        cmbCountry.Items.AddRange(New String() {"Indonesia", "Jepang", "USA", "German", "Rusia"})
        cmbCountry.SelectedIndex = 0

        LoadFromGlobal()
        UpdateTotalRecords()
    End Sub

    ' =========================================================
    ' ✅ INISIALISASI GRID (UPDATE: Header Del & Edit Muncul)
    ' =========================================================
    Private Sub InitializeGrid()
        With dgvTeams
            .Columns.Clear()
            .AllowUserToAddRows = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .RowTemplate.Height = 45

            ' 1. Kolom No
            .Columns.Add("No", "No")
            .Columns("No").Width = 40
            .Columns("No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' 2. Kolom Delete (Header: Del)
            Dim colDel As New DataGridViewButtonColumn()
            colDel.Name = "Delete"
            colDel.HeaderText = "Del"
            colDel.Text = "❌"
            colDel.UseColumnTextForButtonValue = True
            colDel.Width = 45 ' Lebar disesuaikan agar teks header muat
            colDel.FlatStyle = FlatStyle.Flat
            colDel.DefaultCellStyle.BackColor = Color.MistyRose
            colDel.DefaultCellStyle.SelectionBackColor = Color.Red
            colDel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns.Add(colDel)

            ' 3. Kolom Edit (Header: Edit)
            Dim colEdit As New DataGridViewButtonColumn()
            colEdit.Name = "Edit"
            colEdit.HeaderText = "Edit"
            colEdit.Text = "📝"
            colEdit.UseColumnTextForButtonValue = True
            colEdit.Width = 45
            colEdit.FlatStyle = FlatStyle.Flat
            colEdit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns.Add(colEdit)

            ' 4. Kolom Data
            .Columns.Add("Team", "Team Name")
            .Columns("Team").Width = 150
            .Columns.Add("Info", "Info")
            .Columns("Info").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            ' 5. Kolom Logo
            Dim colImg As New DataGridViewImageColumn()
            colImg.Name = "Pict"
            colImg.HeaderText = "Logo"
            colImg.ImageLayout = DataGridViewImageCellLayout.Zoom
            colImg.Width = 80
            colImg.DefaultCellStyle.NullValue = Nothing ' ✅ Menghilangkan tanda silang (X)
            .Columns.Add(colImg)

            ' Merapikan teks Header agar rata tengah
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    ' =========================================================
    ' ✅ LOGIKA AUTO-FLAG
    ' =========================================================
    Private Sub chkUseFlag_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseFlag.CheckedChanged, cmbCountry.SelectedIndexChanged
        If chkUseFlag.Checked Then
            btnSelect.Enabled = False
            btnSelect.BackColor = Color.LightGray

            Dim selectedCountry As String = cmbCountry.Text.Trim()
            Dim fileFlag As String = Path.Combine(flagPath, selectedCountry & ".png")

            If File.Exists(fileFlag) Then
                Try
                    Using fs As New FileStream(fileFlag, FileMode.Open, FileAccess.Read)
                        picTeam.Image = Image.FromStream(fs)
                    End Using
                    picTeam.SizeMode = PictureBoxSizeMode.Zoom
                Catch ex As Exception
                    picTeam.Image = Nothing
                End Try
            Else
                picTeam.Image = Nothing
            End If
        Else
            btnSelect.Enabled = True
            btnSelect.BackColor = Color.Plum
            If Not isEditMode Then picTeam.Image = Nothing
        End If
    End Sub

    ' =========================================================
    ' ✅ TOMBOL SELECT MANUAL & ADD/UPDATE
    ' =========================================================
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If chkUseFlag.Checked Then Exit Sub
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.png;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                Using fs As New FileStream(ofd.FileName, FileMode.Open, FileAccess.Read)
                    picTeam.Image = Image.FromStream(fs)
                End Using
                picTeam.SizeMode = PictureBoxSizeMode.Zoom
            End If
        End Using
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtTeam.Text.Trim = "" Then Exit Sub

        Dim img As Image = Nothing
        If picTeam.Image IsNot Nothing Then img = New Bitmap(picTeam.Image)

        If isEditMode Then
            With dgvTeams.Rows(selectedRowIndex)
                .Cells("Team").Value = txtTeam.Text
                .Cells("Info").Value = txtTeamInfo.Text
                .Cells("Pict").Value = img
            End With
            ResetForm()
        Else
            dgvTeams.Rows.Add(dgvTeams.Rows.Count + 1, "❌", "📝", txtTeam.Text, txtTeamInfo.Text, img)
        End If

        SyncToGlobal()
        UpdateTotalRecords()
        ClearInput()
    End Sub

    ' =========================================================
    ' ✅ SINKRONISASI & GRID EVENTS
    ' =========================================================
    Private Sub SyncToGlobal()
        SharedTeamList.Clear()
        GlobalFullTeams.Clear()
        For Each row As DataGridViewRow In dgvTeams.Rows
            If Not row.IsNewRow Then
                Dim tName As String = If(row.Cells("Team").Value IsNot Nothing, row.Cells("Team").Value.ToString(), "")
                Dim tInfo As String = If(row.Cells("Info").Value IsNot Nothing, row.Cells("Info").Value.ToString(), "")
                Dim tLogo As Image = CType(row.Cells("Pict").Value, Image)

                SharedTeamList.Add(tName)
                GlobalFullTeams.Add(New TeamData With {.Name = tName, .Info = tInfo, .Logo = tLogo})
            End If
        Next

        If Application.OpenForms().OfType(Of Competitor).Any Then
            Competitor.RefreshTeamCombo()
        End If
    End Sub

    Private Sub LoadFromGlobal()
        dgvTeams.Rows.Clear()
        For Each t In GlobalFullTeams
            dgvTeams.Rows.Add(dgvTeams.Rows.Count + 1, "❌", "📝", t.Name, t.Info, t.Logo)
        Next
    End Sub

    Private Sub dgvTeams_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTeams.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        If dgvTeams.Columns(e.ColumnIndex).Name = "Delete" Then
            If MessageBox.Show("Hapus tim ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dgvTeams.Rows.RemoveAt(e.RowIndex)
                RenumberRows()
                SyncToGlobal()
                UpdateTotalRecords()
            End If
        ElseIf dgvTeams.Columns(e.ColumnIndex).Name = "Edit" Then
            isEditMode = True
            selectedRowIndex = e.RowIndex
            With dgvTeams.Rows(e.RowIndex)
                txtTeam.Text = .Cells("Team").Value.ToString()
                txtTeamInfo.Text = .Cells("Info").Value.ToString()
                picTeam.Image = CType(.Cells("Pict").Value, Image)
                chkUseFlag.Checked = False
            End With
            btnAdd.Text = "Update"
            lblStatusNew.Text = "EDITING" : lblStatusNew.ForeColor = Color.Red
        End If
    End Sub

    ' =========================================================
    ' ✅ HELPERS
    ' =========================================================
    Private Sub RenumberRows()
        For i As Integer = 0 To dgvTeams.Rows.Count - 1
            dgvTeams.Rows(i).Cells("No").Value = i + 1
        Next
    End Sub

    Private Sub UpdateTotalRecords()
        lblTotalRecords.Text = "Total Records : " & dgvTeams.Rows.Count
    End Sub

    Private Sub ClearInput()
        txtTeam.Clear() : txtTeamInfo.Clear() : picTeam.Image = Nothing : chkUseFlag.Checked = False
        btnSelect.Enabled = True : btnSelect.BackColor = Color.Plum
    End Sub

    Private Sub ResetForm()
        isEditMode = False : btnAdd.Text = "Add"
        lblStatusNew.Text = "NEW" : lblStatusNew.ForeColor = Color.Black
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearInput() : ResetForm()
    End Sub
End Class