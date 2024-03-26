using System;
using System.Collections.Generic;
using QuizTest.Services.Config;
using Services.WindowService;
using UnityEngine;


namespace QuizTest.Services.Window
{
    public class WindowService : IWindowService
    {
        private Dictionary<string, AbstractWindow> _windows = new Dictionary<string, AbstractWindow>();


        public WindowService(IConfigService configService)
        {
            if (configService.GetData(out AbstractWindow[] windows))
            {
                foreach (AbstractWindow window in windows)
                {
                    _windows[window.WindowId] = window;
                }
            }
            else
                throw new Exception($"В конфиг сервисе не найдены инстансы окон");
        }

                
        public T GetWindowByType<T>(string windowId)
        {
            var instance = GetWindow(windowId);
            if (instance is T window) return window;
            
            throw new Exception($"Окно с указанным Id не связано не является следующей абстракцией {typeof(T)}");
        }
        
        public virtual void ShowWindow(string windowId)
        {
            GetWindow(windowId).Show();
        }

        public virtual void HideWindow(string windowId)
        {
            GetWindow(windowId).Hide();
        }
        

        private AbstractWindow GetWindow(string windowId)
        {
            return _windows.ContainsKey(windowId)
                ? _windows[windowId]
                : throw new Exception($"Запрашиваемое окно не найдено: Id - {windowId}");
        }
    }
}