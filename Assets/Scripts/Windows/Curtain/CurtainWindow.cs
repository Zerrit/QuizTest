using System;
using DG.Tweening;
using QuizTest.Services.Window;
using UnityEngine;
using UnityEngine.UI;

namespace QuizTest.Windows.Curtain
{
    public interface ICurtainWindow
    {
        public event Action OnFadedIn;
    }

    public class CurtainWindow : AbstractWindow, ICurtainWindow
    {
        public event Action OnFadedIn;
        
        [SerializeField] private Image curtainImage;

        private Tween _curtainTween;
        
        
        public override void Show()
        {
            base.Show();
            
            FadeIn(() => OnFadedIn?.Invoke());
        }

        public override void Hide()
        {
            FadeOut(base.Hide);
        }




        private void FadeIn(Action onFadeComplete)
        {
            Fade(1, 1f, onFadeComplete);
        }
        
        private void FadeOut(Action onFadeComplete)
        {
            Fade(0, 1f, onFadeComplete);
        }

        private void Fade(float value, float duration, Action onFadeComplete = null)
        {
            _curtainTween?.Kill();

            _curtainTween = curtainImage.DOFade(value, duration).OnComplete(() => onFadeComplete?.Invoke());
        }
    }
} 