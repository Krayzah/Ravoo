using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AdaptiveCanvasScaler : MonoBehaviour
{
    private CanvasScaler scaler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaler = GetComponent<CanvasScaler>();
        AdjustMatch();
    }

    void AdjustMatch()
    {
        float screenAspect = (float)Screen.width / Screen.height;
        float referenceAspect = scaler.referenceResolution.x / scaler.referenceResolution.y;
        scaler.matchWidthOrHeight = screenAspect > referenceAspect ? 1f : 0f;
    }
}
