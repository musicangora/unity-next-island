using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float jumpPower = 1f;
    [SerializeField]
    private float speedForward = 1f;
    private Rigidbody _rb;
    private bool isJump;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isJump)
        {
            _rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = false;
        }
        
        _rb.AddForce(0f, 0f, Input.GetAxis("Vertical"));
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.position.y < 1.2f)
        {
            if (Input.GetKeyDown(KeyCode.Space)) isJump = true;
        }
    }
}
