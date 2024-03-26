using QuizTest.LevelLogic.System;
using Zparta.Architecture.GameStates;

namespace QuizTest.Architecture.GameStates
{
    public class GameplayState : AbstractGameState
    {
        private readonly ILevelSystem _levelSystem;
        private readonly GameStateMachine _stateMachine;


        public GameplayState(GameStateMachine gameStateMachine, ILevelSystem levelSystem)
        {
            _stateMachine = gameStateMachine;
            _levelSystem = levelSystem;
        }


        public override void Enter()
        {
            base.Enter();

            _levelSystem.OnLevelsOver += ToWinState;
            _levelSystem.Initialize();
        }

        public override void Exit()
        {
            base.Exit();
            _levelSystem.OnLevelsOver -= ToWinState;
        }

        private void ToWinState()
            => _stateMachine.ChangeState<WinState>();
    }
}