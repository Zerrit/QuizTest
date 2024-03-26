using QuizTest.LevelLogic.Data;
using Services.WindowService;

namespace QuizTest.Services.Config
{
    public interface IConfigService
    {
        bool GetData(out CardBundleData[] bundles);
        bool GetData(out LevelQueueData levelsQueue);
        bool GetData(out AbstractWindow[] windows);
    }
}