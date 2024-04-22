using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class Movement : MonoBehaviour
    {
        [Header("Dependencies")] 
        private DirectionMediator directionMediator;
        
        [Header("Settings")]
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [ShowNonSerializedField] private bool isFrozen;

        private CharacterController character;
        private Vector2 moveInput;
        
        private void Start()
        {
            character = GetComponent<CharacterController>();
            directionMediator = FindObjectOfType<DirectionMediator>();
        }
        
        private void FixedUpdate()
        {
            if (isFrozen) return;
            
            Vector3 moveDirection = directionMediator.TransformInput(moveInput);
            var move = new Vector3(moveDirection.x, 0, moveDirection.y) * (speed * Time.deltaTime);
            
            character.Move(move);
        
            if (move != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move);
                Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.rotation = smoothedRotation;
            }
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


