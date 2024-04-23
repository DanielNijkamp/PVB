using UnityEngine;

public sealed class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    public void Play(string animationName)
    {
        animator.Play(animationName);
    }
    
    
}
