using MediatR;

namespace SiUpin.Shared.ProdukOlahans.Commands.CreateProdukOlahan
{
    public class CreateProdukOlahanRequest : IRequest<CreateProdukOlahanResponse>
    {
        public string JenisKomditiID { get; set; }
        public int Name { get; set; }
    }
}
