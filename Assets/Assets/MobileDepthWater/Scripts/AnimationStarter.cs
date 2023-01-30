using UnityEngine;

namespace Assets.MobileDepthWater.Scripts
{
    public class AnimationStarter : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Motion animation;

        public void Awake()
        {
            animator.Play(animation.name);
        }
    }
}
