using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float pitchspeed =30 ;
    public float verticalInput;
    public float horizontalInput;
    public Quaternion direction;
   
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput =  Input.GetAxis("Horizontal");
        // move the plane forward at a constant rate

        // change back to forward  in local using transform


        // tilt the plane up/down based on up/down arrow keys

        // add in multiple of verticle input - pressing the downkey makes the plane pull back and vice versa


// turned speed down in the inspector. Add tim.deltaTIme


        direction = Quaternion.Euler(Time.deltaTime * verticalInput *rotationSpeed,0, Time.deltaTime * -1* horizontalInput * pitchspeed);
        transform.rotation = transform.rotation * direction;


              

        
       
        transform.Translate(Vector3.forward * speed);

    }
}
