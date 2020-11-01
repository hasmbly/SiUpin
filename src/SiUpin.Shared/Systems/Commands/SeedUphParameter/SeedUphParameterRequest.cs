using MediatR;

namespace SiUpin.Shared.Systems.Commands.SeedUphParameter
{
    public class SeedUphParameterRequest : IRequest<SeedUphParameterResponse>
    {
        public string ParameterJawabanID { get; set; }

        public string Description { get; set; }
    }
}