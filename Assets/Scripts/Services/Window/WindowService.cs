using System;
using System.Collections.Generic;
using QuizTest.Services.Config;

namespace QuizTest.Services.Window
{
    /// <summary>
    /// Сервис управления окнами UI.
    /// </summary>
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

              
        /// <summary>
        /// Возвращает инстанс существующего окна по его Id.
        /// </summary>
        /// <param name="windowId"> id окна</param>
        /// <typeparam name="T"> Тип возвращаемого окна. </typeparam>
        public T GetWindowByType<T>(string windowId)
        {
            var instance = GetWindow(windowId);
            if (instance is T window) return window;
            
            throw new Exception($"Окно с указанным Id не связано не является следующей абстракцией {typeof(T)}");
        }
        
        /// <summary>
        /// Включает окно.
        /// </summary>
        /// <param name="windowId"> id окна. </param>
        public virtual void ShowWindow(string windowId)
        {
            GetWindow(windowId).Show();
        }

        /// <summary>
        /// Выключает окно.
        /// </summary>
        /// <param name="windowId"> id окна. </param>
        public virtual void HideWindow(string windowId)
        {
            GetWindow(windowId).Hide();
        }
        
        /// <summary>
        /// Достаёт из словаря окно по id.
        /// </summary>
        /// <param name="windowId"> id окна. </param>
        /// <returns></returns>
        private AbstractWindow GetWindow(string windowId)
        {
            return _windows.ContainsKey(windowId)
                ? _windows[windowId]
                : throw new Exception($"Запрашиваемое окно не найдено: Id - {windowId}");
        }
    }
}