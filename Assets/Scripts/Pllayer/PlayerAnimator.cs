using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public enum AnimationStates
    {
        attack,
        walk,
        run,
        die,
        taunt,
        idle,
        jump
    }

    public void DoAnimation(AnimationStates state, bool value)
    {
        _animator.SetBool(state.ToString(), value);
    }
}
