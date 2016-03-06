using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {
    public Vector3 position;
    public Vector3 original_position;
	// Use this for initialization
	void Start () {
	    original_position = transform.position;
        position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
