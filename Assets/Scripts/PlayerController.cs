using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField]
    public float moveSpeed;
    private float originalMoveSpeed;
    private Vector3 playerVelocity;
    private TimeStop timeStop; 
    public float timeStoppedSpeed;
    public GameObject Trail;
    

    private CharacterController controller;

    private Vector2 movement;
    private Vector2 aim;

    private Rigidbody rb;

    private Camera mainCamera;
    // Start is called before the first frame update
    void Awake()
    {
        originalMoveSpeed = moveSpeed;
        controller = GetComponent<CharacterController>();
        mainCamera = FindObjectOfType<Camera>();
        timeStop = FindObjectOfType<TimeStop>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuLogic.isPaused) return;
        HandRotation();
        HandleMoveInput();
    }

    public void HandleMoveInput () //Handles movement input of player make sure it is smooth and stops when key is pressed.
    {
        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(H, 0, V).normalized;
        float deltaTime = timeStop.isTimeStopped ? Time.fixedDeltaTime : Time.deltaTime; // Use fixedDeltaTime if time is stopped
        float currentSpeed = timeStop.isTimeStopped ? timeStoppedSpeed : moveSpeed; // Use timeStoppedSpeed if time is stopped

        controller.Move(move * deltaTime * currentSpeed); //Time.deltaTime and moveSpeed
       playerVelocity.y += gravityValue * deltaTime;
       controller.Move(playerVelocity * deltaTime);
    }


    

    void HandRotation() //Handles totaion of Player model so that it will face the mouse position.
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            LookAt(point);
        }
    }

    private void LookAt(Vector3 LookPoint) //Look point for mouse when not on plane
    {
        Vector3 heightCorrectedPoint = new Vector3(LookPoint.x, transform.position.y, LookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void StartSpeedBoost(float boostedSpeed, float duration)
    {
        StartCoroutine(SpeedBoost(boostedSpeed, duration));
    }

    private IEnumerator SpeedBoost(float boostedSpeed, float duration)
    {
        moveSpeed = boostedSpeed;
        Trail.SetActive(true);
        yield return new WaitForSeconds(duration);
        moveSpeed = originalMoveSpeed;
        Trail.SetActive(false);
        Debug.Log("Speed Boost ended");
    }

}
