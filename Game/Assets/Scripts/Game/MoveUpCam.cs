using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpCam : MonoBehaviour
{
    public Transform Camera;
    private Vector3 nowCamera;
    public float k, startY = 1.6f, camup = 0.0015f, speed = 0.4f;

    private void Start()
    {
        k = (Camera.localPosition.y - startY) / -Camera.localPosition.z;
        nowCamera = Camera.localPosition;
    }

    
    void Update()
    {
        if (Camera.localPosition.z > nowCamera.z)
        {
            Camera.localPosition = new Vector3(Camera.localPosition.x, Camera.localPosition.y + k * speed * Time.deltaTime, Camera.localPosition.z - (1f / k) * speed * Time.deltaTime);
        }
    }

    public void moveUp(int val)
    {
        nowCamera.y += k * val * camup;
        nowCamera.z -= (1f / k) * val * camup;
    }
}
