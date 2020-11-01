using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedParameterJawaban;

namespace SiUpin.Application.Systems.Commands.SeedParameterJawaban
{
    public class SeedParameterJawabanCommandHandler : IRequestHandler<SeedParameterJawabanRequest, SeedParameterJawabanResponse>
    {
        private readonly ISiUpinDBContext _context;

        public SeedParameterJawabanCommandHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<SeedParameterJawabanResponse> Handle(SeedParameterJawabanRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedParameterJawabanResponse();

            var listOfData = new List<ParameterJawabanExcel>();

            // read excel files then add to List
            var bin = System.IO.File.ReadAllBytes(FilePath.ParameterJawabanExcel);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                //loop all worksheets
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    //loop all rows
                    for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                    {
                        string id_indikator, jawaban, skor = "";

                        id_indikator = worksheet.Cells[i, 1].Value.ToString();
                        jawaban = worksheet.Cells[i, 2].Value.ToString();
                        skor = worksheet.Cells[i, 3].Value.ToString();

                        listOfData.Add(new ParameterJawabanExcel()
                        {
                            id_indikator = id_indikator,
                            jawaban = jawaban,
                            skor = skor
                        });
                    }
                }
            }

            // collect provinsi's data from db to temporary List
            var parentData = await _context.ParameterIndikators
            .ToListAsync(cancellationToken);

            foreach (var data in listOfData)
            {
                ParameterJawaban ParameterJawaban = new ParameterJawaban();

                string parentID = parentData.Where(x => x.id_indikator == data.id_indikator).FirstOrDefault().ParameterIndikatorID ?? "";

                ParameterJawaban = new ParameterJawaban
                {
                    ParameterIndikatorID = parentID,
                    Name = data.jawaban,
                    Skor = data.skor
                };

                _context.ParameterJawabans.Add(ParameterJawaban);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}