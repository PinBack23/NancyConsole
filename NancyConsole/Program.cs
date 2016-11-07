using Devart.Data.Oracle;
using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NancyConsole
{
    class Program
    {
        private const string DOMAIN = "http://localhost:8099";

        static void Main(string[] args)
        {
            //DumpKundenTabelle();

            var loConfig = new HostConfiguration { AllowChunkedEncoding = false };
            loConfig.UrlReservations.CreateAutomatically = true; //Wird Programm unter Admin gestartet braucht man das nicht

            var nancyHost = new Nancy.Hosting.Self.NancyHost(loConfig, new Uri(DOMAIN));

            // start
            nancyHost.Start();
            Console.WriteLine("REST service listening on " + DOMAIN);
            // stop with an <Enter> key press
            Console.ReadLine();
            nancyHost.Stop();
        }

        private static void DumpKundenTabelle()
        {
            string lsSelectQuery = "SELECT * FROM tblkunde";
            using (OracleConnection loConnection = new OracleConnection(CreateConnectionString()))
            {
                loConnection.Open();

                using (OracleCommand loCommand = new OracleCommand(lsSelectQuery, loConnection))
                {
                    using (OracleDataReader loReader = loCommand.ExecuteReader())
                    {
                        while (loReader.Read())
                        {
                            Console.WriteLine("ID: {0}, Vorname: {1}", loReader.GetInt64("ID"), loReader.GetString("VORNAME"));
                        }
                    }
                }

                loConnection.Close();
            }
        }

        private static string CreateConnectionString()
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
