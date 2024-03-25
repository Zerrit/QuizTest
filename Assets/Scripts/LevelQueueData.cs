using UnityEngine;

namespace QuizTest
{
    [CreateAssetMenu(fileName = "NewLevelQueueData", menuName = "Level Queue Data")]
    public class LevelQueueData : ScriptableObject
    {
        [field: SerializeField] public LevelData[] LevelQueue { get; private set; }
    }
}