using Autofac;
using Autofac.Integration.Wcf;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using Server;
using System.Reflection;
using System.Web.Mvc;

namespace Client.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new ChannelFactory<IService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:58296/Service.svc"))).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<IService>>().CreateChannel()).As<IService>().UseWcfSafeRelease();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}