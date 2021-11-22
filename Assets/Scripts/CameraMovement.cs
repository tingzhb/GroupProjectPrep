using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 offset;
    [SerializeField]Transform player;
    [SerializeField]float smoothTime = 0.3f;
    Vector3 velocity = Vector3.zero;


    void Start() {
        offset = transform.position - player.position;
    }

    private void LateUpdate() {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
