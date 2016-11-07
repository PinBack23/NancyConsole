using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using NancyConsole.Model;

namespace NancyConsole.Module
{
    public class MitarbeiterModule : NancyModule
    {
        public MitarbeiterModule()
            : base("Mitarbeiter")
        {
            this.Get["/"] = x => { return this.AlleMitarbeiter(); };
        }

        private object AlleMitarbeiter()
        {
            return Mitarbeiter.GetList();
            //return this.Negotiate
            //    .WithStatusCode(HttpStatusCode.OK)
            //    .WithModel(Mitarbeiter.GetList())
            //    .WithHeader("Accept", "application/json");
        }
    }
}
