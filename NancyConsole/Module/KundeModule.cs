using Devart.Data.Oracle;
using Nancy;
using NancyConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NancyConsole.Module
{
    public class KundeModule : NancyModule
    {
        public KundeModule()
            : base("Kunde")
        {
            this.Get["/"] = x => { return this.AlleKunden(); };
        }

        private object AlleKunden()
        {
            string lsSelectQuery = "SELECT * FROM tblkunde";
            List<Kunde> loKunde = new List<Kunde>();
            using (OracleConnection loConnection = new OracleConnection(this.CreateConnectionString()))
            {
                loConnection.Open();

                using (OracleCommand loCommand = new OracleCommand(lsSelectQuery, loConnection))
                {
                    using (OracleDataReader loReader = loCommand.ExecuteReader())
                    {
                        while (loReader.Read())
                        {
                            loKunde.Add(new Kunde()
                                {
                                    Id = loReader.GetInt64("ID"),
                                    Vorname = loReader.GetString("VORNAME")
                                });
                        }
                    }
                }

                loConnection.Close();
            }
            return loKunde;
        }

        private string CreateConnectionString()
        {
            OracleConnectionStringBuilder loBuilder = new OracleConnectionStringBuilder();
            loBuilder.Direct = true;
            loBuilder.Server = "vmqSrvABR2";
            loBuilder.Port = 1521;
            loBuilder.Sid = "ORCL";
            loBuilder.UserId = "frm";
            loBuilder.Password = "abr1frm";
            return loBuilder.ConnectionString;
        }
    }
}
