using SiUpin.Application.Common.Interfaces;

namespace SiUpin.Infrastructure.Common
{
    public class DapperCommand : IDapperCommand
    {
        public string GetAllByEntityName(string entityName)
        {
            if (entityName == "tb_uph" ||
                entityName == "tb_user" ||
                entityName == "tb_bahan_baku" ||

                entityName == "tb_sarana" ||
                entityName == "tb_gmp" ||
                entityName == "tb_mitra" ||
                entityName == "tb_pasar" ||
                entityName == "tb_produksi" ||
                entityName == "tb_sdm"
                )
            {
                return $"select * from {entityName} limit 50";
            }

            return $"select * from {entityName}";
        }
    }
}