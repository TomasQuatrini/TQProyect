using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float speed = 0.1f;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        transform.position = new Vector3(cameraTransform.position.x, transform.position.y, transform.position.z);
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
