using UnityEngine;
using Cinemachine;
public class CameraFocuser : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup trackTargets;
    private bool isFirstPlayer = true  ;

    private void Start()
    {
        trackTargets = FindObjectOfType<CinemachineTargetGroup>();
        AddTargetToGroup();
    }
    public void AddTargetToGroup()
    {
        Transform transform = gameObject.transform;
        int groupId = isFirstPlayer ? 1 : 2;
        trackTargets.AddMember(transform, groupId, 0);
    }
}
