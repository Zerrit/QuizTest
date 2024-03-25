using UnityEngine;
using Zenject;

namespace QuizTest.Architecture.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterUIControllers();
        }


        
        private void RegisterUIControllers()
        {
            //Container.Bind<IGameplayController>().To<GameplayController>().AsSingle();
            //Container.Bind<IWinController>().To<WinController>().AsSingle();
        }
    }
}