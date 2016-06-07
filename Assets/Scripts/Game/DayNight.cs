using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour
{
    public float speed = 10;
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}