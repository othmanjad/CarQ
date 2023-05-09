using CarAssigment.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarAssigment.Business
{
    public class CarService:ICarService
    {
        private readonly IConfiguration _configuration;
        public CarService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<BaseResponse<List<MakeModel>>> GetMakeList()
        {
            var result = new BaseResponse<List<MakeModel>>();
            try
            {
                var url = _configuration.GetValue<string>("MakeUrlRequest");
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                result = JsonConvert.DeserializeObject<BaseResponse<List<MakeModel>>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                result.Message = "Internal Server Error";
            }
            return result;
        }

        public async Task<BaseResponse<List<VehicleType>>> GetVehicleTypesByMakeId(int Id)
        {
            var result = new BaseResponse<List<VehicleType>>();
            try
            {
                var url = _configuration.GetValue<string>("VehicleTypeUrlRequest");
                url = string.Format(url, Id);
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                result = JsonConvert.DeserializeObject<BaseResponse<List<VehicleType>>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                result.Message = "Internal Server Error";
            }
            return result;
        }
        public async Task<BaseResponse<List<ModelsforMakeResponse>>> GetModelsforMake(ModelsforMakeRequest request)
        {
            var result = new BaseResponse<List<ModelsforMakeResponse>>();
            try
            {
                var url = _configuration.GetValue<string>("ModelsforMakeUrl");
                url = string.Format(url, request.Id,request.Year);
                var client = new HttpClient();
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(httpRequest);
                response.EnsureSuccessStatusCode();
                result = JsonConvert.DeserializeObject<BaseResponse<List<ModelsforMakeResponse>>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                result.Message = "Internal Server Error";
            }
            return result;
        }
    }
}
