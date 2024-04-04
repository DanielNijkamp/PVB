using UnityEngine;
using Cinemachine;
public sealed class CameraFocuser : MonoBehaviour
{
    private CinemachineTargetGroup trackTargets;

    private void Start()
    {
        trackTargets = FindObjectOfType<CinemachineTargetGroup>();
        AddTargetToGroup();
    }
    private void AddTargetToGroup()
    {
        Transform transform = gameObject.transform;
        trackTargets.AddMember(transform, 1, 0);
    }
}
