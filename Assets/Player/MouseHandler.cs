
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    // horizontal rotation speed
    [SerializeField] float horizontalSpeed = 1f;
    // vertical rotation speed
    [SerializeField] float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    [SerializeField] private bool lockMouse = true;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (lockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}

