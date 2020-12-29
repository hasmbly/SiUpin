using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared;
using SiUpin.Shared.UphProduks.Command.CreateUphProduk;

namespace SiUpin.Application.Uphs.Command.CreateUphProduk
{
    public class CreateUphProdukCommandHandler : IRequestHandler<CreateUphProdukRequest, CreateUphProdukResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly ISiUpinDBContext _context;

        public CreateUphProdukCommandHandler(ISiUpinDBContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<CreateUphProdukResponse> Handle(CreateUphProdukRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUphProdukResponse();

            var options = _configuration.GetSection(SiUpinOptions.RootSection).Get<SiUpinOptions>();

            if (await _context.UphProduks.AnyAsync(x => x.UphID == request.UphID && x.Name == request.Name))
            {
                throw new Exception("Maaf Nama Produk sudah di gunakan di UPH ini");
            }
            else
            {
                var entity = new UphProduk
                {
                    UphID = request.UphID,
                    JenisTernakID = request.JenisTernakID,
                    ProdukOlahanID = request.ProdukOlahanID,
                    SatuanID = request.SatuanID,

                    Name = request.Name,
                    Berat = request.Berat,
                    Harga = request.Harga,
                    Description = request.Description
                };

                await _context.UphProduks.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);

                result.UphProdukID = entity.UphProdukID;
            }

            return result;
        }
    }
}