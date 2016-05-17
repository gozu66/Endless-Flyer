using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaneMovement : MonoBehaviour 
{
	public ForceMode myForce;
	public float rollSpeed, pitchSpeed, yawSpeed;
	public Transform localDirection;
	public ForceMode myForce2;
	float speed = 1000;

    Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

	void Update()
	{
		speed += (Input.GetAxis("Mouse ScrollWheel")*-1)*150f;
		speed = Mathf.Clamp(speed, 500, 1500);

        rBody.AddForce((localDirection.forward * speed) * Time.deltaTime, myForce);

        rBody.AddRelativeTorque(0,0,(-rollSpeed*Input.GetAxis("Mouse Y") * Time.deltaTime), myForce);
        rBody.AddRelativeTorque((pitchSpeed*Input.GetAxis("Mouse X") * Time.deltaTime),0,0, myForce);
        rBody.AddRelativeTorque(0,(yawSpeed*Input.GetAxis("Horizontal")) * Time.deltaTime,0, myForce);

        //print(speed);
	}
}