using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Vector3 force = Vector3.zero;
    [SerializeField]
    private float power = 1;
    private Rigidbody _rb;
    private bool isKeyDown;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        isKeyDown = false;
    }

    void FixedUpdate()
    {
        _rb.AddForce(Vector3.forward * power, ForceMode.Acceleration);
        // if (isKeyDown) _rb.AddForce(force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _rb.AddForce(force, ForceMode.Impulse);
        // isKeyDown = true ? Input.GetKeyDown(KeyCode.Space) : false;
    }
}
