using UnityEngine;
using System.Collections;

public class navManager : MonoBehaviour {
    private int timer;
    // Use this for initialization

    void swapping()
    {
        if (timer >= 100)
        {
            GameObject temp = GameObject.Find("bewd");
            temp.transform.position = transform.position;
            GetComponent<Renderer>().enabled = false;
        }
        if (timer >= 200)
        {
            GameObject temp = GameObject.Find("bewd");
            manager managerScript = temp.GetComponent<manager>();
            temp.transform.position = managerScript.original_position;
            GetComponent<Renderer>().enabled = true;
            timer = 0;
        }
        timer++;
    }

	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(timer);
        swapping();
    }
}
