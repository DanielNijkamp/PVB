using System.Collections;
using UnityEngine;

public sealed class PlayerTeleporter : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Transform target;

    [SerializeField] private float moveDuration;
    
    public void Teleport()
    {
        foreach (var player in playerManager.players)
        {
            StartCoroutine(MoveCoroutine(player.transform, target.transform));
        }
    }

    IEnumerator MoveCoroutine(Transform targetTransform, Transform endTransform)
    {
        float t = 0.0f;
        Vector3 start = targetTransform.position;
        Vector3 end = endTransform.position;
 
        while ( t < moveDuration )
        {
            t += Time.deltaTime;
            targetTransform.position = Vector3.Lerp( start, end, t/moveDuration);
            yield return null;
        }
    }
}
