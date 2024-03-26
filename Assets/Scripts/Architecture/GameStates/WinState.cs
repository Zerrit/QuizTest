using QuizTest.Services.Window;
using QuizTest.Windows.Curtain;
using QuizTest.Windows.Win;
using Zparta.Architecture.GameStates;

namespace QuizTest.Architecture.GameStates
{
    public class WinState : AbstractGameState
    {
        private readonly IWinWindow _winWindow;
        private readonly ICurtainWindow _curtainWindow;
        private readonly IWindowService _windowService;
        private readonly GameStateMachine _stateMachine;
        
        public WinState(GameStateMachine gameStateMachine, IWindowService windowService)
        {
            _stateMachine = gameStateMachine;
            _windowService = windowService;
            _winWindow = _windowService.GetWindowByType<IWinWindow>("Win");
            _curtainWindow = _windowService.GetWindowByType<ICurtainWindow>("Curtain");
        }

        public override void Enter()
        {
            base.Enter();

            _winWindow.OnRestartClick += ToCurtain;
            _curtainWindow.OnFadedIn += ToGameplay;
            _windowService.ShowWindow("Win");
        }

        public override void Exit()
        {
            base.Exit();
            
            _curtainWindow.OnFadedIn -= ToGameplay;
            _windowService.HideWindow("Win");
        }

        private void ToCurtain()
        {
            _winWindow.OnRestartClick -= ToCurtain;
            _windowService.ShowWindow("Curtain");
        }

        private void ToGameplay()
        {
            _stateMachine.ChangeState<GameplayState>();
            _windowService.HideWindow("Curtain");
        }
    }
}