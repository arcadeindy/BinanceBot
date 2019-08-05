using System.Threading.Tasks;

namespace Model.Requests.interfaces
{
    public interface IRequest
    {
        string webRequest(string requestUrl, string method, string ApiKey);
        Task<string> webRequestAsync(string requestUrl, string method, string ApiKey);
        string getSignature(string SecretKey, string query);
    }
}
