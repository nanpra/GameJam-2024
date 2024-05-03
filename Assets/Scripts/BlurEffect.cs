using Cinemachine;
using Cinemachine.PostFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurEffect : MonoBehaviour
{
    public float blurDuration = 5.0f;
    public float normalDuration = 2.0f;
    public float minFocusOffset = 0.1f;
    public float maxFocusOffset = 10.0f;

    private CinemachineVirtualCamera virtualCamera;
    private float timer;
    private bool isBlurred = false;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isBlurred)
        {
            if (timer >= blurDuration)
            {
                virtualCamera.GetComponent<CinemachineVolumeSettings>().m_FocusOffset = maxFocusOffset;
                isBlurred = false;
                timer = 0f;
            }
        }
        else
        {
            if (timer >= normalDuration)
            {
                virtualCamera.GetComponent<CinemachineVolumeSettings>().m_FocusOffset = minFocusOffset;
                isBlurred = true;
                timer = 0f;
            }
        }
    }
}