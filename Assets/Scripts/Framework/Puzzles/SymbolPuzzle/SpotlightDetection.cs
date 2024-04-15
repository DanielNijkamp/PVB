using System.Collections.Generic;
using UnityEngine;

public sealed class SpotlightDetection : MonoBehaviour
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
    }
}
