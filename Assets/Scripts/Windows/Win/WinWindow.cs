using System;
using Services.WindowService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace QuizTest.Windows.Win
{
    public class WinWindow : AbstractWindow, IWinWindow
    {
        public event Action OnRestartClick;
        
        [SerializeField] private Button restartButton;
        
        
        private void Awake()
        {
            restartButton.onClick.AddListener(() => OnRestartClick?.Invoke());    
        }
    }
}