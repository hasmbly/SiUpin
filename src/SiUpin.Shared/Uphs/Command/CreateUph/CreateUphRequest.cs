using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SiUpin.Shared.Uphs.Command.CreateUph
{
    public class CreateUphRequest : IRequest<CreateUphResponse>
    {
        [Required]
        public string ProvinsiID { get; set; }
        public string KotaID { get; set; }
        public string KecamatanID { get; set; }
        public string KelurahanID { get; set; }

        [Required]
        public string ParameterBadanHukumID { get; set; }
        [Required]
        public string ParameterAdministrasiID { get; set; }
        [Required]
        public string ParameterBentukLembagaID { get; set; }
        [Required]
        public string ParameterStatusUphID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Ketua { get; set; }

        [Required]
        public string Handphone { get; set; }
        public string Alamat { get; set; }
        public string TahunBerdiri { get; set; }
    }
}
