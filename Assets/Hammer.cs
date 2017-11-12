using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    private Animator anim;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }

    public void playAttackAnimation()
    {
        anim.SetTrigger("Attack");
    }

    // Update is called once per frame
	void Update () {
		
	}
}
