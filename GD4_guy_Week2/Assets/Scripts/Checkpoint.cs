using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject collision;
    public string v_tagChk;
   // public GameObject Player;
    public string v_playname;
    public PlayerMove PlayerMove;
    public TextMeshPro Display;
    public float v_checkPointTime;
    public Timer Timer;
    public float v_checkPointDisplayDuration;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
       
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerMove.f_chkPoint == true && Timer.v_timer < v_checkPointDisplayDuration + v_checkPointTime)

        {
            Display.text = "Checkpoint reached";
        }

        else
        {
            Display.text = "";
        }
    }

    void OnTriggerEnter(Collider collision)
    {

        v_playname = collision.gameObject.name;

        v_checkPointTime = Timer.v_timer;

       

        PlayerMove.f_chkPoint = true;

    }
       
    
}
