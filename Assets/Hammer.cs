using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    private BoxCollider2D trigger;
    private List<Collider2D> insideTrigger;

    private bool doDamage;
    // Use this for initialization
    void Start ()
    {
        doDamage = false;
        insideTrigger = new List<Collider2D>();
        trigger = GetComponent<BoxCollider2D>();
    }

    public void DoDamage()
    {
        doDamage = true;
       
    }
 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!insideTrigger.Contains(col))
        {
            insideTrigger.Add(col);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (insideTrigger.Contains(col))
        {
            insideTrigger.Remove(col);
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (doDamage)
        {
            foreach(Collider2D col in insideTrigger)
            {
                if (col.tag == "Player")
                {
                    col.gameObject.GetComponent<DwarfHealth>().TakeDamage(1);
                }
            }

            doDamage = false;
        }
    }
}
