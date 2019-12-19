Public Class MasterCustomer

    Private koneksi As String
    Private sql As String
    Private conn As SqlClient.SqlConnection = Nothing
    Private cmd As SqlClient.SqlCommand = Nothing
    Private adapter As New SqlClient.SqlDataAdapter
    Private table As New DataTable

    Private Sub Clear()
        Me.txtKode.Text = ""
        Me.txtNama.Text = ""
        Me.txtAlamat.Text = ""
        Me.txtTelepon.Text = ""
        Me.txtKode.Focus()
    End Sub

    Private Sub Simpan()
        Me.sql = "INSERT INTO master_customer VALUES('" & Me.txtKode.Text & "', '" & Me.txtNama.Text & "', '" & Me.txtAlamat.Text & "', '" & Me.txtTelepon.Text & "')"
        Me.cmd = New SqlClient.SqlCommand(Me.sql)
        Me.cmd.Connection = Me.conn
        Me.cmd.ExecuteNonQuery()
    End Sub

    Private Sub Daftar()
        Me.sql = "SELECT * FROM master_customer"
        Me.adapter = New SqlClient.SqlDataAdapter(Me.sql, Me.conn)
        Me.table = New DataTable
        Me.adapter.Fill(Me.table)
        Me.gridTabel.DataSource = Me.table
        With Me.gridTabel
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Kode"
            .Columns(1).HeaderCell.Value = "Nama Customer"
            .Columns(2).HeaderCell.Value = "Alamat"
            .Columns(3).HeaderCell.Value = "Telepon"
        End With
    End Sub

    Private Sub Cari()
        Dim cari As String = InputBox("Masukan kunci pencarian..", "Pencarian")
        Me.sql = "SELECT * FROM master_customer where kode_customer like'%" & cari & "%' or nama_customer like'%" & cari & "%'"
        Me.adapter = New SqlClient.SqlDataAdapter(Me.sql, Me.conn)
        Me.table = New DataTable
        Me.adapter.Fill(Me.table)
        Me.gridTabel.DataSource = Me.table
        With Me.gridTabel
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Kode"
            .Columns(1).HeaderCell.Value = "Nama Customer"
            .Columns(2).HeaderCell.Value = "Alamat"
            .Columns(3).HeaderCell.Value = "Telepon"
        End With
    End Sub

    Private Sub Hapus()
        Dim kode As String = InputBox("Masukan Kode Customer ..", "Input")
        Me.sql = "DELETE FROM master_customer WHERE kode_customer='" & kode & "'"
        Me.cmd = New SqlClient.SqlCommand(Me.sql)
        Me.cmd.Connection = Me.conn
        Me.cmd.ExecuteNonQuery()
        Daftar()
    End Sub

    Private Sub MsgBox(title As String, text As String, icon As MessageBoxIcon)
        MessageBox.Show(text, title, MessageBoxButtons.OK, icon)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Me.Clear()
        Me.MsgBox("Pesan Informasi", "Data Baru", MessageBoxIcon.Information)
    End Sub

    Private Sub MasterCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi = "Data Source=localhost\RAR;Initial Catalog=kampus;Integrated Security=True"
        conn = New SqlClient.SqlConnection(koneksi)
        conn.Open()
        Me.Daftar()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Simpan()
        Me.Clear()
        Me.Daftar()
        Me.MsgBox("Pesan Informasi", "Berhasil menyimpan data !", MessageBoxIcon.Information)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim conf As Integer = MessageBox.Show("Keluar dari aplikasi ?", "Pesan Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If conf = 6 Then
            Me.Close()
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Me.Cari()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Me.Hapus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Clear()
        Me.MsgBox("Pesan Informasi", "Batal menginput data !", MessageBoxIcon.Information)
    End Sub
End Class