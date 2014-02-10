using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    private GameObject player;
    private Vector2 landingPosition;
    private Vector2 startingPosition;

    public float meteorSpeed;

    public AudioClip explosion;
    public Transform explosionParticle;

	// Use this for initialization
	void Awake () {

        player = GameObject.FindGameObjectWithTag("Player");

        landingPosition = player.transform.position;
        startingPosition = transform.position;

        float random = Random.Range(1.0f, 8.0f);
        
            landingPosition.x += random;
            landingPosition.y -= 4.0f;

         meteorSpeed = Random.Range(5.0f, 10.0f);

	
	}
	
	// Update is called once per frame
	void Update () {

       //transform.position.x = Mathf.Lerp(startingPosition.x, landingPosition.x, Time.deltaTime);

       // transform.position.y = Mathf.Lerp(startingPosition.y, landingPosition.y, Time.deltaTime);

        //transform.position.x = Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, landingPosition, Time.deltaTime * meteorSpeed);

	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Platform")
        {
            //play explosion sound
            //destroy self
            Debug.Log("HEllo!");

            //audio.PlayOneShot(explosion);
            Instantiate(explosionParticle, transform.position, transform.rotation);

            if(coll.gameObject.tag == "Player")
            Die.gotHit = true;

            Destroy(this.gameObject);
        }
    }
}
