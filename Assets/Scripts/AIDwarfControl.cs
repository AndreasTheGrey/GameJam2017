using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDwarfControl : MonoBehaviour
{
    public Transform Target;
    private Dwarf dwarf;

    void Start ()
    {
        dwarf = GetComponent<Dwarf>();
    }

    void Update ()
    {
        dwarf.Jump ();
    }

    void FixedUpdate ()
    {
        float sign = Mathf.Sign(Target.position.x - dwarf.transform.position.x);
        dwarf.Move (sign, 0);
    }
}
