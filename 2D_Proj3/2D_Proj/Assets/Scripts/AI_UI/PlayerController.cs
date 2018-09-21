using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject player;
    public GameObject playerPlace;
    public GameObject playerPlaceTarget;


    public bool CanMove = true;
    public float MoveSpeed = 1f;
    //public Vector3 player_Pos;
    private Vector2Int PlayerPos = new Vector2Int(0, 0);
    public Vector2Int PlayerTargetPos = new Vector2Int(0, 0);
    private bool PlayerMoving;
    public float RunawayChance = 50f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 p_p = V2ToV3(PlayerPos);
        Vector3 p_t = V2ToV3(PlayerTargetPos);
        if (CanMove == true)
        {
            bool M = false;
            if (Input.GetKeyDown(KeyCode.W))
            {
                PlayerTargetPos += new Vector2Int(0, 1);
                M = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                PlayerTargetPos += new Vector2Int(0, -1);
                M = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                PlayerTargetPos += new Vector2Int(-1, 0);
                M = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                PlayerTargetPos += new Vector2Int(1, 0);
                M = true;
            }
            if (M == true)
            {
                p_t = V2ToV3(PlayerTargetPos);
                playerPlaceTarget.transform.position = p_t;
                PlayerMoving = true;
            }
        }
        if (PlayerMoving == true)
        {
            player.transform.position += (player.transform.position - p_t).normalized * -Time.deltaTime * MoveSpeed;
            if (PlayerPos.x != Mathf.CeilToInt(player.transform.position.x - 0.5f))
            {
                PlayerPos.x = Mathf.CeilToInt(player.transform.position.x - 0.5f);
                playerPlace.transform.position = new Vector3(PlayerPos.x, 0 , PlayerPos.y);
            }
            if (PlayerPos.y != Mathf.CeilToInt(player.transform.position.z - 0.5f))
            {
                PlayerPos.y = Mathf.CeilToInt(player.transform.position.z - 0.5f);
                playerPlace.transform.position = new Vector3(PlayerPos.x, 0, PlayerPos.y);
            }
        }
        if (((player.transform.position - p_t).normalized * -Time.deltaTime * MoveSpeed).magnitude > (player.transform.position - p_t).magnitude)
        {
            player.transform.position = p_p;
            PlayerMoving = false;
        }
    }
    
    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.tag == "NPC")
        {
            //Debug.Log("OnTriggerEnter p_c");
            if (coll.GetComponent<NPC>().isEnemy == true)
            {
                float r_c = Random.Range(0f, 100f);
                if (r_c >= RunawayChance)
                {
                    coll.GetComponent<NPC>().AttackPlayer();
                    playerPlaceTarget.transform.position = V2ToV3(PlayerTargetPos);
                } else
                {
                    Debug.Log("RunawayChance = " + r_c);
                }
            }
        }
    }

    Vector3 V2ToV3(Vector2Int V)
    {
        return new Vector3(V.x, 0, V.y);
    }
}
