using System;
using QuizTest.LevelLogic.Data;
using QuizTest.LevelLogic.Model;
using QuizTest.Services.Config;
using QuizTest.Services.Window;
using QuizTest.Windows.Gameplay;
using Random = UnityEngine.Random;

namespace QuizTest.LevelLogic.System
{
    public class LevelSystem : ILevelSystem
    {
        public event Action<IReadOnlyLevelModel> OnLevelModelChanged;
        public event Action OnLevelsOver;

        private int _currentLevel = 0;
        private LevelModel _currentLevelModel;
        
        private readonly CardBundleData[] _bundles;
        private readonly LevelQueueData _levelsQueueData;
        private readonly IGameplayWindow _gameplayWindow;
        private readonly IWindowService _windowService;

        public LevelSystem(IConfigService configService, IWindowService windowService)
        {
            configService.GetData(out _bundles);
            configService.GetData(out _levelsQueueData);
            _windowService = windowService;
            _gameplayWindow = _windowService.GetWindowByType<IGameplayWindow>("Gameplay");
        }

        public void Initialize()
        {
            _currentLevel = 0;
            CreateNextLevel();
            
            _windowService.ShowWindow("Gameplay");
        }


        public void CompleteLevel()
        {
            _currentLevel++;
            if (_currentLevel < _levelsQueueData.LevelsQueue.Length)
                CreateNextLevel();
            else
                OnLevelsOver?.Invoke();
        }
        
        
        private void CreateNextLevel()
        {
            int randomBundleIndex = Random.Range(0, _bundles.Length);
            _currentLevelModel = new LevelModel(_levelsQueueData.LevelsQueue[_currentLevel].Size, _bundles[randomBundleIndex]);
            _gameplayWindow.SetTask(_currentLevelModel.RightAnswerId);
            OnLevelModelChanged?.Invoke(_currentLevelModel);
        }
        
        
        public IReadOnlyLevelModel GetGridModel() 
            => _currentLevelModel;


        public bool TryAnswer(string answerId)
        {
            return false;
        }
    }
}