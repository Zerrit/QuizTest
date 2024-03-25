using QuizTest.Services;
using UnityEngine;
using Zenject;

namespace QuizTest.Architecture.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        [SerializeField] private ConfigService configService;
        
        public override void InstallBindings()
        {
            RegistterConfigService();
            //RegisterWindowService();
        }


        private void RegistterConfigService()
            => Container.Bind<IConfigService>().To<ConfigService>().AsSingle();

        /*private void RegisterWindowService() 
            => Container.Bind<IWindowService>().To<WindowService>().AsSingle();*/
    }
}