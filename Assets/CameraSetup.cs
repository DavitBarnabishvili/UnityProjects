using UnityEngine;

public class AdjustCameraAspect : MonoBehaviour
{
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        if (camera == null)
        {
            Debug.LogError("This script should be attached to a camera.");
            return;
        }

        float targetAspect = 16f / 9f; // Adjust this to your desired aspect ratio
        float currentAspect = (float)Screen.width / Screen.height;
        float scaleHeight = currentAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            camera.orthographicSize = camera.orthographicSize / scaleHeight;
        }
    }
}

