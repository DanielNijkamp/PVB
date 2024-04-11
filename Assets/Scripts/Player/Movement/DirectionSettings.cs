using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "DirectionSettings", menuName = "Settings/DirectionSettings")]
    public sealed class DirectionSettings : ScriptableObject
    {
        [SerializeField] private DirectionSetting[] directionSettings;
        
        public int Length => directionSettings.Length;

        public DirectionSetting this[int currentSettingIndex] => directionSettings[currentSettingIndex];
    }
}