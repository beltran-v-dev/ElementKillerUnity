using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class shake : MonoBehaviour
{
    public float ShakeDuration = 0.3f; // Duration of the shake effect
    public float ShakeAmplitude = 1.2f; // Intensity of the shake
    public float ShakeFrequency = 2.0f; // Frequency of the shake

    private float ShakeElapsedTime = 0f; // Timer for the shake effect

    public CinemachineVirtualCamera VirtualCamera; // Reference to the virtual camera
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise; // Noise module for camera shaking

    private void Start()
    {
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemic" || collision.gameObject.tag == "Enemic_2" || collision.gameObject.tag == "Enemic_3")
        {
            // Trigger the camera shake when colliding with an enemy
            shaking();
        }
    }

    private void Update()
    {
        // Update camera shake effect if needed
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            if (ShakeElapsedTime > 0)
            {
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

                ShakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                // Reset camera noise when shake is done
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }
    }

    public void shaking()
    {
        // Trigger the camera shake effect
        ShakeElapsedTime = ShakeDuration;
    }
}
