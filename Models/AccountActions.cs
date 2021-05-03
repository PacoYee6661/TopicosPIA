using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Topicos.Models
{
    public class AccountActions
    {
        public int idTicket { get; set; }
        //Puede que se necesiten cambiar a char
        public string descripcion { get; set; }
        public string detalles { get; set; }
        public string status { get; set; }
    }
}