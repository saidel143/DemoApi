using Newtonsoft.Json.Linq;
using Portales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Portales.Services
{
    public interface IRestApiService
    {
        Task<JContainer> GetClients(DataTableParams parameters);

        Task<ClientModel> GetClient(int id);

        Task<ClientModel> SearchClient(string cedula);

        Task<ClientModel> DeleteClient(int id);

        Task<bool> DeleteRange(int[] collection);

        Task<ClientModel> PostClient(ClientModel client, HttpFileCollectionBase files);

        Task<ClientModel> PutClient(ClientModel client, HttpFileCollectionBase files);

        Task<FileClientModel> GetResumeByClientId(int id);

        Task<FileClientModel> GetZipFile();

        Task<string> HMACAuthentication();

        Task<string> UploadDocument(HttpPostedFileBase file);
    }
}
