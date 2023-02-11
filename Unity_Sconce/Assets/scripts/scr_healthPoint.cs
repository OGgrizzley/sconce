using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_healthPoint : MonoBehaviour
{
    GameObject[] players;
    int target_player;
    

    // Selcts a target_player from the list of "Player" GOs with the least health.
    void Start()
    {   
        
        if (players == null) {// Stops injection
            players = GameObject.FindGameObjectsWithTag("Player");
            var hp_lowest = 0;
            foreach (var p in players)
            {
                var health = p.getHP();
                Debug.Log("player "+ p.GetInstanceID() +" has "+ health +" health.");

                if (hp_lowest > health) {
                    hp_lowest = health;
                    target_player = p.GetInstanceID();
                }
                    
            }
            return;
        }
        
        Debug.Log("No players");
        return;
    }

    
    //Move towards target_player every frame
    void Update()
    {   
        

    }
}
