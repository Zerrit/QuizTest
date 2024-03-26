using QuizTest.LevelLogic.System;
using UnityEngine;
using Zenject;

namespace QuizTest.Architecture.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterLevelSystem();
            RegisterUIControllers();
        }


        private void RegisterLevelSystem()
            => Container.BindInterfacesAndSelfTo<LevelSystem>().AsSingle();

        private void RegisterUIControllers()
        {
            //Container.Bind<IGameplayController>().To<GameplayController>().AsSingle();
            //Container.Bind<IWinController>().To<WinController>().AsSingle();
        }
    }
}