using UnityEngine;
using System.Collections;

public class green : MonoBehaviour {

    public GameObject[] corner;
    
    public float speed = 5.0f;
    public float cornerSpeed = 5.0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

        Vector2 randomDirection = new Vector2(Mathf.Round(Random.value * 2 - 1), Mathf.Round(Random.value * 2 - 1));
        if (randomDirection != new Vector2(0, 0))
        {
            if(randomDirection.x != 0 && randomDirection.y != 0)
            {
                Corners();
            }
            else
            {
                transform.Rotate(randomDirection * 2);
                rb.AddForce(transform.forward * speed * Time.deltaTime * 100, ForceMode2D.Impulse);
            }
            
        }
        else
        {
            Corners();
        }

        
    }

    IEnumerator Bye()
    {

        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        rb.velocity *= 0;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "shredder")
            StartCoroutine("Bye");

        if (coll.gameObject.tag == "Player") {
            
            StartCoroutine("Bye");
        }
            
        

    }

    void Corners()
    {
        int rand = Random.Range(0, 4);


        switch (rand)
        {
            case 0:
                rb.AddForce((corner[0].transform.position - transform.position).normalized * cornerSpeed * Time.deltaTime * 1000);
               // Debug.Log(0);
                break;
            case 1:

                rb.AddForce((corner[1].transform.position - transform.position).normalized * cornerSpeed * Time.deltaTime * 1000);
               // Debug.Log(1);
                break;
            case 2:

                rb.AddForce((corner[2].transform.position - transform.position).normalized * cornerSpeed * Time.deltaTime * 1000);
               // Debug.Log(2);
                break;
            case 3:

                rb.AddForce((corner[3].transform.position - transform.position).normalized * cornerSpeed * Time.deltaTime * 1000);
              //  Debug.Log(3);
                break;
        }
    }
}
