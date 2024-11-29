using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public Vector3 startoffset;
    public Vector3 offset;

    // Assign to player in the inspector


    // Start is called before the first frame update
    void Start()
    {
     // add in initial offset
     // move camera to behin the plane and turn it 180 degrees  
     //point it at the plane dynmatically
        
        startoffset =  transform.position - plane.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //camera is set to behind the plane in the plane's local space, keeping offset constant for plane local
        
        offset = plane.transform.TransformDirection(startoffset);

        

        
        transform.position = plane.transform.position + offset;
        

        //camera looks at the plane

        transform.LookAt(plane.transform.position);
    }
}
