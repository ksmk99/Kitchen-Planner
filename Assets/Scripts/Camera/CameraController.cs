using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [Header("Rotation Speed")]
    [SerializeField] private float pitchSpeed = 2f;
    [SerializeField] private float yawSpeed = 2f;

    [Header("Rotation Limits")]
    [SerializeField]
    [Range(-180, 0)]
    private float leftLimit = -90;
    [SerializeField]
    [Range(0, 180)]
    private float rightLimit = 90;
    [SerializeField]
    [Range(0, 90)]
    private float topLimit = 75;
    [SerializeField]
    [Range(-90, 0)]
    private float botLimit = -55;

    [Header("Camera Move Speed")]
    [SerializeField]
    private float moveSpeed = 2f;

    [Header("Camera Zoom Speed")]
    [SerializeField]
    private float zoomSpeed = 10f;

    [SerializeField] private LayerMask UILayer;

    private Camera camera;
    private float yaw = 0f;
    private float pitch = 0f;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        CameraRotate();
        CameraMove();
        CameraZoom();
    }

    private void CameraZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed);
        }
    }

    private void CameraMove()
    {
        if (Input.GetMouseButton(2) && !Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            var moveDirection = new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0.0f);
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    private void CameraRotate()
    {
        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0) && !Input.GetMouseButton(2))
        {
            yaw += yawSpeed * Input.GetAxis("Mouse X");
            pitch -= pitchSpeed * Input.GetAxis("Mouse Y");

            yaw = Mathf.Clamp(yaw, leftLimit, rightLimit);
            pitch = Mathf.Clamp(pitch, botLimit, topLimit);

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
