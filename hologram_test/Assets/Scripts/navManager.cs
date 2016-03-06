using UnityEngine;
using System.Collections;

public class navManager : MonoBehaviour {
    private int timer;
	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer >= 100) {
            GameObject temp = GameObject.Find("bewd");
            temp.transform.position = transform.position;
        }
        timer++;
    }
}
