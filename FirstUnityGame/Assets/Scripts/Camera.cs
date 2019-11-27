using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject DummySkeleton;
    private Vector3 _positionOffset;

    void Start()
    {
        _positionOffset = transform.position - DummySkeleton.transform.position;
    }


    void Update()
    {
        transform.position = new Vector3(DummySkeleton.transform.position.x + _positionOffset.x, 6, DummySkeleton.transform.position.z + _positionOffset.z);
    }
}
