using UnityEngine;

namespace Services.WindowService
{
    public abstract class AbstractWindow : MonoBehaviour
    {
        [field:SerializeField] public string WindowId { get; private set; }
        [field:SerializeField] public GameObject RootWindow { get; private set; }
        
        /// <summary>
        /// Отображает окно.
        /// </summary>
        public virtual void Show() => RootWindow.SetActive(true);

        /// <summary>
        /// Скрывает окно.
        /// </summary>
        public virtual void Hide() => RootWindow.SetActive(false);
    }
}