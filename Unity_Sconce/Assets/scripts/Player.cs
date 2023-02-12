using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float hp_max = 100;

    [SerializeField] float hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,1,0);
    }

    // Health interfaces
    // TODO: divide into heal(float amount) and damage(float amount, Death style)
    //      - Death data structure informing death animations.
    public float getHP() 
    {
        return hp;
    }
    public void changeHP(float _hp) 
    { 
        if (hp+_hp > hp_max) // guard against over filling...
        {
            hp=hp_max;
            return;

        } else if (hp+_hp < 1) { // death from low...
            hp = 0;
            die();
            return;
        } else { // otherwise change normally.
            hp += _hp;
        }
    }

    
    private void die() {
        Debug.Log("YOU ARE DEAD.");
    }
}
