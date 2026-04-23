Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmScoreboardSetting

    ' Sub New ini adalah fungsi yang PERTAMA KALI dipanggil saat Play (F5) ditekan
    Public Sub New()

        ' 1. Ini untuk membangun bingkai jendelanya yang kosong
        InitializeComponent()

        ' 2. INI KUNCINYA: Memanggil fungsi untuk mengisi tombol, warna, dan tab!
        SetupAdditionalUI()

    End Sub

End Class