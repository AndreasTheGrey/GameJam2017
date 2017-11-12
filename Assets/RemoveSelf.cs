using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSelf : MonoBehaviour {

    // Use this for initialization
    private float alpha;

    void Start ()
	{
	    alpha = 1.0f;
	}

   
	// Update is called once per frame
	void Update ()
	{
	    if (alpha >= 0.1f)
	    {
	        var color = gameObject.GetComponent<Renderer>().material.color;
	        var newColor = new Color(color.r, color.g, color.b, alpha);
	        gameObject.GetComponent<Renderer>().material.color = newColor;
	        alpha -= 0.05f;
	    }
	    else
	    {
            Destroy(gameObject);
	    }

	}
}
