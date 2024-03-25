using Zenject;
using Zparta.Architecture.GameStates;

namespace QuizTest.Factories
{
    public class GameStateFactory
    {
        private readonly DiContainer _container;
        
        public GameStateFactory(DiContainer container)
        {
            _container = container;
        }

        public T CreateState<T>() where T : AbstractGameState
        {
            return _container.Resolve<T>();
        }
    }
}