using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public GameObject Plane;
    public SphereCollider SphereCol;
    private float _radius;
    private const float PI = 3.141592f;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        //_col = GetComponent<SphereCollider>();
        _radius = SphereCol.radius * gameObject.transform.localScale.y;
        _rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collider)
    {
        AddBuoyancy();  // 浮力を加える
    }

    // 水中の体積を計算する
    float CalcVolume(float t, float r)
    {
        if (gameObject.transform.position.y <= -_radius)
        {
            return 4.0f/3.0f*PI*_radius*_radius*_radius;
        }
        float tmp1 = (t*t*t)*(-1.0f/3.0f);
        float tmp2 = r*r*t;
        float tmp3 = (2.0f/3.0f)*r*r*r;
        return (tmp1 + tmp2 + tmp3)*PI;
    }

    // 浮力を計算する
    void AddBuoyancy()
    {
        float posY = gameObject.transform.position.y - _radius;
        float underPlane = Plane.transform.position.y - posY;
        float t = underPlane - _radius;

        float volume = CalcVolume(t, _radius);
        _rb.AddForce(0, volume*9.8f, 0);
    }
}
