using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    public float ziplamaKuvveti = 15f;
    public string mevcutRenk;
    public Color topunRengi;
    public Text scoreText;
    public static int gameScore = 0;
    public GameObject[] cemberler;
    public GameObject RenkTekeri;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = gameScore.ToString();
        RandomColorBall();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * ziplamaKuvveti;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if(collision.tag=="ScoreUp")
        {
            gameScore += 25;
            scoreText.text = gameScore.ToString();
            int rasgeleCember = Random.Range(0, 2);
            Instantiate(cemberler[rasgeleCember], new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z), Quaternion.identity);
            Destroy(collision.gameObject);

        }
        
        if(collision.tag=="ColorSwitch")
        {
            RandomColorBall();
            Destroy(collision.gameObject);
            Instantiate(RenkTekeri, new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z), Quaternion.identity);
            return;
        }
       if(collision.tag!=mevcutRenk && collision.tag != "ScoreUp")
        {
            gameScore = 0;
            scoreText.text = gameScore.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
           
        }
        
    }
    void RandomColorBall()
    {   
        int rastSayi = Random.Range(0, 4);
        switch(rastSayi)
        {
            case 0: mevcutRenk = "Turkuaz";
                topunRengi = Color.cyan;
                break;
            case 1: mevcutRenk = "Sari";
               topunRengi = Color.yellow;
                break;
            case 2: mevcutRenk = "Bordo";
                topunRengi = Color.red;
                break;
            case 3: mevcutRenk= "Mor";
                topunRengi = Color.magenta;
                break;
        }
        GetComponent<SpriteRenderer>().color = topunRengi;

    }
}
