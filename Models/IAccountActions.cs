using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Topicos.Models
{
    public interface IAccountActions
    {
        List<AccountActions> obtenerAccountActions();
        AccountActions obtenerAccountActions(int IdCT);
        void insertarAccountActions(AccountActions datosAccountActions);
        void eliminarAccountActions(int idCT);
        void actualizarAccountActions(AccountActions datosAccountActions);
    }
}