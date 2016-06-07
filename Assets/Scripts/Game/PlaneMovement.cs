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
    public GameObject explosionPtl;
    //bool isCrashed;
    Vector3 startPos;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

	void FixedUpdate()
    {
            speed = Mathf.Clamp(speed, 500, 2000);
            rBody.AddForce((localDirection.forward * speed) * Time.deltaTime, myForce);

            speed += (Input.GetAxis("Triggers1") * -1) * 150;
            rBody.AddRelativeTorque(pitchSpeed * Input.GetAxis("LStick1Y") * Time.deltaTime, yawSpeed * Input.GetAxis("RStick1X") * Time.deltaTime, -rollSpeed * Input.GetAxis("LStick1X") * Time.deltaTime, myForce);

            speed += Input.GetAxis("Mouse ScrollWheel") * 600;
            rBody.AddRelativeTorque(pitchSpeed * Input.GetAxis("Vertical") * Time.deltaTime, yawSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, -rollSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, myForce);
    }

    void OnCollisionEnter(Collision col)
    {
        StartCoroutine("Explode");
    }

    IEnumerator Explode()
    {
        rBody.velocity = Vector3.zero;
        Camera.main.GetComponent<CamFollow>().enabled = false;
        Transform child = transform.GetChild(0);
        child.gameObject.SetActive(false);
        Instantiate(explosionPtl, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        transform.position = startPos;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        child.gameObject.SetActive(true);
        Camera.main.GetComponent<CamFollow>().enabled = true;
    }
}
 