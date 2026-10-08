using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction movement;

    private Vector3 mousePosition;

    Rigidbody2D myRigidbody2D;

    public float enginePower;



    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        movement.Enable();

    }

    
    void Update()
    {
      
            Vector2 movementForce = movement.ReadValue<Vector2>();

            mousePosition = Input.mousePosition;

            Vector3 mouseToWorldPos =
                Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 direction =
                mouseToWorldPos - transform.position;

            float angle =
                Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.eulerAngles =
                new Vector3(0, 0, angle);

            Vector2 move =
                Quaternion.Euler(0, 0, -angle) * movementForce;

            myRigidbody2D.AddForce(
                move.normalized * enginePower
            );
      

    }
}
