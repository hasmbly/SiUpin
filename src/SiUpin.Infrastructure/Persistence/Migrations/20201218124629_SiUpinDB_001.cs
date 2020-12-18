using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiUpin.Infrastructure.Persistence.Migrations
{
    public partial class SiUpinDB_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asalbantuans",
                columns: table => new
                {
                    AsalBantuanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asalbantuans", x => x.AsalBantuanID);
                });

            migrationBuilder.CreateTable(
                name: "beritas",
                columns: table => new
                {
                    BeritaID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    id_berita = table.Column<string>(nullable: true),
                    Title = table.Column<string>(type: "varchar(200)", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beritas", x => x.BeritaID);
                });

            migrationBuilder.CreateTable(
                name: "jeniskomoditis",
                columns: table => new
                {
                    JenisKomoditiID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_komoditi = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jeniskomoditis", x => x.JenisKomoditiID);
                });

            migrationBuilder.CreateTable(
                name: "jenisternaks",
                columns: table => new
                {
                    JenisTernakID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_ternak = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jenisternaks", x => x.JenisTernakID);
                });

            migrationBuilder.CreateTable(
                name: "parameteraspeks",
                columns: table => new
                {
                    ParameterAspekID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_aspek = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameteraspeks", x => x.ParameterAspekID);
                });

            migrationBuilder.CreateTable(
                name: "pesans",
                columns: table => new
                {
                    PesanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pesans", x => x.PesanID);
                });

            migrationBuilder.CreateTable(
                name: "provinsis",
                columns: table => new
                {
                    ProvinsiID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_provinsi = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinsis", x => x.ProvinsiID);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "satuans",
                columns: table => new
                {
                    SatuanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_satuans", x => x.SatuanID);
                });

            migrationBuilder.CreateTable(
                name: "produkolahans",
                columns: table => new
                {
                    ProdukOlahanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_olahan = table.Column<string>(type: "varchar(50)", nullable: true),
                    JenisKomoditiID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produkolahans", x => x.ProdukOlahanID);
                    table.ForeignKey(
                        name: "FK_produkolahans_jeniskomoditis_JenisKomoditiID",
                        column: x => x.JenisKomoditiID,
                        principalTable: "jeniskomoditis",
                        principalColumn: "JenisKomoditiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "parameterkriterias",
                columns: table => new
                {
                    ParameterKriteriaID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_kriteria = table.Column<string>(nullable: true),
                    ParameterAspekID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameterkriterias", x => x.ParameterKriteriaID);
                    table.ForeignKey(
                        name: "FK_parameterkriterias_parameteraspeks_ParameterAspekID",
                        column: x => x.ParameterAspekID,
                        principalTable: "parameteraspeks",
                        principalColumn: "ParameterAspekID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kotas",
                columns: table => new
                {
                    KotaID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_kota = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProvinsiID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kotas", x => x.KotaID);
                    table.ForeignKey(
                        name: "FK_kotas_provinsis_ProvinsiID",
                        column: x => x.ProvinsiID,
                        principalTable: "provinsis",
                        principalColumn: "ProvinsiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "parameterindikators",
                columns: table => new
                {
                    ParameterIndikatorID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_indikator = table.Column<string>(nullable: true),
                    ParameterKriteriaID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameterindikators", x => x.ParameterIndikatorID);
                    table.ForeignKey(
                        name: "FK_parameterindikators_parameterkriterias_ParameterKriteriaID",
                        column: x => x.ParameterKriteriaID,
                        principalTable: "parameterkriterias",
                        principalColumn: "ParameterKriteriaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kecamatans",
                columns: table => new
                {
                    KecamatanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_kecamatan = table.Column<string>(type: "varchar(50)", nullable: true),
                    KotaID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kecamatans", x => x.KecamatanID);
                    table.ForeignKey(
                        name: "FK_kecamatans_kotas_KotaID",
                        column: x => x.KotaID,
                        principalTable: "kotas",
                        principalColumn: "KotaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "parameterjawabans",
                columns: table => new
                {
                    ParameterJawabanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    ParameterIndikatorID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Skor = table.Column<string>(type: "char(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameterjawabans", x => x.ParameterJawabanID);
                    table.ForeignKey(
                        name: "FK_parameterjawabans_parameterindikators_ParameterIndikatorID",
                        column: x => x.ParameterIndikatorID,
                        principalTable: "parameterindikators",
                        principalColumn: "ParameterIndikatorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kelurahans",
                columns: table => new
                {
                    KelurahanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_kelurahan = table.Column<string>(type: "varchar(50)", nullable: true),
                    KecamatanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kelurahans", x => x.KelurahanID);
                    table.ForeignKey(
                        name: "FK_kelurahans_kecamatans_KecamatanID",
                        column: x => x.KecamatanID,
                        principalTable: "kecamatans",
                        principalColumn: "KecamatanID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uphs",
                columns: table => new
                {
                    UphID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    id_uph = table.Column<string>(nullable: true),
                    ProvinsiID = table.Column<string>(type: "varchar(50)", nullable: true),
                    KotaID = table.Column<string>(type: "varchar(50)", nullable: true),
                    KecamatanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    KelurahanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    ParameterBadanHukumID = table.Column<string>(nullable: true),
                    ParameterAdministrasiID = table.Column<string>(nullable: true),
                    ParameterBentukLembagaID = table.Column<string>(nullable: true),
                    ParameterStatusUphID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true),
                    Ketua = table.Column<string>(type: "varchar(50)", nullable: true),
                    Handphone = table.Column<string>(type: "varchar(50)", nullable: true),
                    Alamat = table.Column<string>(type: "varchar(200)", nullable: true),
                    TahunBerdiri = table.Column<string>(type: "char(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uphs", x => x.UphID);
                    table.ForeignKey(
                        name: "FK_uphs_kecamatans_KecamatanID",
                        column: x => x.KecamatanID,
                        principalTable: "kecamatans",
                        principalColumn: "KecamatanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphs_kelurahans_KelurahanID",
                        column: x => x.KelurahanID,
                        principalTable: "kelurahans",
                        principalColumn: "KelurahanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphs_kotas_KotaID",
                        column: x => x.KotaID,
                        principalTable: "kotas",
                        principalColumn: "KotaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphs_parameterjawabans_ParameterAdministrasiID",
                        column: x => x.ParameterAdministrasiID,
                        principalTable: "parameterjawabans",
                        principalColumn: "ParameterJawabanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphs_parameterjawabans_ParameterBadanHukumID",
                        column: x => x.ParameterBadanHukumID,
                        principalTable: "parameterjawabans",
                        principalColumn: "ParameterJawabanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphs_parameterjawabans_ParameterBentukLembagaID",
                        column: x => x.ParameterBentukLembagaID,
                        principalTable: "parameterjawabans",
                        principalColumn: "ParameterJawabanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphs_parameterjawabans_ParameterStatusUphID",
                        column: x => x.ParameterStatusUphID,
                        principalTable: "parameterjawabans",
                        principalColumn: "ParameterJawabanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphs_provinsis_ProvinsiID",
                        column: x => x.ProvinsiID,
                        principalTable: "provinsis",
                        principalColumn: "ProvinsiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    id = table.Column<string>(type: "varchar(50)", nullable: true),
                    RoleID = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProvinsiID = table.Column<string>(type: "varchar(50)", nullable: true),
                    KotaID = table.Column<string>(type: "varchar(50)", nullable: true),
                    KecamatanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    KelurahanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Username = table.Column<string>(type: "varchar(255)", nullable: true),
                    Fullname = table.Column<string>(type: "varchar(255)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    NIP = table.Column<string>(type: "varchar(255)", nullable: true),
                    Jabatan = table.Column<string>(type: "varchar(255)", nullable: true),
                    Instansi = table.Column<string>(type: "varchar(255)", nullable: true),
                    Telepon = table.Column<string>(type: "varchar(255)", nullable: true),
                    Alamat = table.Column<string>(type: "varchar(255)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PictureURL = table.Column<string>(type: "varchar(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_users_kecamatans_KecamatanID",
                        column: x => x.KecamatanID,
                        principalTable: "kecamatans",
                        principalColumn: "KecamatanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_kelurahans_KelurahanID",
                        column: x => x.KelurahanID,
                        principalTable: "kelurahans",
                        principalColumn: "KelurahanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_kotas_KotaID",
                        column: x => x.KotaID,
                        principalTable: "kotas",
                        principalColumn: "KotaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_provinsis_ProvinsiID",
                        column: x => x.ProvinsiID,
                        principalTable: "provinsis",
                        principalColumn: "ProvinsiID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uphbahanbakus",
                columns: table => new
                {
                    UphBahanBakuID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    UphID = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_bahan_baku = table.Column<string>(nullable: true),
                    id_uph = table.Column<string>(nullable: true),
                    JenisTernakID = table.Column<string>(type: "varchar(50)", nullable: true),
                    JenisKomoditiID = table.Column<string>(type: "varchar(50)", nullable: true),
                    SatuanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    TotalKebutuhan = table.Column<string>(type: "varchar(255)", nullable: true),
                    AsalBahanBaku = table.Column<string>(type: "varchar(255)", nullable: true),
                    Nilai = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uphbahanbakus", x => x.UphBahanBakuID);
                    table.ForeignKey(
                        name: "FK_uphbahanbakus_jeniskomoditis_JenisKomoditiID",
                        column: x => x.JenisKomoditiID,
                        principalTable: "jeniskomoditis",
                        principalColumn: "JenisKomoditiID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphbahanbakus_jenisternaks_JenisTernakID",
                        column: x => x.JenisTernakID,
                        principalTable: "jenisternaks",
                        principalColumn: "JenisTernakID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphbahanbakus_satuans_SatuanID",
                        column: x => x.SatuanID,
                        principalTable: "satuans",
                        principalColumn: "SatuanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphbahanbakus_uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uphgmps",
                columns: table => new
                {
                    UphGmpID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    UphID = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_gmp = table.Column<string>(nullable: true),
                    id_uph = table.Column<string>(nullable: true),
                    nama_gmp = table.Column<string>(nullable: true),
                    jml_gmp = table.Column<string>(nullable: true),
                    user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uphgmps", x => x.UphGmpID);
                    table.ForeignKey(
                        name: "FK_uphgmps_uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uphmitras",
                columns: table => new
                {
                    UphMitraID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    UphID = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_mitra = table.Column<string>(nullable: true),
                    id_uph = table.Column<string>(nullable: true),
                    bermitra = table.Column<string>(nullable: true),
                    jenis_usaha = table.Column<string>(nullable: true),
                    nama_perusahaan = table.Column<string>(nullable: true),
                    alamat = table.Column<string>(nullable: true),
                    penanggungjawab = table.Column<string>(nullable: true),
                    no_hp = table.Column<string>(nullable: true),
                    jenis_mitra = table.Column<string>(nullable: true),
                    lembaga = table.Column<string>(nullable: true),
                    lembaga_lain = table.Column<string>(nullable: true),
                    nilai_lembaga = table.Column<string>(nullable: true),
                    nilai_mitra = table.Column<string>(nullable: true),
                    detail_bahan = table.Column<string>(nullable: true),
                    lain_kopetensi = table.Column<string>(nullable: true),
                    satuan_bahan = table.Column<string>(nullable: true),
                    detail_mitra = table.Column<string>(nullable: true),
                    detail_sarana = table.Column<string>(nullable: true),
                    nilai_sarana = table.Column<string>(nullable: true),
                    detail_kopetensi = table.Column<string>(nullable: true),
                    detail_fasilitasi = table.Column<string>(nullable: true),
                    detail_promosi = table.Column<string>(nullable: true),
                    nilai_promosi = table.Column<string>(nullable: true),
                    manajemen_limbah = table.Column<string>(nullable: true),
                    sasaran = table.Column<string>(nullable: true),
                    perjanjian = table.Column<string>(nullable: true),
                    upload_doc = table.Column<string>(nullable: true),
                    awal_periode = table.Column<string>(nullable: true),
                    akhir_periode = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uphmitras", x => x.UphMitraID);
                    table.ForeignKey(
                        name: "FK_uphmitras_uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uphpasars",
                columns: table => new
                {
                    UphPasarID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    UphID = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_pasar = table.Column<string>(nullable: true),
                    id_uph = table.Column<string>(nullable: true),
                    nama_uph = table.Column<string>(nullable: true),
                    mekanisme = table.Column<string>(nullable: true),
                    nilai_mekanisme = table.Column<string>(nullable: true),
                    jangkauan = table.Column<string>(nullable: true),
                    jml_penjualan = table.Column<string>(nullable: true),
                    omset = table.Column<string>(nullable: true),
                    lain = table.Column<string>(nullable: true),
                    user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uphpasars", x => x.UphPasarID);
                    table.ForeignKey(
                        name: "FK_uphpasars_uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uphproduks",
                columns: table => new
                {
                    UphProdukID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    UphID = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProdukOlahanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    JenisTernakID = table.Column<string>(type: "varchar(50)", nullable: true),
                    SatuanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Harga = table.Column<string>(type: "varchar(50)", nullable: true),
                    Berat = table.Column<int>(type: "int(5)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uphproduks", x => x.UphProdukID);
                    table.ForeignKey(
                        name: "FK_uphproduks_jenisternaks_JenisTernakID",
                        column: x => x.JenisTernakID,
                        principalTable: "jenisternaks",
                        principalColumn: "JenisTernakID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphproduks_produkolahans_ProdukOlahanID",
                        column: x => x.ProdukOlahanID,
                        principalTable: "produkolahans",
                        principalColumn: "ProdukOlahanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphproduks_satuans_SatuanID",
                        column: x => x.SatuanID,
                        principalTable: "satuans",
                        principalColumn: "SatuanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uphproduks_uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uphproduksis",
                columns: table => new
                {
                    UphProduksiID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    UphID = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_produksi = table.Column<string>(nullable: true),
                    id_uph = table.Column<string>(nullable: true),
                    nama_uph = table.Column<string>(nullable: true),
                    bahan_baku = table.Column<string>(nullable: true),
                    jml_produksi = table.Column<string>(nullable: true),
                    satuan = table.Column<string>(nullable: true),
                    izin_edar = table.Column<string>(nullable: true),
                    jml_edar = table.Column<string>(nullable: true),
                    sertifikat = table.Column<string>(nullable: true),
                    jml_sertifikat = table.Column<string>(nullable: true),
                    gmp = table.Column<string>(nullable: true),
                    jml_gmp = table.Column<string>(nullable: true),
                    jml_hari_produksi = table.Column<string>(nullable: true),
                    user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uphproduksis", x => x.UphProduksiID);
                    table.ForeignKey(
                        name: "FK_uphproduksis_uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uphsaranas",
                columns: table => new
                {
                    UphSaranaID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    UphID = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_sarana = table.Column<string>(nullable: true),
                    id_uph = table.Column<string>(nullable: true),
                    nama_uph = table.Column<string>(nullable: true),
                    tahun = table.Column<string>(nullable: true),
                    asal_bantuan = table.Column<string>(nullable: true),
                    lain = table.Column<string>(nullable: true),
                    nama_alat = table.Column<string>(nullable: true),
                    kapasitas_terpasang = table.Column<string>(nullable: true),
                    kapasitas_terpakai = table.Column<string>(nullable: true),
                    satuan = table.Column<string>(nullable: true),
                    jenis_mesin = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    alasan = table.Column<string>(nullable: true),
                    lain_alasan = table.Column<string>(nullable: true),
                    user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uphsaranas", x => x.UphSaranaID);
                    table.ForeignKey(
                        name: "FK_uphsaranas_uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uphsdms",
                columns: table => new
                {
                    UphSdmID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    UphID = table.Column<string>(type: "varchar(50)", nullable: true),
                    id_sdm = table.Column<string>(nullable: true),
                    id_uph = table.Column<string>(nullable: true),
                    nama_uph = table.Column<string>(nullable: true),
                    jml_sdm = table.Column<string>(nullable: true),
                    sop = table.Column<string>(nullable: true),
                    struktur_modal = table.Column<string>(nullable: true),
                    sumber_modal = table.Column<string>(nullable: true),
                    jml_modal = table.Column<string>(nullable: true),
                    nama_pelatihan = table.Column<string>(nullable: true),
                    penyelenggara = table.Column<string>(nullable: true),
                    lokasi = table.Column<string>(nullable: true),
                    tahun = table.Column<string>(nullable: true),
                    user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uphsdms", x => x.UphSdmID);
                    table.ForeignKey(
                        name: "FK_uphsdms_uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    FileID = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LastModified = table.Column<DateTimeOffset>(nullable: false),
                    EntityID = table.Column<string>(type: "varchar(50)", nullable: true),
                    EntityType = table.Column<string>(type: "varchar(10)", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", nullable: true),
                    UphID = table.Column<string>(nullable: true),
                    UphProdukID = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_files_uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_files_uphproduks_UphProdukID",
                        column: x => x.UphProdukID,
                        principalTable: "uphproduks",
                        principalColumn: "UphProdukID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_files_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asalbantuans_AsalBantuanID",
                table: "asalbantuans",
                column: "AsalBantuanID");

            migrationBuilder.CreateIndex(
                name: "IX_beritas_BeritaID",
                table: "beritas",
                column: "BeritaID");

            migrationBuilder.CreateIndex(
                name: "IX_files_EntityID",
                table: "files",
                column: "EntityID");

            migrationBuilder.CreateIndex(
                name: "IX_files_FileID",
                table: "files",
                column: "FileID");

            migrationBuilder.CreateIndex(
                name: "IX_files_UphID",
                table: "files",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_files_UphProdukID",
                table: "files",
                column: "UphProdukID");

            migrationBuilder.CreateIndex(
                name: "IX_files_UserID",
                table: "files",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_jeniskomoditis_JenisKomoditiID",
                table: "jeniskomoditis",
                column: "JenisKomoditiID");

            migrationBuilder.CreateIndex(
                name: "IX_jenisternaks_JenisTernakID",
                table: "jenisternaks",
                column: "JenisTernakID");

            migrationBuilder.CreateIndex(
                name: "IX_kecamatans_KecamatanID",
                table: "kecamatans",
                column: "KecamatanID");

            migrationBuilder.CreateIndex(
                name: "IX_kecamatans_KotaID",
                table: "kecamatans",
                column: "KotaID");

            migrationBuilder.CreateIndex(
                name: "IX_kelurahans_KecamatanID",
                table: "kelurahans",
                column: "KecamatanID");

            migrationBuilder.CreateIndex(
                name: "IX_kelurahans_KelurahanID",
                table: "kelurahans",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_kotas_KotaID",
                table: "kotas",
                column: "KotaID");

            migrationBuilder.CreateIndex(
                name: "IX_kotas_ProvinsiID",
                table: "kotas",
                column: "ProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_parameteraspeks_ParameterAspekID",
                table: "parameteraspeks",
                column: "ParameterAspekID");

            migrationBuilder.CreateIndex(
                name: "IX_parameterindikators_ParameterIndikatorID",
                table: "parameterindikators",
                column: "ParameterIndikatorID");

            migrationBuilder.CreateIndex(
                name: "IX_parameterindikators_ParameterKriteriaID",
                table: "parameterindikators",
                column: "ParameterKriteriaID");

            migrationBuilder.CreateIndex(
                name: "IX_parameterjawabans_ParameterIndikatorID",
                table: "parameterjawabans",
                column: "ParameterIndikatorID");

            migrationBuilder.CreateIndex(
                name: "IX_parameterjawabans_ParameterJawabanID",
                table: "parameterjawabans",
                column: "ParameterJawabanID");

            migrationBuilder.CreateIndex(
                name: "IX_parameterkriterias_ParameterAspekID",
                table: "parameterkriterias",
                column: "ParameterAspekID");

            migrationBuilder.CreateIndex(
                name: "IX_parameterkriterias_ParameterKriteriaID",
                table: "parameterkriterias",
                column: "ParameterKriteriaID");

            migrationBuilder.CreateIndex(
                name: "IX_pesans_PesanID",
                table: "pesans",
                column: "PesanID");

            migrationBuilder.CreateIndex(
                name: "IX_produkolahans_JenisKomoditiID",
                table: "produkolahans",
                column: "JenisKomoditiID");

            migrationBuilder.CreateIndex(
                name: "IX_produkolahans_ProdukOlahanID",
                table: "produkolahans",
                column: "ProdukOlahanID");

            migrationBuilder.CreateIndex(
                name: "IX_provinsis_ProvinsiID",
                table: "provinsis",
                column: "ProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_roles_RoleID",
                table: "roles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_satuans_SatuanID",
                table: "satuans",
                column: "SatuanID");

            migrationBuilder.CreateIndex(
                name: "IX_uphbahanbakus_JenisKomoditiID",
                table: "uphbahanbakus",
                column: "JenisKomoditiID");

            migrationBuilder.CreateIndex(
                name: "IX_uphbahanbakus_JenisTernakID",
                table: "uphbahanbakus",
                column: "JenisTernakID");

            migrationBuilder.CreateIndex(
                name: "IX_uphbahanbakus_SatuanID",
                table: "uphbahanbakus",
                column: "SatuanID");

            migrationBuilder.CreateIndex(
                name: "IX_uphbahanbakus_UphBahanBakuID",
                table: "uphbahanbakus",
                column: "UphBahanBakuID");

            migrationBuilder.CreateIndex(
                name: "IX_uphbahanbakus_UphID",
                table: "uphbahanbakus",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_uphgmps_UphGmpID",
                table: "uphgmps",
                column: "UphGmpID");

            migrationBuilder.CreateIndex(
                name: "IX_uphgmps_UphID",
                table: "uphgmps",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_uphmitras_UphID",
                table: "uphmitras",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_uphmitras_UphMitraID",
                table: "uphmitras",
                column: "UphMitraID");

            migrationBuilder.CreateIndex(
                name: "IX_uphpasars_UphID",
                table: "uphpasars",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_uphpasars_UphPasarID",
                table: "uphpasars",
                column: "UphPasarID");

            migrationBuilder.CreateIndex(
                name: "IX_uphproduks_JenisTernakID",
                table: "uphproduks",
                column: "JenisTernakID");

            migrationBuilder.CreateIndex(
                name: "IX_uphproduks_ProdukOlahanID",
                table: "uphproduks",
                column: "ProdukOlahanID");

            migrationBuilder.CreateIndex(
                name: "IX_uphproduks_SatuanID",
                table: "uphproduks",
                column: "SatuanID");

            migrationBuilder.CreateIndex(
                name: "IX_uphproduks_UphID",
                table: "uphproduks",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_uphproduks_UphProdukID",
                table: "uphproduks",
                column: "UphProdukID");

            migrationBuilder.CreateIndex(
                name: "IX_uphproduksis_UphID",
                table: "uphproduksis",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_uphproduksis_UphProduksiID",
                table: "uphproduksis",
                column: "UphProduksiID");

            migrationBuilder.CreateIndex(
                name: "IX_uphs_KecamatanID",
                table: "uphs",
                column: "KecamatanID");

            migrationBuilder.CreateIndex(
                name: "IX_uphs_KelurahanID",
                table: "uphs",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_uphs_KotaID",
                table: "uphs",
                column: "KotaID");

            migrationBuilder.CreateIndex(
                name: "IX_uphs_ParameterAdministrasiID",
                table: "uphs",
                column: "ParameterAdministrasiID");

            migrationBuilder.CreateIndex(
                name: "IX_uphs_ParameterBadanHukumID",
                table: "uphs",
                column: "ParameterBadanHukumID");

            migrationBuilder.CreateIndex(
                name: "IX_uphs_ParameterBentukLembagaID",
                table: "uphs",
                column: "ParameterBentukLembagaID");

            migrationBuilder.CreateIndex(
                name: "IX_uphs_ParameterStatusUphID",
                table: "uphs",
                column: "ParameterStatusUphID");

            migrationBuilder.CreateIndex(
                name: "IX_uphs_ProvinsiID",
                table: "uphs",
                column: "ProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_uphs_UphID",
                table: "uphs",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_uphsaranas_UphID",
                table: "uphsaranas",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_uphsaranas_UphSaranaID",
                table: "uphsaranas",
                column: "UphSaranaID");

            migrationBuilder.CreateIndex(
                name: "IX_uphsdms_UphID",
                table: "uphsdms",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_uphsdms_UphSdmID",
                table: "uphsdms",
                column: "UphSdmID");

            migrationBuilder.CreateIndex(
                name: "IX_users_KecamatanID",
                table: "users",
                column: "KecamatanID");

            migrationBuilder.CreateIndex(
                name: "IX_users_KelurahanID",
                table: "users",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_users_KotaID",
                table: "users",
                column: "KotaID");

            migrationBuilder.CreateIndex(
                name: "IX_users_ProvinsiID",
                table: "users",
                column: "ProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleID",
                table: "users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserID",
                table: "users",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asalbantuans");

            migrationBuilder.DropTable(
                name: "beritas");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "pesans");

            migrationBuilder.DropTable(
                name: "uphbahanbakus");

            migrationBuilder.DropTable(
                name: "uphgmps");

            migrationBuilder.DropTable(
                name: "uphmitras");

            migrationBuilder.DropTable(
                name: "uphpasars");

            migrationBuilder.DropTable(
                name: "uphproduksis");

            migrationBuilder.DropTable(
                name: "uphsaranas");

            migrationBuilder.DropTable(
                name: "uphsdms");

            migrationBuilder.DropTable(
                name: "uphproduks");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "jenisternaks");

            migrationBuilder.DropTable(
                name: "produkolahans");

            migrationBuilder.DropTable(
                name: "satuans");

            migrationBuilder.DropTable(
                name: "uphs");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "jeniskomoditis");

            migrationBuilder.DropTable(
                name: "kelurahans");

            migrationBuilder.DropTable(
                name: "parameterjawabans");

            migrationBuilder.DropTable(
                name: "kecamatans");

            migrationBuilder.DropTable(
                name: "parameterindikators");

            migrationBuilder.DropTable(
                name: "kotas");

            migrationBuilder.DropTable(
                name: "parameterkriterias");

            migrationBuilder.DropTable(
                name: "provinsis");

            migrationBuilder.DropTable(
                name: "parameteraspeks");
        }
    }
}
