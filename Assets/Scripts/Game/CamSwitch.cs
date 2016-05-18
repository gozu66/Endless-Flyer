using UnityEngine;
using System.Collections;

public class CamSwitch : MonoBehaviour {

	Camera mainCam;
	CamFollow mainCamFollow;

	public Transform fpCamTarget, fpCamParent, camTarget;

	void Start()
	{
		mainCam = Camera.main;
		mainCamFollow = mainCam.GetComponent<CamFollow>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Joystick1Button0))
			FPSwitch();
	}

	void FPSwitch()
	{
		if(mainCamFollow.enabled)	{
			mainCamFollow.enabled = false;
			mainCam.transform.position = fpCamTarget.position;
			mainCam.transform.rotation = fpCamParent.rotation;
			mainCam.transform.parent = fpCamParent;
		}
		else {
			mainCam.transform.parent = null;
            mainCam.transform.position = camTarget.position;
            mainCam.transform.rotation = camTarget.rotation;
            mainCamFollow.enabled = true;
		}
	}

}
