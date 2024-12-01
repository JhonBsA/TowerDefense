using System.Collections;
using UnityEngine;

public class LightTransitionManager : MonoBehaviour
{
    public Light directionalLight; 
    public Gradient lightGradient; 
    public float transitionDuration; 

    private float elapsedTime = 0f; // Track the elapsed time.

    // Call this to start the transition.
    public void StartLightTransition()
    {
        StartCoroutine(TransitionLight());
    }

    private IEnumerator TransitionLight()
    {
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration); // Normalize time.
            if (directionalLight != null)
            {
                directionalLight.color = lightGradient.Evaluate(t);
            }
            yield return null; // Wait for the next frame.
        }
    }

    // Optionally, reset the transition if needed (e.g., for level restarts).
    public void ResetTransition()
    {
        elapsedTime = 0f;
        if (directionalLight != null)
        {
            directionalLight.color = lightGradient.Evaluate(0f); // Reset to the first color.
        }
    }
}
