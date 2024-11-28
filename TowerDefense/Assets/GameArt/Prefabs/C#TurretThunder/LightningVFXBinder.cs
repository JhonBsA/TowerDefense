using UnityEngine;
using UnityEngine.VFX;

public class LightningVFXBinder : MonoBehaviour
{
    public Transform startPoint;
    public Transform midPoint1;
    public Transform midPoint2;
    public Transform target;
    public VisualEffect LightningVFX; // Reference to the VFX component

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null && LightningVFX != null)
        {
            UpdateVFXGraph(startPoint.position, target.position);
        }
    }

    void UpdateVFXGraph(Vector3 origin, Vector3 lightningTarget)
    {
        if (LightningVFX == null)
        {
            Debug.LogWarning("[LightningVFXBinder] VFX Component is not assigned!");
            return;
        }

        LightningVFX.SetVector3("Origin", origin);
        LightningVFX.SetVector3("LightningTarget", lightningTarget);

        // Optionally calculate midpoints dynamically for more realistic effects
        Vector3 mid1 = Vector3.Lerp(origin, lightningTarget, 0.3f);
        Vector3 mid2 = Vector3.Lerp(origin, lightningTarget, 0.7f);

        LightningVFX.SetVector3("MidPoint1", mid1);
        LightningVFX.SetVector3("MidPoint2", mid2);
    }
}
