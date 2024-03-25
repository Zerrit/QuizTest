using UnityEngine;

namespace QuizTest.Services
{
    public class ConfigService: MonoBehaviour, IConfigService
    {
        [SerializeField] private CardBundleData[] cardBundles;
        [SerializeField] private LevelQueueData levelQueueData;

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
    }
}