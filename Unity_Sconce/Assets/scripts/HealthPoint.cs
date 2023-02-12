using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    GameObject target_player;
    GameObject[] players;
    

    // Selects a target_player from the list of "Player" GOs with the least health.
    void Start()
    {   
        if (players == null) {// Stops injection
            players = GameObject.FindGameObjectsWithTag("Player");
            float hp_lowest = 0;
            foreach (var p in players)
            {
                var health = p.GetComponent<Player>().getHP();

                if (hp_lowest > health) {
                    hp_lowest = health;
                    target_player = p;
                }
                    
            }
            Debug.Log("player-"+ target_player +" has the lowest health ("+ hp_lowest +").");
            return;
        }
        

        Debug.Log("Error: No players");
        return;
    }

    
    //Move towards target_player every frame
    void Update()
    {   
        

    }
}
