using System;
using System.Linq;
using System.Web.Mvc;
using Portales.Models;
using Portales.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Unity.Attributes;

namespace Portales.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestApiService restApiService;

        public HomeController([Dependency("DefaultConstructor")] IRestApiService restApiService)
        {
            this.restApiService = restApiService;
        }

        public async Task<ActionResult> HMAC()
        {
            ViewBag.Response = await restApiService.HMACAuthentication();
            return View();
        }

        /// <summary>
        /// Renderiza la pagina principal
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Renderiza la vista ClientsApi
        /// </summary>
        /// <returns></returns>
        public ActionResult ClientsApi()
        {
            return View();
        }

        /// <summary>
        /// Obtiene los todos los clientes y los retorna en formato json
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetClients(DataTableParams parameters)
        {
            var jObject = await restApiService.GetClients(parameters);

            //int totalRows = list.Count();

            //var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            //Func<Client, string> orderingFunction = (c => sortColumnIndex == 2 ? c.Name : String.Empty);
            //var sortDirection = Request["sSortDir_0"]; // asc or desc

            //if (sortDirection == "asc")
            //    list = list.OrderBy(orderingFunction).ToList();
            //else
            //    list = list.OrderByDescending(orderingFunction).ToList();

            //if (!String.IsNullOrEmpty(parameters.sSearch))
            //{
            //    list = list.Where(c => c.Email.ToUpper().Contains(parameters.sSearch.ToUpper())).ToList();
            //}

            //int totalFiltered = list.Count();
            //var displayedRecords = list.Skip(parameters.iDisplayStart).Take(parameters.iDisplayLength).ToList();

            //var jsonData = (from items in list
            //                select new Client()
            //                {
            //                    Id = items.Id,
            //                    Name = items.Name,
            //                    Last_Name = items.Last_Name,
            //                    DNI = items.DNI,
            //                    Phone = items.Phone,
            //                    Address = items.Address,
            //                    Email = items.Email

            //                }).ToList();

            var listClients = jObject?["aaData"]?.ToObject<List<ClientModel>>();
            int? totalRows = jObject?["iTotalRecords"]?.ToObject<int>();

            var jsonData = new
            {
                sEcho = parameters.sEcho,
                iTotalRecords = totalRows,
                iTotalDisplayRecords = totalRows,
                aaData = listClients
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Modal que muestra los datos del cliente seleccionado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<ActionResult> ClientApiModal(int? id)
        {
            var model = new ClientModel();

            if (id.HasValue)
            {
                try
                {
                    model = await restApiService.GetClient(id.Value);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryTokenPost]
        public async Task<JsonResult> SaveClient(ClientModel model)
        {
            var result = new ClientModel();

            if (model.Id == 0)
            {
                result = await restApiService.PostClient(model, Request.Files);
            }
            else
            {
                result = await restApiService.PutClient(model, Request.Files);
            }
            
            return Json(result.Id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteClient(int id)
        {
            var client = await restApiService.DeleteClient(id);
            var result = client.Id != 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteRange(int[] collection)
        {
            try
            {
                var result = restApiService.DeleteRange(collection).Result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<FileResult> GetDocument(int id)
        {
            var document = await restApiService.GetResumeByClientId(id);
            return File(document.Content, document.ContentType, document.FileName);
        }

        [HttpGet]
        public async Task<FileResult> GetZipFile()
        {
            var document = await restApiService.GetZipFile();
            return File(document.Content, document.ContentType, document.FileName);
        }

        [HttpPost]
        public async Task<JsonResult> UploadDocument()
        {
            var result = await restApiService.UploadDocument(Request.Files[0]);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}