using System;
using System.Collections.Generic;
using QuizTest.Architecture.GameStates;
using QuizTest.Factories;
using Zenject;
using Zparta.Architecture.GameStates;

namespace QuizTest.Architecture
{
    /// <summary>
    /// Машина состояний игры.
    /// </summary>
    public class GameStateMachine : IInitializable
    {
        private Dictionary<Type, AbstractGameState> _states;
        private AbstractGameState _currentState;
        
        private readonly GameStateFactory _stateFactory;
        
        public GameStateMachine(GameStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }
        
        
        /// <summary>
        /// Заполняет словарь всеми рабочими состояниями в которое машина сможет переключаться.
        /// </summary>
        public void Initialize()
        {
            _states = new Dictionary<Type, AbstractGameState>()
            {
                [typeof(PrepareState)] = _stateFactory.CreateState<PrepareState>(),
                [typeof(GameplayState)] = _stateFactory.CreateState<GameplayState>(),
                [typeof(WinState)] = _stateFactory.CreateState<WinState>(),
            };
            
            StartMachine<PrepareState>();
        }

        /// <summary>
        /// Меняет стейт машины на новый.
        /// </summary>
        /// <typeparam name="T"> Новый стейт. </typeparam>
        public void ChangeState<T>() where T : AbstractGameState
        {
            if (_states.ContainsKey(typeof(T)))
            {
                _currentState?.Exit();
                _currentState = _states[typeof(T)];
                _states[typeof(T)].Enter();
            }
            else throw new Exception($"Не найдено указанное состояние игры: {typeof(T)}");
        }

        /// <summary>
        /// Запускает машину состояний игры в указанное состояние.
        /// </summary>
        /// <typeparam name="T"> Стартовое состояние. </typeparam>
        private void StartMachine<T>() where T : AbstractGameState
        {
            if (_states.ContainsKey(typeof(T)))
            {
                _states[typeof(T)].Enter();
                _currentState = _states[typeof(T)];
            }
            else throw new Exception($"Не найдено указанное состояние игры: {typeof(T)}");
        }
    }
}