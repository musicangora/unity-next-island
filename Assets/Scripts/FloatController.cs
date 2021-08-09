using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatController : MonoBehaviour
{
    // 複数のSphereColliderから浮力を計算し親オブジェクトに反映させる
    public GameObject Plane;
    public GameObject ParentObj;
    private Rigidbody _rb;
    private Transform _parentTransform;
    private float _radius;
    private SphereCollider _sphereColl;
    private const float PI = 3.141592f;
    private bool isUnderWater;
    // Start is called before the first frame update
    void Start()
    {
        _sphereColl = GetComponent<SphereCollider>();
        _parentTransform = ParentObj.GetComponent<Transform>();
        _rb = ParentObj.GetComponent<Rigidbody>();
        
        // 親のスケールから自身のスケールを計算
        Vector3 parentScale = _parentTransform.localScale;
        float maxScale = Mathf.Max(parentScale.x, parentScale.y, parentScale.z);
        _radius = _sphereColl.radius * maxScale;
        isUnderWater = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   // 水中にあれば浮力を加える
        if (isUnderWater) AddBuoyancy();
    }

    void OnTriggerStay(Collider collider)
    {
        isUnderWater = true;
    }

    void OnTriggerExit(Collider collider)
    {
        isUnderWater = false;
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
        _rb.AddForceAtPosition(new Vector3(0, volume*9.8f, 0), gameObject.transform.position);
    }
}
