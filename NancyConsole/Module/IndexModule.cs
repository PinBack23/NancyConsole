using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NancyConsole.Module
{
    public class IndexModule : Nancy.NancyModule
    {

//        private const String IndexPage = @"
//            <html><body>
//            <h1>Yep. The server is running</h1>
//            </body></html>
//            ";

        public IndexModule()
        {
            this.Get["/"] = v => this.View["index.html"];
            //Get["/"] = parameter => { return IndexPage; };
        }
    }
}
