using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Topicos.Models;
namespace Topicos.Controllers
{
    public class AccountActionsController : Controller
    {
        RepositorioAccountActions repoAccountActions = new RepositorioAccountActions();
        // GET: AccountActions
        public ActionResult Index()
        {
            return View(repoAccountActions.obtenerAccountActions());
        }

        //Borrar un Curso_Tema
        public ActionResult AccountActionsDelete(int id)
        {
            //Se obtienen datos de la tabla AccountActions para mostrarlo al usuario antes de borrarlo
            return View(repoAccountActions.obtenerAccountActions(id));
        }

        [HttpPost]
        public ActionResult eliminarAccountActions (int id, FormCollection datos)
        {                     
                repoAccountActions.eliminarAccountActions(id);
            return RedirectToAction("Index");
        }

        public ActionResult Curso_TemaDetails(int id)
        {
            return View(repoAccountActions.obtenerAccountActions(id));
        }

        public ActionResult AccountActionsEdit(int id)
        {
            return View(repoAccountActions.obtenerAccountActions(id));
        }


        [HttpPost]
        public ActionResult AccountActionsEdit(int id, AccountActions datosAccountActions)
        {
            datosAccountActions.idTicket = id;
            repoAccountActions.actualizarAccountActions(datosAccountActions);

            return RedirectToAction("Index");
        }

        public ActionResult AccountActionsCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AccountActionsCreate(AccountActions datos)
        {
            repoAccountActions.insertarAccountActions(datos);
            return RedirectToAction("Index");
        }
    }
}