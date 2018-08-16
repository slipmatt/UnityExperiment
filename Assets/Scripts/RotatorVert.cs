using UnityEngine;
using System.Collections;

public class RotatorVert : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, 90, 0f) * Time.deltaTime* Random.Range(1f,5f));
	}
}
