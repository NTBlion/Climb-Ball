using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyState _firstState;

    public Player Player { get; private set; }
    public Enemy Enemy { get; private set; }

    private EnemyState _currentState;

    private void Awake()
    {
        Enemy = FindObjectOfType<Enemy>();

        Player = FindObjectOfType<Player>();
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
