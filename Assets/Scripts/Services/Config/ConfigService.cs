using QuizTest.LevelLogic.Data;
using Services.WindowService;
using UnityEngine;

namespace QuizTest.Services.Config
{
    public class ConfigService: MonoBehaviour, IConfigService
    {
        [SerializeField] private CardBundleData[] cardBundles;
        [SerializeField] private LevelQueueData levelQueueData;
        [SerializeField] private AbstractWindow[] windowInstances;

        public bool GetData(out CardBundleData[] bundles)
        {
            bundles = cardBundles;
            return (cardBundles != null);
        }
        
        public bool GetData(out LevelQueueData levelsQueue)
        {
            levelsQueue = levelQueueData;
            return (levelQueueData != null);
        }
        
        public bool GetData(out AbstractWindow[] windows)
        {
            windows = windowInstances;
            return (windowInstances != null);
        }
    }
}