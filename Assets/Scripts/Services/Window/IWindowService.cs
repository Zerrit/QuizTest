namespace QuizTest.Services.Window
{
    public interface IWindowService
    {
        public T GetWindowByType<T>(string windowId);
        public void ShowWindow(string windowId);
        public void HideWindow(string windowId);
    }
}