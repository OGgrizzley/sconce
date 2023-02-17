using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    // Properties ///////////////////////////////////////////////////////
    private Player target_player = null;
    
    // TODO: collision with any :Player increments their hp.
    [SerializeField] float restore = 25f;
    [SerializeField] float speed = 0.5f;

    // Methods //////////////////////////////////////////////////////////
    private void Start()
    {   
        target_player = getLowestPlayer();
    }

    void Update()
    {   
        //Move and face towards target_player speed / sec
        if (target_player != null) {
            transform.position += (target_player.transform.position - transform.position).normalized * speed * Time.deltaTime;
            transform.LookAt(target_player.transform);
        }
    }


    // Returns a :Player from GameObjects with the "Player" tag with the lowest hp.
    Player getLowestPlayer() {

        Player target = null;
        float hp_lowest = 9999f;

        foreach (var p in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (p !is Player)
                break;

            float health = p.GetComponent<Vulnerable>().getHP();
            if (hp_lowest < health) 
                break;
            
            hp_lowest = health;
            target = p.GetComponent<Player>();
        }
        
        if (target is Player) 
        {
            Debug.Log("Targeted player-"+ target.ToString() +" ("+ hp_lowest +"HP)");
            return target;
        }

        return null;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Player>())
        {
            col.gameObject.GetComponent<Vulnerable>().takeDamage("heal", restore);
            Destroy(gameObject);
        }
    }

}
