using UnityEngine;

public class HideOnPlay : MonoBehaviour
{
    public bool keepTransformActiveButHideRest;
    void Awake()
    {
        if(!keepTransformActiveButHideRest)gameObject.SetActive(false);

        DisableMeshesAndColliders(transform);
    }

    private void DisableMeshesAndColliders(Transform t)
    {
        foreach(Transform child in t)
        {
            DisableMeshesAndColliders(child);
        }
        if (t.TryGetComponent(out MeshRenderer mr)) mr.enabled = false;
        if (t.TryGetComponent(out Collider c)) c.enabled = false;
    }
}
