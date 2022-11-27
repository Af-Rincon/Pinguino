using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 moveForce;
    public float moveSpeed = 50;
    public float maxSpeed = 15;
    public float steerAngle = 20;
    public float drag = 0.98f;
    public float traction = 1;

    private Rigidbody rb;
    private bool floating = false;

    public float _timeHeld = 0.0f;
    public float _timeForFullJump = 2.0f;
    public float _minJumpForce = 3.0f;
    public float _maxJumpForce = 15.0f;

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
