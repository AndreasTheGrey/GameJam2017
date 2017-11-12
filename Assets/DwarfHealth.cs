using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfHealth : MonoBehaviour {


    private Animator anim;
    public bool dead;
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

    public void TakeDamage(int dmg)
    {
        healthPoints = healthPoints - dmg;
        Transform neck = GetComponent<Transform>();
        neck.localScale = new Vector3(neck.localScale.x, neck.localScale.y - 0.2f, neck.localScale.z);

        if (healthPoints <= 0)
        {
            anim.SetTrigger("Dead");
            dead = true;
        }
    }

}
