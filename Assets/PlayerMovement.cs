using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveInput;
    private float turnInput;

    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    public float maxSpeed = 10f;
    
    public bool speedBoost;

    public bool speedBoostPowerUp;
    public bool missilePowerUp;  

    public Rigidbody sphereRB;
    
    public GameObject engineStart;
    public GameObject engineLoop;

    void Start()
    {
        
        sphereRB.transform.parent = null;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
        
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(engineStart);
        }
        if(moveInput == 0)
        {
            //GameObject thashLoop = gameObject.Find("engine Sound");

            //thashLoop.kill();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(speedBoostPowerUp)
            {
                SpeedBoostOn();
            }
        }
        if(sphereRB.velocity.magnitude > maxSpeed)
        {
            sphereRB.velocity = Vector3.ClampMagnitude(sphereRB.velocity, maxSpeed);
        }
        else{
            transform.position = sphereRB.transform.position + new Vector3(0,.1f,0);
        }
        
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(0, newRotation * 2f, 0, Space.World);
        }
        else{
            transform.Rotate(0, newRotation, 0, Space.World);
        }
        
    }
        
    private void FixedUpdate() 
    {
        if(sphereRB.velocity.magnitude > maxSpeed)
        {
            sphereRB.velocity = Vector3.ClampMagnitude(sphereRB.velocity, maxSpeed);
        }
        else
        {
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);   
        }
    }

    void OnCollisionEnter (Collision other) { 
        if(other.gameObject.tag=="Grass") {
            maxSpeed = 5f;
        }

    }

    public void SpeedBoostOn()
    {
        Debug.Log("speed boost");
        maxSpeed = 40f;
        fwdSpeed = 40f;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    public void blueBallon()
    {
        speedBoostPowerUp = true;
    }

    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        maxSpeed = 10f;
        fwdSpeed = 10f;
    }
}
