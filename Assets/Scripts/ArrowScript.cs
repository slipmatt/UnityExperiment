using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {
    public Transform Coin;
    public GameObject Player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(Coin);
        Vector3 PlayerPositionHover = Player.transform.position;
        
        PlayerPositionHover.y = PlayerPositionHover.y+5;
        this.gameObject.transform.position = PlayerPositionHover;
        this.gameObject.transform.Rotate(45f, 0f, 0f);
    }
}
