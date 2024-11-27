using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; 

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position; 
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
