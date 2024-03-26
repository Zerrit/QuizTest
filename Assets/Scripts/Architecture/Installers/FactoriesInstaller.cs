using QuizTest.Factories;
using Zenject;

namespace QuizTest.Architecture.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterGameStateFactory();
        }
        
    
        private void RegisterGameStateFactory() 
            => Container.Bind<GameStateFactory>().AsSingle().NonLazy();
        
    }
}
    