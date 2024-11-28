using TMPro;
using UnityEngine;

public class End : MonoBehaviour
{

    public GameObject collision;
    public string v_tagChk;
    // public GameObject Player;
    public string v_playname;
    public PlayerMove PlayerMove;
    public Timer Timer;
    public float v_EndDisplayDuration =2;
    public float v_LapTime;
    public TextMeshPro Display;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.f_end == true && Timer.v_timer < v_EndDisplayDuration + v_LapTime)

        {
            Display.text = "Lap 1: " + v_LapTime;
        }

        else
        {
            Display.text = "";
        }
    }



    void OnTriggerEnter(Collider collision)
    {

        v_playname = collision.gameObject.name;

        if (PlayerMove.f_chkPoint == true && PlayerMove.f_end == true)
        {
            PlayerMove.f_finish = true;

           



        }

        if (PlayerMove.f_chkPoint == true)
        {
            PlayerMove.f_end = true;

            v_LapTime = Time.time;

            PlayerMove.f_chkPoint = false;

        }

      

    }
}
