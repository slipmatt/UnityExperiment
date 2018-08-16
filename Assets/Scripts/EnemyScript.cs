using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    public Transform Player;
    public Rigidbody rb;
    public int MoveSpeed = 4;
    private int MaxDist = 10;
    private int MinDist = 5;



    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    void Update()
    {

        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            rb.AddForce(transform.forward * MoveSpeed);



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
    }
}
