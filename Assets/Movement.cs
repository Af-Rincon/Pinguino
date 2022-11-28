using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 moveForce;
    public float moveSpeed = 205;
    public float maxSpeed = 610;
    public float steerAngle = 10;
    public float drag = 0.98f;
    public float traction = 0.6f;

    private Rigidbody rb;
    private bool floating = false;
   

    private float _timeHeld = 0.0f;
    private float _timeForFullJump = 2.0f;
    public float _minJumpForce = 5.0f;
    public float _maxJumpForce = 22.0f;



    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento Vertical
        moveForce += transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += moveForce *Time.deltaTime;

        //Friccion
        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);

        //Movimiento Horizontal
        float steerInput  = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * moveForce.magnitude * steerAngle *Time.deltaTime);

        //Traccion
        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime)*moveForce.magnitude;

        if (Input.GetKeyDown(KeyCode.Space))
         {
             _timeHeld = 0f;
         }
         if (Input.GetKey(KeyCode.Space))
         {
             _timeHeld += Time.deltaTime;
         }
          if (Input.GetKeyUp(KeyCode.Space)&&floating==false)
         {
             jump();
         }

         if(Input.GetKey(KeyCode.J)&&floating==true)
         {
            this.transform.Rotate(0,3,0);
         }

         if(Input.GetKey(KeyCode.K)&&floating==true)
         {
            this.transform.Rotate(0,0,3);
         }
       
    }

    private void jump()
    {
        float verticalJumpForce = ((_maxJumpForce - _minJumpForce) * (_timeHeld / _timeForFullJump)) + _minJumpForce;

        if (verticalJumpForce > _maxJumpForce)
        {
             verticalJumpForce = _maxJumpForce;
        }

        rb.AddForce(new Vector3(0,verticalJumpForce,0), ForceMode.Impulse);
        floating = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        floating = false;
    }
}
