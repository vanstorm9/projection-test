using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {
    public Vector3 position;
    public Vector3 original_position;
	// Use this for initialization
	void Start () {
	    original_position = transform.position;
        //GetComponent<Renderer>().enabled = false;
        
    }

    public void teleportBack(GameObject model)
    {
        Debug.Log(model);
        model.transform.position = new Vector3(1, 0, -20); ;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
