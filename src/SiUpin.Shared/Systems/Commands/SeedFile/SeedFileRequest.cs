using MediatR;

namespace SiUpin.Shared.Systems.Commands.SeedFile
{
    public class SeedFileRequest : IRequest<SeedFileResponse>
    {
        public string EntityType { get; set; }
        public string EntityID { get; set; }
        public string Name { get; set; }
    }
}