/* Noah Richards
 * 7/23/2021 - 7/23/2021
 * CameraMovement.cs - Movement code for camFlyAround for Project Lake Ontario
 * Some code taken from FirstPersonLook.cs, other code based off of various tutorials
 */

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Vector2 currentMouseLook;
    Vector2 appliedMouseDelta;
    public Rigidbody collider;
    public float sensitivity = 1;
    public float smoothing = 2;
    public float speed = 5;
    public KeyCode boostKey = KeyCode.LeftShift;

    void Reset()
    {
        //character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Initialize the camera's position and collision
        transform.rotation = Quaternion.identity;
        collider = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float currentSpeed = speed;

        // Get smooth mouse look
        Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
        appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
        currentMouseLook += appliedMouseDelta;
        currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);

        // Rotate the camera to match the user's mouse movements
        transform.localRotation = Quaternion.Euler(-currentMouseLook.y, currentMouseLook.x, 0);
        //transform.Rotate(-smoothMouseDelta.y, smoothMouseDelta.x, 0, Space.Self);

        // Let the user move faster by holding down the designated "boost" key
        if (Input.GetKey(boostKey))
            currentSpeed *= 5;

        // Set the camera collider's velocity based on the user's 
        collider.velocity = Vector3.zero;
        collider.velocity += currentSpeed * (transform.forward * Input.GetAxis("Vertical"));
        collider.velocity += currentSpeed * (transform.right * Input.GetAxis("Horizontal"));
    }
}
