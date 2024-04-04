using UnityEngine;
using Cinemachine;
public sealed class CameraFocuser : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup trackTargets;

    private void Start()
    {
        trackTargets = FindObjectOfType<CinemachineTargetGroup>();
        AddTargetToGroup();
    }
    public void AddTargetToGroup()
    {
        Transform transform = gameObject.transform;
        trackTargets.AddMember(transform, 0, 0);
    }
}
