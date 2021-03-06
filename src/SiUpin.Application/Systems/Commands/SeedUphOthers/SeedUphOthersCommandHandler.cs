﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedUphOthers;

namespace SiUpin.Application.Systems.Commands.SeedBerita
{
    public class SeedUphOthersCommandHandler : IRequestHandler<SeedUphOthersRequest, SeedUphOthersResponse>
    {
        private readonly ISiUpinDBContext _context;
        private IMediator _mediator;
        private readonly IEntityRepository _entityRepository;

        public SeedUphOthersCommandHandler(ISiUpinDBContext context, IMediator mediator, IEntityRepository entityRepository)
        {
            _context = context;
            _entityRepository = entityRepository;
            _mediator = mediator;
        }

        public async Task<SeedUphOthersResponse> Handle(SeedUphOthersRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedUphOthersResponse();

            var oldSarana = await _entityRepository.GetAllSarana();
            var oldGmp = await _entityRepository.GetAllGmp();
            var oldMitra = await _entityRepository.GetAllMitra();
            var oldPasar = await _entityRepository.GetAllPasar();
            var oldProduksi = await _entityRepository.GetAllProduksi();
            var oldSdm = await _entityRepository.GetAllSdm();

            List<UphSarana> saranas = new List<UphSarana>();
            List<UphGmp> gmps = new List<UphGmp>();
            List<UphMitra> mitras = new List<UphMitra>();
            List<UphPasar> pasars = new List<UphPasar>();
            List<UphProduksi> produksis = new List<UphProduksi>();
            List<UphSdm> sdms = new List<UphSdm>();

            var existingSaranas = await _context.UphSaranas.AsNoTracking().ToListAsync(cancellationToken);
            var existingGmps = await _context.UphGmps.AsNoTracking().ToListAsync(cancellationToken);
            var existingMitra = await _context.UphMitras.AsNoTracking().ToListAsync(cancellationToken);
            var existingPasar = await _context.UphPasars.AsNoTracking().ToListAsync(cancellationToken);
            var existingProduksi = await _context.UphProduksis.AsNoTracking().ToListAsync(cancellationToken);
            var existingSdm = await _context.UphSdms.AsNoTracking().ToListAsync(cancellationToken);

            if (oldSarana.Count() > 0)
            {
                foreach (var data in oldSarana)
                {
                    var existingEntity = existingSaranas.FirstOrDefault(x => x.id_sarana == data.id_sarana);

                    if (existingEntity != null)
                    {
                        if (string.IsNullOrEmpty(existingEntity.UphID))
                        {
                            var oldEntity = await _context.UphSaranas.FirstOrDefaultAsync(x => x.id_sarana == data.id_sarana, cancellationToken);
                            var uph = await _context.Uphs.AsNoTracking().FirstOrDefaultAsync(x => x.id_uph == data.id_uph, cancellationToken);

                            if (uph != null)
                            {
                                System.Console.WriteLine($"id_sarana: {oldEntity.id_sarana} -> doUpdate -> UphID: {uph.UphID}");

                                oldEntity.UphID = uph.UphID;

                                await _context.SaveChangesAsync(cancellationToken);
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    UphSarana entity = new UphSarana();

                    entity = saranas
                        .SingleOrDefault(x => x.id_sarana == data.id_sarana);

                    if (entity == null)
                    {
                        entity = new UphSarana
                        {
                            id_sarana = data.id_sarana,
                            id_uph = data.id_uph,
                            alasan = data.alasan,
                            asal_bantuan = data.asal_bantuan,
                            jenis_mesin = data.jenis_mesin,
                            kapasitas_terpakai = data.kapasitas_terpakai,
                            kapasitas_terpasang = data.kapasitas_terpasang,
                            lain = data.lain,
                            lain_alasan = data.lain_alasan,
                            nama_alat = data.nama_alat,
                            nama_uph = data.nama_uph,
                            satuan = data.satuan,
                            status = data.status,
                            tahun = data.tahun
                        };

                        saranas.Add(entity);
                        _context.UphSaranas.Add(entity);
                    }
                }

                if (saranas.Count > 0)
                    await _context.SaveChangesAsync(cancellationToken);
            }

            if (oldGmp.Count() > 0)
            {
                foreach (var data in oldGmp)
                {
                    var existingEntity = existingGmps.FirstOrDefault(x => x.id_gmp == data.id_gmp);

                    if (existingEntity != null)
                    {
                        if (string.IsNullOrEmpty(existingEntity.UphID))
                        {
                            var oldEntity = await _context.UphGmps.FirstOrDefaultAsync(x => x.id_gmp == data.id_gmp, cancellationToken);
                            var uph = await _context.Uphs.AsNoTracking().FirstOrDefaultAsync(x => x.id_uph == data.id_uph, cancellationToken);

                            if (uph != null)
                            {
                                System.Console.WriteLine($"id_gmp: {oldEntity.id_gmp} -> doUpdate -> UphID: {uph.UphID}");

                                oldEntity.UphID = uph.UphID;

                                await _context.SaveChangesAsync(cancellationToken);
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    UphGmp entity = new UphGmp();

                    entity = gmps
                        .SingleOrDefault(x => x.id_gmp == data.id_gmp);

                    if (entity == null)
                    {
                        entity = new UphGmp
                        {
                            id_gmp = data.id_gmp,
                            id_uph = data.id_uph,
                            jml_gmp = data.jml_gmp,
                            nama_gmp = data.nama_gmp
                        };

                        gmps.Add(entity);
                        _context.UphGmps.Add(entity);
                    }
                }

                if (gmps.Count > 0)
                    await _context.SaveChangesAsync(cancellationToken);
            }

            if (oldMitra.Count() > 0)
            {
                foreach (var data in oldMitra)
                {
                    var existingEntity = existingMitra.FirstOrDefault(x => x.id_mitra == data.id_mitra);

                    if (existingEntity != null)
                    {
                        if (string.IsNullOrEmpty(existingEntity.UphID))
                        {
                            var oldEntity = await _context.UphMitras.FirstOrDefaultAsync(x => x.id_mitra == data.id_mitra, cancellationToken);
                            var uph = await _context.Uphs.AsNoTracking().FirstOrDefaultAsync(x => x.id_uph == data.id_uph, cancellationToken);

                            if (uph != null)
                            {
                                System.Console.WriteLine($"id_mitra: {oldEntity.id_mitra} -> doUpdate -> UphID: {uph.UphID}");

                                oldEntity.UphID = uph.UphID;

                                await _context.SaveChangesAsync(cancellationToken);
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    UphMitra entity = new UphMitra();

                    entity = mitras
                        .SingleOrDefault(x => x.id_mitra == data.id_mitra);

                    if (entity == null)
                    {
                        entity = new UphMitra
                        {
                            id_mitra = data.id_mitra,
                            id_uph = data.id_uph,
                            upload_doc = data.upload_doc,
                            status = data.status,
                            satuan_bahan = data.satuan_bahan,
                            sasaran = data.sasaran,
                            penanggungjawab = data.penanggungjawab,
                            akhir_periode = data.akhir_periode,
                            alamat = data.alamat,
                            awal_periode = data.awal_periode,
                            bermitra = data.bermitra,
                            detail_bahan = data.detail_bahan,
                            detail_fasilitasi = data.detail_fasilitasi,
                            detail_kopetensi = data.detail_kopetensi,
                            detail_mitra = data.detail_mitra,
                            detail_promosi = data.detail_promosi,
                            detail_sarana = data.detail_sarana,
                            jenis_mitra = data.jenis_mitra,
                            jenis_usaha = data.jenis_usaha,
                            lain_kopetensi = data.lain_kopetensi,
                            lembaga = data.lembaga,
                            lembaga_lain = data.lembaga_lain,
                            manajemen_limbah = data.manajemen_limbah,
                            nama_perusahaan = data.nama_perusahaan,
                            nilai_lembaga = data.nilai_lembaga,
                            nilai_mitra = data.nilai_mitra,
                            nilai_promosi = data.nilai_promosi,
                            nilai_sarana = data.nilai_sarana,
                            no_hp = data.no_hp,
                            perjanjian = data.perjanjian
                        };

                        mitras.Add(entity);
                        _context.UphMitras.Add(entity);
                    }
                }

                if (mitras.Count > 0)
                    await _context.SaveChangesAsync(cancellationToken);
            }

            if (oldPasar.Count() > 0)
            {
                foreach (var data in oldPasar)
                {
                    var existingEntity = existingPasar.FirstOrDefault(x => x.id_pasar == data.id_pasar);

                    if (existingEntity != null)
                    {
                        if (string.IsNullOrEmpty(existingEntity.UphID))
                        {
                            var oldEntity = await _context.UphPasars.FirstOrDefaultAsync(x => x.id_pasar == data.id_pasar, cancellationToken);
                            var uph = await _context.Uphs.AsNoTracking().FirstOrDefaultAsync(x => x.id_uph == data.id_uph, cancellationToken);

                            if (uph != null)
                            {
                                System.Console.WriteLine($"id_pasar: {oldEntity.id_pasar} -> doUpdate -> UphID: {uph.UphID}");

                                oldEntity.UphID = uph.UphID;

                                await _context.SaveChangesAsync(cancellationToken);
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    UphPasar entity = new UphPasar();

                    entity = pasars
                        .SingleOrDefault(x => x.id_pasar == data.id_pasar);

                    if (entity == null)
                    {
                        entity = new UphPasar
                        {
                            id_pasar = data.id_pasar,
                            id_uph = data.id_uph,
                            jangkauan = data.jangkauan,
                            jml_penjualan = data.jml_penjualan,
                            lain = data.lain,
                            mekanisme = data.mekanisme,
                            nama_uph = data.nama_uph,
                            nilai_mekanisme = data.nilai_mekanisme,
                            omset = data.omset
                        };

                        pasars.Add(entity);
                        _context.UphPasars.Add(entity);
                    }
                }

                if (pasars.Count > 0)
                    await _context.SaveChangesAsync(cancellationToken);
            }

            if (oldProduksi.Count() > 0)
            {
                System.Console.WriteLine($"oldProduksi.Count(): {oldProduksi.Count()}");

                foreach (var data in oldProduksi)
                {
                    var existingEntity = existingProduksi.FirstOrDefault(x => x.id_produksi == data.id_produksi);

                    if (existingEntity != null)
                    {
                        if (string.IsNullOrEmpty(existingEntity.UphID))
                        {
                            var oldEntity = await _context.UphProduksis.FirstOrDefaultAsync(x => x.id_produksi == data.id_produksi, cancellationToken);
                            var uph = await _context.Uphs.AsNoTracking().FirstOrDefaultAsync(x => x.id_uph == data.id_uph, cancellationToken);

                            if (uph != null)
                            {
                                System.Console.WriteLine($"id_produksi: {oldEntity.id_produksi} -> doUpdate -> UphID: {uph.UphID}");

                                oldEntity.UphID = uph.UphID;

                                await _context.SaveChangesAsync(cancellationToken);
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    System.Console.WriteLine($"insert - produksi id_uph ({data.id_uph})");

                    UphProduksi entity = new UphProduksi();

                    entity = produksis
                        .SingleOrDefault(x => x.id_produksi == data.id_produksi);

                    if (entity == null)
                    {
                        entity = new UphProduksi
                        {
                            id_produksi = data.id_produksi,
                            id_uph = data.id_uph,
                            nama_uph = data.nama_uph,
                            bahan_baku = data.bahan_baku,
                            gmp = data.gmp,
                            izin_edar = data.izin_edar,
                            jml_edar = data.jml_edar,
                            jml_gmp = data.jml_gmp,
                            jml_hari_produksi = data.jml_hari_produksi,
                            jml_produksi = data.jml_produksi,
                            jml_sertifikat = data.jml_sertifikat,
                            satuan = data.satuan,
                            sertifikat = data.sertifikat
                        };

                        produksis.Add(entity);
                        _context.UphProduksis.Add(entity);
                    }
                }

                if (produksis.Count > 0)
                    await _context.SaveChangesAsync(cancellationToken);
            }

            if (oldSdm.Count() > 0)
            {
                foreach (var data in oldSdm)
                {
                    var existingEntity = existingSdm.FirstOrDefault(x => x.id_sdm == data.id_sdm);

                    if (existingEntity != null)
                    {
                        if (string.IsNullOrEmpty(existingEntity.UphID))
                        {
                            var oldEntity = await _context.UphSdms.FirstOrDefaultAsync(x => x.id_sdm == data.id_sdm, cancellationToken);
                            var uph = await _context.Uphs.AsNoTracking().FirstOrDefaultAsync(x => x.id_uph == data.id_uph, cancellationToken);

                            if (uph != null)
                            {
                                System.Console.WriteLine($"id_sdm: {oldEntity.id_sdm} -> doUpdate -> UphID: {uph.UphID}");

                                oldEntity.UphID = uph.UphID;

                                await _context.SaveChangesAsync(cancellationToken);
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    UphSdm entity = new UphSdm();

                    entity = sdms
                        .SingleOrDefault(x => x.id_sdm == data.id_sdm);

                    if (entity == null)
                    {
                        entity = new UphSdm
                        {
                            id_sdm = data.id_sdm,
                            id_uph = data.id_uph,
                            jml_modal = data.jml_modal,
                            jml_sdm = data.jml_sdm,
                            lokasi = data.lokasi,
                            nama_pelatihan = data.nama_pelatihan,
                            nama_uph = data.nama_uph,
                            penyelenggara = data.penyelenggara,
                            sop = data.sop,
                            struktur_modal = data.struktur_modal,
                            sumber_modal = data.sumber_modal,
                            tahun = data.tahun
                        };

                        sdms.Add(entity);
                        _context.UphSdms.Add(entity);
                    }
                }

                if (sdms.Count > 0)
                    await _context.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
    }
}