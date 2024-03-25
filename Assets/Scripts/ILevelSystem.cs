using System;

namespace QuizTest
{
    public interface ILevelSystem
    {
        public event Action<IReadOnlyLevelModel> OnLevelModelChanged;
        public IReadOnlyLevelModel GetGridModel();

        public bool TryAnswer(string answerId);
    }
}