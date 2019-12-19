Imports System.Data
Imports System.Data.SqlClient

Public Class form

    Private koneksi As String
    Private sql As String
    Private conn As SqlClient.SqlConnection = Nothing
    Private cmd As SqlClient.SqlCommand = Nothing
    Private adapter As New SqlClient.SqlDataAdapter
    Private table As New DataTable

    Private Sub Clear()
        Me.txtKode.Text = ""
        Me.txtNama.Text = ""
        Me.cmbJenis.Text = ""
        Me.txtStok.Text = ""
        Me.txtHarga.Text = ""
        Me.txtKode.Focus()
    End Sub

    Private Sub Simpan()
        Me.sql = "INSERT INTO master_barang VALUES('" & Me.txtKode.Text & "', '" & Me.txtNama.Text & "', '" & Me.cmbJenis.Text & "', '" & Me.txtStok.Text & "', '" & Me.txtHarga.Text & "')"
        Me.cmd = New SqlClient.SqlCommand(Me.sql)
        Me.cmd.Connection = Me.conn
        Me.cmd.ExecuteNonQuery()
    End Sub

    Private Sub Daftar()
        Me.sql = "SELECT * FROM master_barang"
        Me.adapter = New SqlClient.SqlDataAdapter(Me.sql, Me.conn)
        Me.table = New DataTable
        Me.adapter.Fill(Me.table)
        Me.gridTabel.DataSource = Me.table
        With Me.gridTabel
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Kode"
            .Columns(1).HeaderCell.Value = "Nama Barang"
            .Columns(2).HeaderCell.Value = "Jenis"
            .Columns(3).HeaderCell.Value = "Stok"
            .Columns(4).HeaderCell.Value = "Harga"
        End With
    End Sub

    Private Sub MsgBox(title As String, text As String, icon As MessageBoxIcon)
        MessageBox.Show(text, title, MessageBoxButtons.OK, icon)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim conf As Integer = MessageBox.Show("Keluar dari aplikasi ?", "Pesan Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If conf = 6 Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Clear()
        Me.MsgBox("Pesan Informasi", "Data sudah digagalkan !", MessageBoxIcon.Warning)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Me.Clear()
        Me.MsgBox("Pesan Informasi", "Data Baru", MessageBoxIcon.Information)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Simpan()
        Me.Clear()
        Me.Daftar()
        Me.MsgBox("Pesan Informasi", "Berhasil menyimpan data !", MessageBoxIcon.Information)
    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = "Data Source=localhost\RAR;Initial Catalog=kampus;Integrated Security=True"
        conn = New SqlClient.SqlConnection(koneksi)
        conn.Open()
        Me.Daftar()
    End Sub
End Class
