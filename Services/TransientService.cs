using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;

namespace WebApplication2._2.Services
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ITransientService>().ImplementedBy<TransientService>().LifestyleTransient(),
                Component.For<IPerWebRequestService>().ImplementedBy<PerWebRequestService>().LifestyleCustom<MsScopedLifestyleManager>(),
                Component.For<IOtherTransient>().ImplementedBy<OtherTransient>().LifestyleTransient()
            );
        }
    }

    public interface ITransientService
    {
    }

    public class TransientService : LifeTimeLogger, ITransientService
    {
        private readonly IPerWebRequestService _web;

        public TransientService(IPerWebRequestService web) : base("TransientService")
        {
            _web = web;
        }
    }


    public interface IPerWebRequestService
    {
    }

    public class PerWebRequestService : LifeTimeLogger, IPerWebRequestService
    {
        public PerWebRequestService() : base("PerWebRequestService")
        {
        }
    }

    public interface IOtherTransient
    {
    }

    public class OtherTransient : LifeTimeLogger, IOtherTransient
    {
        private readonly IPerWebRequestService _web;

        public OtherTransient(IPerWebRequestService web) : base("OtherTransient")
        {
            _web = web;
        }
    }
}