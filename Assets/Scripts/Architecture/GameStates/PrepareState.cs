using Zparta.Architecture.GameStates;

namespace QuizTest.Architecture.GameStates
{
    public class PrepareState : AbstractGameState
    {
        private readonly GameStateMachine _stateMachine;
        
        public PrepareState(GameStateMachine gameStateMachine)
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
    }
}