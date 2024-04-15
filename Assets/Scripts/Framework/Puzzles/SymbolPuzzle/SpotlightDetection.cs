using System.Collections.Generic;
using UnityEngine;

public class SpotlightDetection : MonoBehaviour
{
    private Light light;
    [Header("configuration")]
    [SerializeField] private  float coneAngle;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float capsuleRadius = 0.5f;
    [SerializeField] private float capsuleLength = 5f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private List<Transform> lastHitObjects = new List<Transform>();
    [SerializeField] private List<Transform> currentHitObjects = new List<Transform>();
    [Header("Debug")]
    [SerializeField] private bool debugGyzmos;

    private void Start()
    {
        light = GetComponent<Light>();
        coneAngle = light.range;
    }

    void Update()
    {
        Vector3 capsuleDirection = transform.forward;
        Vector3 capsuleStart = transform.position;
        Vector3 capsuleEnd = transform.position + capsuleDirection * capsuleLength;

        RaycastHit[] hits = Physics.CapsuleCastAll(capsuleStart, capsuleEnd, capsuleRadius, capsuleDirection, maxDistance, layerMask);
        currentHitObjects.Clear();
        foreach (RaycastHit hit in hits)
        {
            Transform hitTransform = hit.transform;
            if (!currentHitObjects.Contains(hitTransform))
            {
                currentHitObjects.Add(hitTransform);
                hitTransform.GetComponent<SpotlightDDetectionHandler>().OnDetected();
                if(debugGyzmos)
                Debug.DrawLine(transform.position, hit.point, Color.red);
            }
        }
        for (int i = 0; i < lastHitObjects.Count; i++)
        {
            if (!currentHitObjects.Contains(lastHitObjects[i]))
            {
                lastHitObjects[i].GetComponent<SpotlightDDetectionHandler>().OnDetectionLost();
                lastHitObjects.Remove(lastHitObjects[i]);
            }
        }
        for (int i = 0; i < currentHitObjects.Count; i++)
        {
            if (!lastHitObjects.Contains(currentHitObjects[i]))
            {
                lastHitObjects.Add(currentHitObjects[i]);
            }
        }
        if(debugGyzmos)
        DebugDrawCapsule(capsuleStart, capsuleEnd, capsuleRadius, Color.green);
    }

    void DebugDrawCapsule(Vector3 start, Vector3 end, float radius, Color color)
    {
        Vector3 up = (end - start).normalized * radius;
        Vector3 forward = Vector3.Slerp(up, -up, 0.5f);
        Vector3 right = Vector3.Cross(up, forward).normalized * radius;

        Debug.DrawLine(start + right, end + right, color);
        Debug.DrawLine(start - right, end - right, color);
        Debug.DrawLine(start + forward, end + forward, color);
        Debug.DrawLine(start - forward, end - forward, color);

        Debug.DrawRay(start + right, (start + forward - start - right).normalized * radius, color);
        Debug.DrawRay(start - right, (start - forward - start + right).normalized * radius, color);
        Debug.DrawRay(end + right, (end + forward - end - right).normalized * radius, color);
        Debug.DrawRay(end - right, (end - forward - end + right).normalized * radius, color);
    }
}
