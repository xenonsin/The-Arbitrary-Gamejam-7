using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 180, 300, 200));



        if (GUI.Button(new Rect(60, 60, 100, 50), "Main Menu"))
        {

            Application.LoadLevel("Main Menu");
        }

        GUI.EndGroup();
    }
}
