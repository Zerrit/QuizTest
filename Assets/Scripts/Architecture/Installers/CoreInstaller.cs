using QuizTest.Interfaces;
using Zenject;

namespace QuizTest.Architecture.Installers
{
    public class CoreInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
        }
    }
}