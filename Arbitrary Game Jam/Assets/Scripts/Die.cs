using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

    public static bool isAlive;
    public AudioClip dead;

	// Use this for initialization
	void Start () {
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Meteor")
        {
            //play death sound
            //death animation
            Debug.Log("Die");

            isAlive = false;

            audio.PlayOneShot(dead);
           
        }
    }
}
