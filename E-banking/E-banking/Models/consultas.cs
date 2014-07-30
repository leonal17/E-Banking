﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace E_banking.Models
{
    public class consultas
    {
        protected DataSet _reportData;
        protected DataSet _reportFilterTable;
        protected DataSet _reportArguments;
        protected DataTable _reportTable;

        public virtual bool Autenticar(string usuario, string contraseña)
        {
             bool autenticado = false;
             /* string query = string.Format("SELECT * FROM [User] WHERE usuario = '{0}' AND contraseña = '{1}'", usuario, contraseña);

             SqlCommand cmd = new SqlCommand(query, conn);
             conn.Open();
             SqlDataReader sdr = cmd.ExecuteReader();
             authenticato = sdr.HasRows;  */

            var da = new SqlDataAccess("UseConfig");
            da.SetProc("LoginValidation");
            da.AddParameter("@User", usuario);
            da.AddParameter("@password", contraseña);
            _reportTable = da.ExecuteDataSet().Tables[0];

           Boolean valor = bool.Parse(_reportTable.Rows[0]["validar"].ToString());

           return valor;


        }

        public virtual DataTable ViewAccounts(int client)
        {
            var da = new SqlDataAccess("UseConfig");
            da.SetProc("searchAccount");
            da.AddParameter("@clientId", client);
            _reportTable = da.ExecuteDataSet().Tables[0];

           
            

            return _reportTable;
        }
    }
}