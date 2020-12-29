using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphProduks.Command.UpdateUphProduk;

namespace SiUpin.Application.UphProduks.Command.UpdateUphProduk
{
    public class UpdateUphProdukQueryHandler : IRequestHandler<UpdateUphProdukRequest, UpdateUphProdukResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IMediator _mediator;

        public UpdateUphProdukQueryHandler(ISiUpinDBContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<UpdateUphProdukResponse> Handle(UpdateUphProdukRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUphProdukResponse();

            var uphProduk = await _context.UphProduks.FirstOrDefaultAsync(x => x.UphProdukID == request.UphProdukID, cancellationToken);

            if (request.Name != uphProduk.Name)
            {
                if (await _context.UphProduks.AnyAsync(x => x.UphID == request.UphID && x.Name == request.Name))
                {
                    throw new Exception("Maaf Nama Produk sudah di gunakan di UPH ini");
                }
            }

            if (uphProduk != null)
            {
                uphProduk.UphID = request.UphID;
                uphProduk.JenisTernakID = request.JenisTernakID;
                uphProduk.ProdukOlahanID = request.ProdukOlahanID;
                uphProduk.SatuanID = request.SatuanID;
                uphProduk.Name = request.Name;
                uphProduk.Berat = request.Berat;
                uphProduk.Harga = request.Harga;
                uphProduk.Description = request.Description;

                await _context.SaveChangesAsync(cancellationToken);
            }

            result.UphProdukID = uphProduk.UphProdukID;

            return result;
        }
    }
}