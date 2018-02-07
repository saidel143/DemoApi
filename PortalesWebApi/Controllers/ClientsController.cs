using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Portales.Dal.Model;
using Portales.Servicio;
using System.Web.Http.OData.Query;
using Microsoft.Data.OData;

namespace Portales.Api.Controllers
{
    /*
    Puede que la clase WebApiConfig requiera cambios adicionales para agregar una ruta para este controlador. Combine estas instrucciones en el método Register de la clase WebApiConfig según corresponda. Tenga en cuenta que las direcciones URL de OData distinguen mayúsculas de minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Portales.DAL.Model;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Client>("Clients");
    builder.EntitySet<Bill>("Bill"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    [Authorize]
    public class ClientsController : EntitySetController<Client, int>
    {
        IEntityService<Client> service;
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        public ClientsController(IEntityService<Client> service)
        {
            this.service = service;
        }

        //GET: odata/Clients
        //[EnableQuery]
        //public IQueryable<Client> GetClients()
        //{
        //    return service.Get();
        //}

        public IHttpActionResult GetClients(ODataQueryOptions<Client> queryOptions)
        {
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(service.Get(true));
        }

        // GET: odata/Clients(5)
        [EnableQuery]
        public SingleResult<Client> GetClient([FromODataUri] int key)
        {
            return SingleResult.Create(service.Get(c => c.Id == key, true));
        }

        [HttpPost]
        public IQueryable<Client> ObtenerClientesPorNombre(ODataActionParameters parameters)
        {
            string name = parameters["name"].ToString();
            var result = service.Get(c => c.Name.Contains(name), true);
            return result;
        }

        // PUT: odata/Clients(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Client> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Client client = await  service.FindAsync(key);
            if (client == null)
            {
                return NotFound();
            }

            patch.Put(client);

            try
            {
                await service.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ClientExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(client);
        }

        // POST: odata/Clients
        public async Task<IHttpActionResult> Post(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await service.AddAsync(client);
            return Created(client);
        }

        // PATCH: odata/Clients(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Client> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Client client = await service.FindAsync(key);
            if (client == null)
            {
                return NotFound();
            }

            patch.Patch(client);

            try
            {
                await service.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ClientExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(client);
        }

        // DELETE: odata/Clients(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Client client = await service.FindAsync(key);
            if (client == null)
            {
                return NotFound();
            }

            await service.RemoveAsync(client);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Clients(5)/Bill
        [EnableQuery]
        public IQueryable<Bill> GetBill([FromODataUri] int key)
        {
            return service.Get(m => m.Id == key, true).SelectMany(m => m.Bill);
        }

        private async Task<bool> ClientExists(int key)
        {
            var client = await service.FindAsync(key);
            return client.Id > 0;
        }
    }
}
