using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using Topicos.Utilerias;
using System.Data.SqlClient;

namespace Topicos.Models
{
    public class RepositorioAccountActions : IAccountActions
    {
        public List<AccountActions> obtenerAccountActions()
        {
            //Obtener la informacion de Curso_Tema de la Base
            DataTable dtAccountActions;
            dtAccountActions = BaseHelper.ejecutarConsulta("SPConsultar_TICKET_ADMIN", CommandType.StoredProcedure);

            List<AccountActions> lstCurso_Tema = new List<AccountActions>();

            //convertir el DataTable a una lista de Curso List<Curso>
            foreach (DataRow item in dtAccountActions.Rows)
            {
                AccountActions AccountActions_TemaAux = new AccountActions();
                AccountActions_TemaAux.idTicket = int.Parse(item["idTicket"].ToString());
                AccountActions_TemaAux.descripcion = item["descripcion"].ToString();
                AccountActions_TemaAux.detalles = item["detalles"].ToString();
                AccountActions_TemaAux.solucion = item["solucion"].ToString();
                AccountActions_TemaAux.status = item["status"].ToString();


                lstCurso_Tema.Add(AccountActions_TemaAux);
            }

            return lstCurso_Tema;
        }


        public AccountActions obtenerAccountActions(int idTicket)
        {
            DataTable dtAccountActions;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idTicket", idTicket));

            dtAccountActions = BaseHelper.ejecutarConsulta("SPConsultar_TICKET", CommandType.StoredProcedure, parametros);


            AccountActions datosAccountActions = new AccountActions();

            if (dtAccountActions.Rows.Count > 0) //Se Encontro
            {
                datosAccountActions.idTicket = int.Parse(dtAccountActions.Rows[0]["idTicket"].ToString());
                datosAccountActions.descripcion = dtAccountActions.Rows[0]["descripcion"].ToString();
                datosAccountActions.detalles = dtAccountActions.Rows[0]["detalles"].ToString();
                datosAccountActions.solucion = dtAccountActions.Rows[0]["solucion"].ToString();
                datosAccountActions.status = dtAccountActions.Rows[0]["status"].ToString();

                return datosAccountActions;
            }
            else
            {
                return null;
            }
        }

        public void insertarAccountActions(AccountActions datosAccountActions)
        {
            //Update
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idTicket", datosAccountActions.idTicket));
            parametros.Add(new SqlParameter("@descripcion", datosAccountActions.descripcion));
            parametros.Add(new SqlParameter("@detalles", datosAccountActions.idTicket));
            parametros.Add(new SqlParameter("@solucion", datosAccountActions.descripcion));
            parametros.Add(new SqlParameter("@status", datosAccountActions.descripcion));
            BaseHelper.ejecutarConsulta("SP_CreateTicket", CommandType.StoredProcedure, parametros);

        }

        public void eliminarAccountActions(int idTicket)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idTicket", idTicket));

            BaseHelper.ejecutarSentencia("SP_DeleteTicket", CommandType.StoredProcedure, parametros);

        }

        public void actualizarAccountActions(AccountActions datosAccountActions)
        {
            //Update
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idTicket", datosAccountActions.idTicket));
            parametros.Add(new SqlParameter("@descripcion", datosAccountActions.descripcion));
            parametros.Add(new SqlParameter("@detalles", datosAccountActions.detalles));
            parametros.Add(new SqlParameter("@solucion", datosAccountActions.solucion));
            parametros.Add(new SqlParameter("@status", datosAccountActions.status));
            BaseHelper.ejecutarConsulta("SP_UpdateTicket", CommandType.StoredProcedure, parametros);

        }
    }
}