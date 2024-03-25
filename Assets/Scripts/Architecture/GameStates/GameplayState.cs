using Zparta.Architecture.GameStates;

namespace QuizTest.Architecture.GameStates
{
    public class GameplayState : AbstractGameState
    {
        private readonly GameStateMachine _stateMachine;
        
        public GameplayState(GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }
        
        
    }
}