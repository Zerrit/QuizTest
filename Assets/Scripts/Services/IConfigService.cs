namespace QuizTest.Services
{
    public interface IConfigService
    {
        bool GetData(out CardBundleData[] bundles);
        bool GetData(out LevelQueueData levelsQueue);
    }
}