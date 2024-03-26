using System;
using QuizTest.LevelLogic.Model;

namespace QuizTest.LevelLogic.System
{
    public interface ILevelSystem
    {
        public event Action<IReadOnlyLevelModel> OnLevelModelChanged;
        public event Action OnLevelsOver;
        //public IReadOnlyLevelModel GetGridModel();

        public void Initialize();
        public void CompleteLevel();

    }
}