using System.Linq;
using System.Web.Http;
using System;
using Newtonsoft.Json.Linq;
using Portales.Dal.Model;
using System.Collections.Generic;
using Portales.Api.Models;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using System.Net;
using Portales.Servicio;
using System.Security.Cryptography;
using Portales.Api.Extensions;
using System.Threading;
using System.Data.Entity;
using System.Threading.Tasks;
using Portales.Dto;
using System.IO;
using Newtonsoft.Json;
using System.Web.Http.Routing;
using System.Security.Claims;
using Portales.Api.Filter;
using System.Web.Hosting;
using Ionic.Zip;

namespace PortalesWebApi.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        //ILog log;
        //Logger logger;
        IEntityService<Client> service;
        IEntityService<FileClient> clientFiles;

        public ValuesController(IEntityService<Client> service, IEntityService<FileClient> clientFiles)
        {
            this.service = service;
            this.clientFiles = clientFiles;
            //logger = new Logger();
            //log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);            
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetClients(int page = 0, int pageSize = 10)
        {
            //IContentNegotiator negotiator = Configuration.Services.GetContentNegotiator();
            //ContentNegotiationResult result = negotiator.Negotiate(typeof(IQueryable<Client>), Request, Configuration.Formatters);
            //var bestFormatter = result.Formatter;
            //var bestMediaType = result.MediaType.MediaType;

            //var response = new HttpResponseMessage()
            //{
            //    Content = new ObjectContent<IQueryable<Client>>(service.Get(), bestFormatter, bestMediaType)
            //};
            ////return response;
            //return ResponseMessage(response);

            //if (result.Count() == 0)
            //{
            //    log.Fatal("No existen clientes registrados", new ArgumentNullException("No existen registros"));
            //    //logger.LogToDatabase();
            //}

            //PAGINATION
            var listClients = service.Get(true);
            int totalRows = listClients.Count();

            var displayedRecords = await listClients
                .OrderBy(c => c.Id)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var jsonData = AutoMapper.Mapper.Map<List<ClientDto>>(displayedRecords);

            var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);
            var urlHelper = new UrlHelper(Request);
            var prevLink = page > 0 ? urlHelper.Link("DefaultApi", new { page = page - 1, pageSize = pageSize }) : "";
            var nextLink = page < totalPages - 1 ? urlHelper.Link("DefaultApi", new { page = page + 1, pageSize = pageSize }) : "";

            var paginationHeader = new
            {
                iTotalPages = totalPages,
                iTotalRecords = totalRows,
                PrevPageLink = prevLink,
                NextPageLink = nextLink
            };
            HttpContext.Current.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationHeader));

            return Ok(jsonData);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetGroups()
        {
            IList<Client> clients = await service.Get(true).ToListAsync();
            var jsonData = AutoMapper.Mapper.Map<List<ClientDto>>(clients);
            HttpResponseMessage response = Request.CreateResponse();
            response.Content = new PushStreamContent((stream, c, a) => StreamClients(stream, jsonData));
            return response;
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetImage1()
        {
            byte[] bytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Images/Saidel.jpeg"));
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(bytes)
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return ResponseMessage(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetImage2()
        {
            byte[] bytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Images/Saidel.jpeg"));
            return new HttpActionResult(HttpStatusCode.OK, bytes);
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetImage3()
        {
            string filePath = HostingEnvironment.MapPath("~/Images/Saidel.jpeg");
            var file = new FileInfo(filePath);
            string mimeType = MimeMapping.GetMimeMapping(file.Name);

            StreamContent streamContent = new StreamContent(file.OpenRead());
            streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mimeType);

            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = streamContent
            });
        }

        [HttpGet]
        [AllowAnonymous]
        [HMACAuthentication]
        public IHttpActionResult GetHMACAuthentication()
        {
            return Ok("HMAC valid");
        }

        [HttpGet]
        public IHttpActionResult GetGenerico()
        {
            return new CustomActionResult<IQueryable<Client>>(service.Get(true), 1);
        }

        [HttpGet]
        public IHttpActionResult GetJson()
        {
            return Json(service.Get(true), JsonExtensions.ToJsonString(true, true));
        }

        [HttpGet]
        public IHttpActionResult GetModelStateError(int id)
        {
            if (id == 0)
            {
                ModelState.AddModelError("id vacio", "el valor de id no puede ser nulo");
            }
            else
            {
                RandomNumberGenerator _random = new RNGCryptoServiceProvider();
                byte[] data = new byte[16];
                _random.GetBytes(data);
                var valor = HttpServerUtility.UrlTokenEncode(data);
                ModelState.AddModelError("clave", valor);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        //[PostParam]
        public IHttpActionResult PostClientsByName([FromBody] string name)
        {
            var result = service.Get(c => c.Name.Contains(name), true);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            Client client = await service.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            var result = AutoMapper.Mapper.Map<ClientDto>(client);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetResumeByClientId(int id)
        {
            var fileClient = await clientFiles.FindAsync(file => file.ClientId == id && file.FileType == FileType.Resume);
            if (fileClient == null)
            {
                return NotFound();
            }

            var resumeResponse = new HttpResponseMessage()
            {
                Content = new ByteArrayContent(fileClient.Content)
            };
            resumeResponse.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(fileClient.ContentType);
            resumeResponse.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            resumeResponse.Content.Headers.ContentLength = fileClient.Content.LongLength;
            resumeResponse.Content.Headers.ContentDisposition.FileName = fileClient.FileName;

            return ResponseMessage(resumeResponse);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAvatarByClientId(int id)
        {
            var fileClient = await clientFiles.FindAsync(file => file.ClientId == id && file.FileType == FileType.Avatar);
            if (fileClient == null)
            {
                return NotFound();
            }

            var imageResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(fileClient.Content)
            };
            imageResponse.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(fileClient.ContentType);
            imageResponse.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            imageResponse.Content.Headers.ContentLength = fileClient.Content.LongLength;
            imageResponse.Content.Headers.ContentDisposition.FileName = fileClient.FileName;

            return ResponseMessage(imageResponse);
        }

        [HttpPost]
        public async Task<IHttpActionResult> SearchClient(JObject jObject)
        {

            dynamic json = jObject;

            string cedula = json.cedula;
            if (string.IsNullOrEmpty(cedula))
            {
                return BadRequest();
            }

            var client = await service.FindAsync(r => r.DNI.Equals(cedula));
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostClient()
        {
            Client client = new Client();
            var currentRequest = HttpContext.Current.Request;
            try
            {
                var postedImage = currentRequest.Files["image"];
                var postedDoc = currentRequest.Files["document"];

                if (postedImage != null && postedImage.ContentLength > 0)
                {
                    FileClient fileAvatar = new FileClient()
                    {
                        ContentType = postedImage.ContentType,
                        FileName = postedImage.FileName,
                        FileType = FileType.Avatar
                    };
                    using (var binaryReader = new BinaryReader(postedImage.InputStream))
                    {
                        byte[] arrayImage = binaryReader.ReadBytes(postedImage.ContentLength);
                        fileAvatar.Content = arrayImage;
                    }
                    client.FileClient.Add(fileAvatar);
                }
                if (postedDoc != null && postedDoc.ContentLength > 0)
                {
                    FileClient fileDoc = new FileClient()
                    {
                        ContentType = postedDoc.ContentType,
                        FileName = postedDoc.FileName,
                        FileType = FileType.Resume
                    };
                    using (var binaryReader = new BinaryReader(postedDoc.InputStream))
                    {
                        byte[] arrayDoc = binaryReader.ReadBytes(postedDoc.ContentLength);
                        fileDoc.Content = arrayDoc;
                    }
                    client.FileClient.Add(fileDoc);
                }

                client.DNI = currentRequest.Form["DNI"];
                client.Name = currentRequest.Form["Name"];
                client.Last_Name = currentRequest.Form["Last_Name"];
                client.Email = currentRequest.Form["Email"];
                client.Phone = currentRequest.Form["Phone"];
                client.Address = currentRequest.Form["Address"];

                var result = AutoMapper.Mapper.Map<ClientDto>(await service.AddAsync(client));
                return CreatedAtRoute("DefaultApi", new { id = result.Id, action = "GetClient", controller = "Values" }, result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutClient()
        {
            var currentRequest = HttpContext.Current.Request;

            try
            {
                var id = Convert.ToInt32(currentRequest.Form["Id"]);
                var tuple = await ClientExists(id);
                Client client = tuple.Item2;
                if (!tuple.Item1)
                {
                    return NotFound();
                }

                var postedImage = currentRequest.Files["image"];
                var postedDoc = currentRequest.Files["document"];


                if (postedImage != null && postedImage.ContentLength > 0)
                {
                    var fileAvatar = client.FileClient.FirstOrDefault(f => f.FileType == FileType.Avatar);
                    byte[] arrayImage;

                    using (var binaryReader = new BinaryReader(postedImage.InputStream))
                    {
                        arrayImage = binaryReader.ReadBytes(postedImage.ContentLength);
                    }

                    if (fileAvatar != null)
                    {
                        fileAvatar.ContentType = postedImage.ContentType;
                        fileAvatar.FileName = postedImage.FileName;
                        fileAvatar.FileType = FileType.Avatar;
                        fileAvatar.Content = arrayImage;

                        await clientFiles.UpdateAsync(fileAvatar);
                    }
                    else
                    {
                        await clientFiles.AddAsync(new FileClient()
                        {
                            ClientId = client.Id,
                            Content = arrayImage,
                            ContentType = postedImage.ContentType,
                            FileName = postedImage.FileName,
                            FileType = FileType.Avatar
                        });
                    }
                }
                if (postedDoc != null && postedDoc.ContentLength > 0)
                {
                    var fileDoc = client.FileClient.FirstOrDefault(f => f.FileType == FileType.Resume);
                    byte[] arrayDoc;

                    using (var binaryReader = new BinaryReader(postedDoc.InputStream))
                    {
                        arrayDoc = binaryReader.ReadBytes(postedDoc.ContentLength);
                    }

                    if (fileDoc != null)
                    {
                        fileDoc.ContentType = postedDoc.ContentType;
                        fileDoc.FileName = postedDoc.FileName;
                        fileDoc.FileType = FileType.Resume;
                        fileDoc.Content = arrayDoc;

                        await clientFiles.UpdateAsync(fileDoc);
                    }
                    else
                    {
                        await clientFiles.AddAsync(new FileClient()
                        {
                            ClientId = client.Id,
                            Content = arrayDoc,
                            ContentType = postedDoc.ContentType,
                            FileName = postedDoc.FileName,
                            FileType = FileType.Resume
                        });
                    }
                }

                client.DNI = currentRequest.Form["DNI"];
                client.Name = currentRequest.Form["Name"];
                client.Last_Name = currentRequest.Form["Last_Name"];
                client.Email = currentRequest.Form["Email"];
                client.Phone = currentRequest.Form["Phone"];
                client.Address = currentRequest.Form["Address"];

                var result = AutoMapper.Mapper.Map<ClientDto>(await service.UpdateAsync(client));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult DeleteRange(JArray jArray)
        {
            int[] array = jArray.ToObject<int[]>();
            var clientes = service.Get(row => (array.Any(t => t == row.Id)), false).AsEnumerable();
            service.Remove(clientes);
            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteClient(int id)
        {
            var tuple = await ClientExists(id);
            Client client = tuple.Item2;
            if (!tuple.Item1)
            {
                return NotFound();
            }

            clientFiles.Remove(client.FileClient);
            var result = AutoMapper.Mapper.Map<ClientDto>(await service.RemoveAsync(client));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> UploadDocument()
        {
            var httpPostedFile = HttpContext.Current.Request.Files[0];
            var path = HttpContext.Current.Server.MapPath("~/App_Data");
            string fileName = httpPostedFile.FileName;
            var pathString = Path.Combine(path, fileName);
            if (!File.Exists(pathString))
            {
                using (FileStream fs = File.Create(pathString))
                {
                    await httpPostedFile.InputStream.CopyToAsync(fs);
                }
            }
            return Ok(new { succcess = true });
        }

        private async Task<Tuple<bool, Client>> ClientExists(int id)
        {
            var client = await service.FindAsync(id);
            return new Tuple<bool, Client>(client != null, client);
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetVideo()
        {
            var video = new VideoStream();
            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(video.WriteToStream, new MediaTypeHeaderValue("video/webm"));
            return ResponseMessage(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetZipFile()
        {
            var client = new HttpClient();
            var filenamesAndUrls = new Dictionary<string, string>
            {
                { "README.md", "https://raw.githubusercontent.com/StephenClearyExamples/AsyncDynamicZip/master/README.md" },
                { ".gitignore", "https://raw.githubusercontent.com/StephenClearyExamples/AsyncDynamicZip/master/.gitignore" },
            };

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new PushStreamContent(async (outputStream, httpContext, transportContext) =>
                {
                    using (var zipStream = new ZipOutputStream(outputStream))
                    {
                        foreach (var kvp in filenamesAndUrls)
                        {
                            zipStream.PutNextEntry(kvp.Key);
                            using (var stream = await client.GetStreamAsync(kvp.Value))
                            {
                                await stream.CopyToAsync(zipStream);
                            }
                        }
                    }
                }),
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "archivo.zip" };
            return ResponseMessage(result);
        }

        private async Task StreamClients(Stream stream, IEnumerable<ClientDto> clients)
        {
            using (StreamWriter sw = new StreamWriter(stream))
            {
                foreach (ClientDto dto in clients)
                {
                    await sw.WriteLineAsync(JsonConvert.SerializeObject(dto));
                }
            }

            stream.Close();
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }
    }
}
