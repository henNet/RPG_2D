using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(target.transform.position.x, 
          //                          target.transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        Vector3 des = target.transform.position + offset;
        Vector3 smooth = Vector3.Lerp(transform.position, des, 0.125f);

        transform.position = smooth;
    }
}
