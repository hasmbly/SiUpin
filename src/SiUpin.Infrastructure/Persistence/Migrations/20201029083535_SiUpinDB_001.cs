using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiUpin.Infrastructure.Persistence.Migrations
{
    public partial class SiUpinDB_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsalBantuans",
                columns: table => new
                {
                    AsalBantuanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsalBantuans", x => x.AsalBantuanID);
                });

            migrationBuilder.CreateTable(
                name: "Beritas",
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
                    table.PrimaryKey("PK_Beritas", x => x.BeritaID);
                });

            migrationBuilder.CreateTable(
                name: "JenisKomoditis",
                columns: table => new
                {
                    JenisKomoditiID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_komoditi = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisKomoditis", x => x.JenisKomoditiID);
                });

            migrationBuilder.CreateTable(
                name: "JenisTernaks",
                columns: table => new
                {
                    JenisTernakID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_ternak = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisTernaks", x => x.JenisTernakID);
                });

            migrationBuilder.CreateTable(
                name: "ParameterAspeks",
                columns: table => new
                {
                    ParameterAspekID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_aspek = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterAspeks", x => x.ParameterAspekID);
                });

            migrationBuilder.CreateTable(
                name: "Pesans",
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
                    table.PrimaryKey("PK_Pesans", x => x.PesanID);
                });

            migrationBuilder.CreateTable(
                name: "Provinsis",
                columns: table => new
                {
                    ProvinsiID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_provinsi = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinsis", x => x.ProvinsiID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Satuans",
                columns: table => new
                {
                    SatuanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satuans", x => x.SatuanID);
                });

            migrationBuilder.CreateTable(
                name: "ProdukOlahans",
                columns: table => new
                {
                    ProdukOlahanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_olahan = table.Column<string>(type: "varchar(50)", nullable: true),
                    JenisKomoditiID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdukOlahans", x => x.ProdukOlahanID);
                    table.ForeignKey(
                        name: "FK_ProdukOlahans_JenisKomoditis_JenisKomoditiID",
                        column: x => x.JenisKomoditiID,
                        principalTable: "JenisKomoditis",
                        principalColumn: "JenisKomoditiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParameterKriterias",
                columns: table => new
                {
                    ParameterKriteriaID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_kriteria = table.Column<string>(nullable: true),
                    ParameterAspekID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterKriterias", x => x.ParameterKriteriaID);
                    table.ForeignKey(
                        name: "FK_ParameterKriterias_ParameterAspeks_ParameterAspekID",
                        column: x => x.ParameterAspekID,
                        principalTable: "ParameterAspeks",
                        principalColumn: "ParameterAspekID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kotas",
                columns: table => new
                {
                    KotaID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_kota = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProvinsiID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kotas", x => x.KotaID);
                    table.ForeignKey(
                        name: "FK_Kotas_Provinsis_ProvinsiID",
                        column: x => x.ProvinsiID,
                        principalTable: "Provinsis",
                        principalColumn: "ProvinsiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParameterIndikators",
                columns: table => new
                {
                    ParameterIndikatorID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_indikator = table.Column<string>(nullable: true),
                    ParameterKriteriaID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterIndikators", x => x.ParameterIndikatorID);
                    table.ForeignKey(
                        name: "FK_ParameterIndikators_ParameterKriterias_ParameterKriteriaID",
                        column: x => x.ParameterKriteriaID,
                        principalTable: "ParameterKriterias",
                        principalColumn: "ParameterKriteriaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kecamatans",
                columns: table => new
                {
                    KecamatanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_kecamatan = table.Column<string>(type: "varchar(50)", nullable: true),
                    KotaID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kecamatans", x => x.KecamatanID);
                    table.ForeignKey(
                        name: "FK_Kecamatans_Kotas_KotaID",
                        column: x => x.KotaID,
                        principalTable: "Kotas",
                        principalColumn: "KotaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParameterJawabans",
                columns: table => new
                {
                    ParameterJawabanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    ParameterIndikatorID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Skor = table.Column<string>(type: "char(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterJawabans", x => x.ParameterJawabanID);
                    table.ForeignKey(
                        name: "FK_ParameterJawabans_ParameterIndikators_ParameterIndikatorID",
                        column: x => x.ParameterIndikatorID,
                        principalTable: "ParameterIndikators",
                        principalColumn: "ParameterIndikatorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kelurahans",
                columns: table => new
                {
                    KelurahanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_kelurahan = table.Column<string>(type: "varchar(50)", nullable: true),
                    KecamatanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelurahans", x => x.KelurahanID);
                    table.ForeignKey(
                        name: "FK_Kelurahans_Kecamatans_KecamatanID",
                        column: x => x.KecamatanID,
                        principalTable: "Kecamatans",
                        principalColumn: "KecamatanID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uphs",
                columns: table => new
                {
                    UphID = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_uph = table.Column<string>(nullable: true),
                    ProvinsiID = table.Column<string>(type: "varchar(50)", nullable: true),
                    KotaID = table.Column<string>(type: "varchar(50)", nullable: true),
                    KecamatanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    KelurahanID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    Ketua = table.Column<string>(type: "varchar(50)", nullable: true),
                    Handphone = table.Column<string>(type: "varchar(50)", nullable: true),
                    Alamat = table.Column<string>(type: "varchar(200)", nullable: true),
                    TahunBerdiri = table.Column<string>(type: "char(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uphs", x => x.UphID);
                    table.ForeignKey(
                        name: "FK_Uphs_Kecamatans_KecamatanID",
                        column: x => x.KecamatanID,
                        principalTable: "Kecamatans",
                        principalColumn: "KecamatanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uphs_Kelurahans_KelurahanID",
                        column: x => x.KelurahanID,
                        principalTable: "Kelurahans",
                        principalColumn: "KelurahanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uphs_Kotas_KotaID",
                        column: x => x.KotaID,
                        principalTable: "Kotas",
                        principalColumn: "KotaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uphs_Provinsis_ProvinsiID",
                        column: x => x.ProvinsiID,
                        principalTable: "Provinsis",
                        principalColumn: "ProvinsiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
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
                    Username = table.Column<string>(type: "varchar(50)", nullable: true),
                    Fullname = table.Column<string>(type: "varchar(200)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    NIP = table.Column<string>(type: "varchar(100)", nullable: true),
                    Jabatan = table.Column<string>(type: "varchar(100)", nullable: true),
                    Instansi = table.Column<string>(type: "varchar(100)", nullable: true),
                    Telepon = table.Column<string>(type: "varchar(100)", nullable: true),
                    Alamat = table.Column<string>(type: "varchar(100)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PictureURL = table.Column<string>(type: "varchar(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Kecamatans_KecamatanID",
                        column: x => x.KecamatanID,
                        principalTable: "Kecamatans",
                        principalColumn: "KecamatanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Kelurahans_KelurahanID",
                        column: x => x.KelurahanID,
                        principalTable: "Kelurahans",
                        principalColumn: "KelurahanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Kotas_KotaID",
                        column: x => x.KotaID,
                        principalTable: "Kotas",
                        principalColumn: "KotaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Provinsis_ProvinsiID",
                        column: x => x.ProvinsiID,
                        principalTable: "Provinsis",
                        principalColumn: "ProvinsiID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UphParameters",
                columns: table => new
                {
                    UphID = table.Column<string>(type: "varchar(50)", nullable: false),
                    ParameterJawabanID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UphParameters", x => new { x.UphID, x.ParameterJawabanID });
                    table.ForeignKey(
                        name: "FK_UphParameters_ParameterJawabans_ParameterJawabanID",
                        column: x => x.ParameterJawabanID,
                        principalTable: "ParameterJawabans",
                        principalColumn: "ParameterJawabanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UphParameters_Uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "Uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UphProduks",
                columns: table => new
                {
                    UphProdukID = table.Column<string>(type: "varchar(50)", nullable: false),
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
                    table.PrimaryKey("PK_UphProduks", x => x.UphProdukID);
                    table.ForeignKey(
                        name: "FK_UphProduks_JenisTernaks_JenisTernakID",
                        column: x => x.JenisTernakID,
                        principalTable: "JenisTernaks",
                        principalColumn: "JenisTernakID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UphProduks_ProdukOlahans_ProdukOlahanID",
                        column: x => x.ProdukOlahanID,
                        principalTable: "ProdukOlahans",
                        principalColumn: "ProdukOlahanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UphProduks_Satuans_SatuanID",
                        column: x => x.SatuanID,
                        principalTable: "Satuans",
                        principalColumn: "SatuanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UphProduks_Uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "Uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
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
                    table.PrimaryKey("PK_Files", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_Files_Uphs_UphID",
                        column: x => x.UphID,
                        principalTable: "Uphs",
                        principalColumn: "UphID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_UphProduks_UphProdukID",
                        column: x => x.UphProdukID,
                        principalTable: "UphProduks",
                        principalColumn: "UphProdukID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsalBantuans_AsalBantuanID",
                table: "AsalBantuans",
                column: "AsalBantuanID");

            migrationBuilder.CreateIndex(
                name: "IX_Beritas_BeritaID",
                table: "Beritas",
                column: "BeritaID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_EntityID",
                table: "Files",
                column: "EntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileID",
                table: "Files",
                column: "FileID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UphID",
                table: "Files",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UphProdukID",
                table: "Files",
                column: "UphProdukID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserID",
                table: "Files",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_JenisKomoditis_JenisKomoditiID",
                table: "JenisKomoditis",
                column: "JenisKomoditiID");

            migrationBuilder.CreateIndex(
                name: "IX_JenisTernaks_JenisTernakID",
                table: "JenisTernaks",
                column: "JenisTernakID");

            migrationBuilder.CreateIndex(
                name: "IX_Kecamatans_KecamatanID",
                table: "Kecamatans",
                column: "KecamatanID");

            migrationBuilder.CreateIndex(
                name: "IX_Kecamatans_KotaID",
                table: "Kecamatans",
                column: "KotaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kelurahans_KecamatanID",
                table: "Kelurahans",
                column: "KecamatanID");

            migrationBuilder.CreateIndex(
                name: "IX_Kelurahans_KelurahanID",
                table: "Kelurahans",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_Kotas_KotaID",
                table: "Kotas",
                column: "KotaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kotas_ProvinsiID",
                table: "Kotas",
                column: "ProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterAspeks_ParameterAspekID",
                table: "ParameterAspeks",
                column: "ParameterAspekID");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterIndikators_ParameterIndikatorID",
                table: "ParameterIndikators",
                column: "ParameterIndikatorID");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterIndikators_ParameterKriteriaID",
                table: "ParameterIndikators",
                column: "ParameterKriteriaID");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterJawabans_ParameterIndikatorID",
                table: "ParameterJawabans",
                column: "ParameterIndikatorID");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterJawabans_ParameterJawabanID",
                table: "ParameterJawabans",
                column: "ParameterJawabanID");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterKriterias_ParameterAspekID",
                table: "ParameterKriterias",
                column: "ParameterAspekID");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterKriterias_ParameterKriteriaID",
                table: "ParameterKriterias",
                column: "ParameterKriteriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pesans_PesanID",
                table: "Pesans",
                column: "PesanID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdukOlahans_JenisKomoditiID",
                table: "ProdukOlahans",
                column: "JenisKomoditiID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdukOlahans_ProdukOlahanID",
                table: "ProdukOlahans",
                column: "ProdukOlahanID");

            migrationBuilder.CreateIndex(
                name: "IX_Provinsis_ProvinsiID",
                table: "Provinsis",
                column: "ProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleID",
                table: "Roles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Satuans_SatuanID",
                table: "Satuans",
                column: "SatuanID");

            migrationBuilder.CreateIndex(
                name: "IX_UphParameters_ParameterJawabanID",
                table: "UphParameters",
                column: "ParameterJawabanID");

            migrationBuilder.CreateIndex(
                name: "IX_UphParameters_UphID",
                table: "UphParameters",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_UphProduks_JenisTernakID",
                table: "UphProduks",
                column: "JenisTernakID");

            migrationBuilder.CreateIndex(
                name: "IX_UphProduks_ProdukOlahanID",
                table: "UphProduks",
                column: "ProdukOlahanID");

            migrationBuilder.CreateIndex(
                name: "IX_UphProduks_SatuanID",
                table: "UphProduks",
                column: "SatuanID");

            migrationBuilder.CreateIndex(
                name: "IX_UphProduks_UphID",
                table: "UphProduks",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_UphProduks_UphProdukID",
                table: "UphProduks",
                column: "UphProdukID");

            migrationBuilder.CreateIndex(
                name: "IX_Uphs_KecamatanID",
                table: "Uphs",
                column: "KecamatanID");

            migrationBuilder.CreateIndex(
                name: "IX_Uphs_KelurahanID",
                table: "Uphs",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_Uphs_KotaID",
                table: "Uphs",
                column: "KotaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uphs_ProvinsiID",
                table: "Uphs",
                column: "ProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_Uphs_UphID",
                table: "Uphs",
                column: "UphID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_KecamatanID",
                table: "Users",
                column: "KecamatanID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_KelurahanID",
                table: "Users",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_KotaID",
                table: "Users",
                column: "KotaID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProvinsiID",
                table: "Users",
                column: "ProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserID",
                table: "Users",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsalBantuans");

            migrationBuilder.DropTable(
                name: "Beritas");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Pesans");

            migrationBuilder.DropTable(
                name: "UphParameters");

            migrationBuilder.DropTable(
                name: "UphProduks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ParameterJawabans");

            migrationBuilder.DropTable(
                name: "JenisTernaks");

            migrationBuilder.DropTable(
                name: "ProdukOlahans");

            migrationBuilder.DropTable(
                name: "Satuans");

            migrationBuilder.DropTable(
                name: "Uphs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ParameterIndikators");

            migrationBuilder.DropTable(
                name: "JenisKomoditis");

            migrationBuilder.DropTable(
                name: "Kelurahans");

            migrationBuilder.DropTable(
                name: "ParameterKriterias");

            migrationBuilder.DropTable(
                name: "Kecamatans");

            migrationBuilder.DropTable(
                name: "ParameterAspeks");

            migrationBuilder.DropTable(
                name: "Kotas");

            migrationBuilder.DropTable(
                name: "Provinsis");
        }
    }
}
