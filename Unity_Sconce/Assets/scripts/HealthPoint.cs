using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    public GameObject target_player;
    public GameObject[] players;
    
    // TODO: collision with any :Player increments their hp.
    [SerializeField] float restore;
    [SerializeField] float speed;

    // Selects a target_player from the list of "Player" GameObjects with the least health.
    void Start()
    {   
        // if (players == null) // Stops injection
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            float hp_lowest = 9999;

            foreach (var p in players)
            {
                float health = p.GetComponent<Player>().getHP();

                if (hp_lowest > health) {
                    hp_lowest = health;
                    target_player = p;
                }
            }
            if (target_player != null) 
            {
                Debug.Log("player-"+ target_player.ToString() +" has the lowest health ("+ hp_lowest +").");
            return;
            }
        }
        if (target_player == null)
        {
            Debug.Log("E: No players");
            Destroy(gameObject);
        }
            
        return;
    }

    
    //Move towards target_player every frame
    void Update()
    {   
        if (target_player != null) {
            transform.position += (target_player.transform.position - transform.position).normalized * speed * Time.deltaTime;
            transform.LookAt(target_player.transform);
        }
    }
}
