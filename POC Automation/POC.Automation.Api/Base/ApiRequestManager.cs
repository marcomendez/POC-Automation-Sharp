using POC.Automation.Helpers;
using RestSharp;
using System.Threading.Tasks;

namespace POC.Automation.Base.Api
{
    public class ApiRequestManager
    {
        private readonly RestClient RestClient;

        private RestRequest Request;

        public ApiRequestManager()
        {
            RestClient = new RestClient(Env.ApiBaseUrl);
        }

        private RestRequest InstanceRequest(string endPoint)
        {
            Request = new RestRequest(endPoint);
            Request.AddHeader(Keys.Authorization, Env.Authorization);
            return Request;
        }

        public IRestResponse Get(string endPoint)
        {
            return RestClient.Get(InstanceRequest(endPoint));
        }

        public async Task<T> GetAsync<T>(string endPoint) where T : new()
        {
            return await RestClient.GetAsync<T>(InstanceRequest(endPoint));
        }

        public IRestResponse Post(string endPoint, object body)
        {
            return RestClient.Post(InstanceRequest(endPoint).AddJsonBody(body));
        }

        public IRestResponse Put(string endPoint, object body)
        {
            return RestClient.Put(InstanceRequest(endPoint).AddJsonBody(body));
        }

        public IRestResponse Delete(string endPoint)
        {
            return RestClient.Delete(InstanceRequest(endPoint));
        }
    }
}
