using MediatR;

namespace SiUpin.Shared.ProdukOlahans.Commands.DeleteProdukOlahan
{
    public class DeleteProdukOlahanRequest : IRequest<DeleteProdukOlahanResponse>
    {
        public string ProdukOlahanID { get; set; }
    }
}
