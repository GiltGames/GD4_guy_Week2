using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Variables
    Vector3 v_P1_vec;
    
    float v_Accel=40;
    float v_brakeforce =0.3f;
    float v_turnspeed = 0.3f;
    float v_forceinput;
    float v_sideinput;
    Rigidbody rb;
    Vector3 v_localForce;
    Vector3 v_AccelComp;
    Vector3 v_LocalinEuluer;
    float v_uprightdamping =0.2f;
    float v_limitrot = 30f;
    float v_angDamp = .85f;
    float v_speed;
    float v_drag =0.5f;
    bool f_grounded;
    bool f_onDust;
    string v_touching;
    GameObject v_collide;
    GameObject v_terrain;
    TagField v_terratintag;
    string v_tertag = "Dust";
    string v_tag;
    float v_highgear = 4f;
    float v_highGearInput;
    bool v_highgearF;
    bool v_highgearB;
    float v_highgearMv=0;
    float v_lowerSpeedLimitforTurn =0.1f;

    public FollowPlayer FollowPlayer;


    public bool f_chkPoint = false;
    public bool f_end = false;
    public bool f_finish = false;
    public string v_playerIndex;

    public StartScript StartScript;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs

        // HAs Game Started
                
        //Input for movement only active when touching

        if (v_touching != "" && StartScript.v_GAMESTART == true)
        {

            v_forceinput = Input.GetAxis("Vertical"+v_playerIndex);
            v_sideinput = Input.GetAxis("Horizontal"+v_playerIndex);
            v_highgearMv = Input.GetAxis("Extra" + v_playerIndex);
            

            
         

        }
          
            v_localForce = (transform.forward);

            v_LocalinEuluer = transform.localEulerAngles;
            v_speed = rb.linearVelocity.magnitude;
        
        
        //


        // Check to see what it is on, and modify Input
        
        if(v_tag ==v_tertag)
        
            {
            v_localForce = v_localForce * v_drag;
        }

        if (v_touching == "")
        {
            v_localForce = Vector3.zero;
            v_sideinput = 0;
        }

        // Stop turning if speed is zero (or very low)

        if(v_speed < v_lowerSpeedLimitforTurn && v_highgearMv==0)
        {
            v_sideinput = 0;
        }

        //reverse turn direction while moving backwards 

        if(v_highgearMv <0 )
        {
            v_sideinput = -1 * v_sideinput;
        }
        
        //reverse turn directio if rear view camera is on


       if (FollowPlayer.v_camView == 2)
      {
          v_sideinput = -1 * v_sideinput;
       }



        //If input, apply changes

        if (v_forceinput > 0)
        {
           // rb.AddForce(v_Accel * v_forceinput * v_localForce, ForceMode.Acceleration);
           rb.linearVelocity = rb.linearVelocity + (Time.deltaTime* v_localForce*v_Accel*v_forceinput);

        }
        if (v_forceinput < 0)
        {
            //rb.AddForce(v_brakeforce * -v_forceinput* v_localForce, ForceMode.Acceleration);

            rb.linearVelocity = rb.linearVelocity * (1-( Time.deltaTime * v_brakeforce));

          //  rb.linearVelocity = rb.linearVelocity + (v_localForce * v_brakeforce * v_forceinput);

            if (rb.linearVelocity.magnitude < 0)
            {
                rb.linearVelocity = Vector3.zero;
            }
        }
            transform.Rotate (0,v_turnspeed*v_sideinput,0);

        transform.Rotate(-v_localForce.x * v_uprightdamping *Time.deltaTime, 0, -v_localForce.z * v_uprightdamping *Time.deltaTime);

        // stop it overbalancing

        if(transform.localEulerAngles.x < (360- v_limitrot) && transform.localEulerAngles.x>180)
        {
            transform.localEulerAngles = new Vector3((360-v_limitrot), transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        
        if (transform.localEulerAngles.x > v_limitrot && transform.localEulerAngles.x <180)
        {
            transform.localEulerAngles = new Vector3(v_limitrot, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }


        if (transform.localEulerAngles.z < (360 - v_limitrot) && transform.localEulerAngles.z > 180)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y,(360 - v_limitrot));
        }

        if (transform.localEulerAngles.z > v_limitrot && transform.localEulerAngles.z< 180)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, v_limitrot);
        }

        rb.angularVelocity = rb.angularVelocity *v_angDamp;


      /// High Gear Movement FWD/BACM
        
            transform.Translate(Vector3.forward * Time.deltaTime * v_highgear *v_highgearMv);
        



        //Escape

        if(Input.GetKey(KeyCode.Escape))
        {
            StartScript.v_GAMESTART = false;
            SceneManager.LoadScene(0);
        }



    }


    void OnCollisionStay (Collision hit)
    {


        v_collide = hit.gameObject;
        v_touching = hit.gameObject.name;
        v_tag = hit.gameObject.tag;

    }

   void OnCollisionExit(Collision hit)
    {
        v_touching = "";
        v_collide = null;
        v_tag = ""; 
    }





}
