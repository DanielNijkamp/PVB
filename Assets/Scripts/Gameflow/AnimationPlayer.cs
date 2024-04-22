using UnityEngine;

public sealed class AnimationPlayer : MonoBehaviour
{
    //TODO: another script should mask the door going up.
    
    [SerializeField] private Animator animator;
    
    public void Play(string animationName)
    {
        animator.Play(animationName);
    }
    
    
}
