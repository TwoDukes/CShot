using UnityEngine;
using System.Collections;

public class Red : MonoBehaviour {

    Rigidbody2D rb;
    GameObject player;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb.AddForce((player.transform.position - transform.position).normalized * speed * Time.deltaTime * 1000, ForceMode2D.Impulse);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
	}

    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "shredder")
            Destroy(gameObject);

    }
}
