using MediatR;

namespace SiUpin.Shared.JenisKomiditis.Commands.DeleteJenisKomoditi
{
    public class DeleteJenisKomoditiRequest : IRequest<DeleteJenisKomoditiResponse>
    {
        public string JenisKomoditiID { get; set; }
    }
}
