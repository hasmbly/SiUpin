namespace SiUpin.Domain.Entities
{
    public class UphParameter
    {
        public string UphID { get; set; }

        public string ParameterJawabanID { get; set; }

        public string Description { get; set; }

        public Uph Uph { get; set; }
        public ParameterJawaban ParameterJawaban { get; set; }
    }
}