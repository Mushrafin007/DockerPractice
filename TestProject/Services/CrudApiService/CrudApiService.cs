using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Common;
using static TestProject.Model.CrudApiModel;

namespace TestProject.Services.CrudApiService
{
    public class CrudApiService : ICrudApiService
    {
        private readonly ORMS.Dapper.Dapper objDapper = null;
        private readonly CommonFunction _CommonFunctions;

        public CrudApiService(CommonFunction commonFunctions)
        {
            _CommonFunctions = commonFunctions;
            string Sqlcon = commonFunctions.GetConfigKey("connectionstring");
            objDapper=new ORMS.Dapper.Dapper(Sqlcon);
        }
        public  async Task<ApiCommonResponseModel> USP_CREATE_INS(object Parameters)
        {
            string sqlQuery = "USP_CREATE_INS";
            var SqlResp = objDapper.ExecuteQuery<ApiCommonResponseModel>(sqlQuery, Parameters).FirstOrDefault();
            return SqlResp;
        }
    }
}
