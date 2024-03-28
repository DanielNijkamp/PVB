using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class Movement : MonoBehaviour
    {
        [Header("Dependencies")] 
        [SerializeField] private DirectionMediator directionMediator;
        
        [Header("Settings")]
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;

        private CharacterController character;
    
        private Vector2 moveInput;
        private Vector2 rotateInput;
        
        private void Start()
        {
            character = GetComponent<CharacterController>();
        }
        
        private void FixedUpdate()
        {
            Vector3 moveDirection = directionMediator.TransformInput(moveInput);
            var move = new Vector3(moveDirection.x, 0, moveDirection.y) * (speed * Time.deltaTime);
            
            character.Move(move);
        
            Vector3 rotate = new Vector3(0, rotateInput.x, 0) * (rotationSpeed * Time.deltaTime);
            transform.Rotate(rotate);
        }
    
        public void Move(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        public void Rotate(InputAction.CallbackContext context)
        {
            rotateInput = context.ReadValue<Vector2>();
        }
        
    }
}


