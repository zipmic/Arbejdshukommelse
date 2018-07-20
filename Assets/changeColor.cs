using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour {

    private MeshRenderer r;

	// Use this for initialization
	void Start () {
        r = GetComponent<MeshRenderer>();
        InvokeRepeating("ChangeColorOnBlock", 0, 1);
		
	}

    void ChangeColorOnBlock()
    {
        r.material.SetColor("_Color", new Color(Random.Range(0.25f, 1f), Random.Range(0.25f, 1f), Random.Range(0.25f, 1f)));
    }
	
	
}
