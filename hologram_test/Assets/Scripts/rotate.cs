using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

    private int ang;

	// Use this for initialization
	void Start () {
        ang = 1;
	}
	
	// Update is called once per frame
	void Update () {
        // Sets the transforms rotation to rotate 30 degrees around the y-axis
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.up);
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.left);
        ang = ang + 1;
        
    }
}
