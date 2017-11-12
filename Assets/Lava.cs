using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    private BoxCollider2D trigger;
    private List<Collider2D> insideTrigger;

    void Start ()
    {
        insideTrigger = new List<Collider2D>();
        trigger = GetComponent<BoxCollider2D>();
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

    void FixedUpdate ()
    {
        foreach(Collider2D col in insideTrigger)
        {
            if (col.tag == "Player")
            {
                col.gameObject.GetComponent<DwarfHealth> ().dead = true;
            }
        }
    }
}
