using MediatR;

namespace SiUpin.Shared.JenisKomiditis.Commands.UpdateJenisKomoditi
{
    public class UpdateJenisKomoditiRequest : IRequest<UpdateJenisKomoditiResponse>
    {
        public string JenisKomoditiID { get; set; }
        public string Nsame { get; set; }
    }
}
