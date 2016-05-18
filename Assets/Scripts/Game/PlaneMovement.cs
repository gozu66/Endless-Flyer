using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaneMovement : MonoBehaviour 
{
	public ForceMode myForce;
	public float rollSpeed, pitchSpeed, yawSpeed;
	public Transform localDirection;
	float speed = 1000;
    Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

	void FixedUpdate()
	{
        speed = Mathf.Clamp(speed, 500, 1500);
        rBody.AddForce((localDirection.forward * speed) * Time.deltaTime, myForce);
        //speed += (Input.GetAxis("Mouse ScrollWheel")*-1)*150f; 
        speed += (Input.GetAxis("Triggers1") * -1) * 150f;
        rBody.AddRelativeTorque(pitchSpeed * Input.GetAxis("LStick1Y") * Time.deltaTime, yawSpeed * Input.GetAxis("LStick1X") * Time.deltaTime, -rollSpeed*Input.GetAxis("RStick1X") * Time.deltaTime, myForce);

        print(speed);

        /*
        speed += (Input.GetAxis("Mouse ScrollWheel")*-1)*150f;
        rBody.AddRelativeTorque(0,0,(-rollSpeed*Input.GetAxis("Mouse Y") * Time.deltaTime), myForce);
        rBody.AddRelativeTorque((pitchSpeed*Input.GetAxis("Mouse X") * Time.deltaTime),0,0, myForce);
        rBody.AddRelativeTorque(0,(yawSpeed*Input.GetAxis("Horizontal")) * Time.deltaTime,0, myForce);
        */
    }
}
 