using QuizTest.LevelLogic.Data;
using QuizTest.Services.Window;

namespace QuizTest.Services.Config
{
    public interface IConfigService
    {      
        /// <summary>
        /// Возвращает массив всех наборов карточек.
        /// </summary>
        public bool GetData(out CardBundleData[] bundles);
        
        /// <summary>
        /// Возвращает данные о списке уровней.
        /// </summary>
        public bool GetData(out LevelQueueData levelsQueue);
        
        /// <summary>
        /// Возвращает данные об существующих окнах.
        /// </summary>
        public bool GetData(out AbstractWindow[] windows);
    }
}