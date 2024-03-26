using QuizTest.Architecture.GameStates;
using Zenject;

namespace QuizTest.Architecture.Installers
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterGameStateMachine();

            RegisterGameStates();
        }

        
        //-----------------------------------------------------------------------------------------------------//
        
        private void RegisterGameStateMachine() 
            => Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        
        private void RegisterGameStates()
        {
            Container.Bind<GameplayState>().AsSingle();
            Container.Bind<WinState>().AsSingle();
        }
    }
}