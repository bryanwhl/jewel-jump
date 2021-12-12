using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floatate : MonoBehaviour
{
    public Vector3 initialPos;
    public float amplitude = 0.1f;
    public float rotateSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(initialPos.x, initialPos.y + (Mathf.Sin(Time.time) * amplitude), initialPos.z);
        transform.position = newPosition;
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
