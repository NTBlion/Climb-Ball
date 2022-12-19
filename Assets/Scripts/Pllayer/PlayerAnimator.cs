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
        jump,
        movement
    }

    public void DoAnimation(AnimationStates state, bool value)
    {
        _animator.SetBool(state.ToString(), value);
    }

    public void DoAnimation(AnimationStates state, float value)
    {
        _animator.SetFloat(state.ToString(), value);
    }
}
