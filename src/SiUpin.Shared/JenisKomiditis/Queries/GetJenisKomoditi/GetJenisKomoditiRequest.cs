using MediatR;

namespace SiUpin.Shared.JenisKomiditis.Queries.GetJenisKomoditi
{
    public class GetJenisKomoditiRequest : IRequest<GetJenisKomoditiResponse>
    {
        public string JenisKomoditiID { get; set; }
    }
}
