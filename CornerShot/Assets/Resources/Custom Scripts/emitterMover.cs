using UnityEngine;
using System.Collections;

public class emitterMover : MonoBehaviour {

    Rigidbody2D rb;

    public bool starter = false;

    bool alive = true;

    bool touchingWall = false;

    GameObject player, center;

    public GameObject sparks;

    public float speed = 5f;

    enum EnemyType { follower, avoider, roamer, patroller };
    EnemyType me;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        center = GameObject.FindGameObjectWithTag("center");



        if (starter)
        {
            me = EnemyType.follower;
        }
        else
        {
            int rand = Random.Range(0, 4);
            switch (rand)
            {
                case 0:
                    me = EnemyType.avoider;
                    break;
                case 1:
                    me = EnemyType.follower;
                    break;
                case 2:
                    me = EnemyType.roamer;
                    break;
                case 3:
                    me = EnemyType.patroller;
                    break;

            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (alive)
        {
            switch (me)
            {
                case EnemyType.avoider:

                    break;

                case EnemyType.follower:

                    if (touchingWall)
                    {
                        
                        rb.AddForce((center.transform.position - transform.position).normalized * speed, ForceMode2D.Impulse);
                    }
                    else
                    {
                        rb.AddForce((player.transform.position - transform.position).normalized * speed, ForceMode2D.Impulse);

                    }


                    break;

                case EnemyType.roamer:

                    break;

                case EnemyType.patroller:

                    break;
            }
        }
        else
        {
            Destroy(gameObject);
        }


        

	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Mlimit")
        {
            touchingWall = true;
            Debug.Log("HIT WALL");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Mlimit")
        {
            touchingWall = false;
            Debug.Log("MOVED AWAY FROM WALL");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            //Instantiate your particle system here.
            Instantiate(sparks, contact.point, Quaternion.identity);
        }
    }

    public void restart()
    {
        if (starter)
        {
            rb.velocity *= 0;
            rb.rotation *= 0;
            transform.position = center.transform.position;
            Debug.Log("reset");

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
