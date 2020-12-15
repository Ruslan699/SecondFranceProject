using LightInject;
using LightInject.ServiceLocation;
using Microsoft.Practices.ServiceLocation;
using System.ServiceProcess;

namespace Papastreet.JobRunner
{
    class Program
    {
        static void Main()
        {
            ServiceContainer serviceContainer = new ServiceContainer();
            IServiceLocator serviceLocator = new LightInjectServiceLocator(serviceContainer);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            ServiceConfig.Register(serviceContainer);

#if DEBUG
            var service = new JobService();
            service.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase.Run(new JobService());
#endif
        }
       
    }
}
