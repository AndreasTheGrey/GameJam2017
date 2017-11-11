using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDwarfControl : MonoBehaviour
{

    private Dwarf dwarf;
    public int playerNum = 1;

    void Start ()
    {
        dwarf = GetComponent<Dwarf>();
    }

    void Update ()
    {
        if (Input.GetButtonDown (appendPlayerSuffix ("Jump"))) {
            Debug.Log (appendPlayerSuffix ("Jump"));
            dwarf.Jump ();
        }
        if (Input.GetAxis (appendPlayerSuffix ("Attack")) == 1) {
            Debug.Log (appendPlayerSuffix ("Attack"));
            dwarf.Attack ();
        }
    }

    void FixedUpdate ()
    {
        dwarf.Move (Input.GetAxis (appendPlayerSuffix ("Horizontal")), Input.GetAxis (appendPlayerSuffix ("Vertical")));
    }

    private string appendPlayerSuffix (string name)
    {
        return name + "_P" + playerNum;
    }
}
