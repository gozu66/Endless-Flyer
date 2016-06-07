using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CamFollow : MonoBehaviour 
{
	public Transform LookPoint, movePoint;
	Vector3 refV3 = Vector3.zero;
    public float dampTime;
    Transform myT;

    void Start()
    {
        myT = transform;
    }

	void FixedUpdate()
	{
        if (LookPoint != null)
        {
            this.transform.LookAt(LookPoint.position, Vector3.up);
            myT.position = Vector3.SmoothDamp(transform.position, movePoint.position, ref refV3, dampTime);
        }
		if(Input.GetKeyDown(KeyCode.R))
			SceneManager.LoadScene(0);
        
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
}