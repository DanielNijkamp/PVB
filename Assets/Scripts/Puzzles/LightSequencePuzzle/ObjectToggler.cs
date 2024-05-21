using UnityEngine;

public sealed class  ObjectToggler : MonoBehaviour
{
    [SerializeField] private Renderer buttonMaterial;
    [SerializeField] private Material active;
    [SerializeField] private Material unactive;
    private bool isActive;
   public void ToggleObject()
    {
        isActive = !isActive;
        buttonMaterial.material = isActive ? active : unactive;
    }
    public bool GetActive()
    {
        return isActive;
    }
}
