using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit))
            this.GetComponent<Renderer>().material.color = Color.blue;
        else 
            this.GetComponent<Renderer>().material.color = Color.white;
    }
}
