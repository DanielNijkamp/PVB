using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public sealed class AnimationInit : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string startState;

    private void Start()
    {
        animator.Play(startState);
    }
}