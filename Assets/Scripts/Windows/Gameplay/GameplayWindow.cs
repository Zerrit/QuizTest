using DG.Tweening;
using QuizTest.Services.Window;
using UnityEngine;
using UnityEngine.UI;

namespace QuizTest.Windows.Gameplay
{
    public class GameplayWindow : AbstractWindow, IGameplayWindow
    {
        [SerializeField] private Text taskText;

        private Tween _fadeTween;
        
        
        public void SetTask(string task)
        {
            taskText.text = $"Find {task}";
        }

        public override void Show()
        {
            base.Show();
            FadeIn();
        }
        
        
        private void FadeIn()
        {
            Fade(1, .5f);
        }
        
        private void FadeOut()
        {
            Fade(0, 1f);
        }

        private void Fade(float value, float duration)
        {
            _fadeTween?.Kill();

            _fadeTween = taskText.DOFade(value, duration);
        }
    }
}