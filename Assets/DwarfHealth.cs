using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfHealth : MonoBehaviour {


    private Animator anim;
    private bool dead;
    public int healthPoints;
    void Awake()
    {
        dead = false;
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void takeDamage(int dmg)
    {
        healthPoints = healthPoints - dmg;
        if (healthPoints <= 0)
        {
            anim.SetTrigger("Dead");
            dead = true;
        }
    }

}
