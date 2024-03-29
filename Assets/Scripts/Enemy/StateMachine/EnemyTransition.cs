using UnityEngine;

namespace Enemy.StateMachine
{
    public abstract class EnemyTransition : MonoBehaviour
    {
        [SerializeField] private EnemyState _targetState;

        public EnemyState TargetState => _targetState;
        public bool NeedTransit { get; protected set; }
        protected Player.Player Player { get; private set; }
        protected Enemy Enemy { get; private set; }

        public void Init(Player.Player player, Enemy enemy)
        {
            Player = player;
            Enemy = enemy;
        }

        protected virtual void OnEnable()
        {
            NeedTransit = false;
        }
    }
}
