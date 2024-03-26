using QuizTest.LevelLogic.Data;
using QuizTest.Services.Window;
using UnityEngine;

namespace QuizTest.Services.Config
{
    /// <summary>
    /// Сервис предоставляющий доступ к данным.
    /// </summary>
    public class ConfigService: MonoBehaviour, IConfigService
    {
        [SerializeField] private CardBundleData[] cardBundles;
        [SerializeField] private LevelQueueData levelQueueData;
        [SerializeField] private AbstractWindow[] windowInstances;
        
        
        bool IConfigService.GetData(out CardBundleData[] bundles)
        {
            bundles = cardBundles;
            return (cardBundles != null);
        }

        bool IConfigService.GetData(out LevelQueueData levelsQueue)
        {
            levelsQueue = levelQueueData;
            return (levelQueueData != null);
        }

        bool IConfigService.GetData(out AbstractWindow[] windows)
        {
            windows = windowInstances;
            return (windowInstances != null);
        }
    }
}