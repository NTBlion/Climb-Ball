using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public const string ATTACK = "attack";
    public const string WALK = "walk";
    public const string RUN = "run";
    public const string DIE = "die";
    public const string TAUNT = "taunt";
    public const string IDLE = "idle";
    public const string JUMP = "jump";

    public void DoAnimation(string AnimationName, bool value)
    {
        _animator.SetBool(name, value);
    }
}
