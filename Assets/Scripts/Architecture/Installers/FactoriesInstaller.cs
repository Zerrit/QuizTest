using QuizTest.Factories;
using Zenject;

namespace QuizTest.Architecture.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterGameStateFactory();
            //RegisterWindowFactory();
        }
    
    
    
        private void RegisterGameStateFactory() 
            => Container.Bind<GameStateFactory>().AsSingle().NonLazy();

        /*private void RegisterWindowFactory() 
            => Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle().NonLazy();*/
    }
}
    