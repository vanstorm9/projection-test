using UnityEngine;
using System.Collections;
using Leap;

public class navManager : MonoBehaviour {
    private int timer;
    private string[] object_list = new string[] { "bewd", "wk"};
    private int obj_iter = 0;
    Controller controller;
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

    void deletePrevModel()
    {
        string curr_obj_state = object_list[obj_iter];

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

 
        
    }

    void tail_connect(int state)
    {
        // Right == 1
        // Left == 0
        if(state == 1) { 
            if (object_list.Length <= obj_iter + 1)
            {
                obj_iter = 0;
            }
            else
            {
                obj_iter++;
            }
        } else if(state == 0)
        {
            if (object_list.Length >= 0)
            {
                obj_iter = object_list.Length - 1;
            }
            else
            {
                obj_iter--;
            }
        
        }
    }

    void nextRight()
    {
        tail_connect(1);

        string curr_obj_state = object_list[obj_iter];

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

    void nextLeft()
    {
        tail_connect(0);

        string curr_obj_state = object_list[obj_iter];

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

    void Start () {
        controller = new Controller();
        controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        //controller.Config.SetFloat("Gesture.Swipe.MinLength", 200.0f);
        //controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 750f);
        controller.Config.SetFloat("Gesture.Swipe.MinLength", 50.0f);
        controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 150f);

        controller.Config.Save();
        Debug.Log("Leap Connected");
        timer = 0;
	}

    void swipeFun()
    {
        Frame frame = controller.Frame();
        GestureList gestures = frame.Gestures();
        for (int i = 0; i < gestures.Count; i++)
        {
            Gesture gesture = gestures[i];
            if (gesture.Type == Gesture.GestureType.TYPESWIPE)
            {
                SwipeGesture Swipe = new SwipeGesture(gesture);
                Vector swipeDirection = Swipe.Direction;
                Debug.Log("swipe: " + swipeDirection.x);
                if (swipeDirection.x < 0)
                {
                    Debug.Log("Left");
                    deletePrevModel();
                    nextLeft();
                }
                else if (swipeDirection.x > 0) {
                    Debug.Log("Right");
                    deletePrevModel();
                    nextRight();
                }


            }
        }
    }

    // Update is called once per frame
    void Update () {

        if (timer % 20 == 0 || timer > 20)
        {
            swipeFun();
            timer = 0;
        }
        //Debug.Log(timer);
        //swapping();

        timer++;
    }
}
