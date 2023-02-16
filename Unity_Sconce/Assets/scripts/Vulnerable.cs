using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vulnerable : MonoBehaviour
{
    // Properties ///////////////////////////////////////////////////////
    [SerializeField] protected float hp_max;
    protected float hp;

    

    //  Constructors ////////////////////////////////////////////////////
    public Vulnerable() {
        hp = hp_max;
    }

   
    
    // Interfaces ///////////////////////////////////////////////////////
    // reduce health based on damage type and amount
    public abstract void takeDamage(string _type, float _amount);
    // Define what happens when health goes below 1.
    public abstract void die();



    // Methods //////////////////////////////////////////////////////////
    // return hp<float>
    public float getHP() 
    {
        return hp;
    }
    // change hp by a float
    protected void changeHP(float _hp) 
    {
        if (hp+_hp < 1) // death from low...
        { 
            hp = 0;
            die();
            return;
        } 
        else if (hp+_hp > hp_max) // guard against over filling...
        {
            hp=hp_max;
            return;
        }
        else // otherwise change normally.
        {
            hp += _hp;
        }
    }
    

}
