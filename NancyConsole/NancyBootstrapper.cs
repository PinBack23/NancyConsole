using Nancy;
using Nancy.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NancyConsole
{
    public class NancyBootstrapper : DefaultNancyBootstrapper
    {

        //protected override Nancy.Bootstrapper.NancyInternalConfiguration InternalConfiguration
        //{
        //    get
        //    {
        //        return Nancy.Bootstrapper.NancyInternalConfiguration.Default;
        //    }
        //}

    protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
    {
        nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("scripts", "scripts"));
        base.ConfigureConventions(nancyConventions);
    }

    }
}
