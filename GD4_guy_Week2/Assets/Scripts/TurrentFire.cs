using UnityEngine;

public class TurrentFire : MonoBehaviour
{

    // public Timer Timer;
    public float v_localTimer;
    public float v_ShotInterval=5;
    public GameObject Shot;
   // public GameObject Newshot;
  //  public Rigidbody rb;
    public Rigidbody rb1;
    public float v_shotPower=100;
  //  public Vector3 v_shotOffset = new Vector3(3, 0, 0);
    public Vector3 v_shotDirection;
    public GameObject v_Firepoint;
    public AudioSource firesound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
       firesound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        v_localTimer += Time.deltaTime;
        if (v_localTimer > v_ShotInterval )
        {
            v_localTimer = 0;  

            firesound.Play();

            v_shotDirection = transform.eulerAngles;

            GameObject NewShot = Instantiate(Shot, v_Firepoint.transform.position,Quaternion.identity);

           rb1 = NewShot.GetComponent<Rigidbody>();

            NewShot.transform.eulerAngles = v_shotDirection;

            rb1.AddForce(NewShot.transform.forward *  v_shotPower);




        }

    }
}
