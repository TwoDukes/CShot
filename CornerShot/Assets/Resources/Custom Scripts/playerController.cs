using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public GameObject topLeft, topRight, bottomLeft, bottomRight;
    float moveTimer = 0.0f;

    [HideInInspector]  public bool alive = true;
    [HideInInspector]  public float health = 100;

    int score = 0;
    public Text scoreText;
    public Button restart;
    public Image healthBar;

    Color startColor;

    

    GameObject current;


        // Use this for initialization
        void Start () {
        restart.gameObject.SetActive(false);
        startColor = GetComponent<SpriteRenderer>().color;
        current = topLeft;
        StartCoroutine("Move", topLeft);
        StartCoroutine("ScoreTimer");
    }

    IEnumerator Move(GameObject target)
    {
        moveTimer = 0.0f;
        while (moveTimer < 1.0f && current == target && alive)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, moveTimer);
            moveTimer = moveTimer + 0.02f;
            yield return new WaitForSeconds(0.01f);
        }
        
    }


    IEnumerator ScoreTimer()
    {
        while (alive) {
        
        yield return new WaitForSeconds(0.1f);
            score += 1;
        }

    }

    IEnumerator HealthDrop()
    {
        for(int i = 0; i < 20; i++)
        {
            health -= 0.5f;
            yield return new WaitForSeconds(0.01f);
            
        }

    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + score;

        if (health <= 0)
            alive = false;
        if (!alive)
        {
            restart.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
            

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }

        if (health > 0)
        {
            healthBar.fillAmount = health / 100.0f;
        }
        else
        {
            healthBar.fillAmount = 0;
        }

        transform.Rotate(0, 0, -25 * Time.deltaTime);
    }

    public void MoveTopLeft()
    {
        if(current != topLeft) {
            StopCoroutine("Move");
            current = topLeft;
            StartCoroutine("Move", topLeft);
            
        }
           

    }
    public void MoveTopRight()
    {
        if (current != topRight) {
            StopCoroutine("Move");
            current = topRight;
            StartCoroutine("Move", topRight);
            
        }
            
    }
    public void MoveBottomLeft()
    {
        if (current != bottomLeft) {
            StopCoroutine("Move");
            current = bottomLeft;
            StartCoroutine("Move", bottomLeft);
            
        }
            
    }
    public void MoveBottomRight()
    {
        if (current != bottomRight) {
            StopCoroutine("Move");
            current = bottomRight;
            StartCoroutine("Move", bottomRight);
            
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "green")
        {
            
           // Destroy(other.gameObject);
            score += 50;
        }
        if (other.tag == "red")
        {

            Destroy(other.gameObject);
            StartCoroutine("HealthDrop");
        }
    }

   public void Restart()
    {
        
        restart.gameObject.SetActive(false);
        health = 100;
        alive = true;
        GetComponent<SpriteRenderer>().color = startColor;
        score = 0;
        StartCoroutine("ScoreTimer");
        current = topLeft;
        StartCoroutine("Move", topLeft);

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            enemy.GetComponent<emitterMover>().restart();
        }

        GameObject.FindGameObjectWithTag("center").GetComponent<enemySpawn>().startUp();
    }
}
