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
        speed = Mathf.Clamp(speed, 500, 2000);
        rBody.AddForce((localDirection.forward * speed) * Time.deltaTime, myForce);

        speed += (Input.GetAxis("Triggers1") * -1) * 150;
        rBody.AddRelativeTorque(pitchSpeed * Input.GetAxis("LStick1Y") * Time.deltaTime, yawSpeed * Input.GetAxis("LStick1X") * Time.deltaTime, -rollSpeed*Input.GetAxis("RStick1X") * Time.deltaTime, myForce);

        speed += Input.GetAxis("Mouse ScrollWheel") * 600;
        rBody.AddRelativeTorque(pitchSpeed * Input.GetAxis("Vertical") * Time.deltaTime, yawSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, -rollSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, myForce);
    }
}
 