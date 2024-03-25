using Zparta.Architecture.GameStates;

namespace QuizTest.Architecture.GameStates
{
    public class WinState : AbstractGameState
    {
        private readonly GameStateMachine _stateMachine;
        
        public WinState(GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void ToBonusLevel()
        {
            
        }
    }
}