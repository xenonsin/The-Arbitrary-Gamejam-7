using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public static int score;

    public GUIStyle style;

    //public static bool isAlive = true;

	// Use this for initialization
	void Start () {

    score = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Die.isAlive)
        score += 1;
	
	}

    void OnGUI()
    {
        if (Die.isAlive)
        GUI.Label(new Rect(50, 0, 200, 200), "Score: " + score, style);
        else
        {
            GUI.BeginGroup(new Rect(Screen.width / 2-200, Screen.height / 2, 300, 200));
            GUI.Box(new Rect(0, 0, 300, 200), "You Lose!  Score: " + score);


            if (GUI.Button(new Rect(100, 60, 100, 50), "Restart?"))
            {

                Application.LoadLevel("Test");
            }

            if (GUI.Button(new Rect(100, 120, 100, 50), "Main Menu"))
            {
                //Debug.Log("QUIT!");

                Application.LoadLevel("Main Menu");
            }

            GUI.EndGroup();
        }
    }
}
