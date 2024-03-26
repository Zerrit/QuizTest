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
        }

        private void RegisterLevelSystem()
            => Container.BindInterfacesAndSelfTo<LevelSystem>().AsSingle();
    }
}