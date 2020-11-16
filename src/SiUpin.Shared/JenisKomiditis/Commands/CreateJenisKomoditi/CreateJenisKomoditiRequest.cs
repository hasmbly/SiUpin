using MediatR;

namespace SiUpin.Shared.JenisKomiditis.Commands.CreateJenisKomoditi
{
    public class CreateJenisKomoditiRequest : IRequest<CreateJenisKomoditiResponse>
    {
        public string Name { get; set; }
    }
}
