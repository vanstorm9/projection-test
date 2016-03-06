using UnityEngine;
using System.Collections;
using Leap;

public class navManager : MonoBehaviour {
    private int timer;
    public string[] object_list = { "car","bewd", "wk", "unitychan"};
    public int obj_iter = 0;
    Controller controller;
    // Use this for initialization

    public string text = "Search. . .";
    // void GUIElements()
    void OnGUI()
    {
        float height_rect = UnityEngine.Screen.height * (0.45f / 6.3f);
        float width_rect = UnityEngine.Screen.width * (1.1f / 6.3f);
        float y_rect = UnityEngine.Screen.height * (0.1f / 6.3f);
        float x_rect = UnityEngine.Screen.width * (2.7f / 6.55f);

        text = GUI.TextField(new Rect(x_rect, y_rect, width_rect, height_rect), text, 25);
    }


    void removeOtherModel()
    {
        string curr_obj_state = object_list[obj_iter];

        GameObject temp = GameObject.Find(curr_obj_state);
        if (temp == null)
        {
            Debug.Log("GameObject " + curr_obj_state + " not found");
            UnityEditor.EditorApplication.isPlaying = false;
            return;
        }
        manager managerScript = temp.GetComponent<manager>();
        Debug.Log(managerScript.original_position);
        Debug.Log(managerScript.transform.position);
        managerScript.teleportBack(temp);

        Debug.Log(managerScript.original_position);
        Debug.Log(managerScript.transform.position);
        //temp.GetComponent<Renderer>().enabled = false;
        //GetComponent<Renderer>().enabled = true;



    }

    void foundHoloObject(int ind)
    {
        removeOtherModel();

        GameObject temp = GameObject.Find(object_list[ind]);
        Debug.Log(temp);
        if (temp == null)
        {
            Debug.Log("GameObject " + text + " not found");
            UnityEditor.EditorApplication.isPlaying = false;
            return;
        }
        GameObject cube_model = GameObject.Find("Cube");
        temp.transform.position = cube_model.transform.position;
        //temp.GetComponent<Renderer>().enabled = true;
        GetComponent<Renderer>().enabled = false;
    }

    void keyCheck()
    {
   
        if (Input.GetKeyDown("return"))
        {
            Debug.Log("Enter key detected!");
            Debug.Log(text);
            for (int i = 0; i < object_list.Length; i++) { 
                if (string.Equals(text,object_list[i]))
                {
                    obj_iter = i;
                    text = "Found!";
                    foundHoloObject(i);
                    return;
                }
            }
            text = "No object found. . .";
          
        }
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
        //controller = new Controller();
        //controller.Config.SetFloat("Gesture.Swipe.MinLength", 200.0f);
        //controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 750f);


        //controller.Config.Save();
        //Debug.Log("Leap Connected");
        timer = 0;
	}
    
    //
    // Update is called once per frame
    void Update () {
        //circleFun();
        /*
        if (timer > 20)
        {
            swipeFun();
            timer = 0;
        }
        */

        keyCheck();
        //Debug.Log(timer);
        //swapping();

        timer++;
    }
}
