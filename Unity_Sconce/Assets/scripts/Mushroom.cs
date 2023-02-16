using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Vulnerable
{
    // Start is called before the first frame update
    void Start()
    {
        hp_max = 66;
        hp = hp_max;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void takeDamage(string _type, float _amount) 
    {
        changeHP(_amount);

        if (_type == "fire")
            changeHP(_amount);
    }
    public override void die() {
        Destroy(gameObject);
    }

    Target() {

    }
}
