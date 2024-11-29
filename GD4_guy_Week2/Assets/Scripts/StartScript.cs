using TMPro;
using UnityEngine;

public class StartScript : MonoBehaviour
{

    //Game Intro

    public Timer Timer;
    public bool v_GAMESTART = false;
    public TextMeshProUGUI TimeDsp;
    public TextMeshProUGUI StartText;
    public int v_NoofPlayers=0;
    public float v_BeforeTime = 0;
    public GameObject Cam0;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject CamZ;
    public GameObject v2P;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cam0.SetActive(false);
        Cam1.SetActive(false);
        Cam2.SetActive(false);  
        CamZ.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (v_GAMESTART == false)
        {
            Timer.v_timer = 0;

            TimeDsp.text = "";

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                v_NoofPlayers = 1;

                Cam0.SetActive(true);
                CamZ.SetActive(false);
                v2P.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                v_NoofPlayers = 2;

                CamZ.SetActive(false);
                Cam1.SetActive(true);
                Cam2.SetActive(true);  
            }

           

            }

        if (v_NoofPlayers > 0)
        {

            v_BeforeTime += Time.deltaTime;

            if (v_BeforeTime < 2)
            {
                StartText.text = "Get Ready";
            }

            if (v_BeforeTime < 3 && v_BeforeTime > 2)
            {
                StartText.text = "3";
            }

            if (v_BeforeTime < 4 && v_BeforeTime > 3)
            {
                StartText.text = "2";
            }


            if (v_BeforeTime < 5 && v_BeforeTime > 4)
            {
                StartText.text = "1";
            }

            if (v_BeforeTime < 6 && v_BeforeTime > 5)
            {
                StartText.text = "GO!";

                v_GAMESTART = true;
            }

            if (v_BeforeTime > 6 )
            {
                StartText.text = "";

               
            }

        }
        




    }
}
