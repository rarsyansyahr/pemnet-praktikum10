CREATE DATABASE kampus;

use kampus;

CREATE TABLE master_barang(
	kode_barang char(15) PRIMARY KEY,
	nama_barang char(50),
	jenis_barang char(35),
	stok_barang int,
	harga_barang int
);