using UnityEngine;
using System.Collections;

public class DestroyWhenDone : MonoBehaviour {

    public string sortingLayerName;
    public AudioClip boom;
   

	// Use this for initialization
	void Start () {
        audio.PlayOneShot(boom);
        ParticleSystem ps = this.GetComponent<ParticleSystem>();
        ps.renderer.sortingLayerName = sortingLayerName;
        Destroy(this.gameObject, ps.duration);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
