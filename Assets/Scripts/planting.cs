﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class planting : MonoBehaviour
{
    public adiomanager_main plantsound;
    Player p;
    public GameObject watermelon;
    public GameObject parsnip;
    public GameObject corn;
    public Transform player;
    public Vector3 player_pos;

    //public Vector3 q1_edge1;
    public Vector3 q1_edge2;

    public Vector3 q2_edge1;
    public Vector3 q2_edge2;

    public Vector3 q3_edge1;
    public Vector3 q3_edge2;
    public int my_q;
   
    public int rand;
    public bool can_plant = true;
    // Start is called before the first frame update
    void Start()
    {
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        p = playerObject.GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        can_plant = true;
    }
    private void OnTriggerExit(Collider other)
    {
     //   can_plant = false;
    }
    // Update is called once per frame
    void Update()
    {
        can_plant = true;
        player_pos = player.position;
        my_q = 4;
        if (player_pos.x < 54.32999f && player_pos.z > 59.76308f)
        {
            my_q = 3;
        }

        if (player_pos.x < 53.4f && player_pos.z < 55.1f)
        {
            my_q = 2;
        }
        if (player_pos.x > 53.4f && player_pos.z > 58.8)
        {
            my_q = 1;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && p._inventory["radishseeds"] > 0 && can_plant == true)
        {
         //   var plant_position = p.GetPlantPosition();
        //    LayerMask mask = LayerMask.GetMask("Field");
        //    print(""+transform.position+" "+plant_position);
        //    bool can_plant = Physics.Raycast(plant_position+Vector3.up*5, Vector3.down, 10, mask, QueryTriggerInteraction.Collide);
          //  if (can_plant)
          //  {
                p._inventory["radishseeds"] = p._inventory["radishseeds"] - 1;
                rand = Random.Range(1, 4);
            //for testing only removed
            // rand = 1;
            plantsound.Play_plant();
            player_pos.z -= 5;
                if (rand == 1)
                {
                    Instantiate(watermelon, player_pos, Quaternion.identity);
                }
                if (rand == 2)
                {
                    Instantiate(parsnip, player_pos, Quaternion.identity);
                }
                if (rand == 3)
                {
                    Instantiate(corn, player_pos, Quaternion.identity);
                }
         //   }
         //   else
          //  {
          //      print("No field");
          //  }
        }

    }
}
