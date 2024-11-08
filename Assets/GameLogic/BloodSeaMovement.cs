using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSeaMovement : MonoBehaviour
{
    public BloodManager bloodManager; // Value should range from 0 to 10000
    private float minY = -2f;
    private float maxY = -9f;
    private float smoothTime = 0.3f; // Time to reach the target position smoothly
    private float velocity = 0f; // Required by SmoothDamp to track the rate of change
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the normalized value of BloodCount between 0 and 10000
        float normalizedBloodCount = Mathf.Clamp01((float)bloodManager.bloodCount / 99999);

        // Calculate the target Y position by lerping between minY and maxY based on normalizedBloodCount
        float targetY = Mathf.Lerp(maxY, minY, normalizedBloodCount);
        float smoothY = Mathf.SmoothDamp(transform.position.y, targetY, ref velocity, smoothTime);

        // Set the new position with smooth Y-axis transition, keeping X and Z positions unchanged
        transform.position = new Vector3(transform.position.x, smoothY, transform.position.z);
    }
}
