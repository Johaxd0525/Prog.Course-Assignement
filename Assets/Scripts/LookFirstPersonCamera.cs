using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class LookFirstPersonCamera : MonoBehaviour
{
    public float sensX = 500f;
    public float sensY = 500f;
    public float interactDistance = 6f;

    public new Transform camera;
    public float eyeHeight = 1f;

    //Private Varibles
    float xRotation;
    float yRotation;
    private Cookable currentCookable;

    void Start()
    {
        Cursor.visible = false; //Locks Cursor
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = cameraTargetPosition;
    }

  
    void Update()
    {
        // Create usable mouse movement inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        // Prevent camera from turning upside down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Set rotation of camera and character
        transform.eulerAngles = new Vector3(0f, yRotation, 0f);
        camera.eulerAngles = new Vector3(xRotation, yRotation, 0f);

        // Move camera
        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = Vector3.Lerp(camera.position, cameraTargetPosition, 0.5f);

        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(camera.position, camera.forward * interactDistance, out var hit);

            if (hit.collider && hit.collider.GetComponent<Cookable>())
            {
                hit.collider.GetComponent<Cookable>().SetCamera(camera);
                currentCookable = hit.collider.GetComponent<Cookable>();
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (currentCookable != null)
            {
                currentCookable.camera = null;
                currentCookable = null;
            }
        }
    }
}
