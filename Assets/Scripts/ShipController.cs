using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float strafeSpeed = 5f;
    public float hoverSpeed = 3f;

    public float lookRateSpeed = 80f;
    private Vector2 lookInput;
    private Vector2 screenCenter;
    private Vector2 mouseDistance;

    private float rollInput;
    public float rollSpeed = 80f;
    public float rollAcceleration = 3f;

    private float forwardAcceleration = 2f;
    private float strafeAcceleration = 1.5f;
    private float hoverAcceleration = 1.5f;

    private float activeForwardSpeed;
    private float activeStrafeSpeed;
    private float activeHoverSpeed;

    public ParticleSystem boosterL;
    public ParticleSystem boosterM;
    public ParticleSystem boosterR;



    private void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;
        Cursor.lockState = CursorLockMode.Confined;

        boosterL.Stop();
        boosterM.Stop();
        boosterR.Stop();
    }


    private void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);



        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        
        if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
        {
            boosterL.Play();
            boosterM.Play();
            boosterR.Play();
        }
        else { boosterL.Stop(); boosterM.Stop(); boosterR.Stop(); }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.forward * activeForwardSpeed * 5 * Time.deltaTime;
        }

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);
        
    }

    

}

