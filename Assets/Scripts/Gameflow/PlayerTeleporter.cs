using UnityEngine;

public sealed class PlayerTeleporter : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Transform target;
    
    public void Teleport()
    {
        foreach (var player in playerManager.players)
        {
            player.transform.position = target.position;
        }
    }
}
