using MediatR;

namespace SiUpin.Shared.ParameterJawabans.Queries.GetParameterJawabansByIndikatorName
{
    public class GetParameterJawabansByIndikatorNameRequest : IRequest<GetParameterJawabansByIndikatorNameResponse>
    {
        public string ParameterIndikatorName { get; set; }
    }
}
