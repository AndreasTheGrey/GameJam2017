using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private int _health;


    // Use this for initialization
	void Start (int health)
	{
	    _health = health;
	}

    public void GetHit()
    {
        _health--;

        if (_health == 0)
        {
            Death();
        }
    }

    private void Attack()
    {

    }

    private void Death()
    {
        throw new System.NotImplementedException();
    }


    // Update is called once per frame
	void Update () {
		
	}
}
