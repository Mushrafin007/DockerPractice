using static TestProject.Model.CrudApiModel;

namespace TestProject.Services.CrudApiService
{
    public interface ICrudApiService
    {
        Task<ApiCommonResponseModel> USP_CREATE_INS(object Parameters);
    }
}
