using System;
using QuizTest.Services;
using UnityEngine;
using Zenject;

namespace QuizTest
{
    public class LevelSystem : ILevelSystem, IInitializable
    {
        public event Action<IReadOnlyLevelModel> OnLevelModelChanged;

        private int _currentLevel = 2;
        private LevelModel _currentLevelModel;
        
        private readonly CardBundleData[] _bundles;
        private readonly LevelQueueData _levelsQueueData;
        
        
        public LevelSystem(IConfigService configService)
        {
            configService.GetData(out _bundles);
            configService.GetData(out _levelsQueueData);
        }

        
        public void Initialize()
        {
            CreateNextLevel();
        }
        
        
        private void CreateNextLevel()
        {
            _currentLevelModel = new LevelModel(_levelsQueueData.LevelsQueue[_currentLevel].Size, _bundles[0]);
            OnLevelModelChanged?.Invoke(_currentLevelModel);
            Debug.LogWarning("Событие отправлено.");
        }
        
        
        public IReadOnlyLevelModel GetGridModel() 
            => _currentLevelModel;


        public bool TryAnswer(string answerId)
        {
            return false;
        }
    }
}