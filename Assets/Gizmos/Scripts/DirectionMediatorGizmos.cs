using System;
using UnityEngine;

namespace Player
{
    public sealed partial class DirectionMediator
    {
        [Header("Gizmos")]
        [SerializeField] private float distance;
        [SerializeField] private Color[] colors = new Color[4];
        
        public void OnDrawGizmosSelected()
        {
            if (currentSettingIndex < 0 || currentSettingIndex >= directionSettings.Length)
                return;

            SwitchSetting(currentSettingIndex);
            
            Gizmos.color = colors[0];
            
            Vector2 up = GetVectorFromEnum(currentSetting.Up);
            Gizmos.DrawLine(Vector3.zero, new Vector3(up.x, 0, up.y) * distance);
            Gizmos.color = colors[1];
            
            Vector2 down = GetVectorFromEnum(currentSetting.Down);
            Gizmos.DrawLine(Vector3.zero, new Vector3(down.x, 0, down.y) * distance);
            
            Gizmos.color = colors[2];
            Vector2 left = GetVectorFromEnum(currentSetting.Left);
            Gizmos.DrawLine(Vector3.zero, new Vector3(left.x, 0, left.y) * distance);
            
            Gizmos.color = colors[3];
            Vector2 right = GetVectorFromEnum(currentSetting.Right);
            Gizmos.DrawLine(Vector3.zero, new Vector3(right.x, 0, right.y) * distance);
        }
    }
}