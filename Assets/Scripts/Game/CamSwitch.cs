using UnityEngine;
using System.Collections;

public class CamSwitch : MonoBehaviour {

	Camera mainCam;
	CamFollow mainCamFollow;

	public Transform fpCamTarget, fpCamParent;
	Vector3 cachedPosition;

	void Start()
	{
		mainCam = Camera.main;
		mainCamFollow = mainCam.GetComponent<CamFollow>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab))
			FPSwitch();
	}

	void FPSwitch()
	{
		if(mainCamFollow.enabled)	{
			cachedPosition = mainCam.transform.position;
			mainCamFollow.enabled = false;
			mainCam.transform.position = fpCamTarget.position;
			mainCam.transform.rotation = fpCamParent.rotation;
			mainCam.transform.parent = fpCamParent;
		}
		else {
			mainCam.transform.parent = null;
			mainCam.transform.position = cachedPosition;
			mainCamFollow.enabled = true;
		}
	}

}
