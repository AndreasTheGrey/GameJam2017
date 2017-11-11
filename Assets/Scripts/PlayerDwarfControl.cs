using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDwarfControl : MonoBehaviour
{

    public IDwarfControl dwarfControl;
    public int playerNum = 1;

    void Start ()
    {
    }

    void Update ()
    {
        if (Input.GetButtonDown (appendPlayerSuffix ("Jump"))) {
            dwarfControl.Jump ();
        }
        if (Input.GetButtonDown (appendPlayerSuffix ("Attack"))) {
            dwarfControl.Attack ();
        }
    }

    void FixedUpdate ()
    {
        dwarfControl.Move (Input.GetAxis (appendPlayerSuffix ("Horizontal")), Input.GetAxis (appendPlayerSuffix ("Vertical")));
    }

    private string appendPlayerSuffix (string name)
    {
        return name + "_P" + playerNum;
    }
}
