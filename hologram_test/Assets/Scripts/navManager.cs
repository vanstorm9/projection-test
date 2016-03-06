using UnityEngine;
using System.Collections;
//using Leap;

public class navManager : MonoBehaviour {
    private int timer;
    private string[] object_list = new string[] { "bewd", "wk"};
    private int obj_iter = 0;
    //Controller controller = new Controller();
    // Use this for initialization

    void swapping()
    {
        string curr_obj_state = object_list[obj_iter];
        if (timer >= 100)
        {
            GameObject temp = GameObject.Find(curr_obj_state);
            if (temp == null)
            {
                Debug.Log("GameObject " + curr_obj_state + " not found");
                UnityEditor.EditorApplication.isPlaying = false;
            }
            temp.transform.position = transform.position;
            temp.GetComponent<Renderer>().enabled = true;
            GetComponent<Renderer>().enabled = false;
        }
        if (timer >= 200)
        {
            GameObject temp = GameObject.Find(curr_obj_state);
            if (temp == null)
            {
                Debug.Log("GameObject " + curr_obj_state + " not found");
                UnityEditor.EditorApplication.isPlaying = false;
            }
            manager managerScript = temp.GetComponent<manager>();
            temp.transform.position = managerScript.original_position;
            temp.GetComponent<Renderer>().enabled = false;
            GetComponent<Renderer>().enabled = true;
            if (object_list.Length <= obj_iter + 1) {
                obj_iter = 0;
            } else {
                obj_iter++;
            }
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
