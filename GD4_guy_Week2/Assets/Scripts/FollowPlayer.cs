using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform v_Target;
    public Vector3 v_defaultOffset;
    public Vector3 v_offset;
    public Vector3 v_targetCamPost;
    public float v_targetFacing;
    public float v_camMove = 4;
    public float v_camMoveLimit = 0.2f;
    public Rigidbody s_player;
    public float v_playerspeed;
    public float v_playerspeedLimit;
    public float v_offsetSpeedMutl = 10;
    public Vector3 v_OffsetFPDefault =  new Vector3(2,0.7f,0);
    public Vector3 v_OffsetFP;
    public Vector3 v_OffsetRVDefault = new Vector3(0, 1, -2);
    public Vector3 v_OffsetRV;
    public int v_camView = 0;
    public int v_noofCams = 3;
    public PlayerMove Player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        v_defaultOffset = new Vector3(0, 5, -10);

        v_offset = v_defaultOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //v_targetFacing = v_Target.transform.forward.y;


        //v_targetCamPost = v_Target + v_targetFacing * v_offset;

        if (Input.GetButtonDown("Camera" +Player.v_playerIndex))

        {
            v_camView += 1;
            if (v_camView == v_noofCams)
            {
                v_camView = 0;
            }

        }


        switch (v_camView)
        {
            case 0:
                ///Third Person









                if (s_player != null && s_player.linearVelocity != null)
                {

                    v_playerspeed = s_player.linearVelocity.magnitude;
                }


                if (v_playerspeed < v_playerspeedLimit)
                { v_playerspeed = v_playerspeedLimit; }

                v_offset = v_defaultOffset * (1 + v_playerspeed / v_offsetSpeedMutl);


                //v_targetCamPost = v_Target.TransformPoint(v_offset);
                v_targetCamPost = v_Target.position + (v_Target.forward * v_offset.z) + new Vector3(0, v_offset.y, 0);



                if (Vector3.Distance(transform.position, v_targetCamPost) > v_camMoveLimit)
                {
                    transform.position += v_playerspeed * Time.deltaTime * v_camMove * (v_targetCamPost - transform.position).normalized;
                }

                transform.LookAt(v_Target);
                break;

            case 1:

                v_OffsetFP = v_Target.transform.TransformDirection(v_OffsetFPDefault);

                transform.position = v_Target.position + v_OffsetFP;
                    
                transform.rotation = v_Target.rotation;

                break;


                case 2:


                v_OffsetRV = v_Target.transform.TransformDirection(v_OffsetRVDefault);

                transform.position = v_Target.position + v_OffsetRV;
                transform.rotation = v_Target.rotation;
                transform.Rotate(0,180,0, Space.Self);

                break;


        }
    }
}
