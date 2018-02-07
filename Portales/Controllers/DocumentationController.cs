using Portales.Models;
using Sistran.Core.Framework.UIF2.Controls.UifSelect;
using Sistran.Core.Framework.UIF2.Controls.UifTable;
using Sistran.Core.Framework.UIF2.Controls.UifTreeView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistran.Core.Framework.UIF.Web.Controllers
{
    public class SampleMultipleDTO
    {
        public int Id { get; set; }
        public string Columna1 { get; set; }
        public string Columna2 { get; set; }
        public string Columna3 { get; set; }
        public string Columna4 { get; set; }
        public string Columna5 { get; set; }
        public string Columna6 { get; set; }
        public string Columna7 { get; set; }
        public string Columna8 { get; set; }
        public string Columna9 { get; set; }
        public string Columna10 { get; set; }
        public string Columna11 { get; set; }
        public string Columna12 { get; set; }
        public string Columna13 { get; set; }
        public string Columna14 { get; set; }

    }


    public class SampleDTO
    {
        public SampleDTO()
        {
            this.Fecha = DateTime.Now;
            this.Monto = 44000.55;
        }

        public int Id { get; set; }
        [Required]
        public string Empresa { get; set; }

        [Required]
        public string Ciudad { get; set; }
        public string Pais { get; set; }

        public DateTime Fecha { get; set; }

        public Double Monto { get; set; }

        public bool Habilitado { get; set; }
    };

    public class SampleDTO2
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
    };


    public class ListViewDTO
    {
        public int Id { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string Pais { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public double Monto { get; set; }

        public string NombreEmpresa { get; set; }
        public int EmpresaId { get; set; }
    };



    //[Authorize]

    public class DocumentationController : Controller
    {
        //
        // GET: /Documentation/

        public ActionResult Inline()
        {
            return View();
        }

        public ActionResult Wizard()
        {
            return View();
        }

        public ActionResult Quotate()
        {
            return View();
        }


        public ActionResult Layout()
        {
            return View();
        }

        public ActionResult Select()
        {
            return View();
        }

        public ActionResult TableABM()
        {
            return View();
        }

        public ActionResult LocalABM()
        {
            return View();
        }

        public ActionResult EnabledDisabledPanel()
        {
            return View();
        }

        public ActionResult EnabledDisabledTab()
        {
            return View();
        }

        public ActionResult NavigateDataTable()
        {
            return View();
        }

        public ActionResult InputSearch()
        {
            return View();
        }

        public ActionResult Summary()
        {
            return View();
        }

        public ActionResult RightBar()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(true)]
        public ActionResult LocalABM(SampleDTO2 personalData, List<SampleDTO> jobs)
        {
            try
            {
                //Save data in db.


                return new UifJsonResult(true, null);
            }
            catch
            {
                return new UifJsonResult(false, "Ups... se produjo un error");
            }

        }


        public ActionResult AddLocal()
        {
            return View();
        }


        public ActionResult SelectSource()
        {
            List<SampleDTO> data = new List<SampleDTO>();

            for (int i = 0; i < 4; i++)
            {
                SampleDTO dato = new SampleDTO();
                dato.Id = i;
                dato.Empresa = "Sistran";
                dato.Ciudad = "Buenos Aires";
                dato.Pais = "Argentina";
                data.Add(dato);
            }


            return new UifSelectResult(data);

        }

        public ActionResult SelectSourceWithParameter(int id)
        {
            List<SampleDTO> data = new List<SampleDTO>();

            for (int i = 1; i < 5; i++)
            {
                SampleDTO dato = new SampleDTO();
                dato.Id = i;
                dato.Empresa = "Toyota";
                dato.Ciudad = "Nueva York";
                dato.Pais = "Estados Unidos";
                data.Add(dato);
            }

            System.Threading.Thread.Sleep(1000);


            return new UifSelectResult(data);
        }


        public ActionResult MultiplesColumnas()
        {
            return View();
        }

        public ActionResult AccountingPlan()
        {
            return View();
        }

        public JsonResult TreeViewData()
        {
            List<TreeViewItem> list = new List<TreeViewItem>();

            TreeViewItem item1 = new TreeViewItem("1", "Nodo 1", "false");
            TreeViewItem item2 = new TreeViewItem("2", "Nodo 2", "false");
            TreeViewItem item3 = new TreeViewItem("3", "Nodo 3", "fa fa-home");

            item2.Children.Add(new TreeViewItem("4", "Hijo 1", "fa fa-home"));

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);

            return new UifTreeViewResult(list);

        }




        public ActionResult Tabla1Source()
        {
            List<SampleMultipleDTO> data = new List<SampleMultipleDTO>();

            for (int i = 0; i < 1000; i++)
            {
                SampleMultipleDTO dato = new SampleMultipleDTO();
                dato.Id = i;
                dato.Columna1 = "Casa Matriz Panama";
                dato.Columna2 = "Automovil";
                dato.Columna3 = "75";
                dato.Columna4 = "2012";
                dato.Columna5 = "116";
                dato.Columna6 = "Autonomo";
                dato.Columna7 = "Ricardo Perez Perez";
                dato.Columna8 = "209999";
                dato.Columna9 = "Juan Pablo Guardia";
                dato.Columna10 = "Descripción de Prueba de caso";
                dato.Columna11 = "El texto puede ser largo";
                dato.Columna12 = "true";
                dato.Columna13 = "Descripción de Prueba de caso";
                dato.Columna14 = "El texto puede ser largo";
                data.Add(dato);
            }

            return new UifTableResult(data);
        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(true)]
        public ActionResult Tables()
        {
            ViewBag.Param1 = "valor1";
            ViewBag.Param2 = "valor2";
            return View();
        }

        public ActionResult TablesServerSide()
        {
            return View();
        }

        public ActionResult TablesMasterDetail()
        {
            return View();
        }

        public ActionResult SelectWithModal()
        {
            return View();
        }

        public ActionResult GetRecordsMaster()
        {
            List<SampleDTO> data = new List<SampleDTO>();

            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });


            return new UifTableResult(data);
        }

        public ActionResult GetRecordDetail(string Id)
        {
            List<SampleDTO2> data = new List<SampleDTO2>();

            data.Add(new SampleDTO2() { Id = 1, Nombre = "Leandro", Apellido = "Zapata" });
            data.Add(new SampleDTO2() { Id = 2, Nombre = "Martin", Apellido = "Garcia" });
            data.Add(new SampleDTO2() { Id = 3, Nombre = "Ramiro", Apellido = "Leal" });

            return new UifTableResult(data);
        }


        public ActionResult AdvancedSearch()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult DatePicker()
        {
            return View();
        }


        public ActionResult GetRecords()
        {

            List<SampleDTO> data = new List<SampleDTO>();

            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });

            return new UifTableResult(data);
        }

        public IList<SampleDTO> PaggingSource
        {
            get
            {
                //En este ejemplo se usa sessión para emular el comportamiento de una lista en DAF. No usar sessión en ningún proyecto, está totalmente prohibido. Salvo aquí :=)
                if (Session["PaggingSource"] != null)
                    return Session["PaggingSource"] as List<SampleDTO>;
                else
                {
                    List<SampleDTO> data = new List<SampleDTO>();

                    data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
                    data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Goddwi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gorrrwi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Goeeewi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Godddwi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gdddddowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "rrererer", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "tetetertert", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "363636363", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "tetertetet", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });
                    data.Add(new SampleDTO() { Id = 3, Empresa = "utyutyutyutyu", Ciudad = "Pancevo", Pais = "Serbia" });

                    return data;
                }
            }

        }

        public ActionResult GetRecordsWithPagging(UifTableParam param)
        {

            var data = PaggingSource;
            var result = data.Select(row => row);

            //En esta linea se debería pedir a DAF el total de registros de la query efectuada para llenar el DataTable.
            int totalRows = result.Count();
            if (!string.IsNullOrEmpty(param.Filter))
            {
                result = data.Where(s => s.Empresa.Contains(param.Filter));

            }
            int totalFiltered = result.Count();

            //En esta linea se debería invocar al paginado de Daf para traer en result sólo los datos que se quieren mostrar por página.
            result = result.Skip(param.Start).Take(param.Length);
            return new UifTableResult(result.ToList(), param.Raw, totalRows, totalFiltered);
        }

        public ActionResult GetRecords2()
        {

            List<SampleDTO> data = new List<SampleDTO>();

            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA", Habilitado = true });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA", Habilitado = false });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia", Habilitado = true });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia", Habilitado = false });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia", Habilitado = true });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia", Habilitado = true });
            return new UifTableResult(data);

        }


        public ActionResult GetRecords3()
        {

            List<SampleDTO> data = new List<SampleDTO>();

            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA", Habilitado = true });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA", Habilitado = false });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia", Habilitado = true });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia", Habilitado = false });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia", Habilitado = true });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia", Habilitado = true });

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetRecordsWithParameters(string param1, string param2)
        {
            List<SampleDTO> data = new List<SampleDTO>();

            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });


            return new UifTableResult(data);
        }

        public ActionResult GetRecordsforAdvancedSearch(string searchText)
        {
            List<string[]> data = new List<string[]>() {
                    new string[] {"1", "Microsoft", "Redmond", "USA"},
                    new string[] {"2", "Google", "Mountain View", "USA"},
                    new string[] {"3", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"4", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"5", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"6", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"7", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"8", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"9", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"10", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"11", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"12", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"13", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"14", "Gowi", "Pancevo", "Serbia"},
                    new string[] {"15", "Gowi", "Pancevo", "Serbia"}
                    };

            return new UifTableResult(data);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdvancedSearch(int personaId)
        {
            return View();
        }

        public ActionResult Add()
        {
            return PartialView("Add");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(SampleDTO sample)
        {
            try
            {
                //Save data in db.


                return new UifJsonResult(true, null);
            }
            catch
            {
                return new UifJsonResult(false, "Ups... se produjo un error");
            }

        }

        public ActionResult AutoComplete()
        {
            return View();
        }

        public JsonResult AutoCompleteSource(string query)
        {
            List<SampleDTO> data = new List<SampleDTO>();

            data.Add(new SampleDTO() { Id = 1, Empresa = "Microsoft", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Miranda", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Mirndia", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Mirndisssa", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Mirnsssdssssssia", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Mirnd45545454ia", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Mirndia", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Mirndssssia", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 1, Empresa = "Gorr", Ciudad = "Redmond", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 2, Empresa = "Google", Ciudad = "Mountain View", Pais = "USA" });
            data.Add(new SampleDTO() { Id = 3, Empresa = "Gowi", Ciudad = "Pancevo", Pais = "Serbia" });

            var dataFiltered = data.Where(d => d.Empresa.Contains(query));
            if (!string.IsNullOrEmpty(query))
                return Json(dataFiltered, JsonRequestBehavior.AllowGet);
            else
                return Json(data, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Alert()
        {
            return View();
        }

        public ActionResult Mask()
        {
            return View();
        }

        public ActionResult TreeView()
        {
            return View();
        }

        public ActionResult Multiselect()
        {
            return View();
        }

        public ActionResult MultiselectSource()
        {
            List<SampleDTO> data = new List<SampleDTO>();

            for (int i = 1; i < 10; i++)
            {
                SampleDTO dato = new SampleDTO();
                dato.Id = i;
                dato.Empresa = "Sistran " + Guid.NewGuid().ToString().Substring(0, 4);
                dato.Ciudad = "Buenos Aires";
                dato.Pais = "Argentina";
                data.Add(dato);
            }


            return new UifSelectResult(data);

        }

        public ActionResult Notify()
        {
            return View();
        }

        public ActionResult InputFile()
        {
            return View();
        }

        public ActionResult Dialog()
        {
            return View();
        }

        public ActionResult Editor()
        {
            return View();
        }


        public ActionResult ListView()
        {
            return View();
        }

        public ActionResult ListViewLocal()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ListView(ListViewDTO listViewDTO)
        {
            try
            {
                //Save data in db.


                return new UifJsonResult(true, null);
            }
            catch
            {
                return new UifJsonResult(false, "Ups... se produjo un error");
            }

        }

        [HttpPost]
        public ActionResult ListViewEdit(ListViewDTO listViewDTO)
        {
            try
            {
                //Save data in db and return new object.
                listViewDTO.Id = 1;
                listViewDTO.NombreEmpresa = "Sistran";

                return new UifJsonResult(true, listViewDTO);
            }
            catch
            {
                return new UifJsonResult(false, "Ups... se produjo un error");
            }

        }

        [HttpPost]
        public ActionResult ListViewDelete(ListViewDTO listViewDTO)
        {
            try
            {
                //Delete data in db and return true if all is fine.

                return new UifJsonResult(true, "OK");
            }
            catch
            {
                return new UifJsonResult(false, "Ups... se produjo un error");
            }

        }



        public ActionResult GetListViewSource()
        {

            List<ListViewDTO> data = new List<ListViewDTO>();

            data.Add(new ListViewDTO() { Id = 1, Nombre = "Leandro", Ciudad = "Redmond", Pais = "USA", NombreEmpresa = "Sistran", EmpresaId = 1 });
            data.Add(new ListViewDTO() { Id = 2, Nombre = "Guillermo", Ciudad = "Mountain View", Pais = "USA", NombreEmpresa = "Sistran", EmpresaId = 1 });
            data.Add(new ListViewDTO() { Id = 3, Nombre = "Virgina", Ciudad = "Pancevo", Pais = "Serbia", NombreEmpresa = "Sistran", EmpresaId = 1 });
            data.Add(new ListViewDTO() { Id = 3, Nombre = "Franco", Ciudad = "Pancevo", Pais = "Serbia", NombreEmpresa = "Sistran", EmpresaId = 1 });
            data.Add(new ListViewDTO() { Id = 3, Nombre = "Vanina", Ciudad = "Pancevo", Pais = "Serbia", NombreEmpresa = "Sistran", EmpresaId = 1 });
            data.Add(new ListViewDTO() { Id = 3, Nombre = "Nelson", Ciudad = "Pancevo", Pais = "Serbia", NombreEmpresa = "Sistran", EmpresaId = 1 });
            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
}
