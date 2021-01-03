using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SiUpin.Shared.JenisKomiditis.Commands.UpdateJenisKomoditi
{
    public class UpdateJenisKomoditiRequest : IRequest<UpdateJenisKomoditiResponse>
    {
        public string JenisKomoditiID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
