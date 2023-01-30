using UnityEngine;

namespace Enemy.StateMachine
{
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyState _firstState;

        private EnemyState _currentState;

        public Player.Player Player { get; private set; }
        public Enemy Enemy { get; private set; }

        private void Awake()
        {
            Enemy = GetComponent<Enemy>();

            Player = FindObjectOfType<Player.Player>();
        }

        private void Start()
        {
            _currentState = _firstState;
            _currentState.Enter(Enemy, Player);
        }

        private void Update()
        {
            if (_currentState == null)
                return;

            EnemyState nextState = _currentState.GetNextState();

            if (nextState != null)
                Transit(nextState);
        }

        private void Transit(EnemyState nextState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = nextState;

            if (_currentState != null)
                _currentState.Enter(Enemy, Player);
        }
    }
}
