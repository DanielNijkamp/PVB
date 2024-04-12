using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VisibilitySymbol : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        RevealToggle();
    }
    public void RevealToggle()
    {
        //reveal object
        meshRenderer.enabled = !meshRenderer.enabled;
    }
}
