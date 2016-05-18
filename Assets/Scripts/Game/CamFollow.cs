using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour 
{
	public Transform LookPoint, movePoint;
	public Rigidbody rBody;
	Vector3 refV3 = Vector3.zero;
    public float dampTime;
    Transform myT;

    void Start()
    {
        myT = transform;
    }

	void FixedUpdate()
	{
		this.transform.LookAt(LookPoint.position, Vector3.up);
		//transform.position = Vector3.SmoothDamp(transform.position, movePoint.position, ref refV3, dampTime, 3000f, Time.deltaTime);

        myT.position = Vector3.Lerp(myT.position, movePoint.position, Time.deltaTime * dampTime);

		//if(Input.GetKeyDown(KeyCode.R))
			//Application.LoadLevel(0);

		//if(Input.GetKeyDown(KeyCode.Escape))
			//Application.Quit();
	}
}