using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Vulnerable
{

    // Start is called before the first frame update
    private void Start()
    {
        hp_max = 66;
        hp = hp_max;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Overrides ////////////////////////////////////////////////////////
    public override void takeDamage(string _type, float _amount) 
    {
        changeHP(_amount);

        if (_type == "fire")
            changeHP(_amount);
    }
    public override void die() {
        Destroy(gameObject);
    }

    // Methods //////////////////////////////////////////////////////////
    
    Player targetPlayer() {
        return getLowestPlayer();
    }

    // Returns a :Player from GameObject with the "Player" tag.
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
}
