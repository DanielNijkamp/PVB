using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class Movement : MonoBehaviour
    {
        [Header("Dependencies")] 
        [SerializeField] private Animator animator;
        [SerializeField,AnimatorParam("animator")] private string animParam;
        private DirectionMediator directionMediator;
        
        [Header("Settings")]
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private LayerMask groundMask;

        [ShowNonSerializedField] private bool isFrozen;
        [ShowNonSerializedField] private bool isGrounded;

        private CharacterController character;
        private Vector2 moveInput;
        private Vector3 velocity;

        private void Start()
        {
            character = GetComponent<CharacterController>();
            directionMediator = FindObjectOfType<DirectionMediator>();
        }

        private void Update()
        {
            isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (!isGrounded)
            {
                velocity.y += gravity * Time.deltaTime;
            }

            character.Move(velocity * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (isFrozen) return;
            
            Vector3 moveDirection = directionMediator.TransformInput(moveInput);
            var move = new Vector3(moveDirection.x, 0, moveDirection.y) * (speed * Time.deltaTime);
            
            character.Move(move);
            
            var isMoving = move != Vector3.zero;
            animator.SetBool(animParam, isMoving);

            if (!isMoving) return;
            
            Quaternion targetRotation = Quaternion.LookRotation(move);
            Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = smoothedRotation;
        }
    
        public void Move(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        public void ToggleFreeze()
        {
            isFrozen = !isFrozen;
        }
        
    }
}


