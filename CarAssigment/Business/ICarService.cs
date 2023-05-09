using CarAssigment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAssigment.Business
{
    public interface ICarService
    {
        Task<BaseResponse<List<MakeModel>>> GetMakeList();
        Task<BaseResponse<List<VehicleType>>> GetVehicleTypesByMakeId(int Id);
        Task<BaseResponse<List<ModelsforMakeResponse>>> GetModelsforMake(ModelsforMakeRequest request);
    }
}
