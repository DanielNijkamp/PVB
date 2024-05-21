using UnityEngine;

public sealed class AnimationInit : MonoBehaviour
{
    [SerializeField] private string startState;

    [SerializeField] private Animator animator;
    
    private void Start()
    {
        animator.Play(startState);
    }
}