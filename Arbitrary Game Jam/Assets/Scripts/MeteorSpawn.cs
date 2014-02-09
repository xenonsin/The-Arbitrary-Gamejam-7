using UnityEngine;
using System.Collections;

public class MeteorSpawn : MonoBehaviour {

    public GameObject meteor;
    public float spawnWaitTime;// = 2.0f;

    private float timeStamp = 0.0f;
    

	// Use this for initialization
	void Start () {

        float randomTime = Random.Range(0.5f, 10.0f);

        Invoke("Spawn", randomTime);
	
	}
	
	// Update is called once per frame
	void Update () {

       
	
	}
    void Spawn()

{

      float randomTime = Random.Range(2.0f, 10.0f );

 

      GameObject newEnemy = (GameObject)Instantiate(meteor, transform.position, transform.rotation);

 

      Invoke("Spawn", randomTime);

 

}

}
