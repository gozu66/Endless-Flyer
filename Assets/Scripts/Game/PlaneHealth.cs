using UnityEngine;
using System.Collections;

public class PlaneHealth : MonoBehaviour {

//	public static bool isCrashed;
//	public GameObject explosion;
////	Vector3 cachedPosition;
//
//	void Start()
//	{
//		cachedPosition = transform.position;
//	}
//	void OnCollisionEnter(Collision other)
//	{
//		if(other.relativeVelocity.magnitude >= 100)
//		{
//			StartCoroutine("Destruct");
//		}
//	}
//
//	IEnumerator Destruct()
//	{
//		rigidbody.isKinematic = true;
////		isCrashed = true;
////		Instantiate(explosion, transform.position, transform.rotation);
//		yield return new WaitForSeconds(2);
////		transform.position = cachedPosition;
//		Application.LoadLevel(0);
//	}
}
