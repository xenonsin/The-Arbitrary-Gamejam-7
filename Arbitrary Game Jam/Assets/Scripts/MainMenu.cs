﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2, 300, 200));



        if (GUI.Button(new Rect(60, 60, 100, 50), "Start Game"))
        {

            Application.LoadLevel("Test");
        }

        if (GUI.Button(new Rect(60, 120, 100, 50), "Credits"))
        {
           // Debug.Log("QUIT!");

           // Application.Quit();
            Application.LoadLevel("Credits");
        }

        GUI.EndGroup();
    }
}
