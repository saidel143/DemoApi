using Newtonsoft.Json.Linq;
using Portales.Models;
using Portales.Web.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Unity.Attributes;

namespace Portales.Services
{
    public class RestApiService : IRestApiService
    {
        private static HttpClient httpClient;
        string defaultResource;
        string serverAddress;

        public RestApiService([Dependency("DefaultConstructor")] string serverAddress)
        {
            defaultResource = "api/values";
            this.serverAddress = serverAddress;
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(serverAddress)
            };
            var token = Authorization();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("API_KEY", "X-some-key");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("username:password")));
        }

        private string Authorization()
        {
            string token = "";
            var nameValueCollection = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", "saidel@gmail.com" },
                { "password", "Alejandra1984" }
            };

            try
            {
                var response = httpClient.PostAsync("oauth/token", new FormUrlEncodedContent(nameValueCollection)).Result;
                if (response.IsSuccessStatusCode)
                {
                    JObject jObject = response.Content.ReadAsAsync<JObject>().Result;
                    token = (string)jObject["access_token"];
                }
                return token;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public async Task<JContainer> GetClients(DataTableParams parameters)
        {
            JObject result = new JObject();
            int pageSize = parameters.iDisplayLength;
            int page = (int)Math.Ceiling((double)parameters.iDisplayStart / pageSize);
            var response = await httpClient.GetAsync($"{defaultResource}/GetClients?page={page}&pageSize={pageSize}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var header = response.Headers.GetValues("X-Pagination").FirstOrDefault();
                var iTotalRecords = (int)JObject.Parse(header)["iTotalRecords"];

                result.Add("aaData", JArray.Parse(json));
                result.Add("iTotalRecords", iTotalRecords);
            }

            return result;
        }

        public async Task<ClientModel> GetClient(int id)
        {
            ClientModel model = new ClientModel();
            var response = await httpClient.GetAsync($"{defaultResource}/GetClient/{id}");
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<ClientModel>();

                var imageResponse = await httpClient.GetAsync($"{defaultResource}/GetAvatarByClientId/{id}");
                if (imageResponse.IsSuccessStatusCode)
                {
                    var mediaType = imageResponse.Content.Headers.ContentType.MediaType;
                    var bytes = Convert.ToBase64String(await imageResponse.Content.ReadAsByteArrayAsync());
                    model.AvatarBase64 = $"data:{mediaType};base64,{bytes}";
                }
            }
            return model;
        }

        public async Task<ClientModel> DeleteClient(int id)
        {
            ClientModel model = new ClientModel();
            var response = await httpClient.DeleteAsync($"{defaultResource}/DeleteClient/{id}");
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<ClientModel>();
            }
            return model;
        }

        public async Task<ClientModel> PostClient(ClientModel client, HttpFileCollectionBase files)
        {
            ClientModel model = new ClientModel();
            MultipartFormDataContent formData = new MultipartFormDataContent
            {
                { new StringContent(client.DNI), "DNI" },
                { new StringContent(client.Email), "Email" },
                { new StringContent(client.Name), "Name" },
                { new StringContent(client.Last_Name), "Last_Name" },
                { new StringContent(client.Address), "Address" },
                { new StringContent(client.Phone), "Phone" }
            };

            if (files["image"] != null)
            {
                var httpContentImage = new StreamContent(files["image"].InputStream);
                httpContentImage.Headers.ContentType = MediaTypeHeaderValue.Parse(files["image"].ContentType);
                formData.Add(httpContentImage, "image", files["image"].FileName);
            }

            if (files["document"] != null)
            {
                var httpContentDoc = new StreamContent(files["document"].InputStream);
                httpContentDoc.Headers.ContentType = MediaTypeHeaderValue.Parse(files["document"].ContentType);
                formData.Add(httpContentDoc, "document", files["document"].FileName);
            }

            var response = await httpClient.PostAsync($"{defaultResource}/PostClient", formData);
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<ClientModel>();
            }
            return model;
        }

        public async Task<ClientModel> PutClient(ClientModel client, HttpFileCollectionBase files)
        {
            ClientModel model = new ClientModel();
            MultipartFormDataContent formData = new MultipartFormDataContent
            {
                { new StringContent(client.Id.ToString()), "Id" },
                { new StringContent(client.DNI), "DNI" },
                { new StringContent(client.Email), "Email" },
                { new StringContent(client.Name), "Name" },
                { new StringContent(client.Last_Name), "Last_Name" },
                { new StringContent(client.Address), "Address" },
                { new StringContent(client.Phone), "Phone" }
            };

            if (files["image"] != null)
            {
                var httpContentImage = new StreamContent(files["image"].InputStream);
                httpContentImage.Headers.ContentType = MediaTypeHeaderValue.Parse(files["image"].ContentType);
                formData.Add(httpContentImage, "image", files["image"].FileName);
            }

            if (files["document"] != null)
            {
                var httpContentDoc = new StreamContent(files["document"].InputStream);
                httpContentDoc.Headers.ContentType = MediaTypeHeaderValue.Parse(files["document"].ContentType);
                formData.Add(httpContentDoc, "document", files["document"].FileName);
            }

            var response = await httpClient.PutAsync($"{defaultResource}/PutClient", formData);

            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<ClientModel>();
            }
            return model;
        }

        public async Task<ClientModel> SearchClient(string cedula)
        {
            ClientModel model = new ClientModel();
            JObject jObject = new JObject(new { cedula = cedula });
            var response = await httpClient.PostAsJsonAsync($"{defaultResource}/SearchClient", jObject);
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<ClientModel>();
            }
            return model;
        }

        public async Task<bool> DeleteRange(int[] collection)
        {
            JArray jArray = new JArray(collection);
            var response = await httpClient.PostAsJsonAsync($"{defaultResource}/DeleteRange", jArray);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<FileClientModel> GetResumeByClientId(int id)
        {
            var model = new FileClientModel();
            var response = await httpClient.GetAsync($"{defaultResource}/GetResumeByClientId/{id}");
            if (response.IsSuccessStatusCode)
            {
                model.Content = await response.Content.ReadAsByteArrayAsync();
                model.ContentType = response.Content.Headers.ContentType.MediaType;
                model.FileName = response.Content.Headers.ContentDisposition.FileName.Trim(' ', '\\', '"');
            }
            return model;
        }

        public async Task<string> HMACAuthentication()
        {
            HMACDelegatingHandler hmacHandler = new HMACDelegatingHandler();
            httpClient = new HttpClient(hmacHandler)
            {
                BaseAddress = new Uri(serverAddress)
            };

            HttpResponseMessage response = await httpClient.GetAsync($"{defaultResource}/GetHMACAuthentication");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                return $"Body: {responseString}, HTTP Status: {response.StatusCode}, Reason {response.ReasonPhrase}.";
            }
            else
            {
                return $"Failed to call the API. HTTP Status: {response.StatusCode}, Reason {response.ReasonPhrase}";
            }

        }

        public async Task<string> UploadDocument(HttpPostedFileBase file)
        {
            MultipartFormDataContent formData = new MultipartFormDataContent();
            var httpContentImage = new StreamContent(file.InputStream);
            httpContentImage.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);
            formData.Add(httpContentImage, "image", file.FileName);
            var response = await httpClient.PostAsync($"{defaultResource}/UploadDocument", formData);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<FileClientModel> GetZipFile()
        {
            var model = new FileClientModel();
            var response = await httpClient.GetAsync($"{defaultResource}/GetZipFile");
            if (response.IsSuccessStatusCode)
            {
                model.Content = await response.Content.ReadAsByteArrayAsync();
                model.ContentType = response.Content.Headers.ContentType.MediaType;
                model.FileName = response.Content.Headers.ContentDisposition.FileName.Trim(' ', '\\', '"');
            }
            return model;
        }
    }
}