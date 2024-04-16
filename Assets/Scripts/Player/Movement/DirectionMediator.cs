using System;
using UnityEngine;

namespace Player
{
    public sealed partial class DirectionMediator : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private DirectionSettings directionSettings;
        [SerializeField] private int currentSettingIndex;
        
        private DirectionSetting currentSetting;

        private void Start()
        {
            SwitchSetting(currentSettingIndex);
        }
        

        public Vector2 TransformInput(Vector2 input)
        {
            Vector2 direction = Vector2.zero;
            
            if (input.y != 0)   
            {
                direction += GetVectorFromEnum(input.y > 0 ? currentSetting.Up : currentSetting.Down);
            }
            if (input.x != 0)
            {
                direction += GetVectorFromEnum(input.x > 0 ? currentSetting.Right : currentSetting.Left);
            }
            
            return direction;
        }
        
        public void SwitchSetting(int index)
        {
            currentSetting = directionSettings[index];
        }

        private static Vector2 GetVectorFromEnum(Direction direction)
        {
            return direction switch
            {
                Direction.Up => Vector2.up,
                Direction.Down => Vector2.down,
                Direction.Left => Vector2.left,
                Direction.Right => Vector2.right,
                _ => Vector2.zero
            };
        }
        
        
    }
}