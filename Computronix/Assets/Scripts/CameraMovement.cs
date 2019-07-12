using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerPos;
    [Range(0f, 0.5f)]
    public float xMargin = 0.45f;
    public float xMax = 100f;
    public float xMin = 1.6f;

    private Vector3 camPos = Vector3.zero;

    private void FixedUpdate()
    {
        UpdateCameraPosition();
        transform.position = camPos;
    }

    public void UpdateCameraPosition()
    {
        camPos = Camera.main.transform.position;
        Vector2 pPos = playerPos.position;

        if((pPos.x + xMargin > camPos.x + 0.5f && pPos.x + xMargin < xMax) || (pPos.x - xMargin < camPos.x - 0.5f && camPos.x > xMin))
        {
            camPos = new Vector3(Mathf.SmoothStep(camPos.x, pPos.x, 0.15f), camPos.y, camPos.z);
        }
    }
}
