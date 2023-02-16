using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    // Properties ///////////////////////////////////////////////////////
    public GameObject target_player = null;
    public GameObject[] players = null;
    
    // TODO: collision with any :Player increments their hp.
    [SerializeField] float restore = 10f;
    [SerializeField] float speed = 0.5f;

    // Methods //////////////////////////////////////////////////////////
    // Selects a target_player from the list of "Player" GameObjects with the least health.
    void Start()
    {   
        getTarget();
    }

    //Move and face towards target_player speed / sec
    void Update()
    {   
        if (target_player != null) {
            transform.position += (target_player.transform.position - transform.position).normalized * speed * Time.deltaTime;
            transform.LookAt(target_player.transform);
        }
    }

    void getTarget() {
        {
            players = GameObject.FindGameObjectsWithTag("Player");;
            float hp_lowest = 9999;

            foreach (var p in players)
            {
                float health = p.GetComponent<Vulnerable>().getHP();

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
        
        // this is currently redundant, should always evaluate to true.
        if (target_player == null)
        {
            Debug.Log("E: No players");
            Destroy(gameObject);
        }
    }

    
    
}
