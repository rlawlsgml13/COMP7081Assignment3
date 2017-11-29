using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour {


    public Text scoreboard;
    

    private int player_1_score = 0;
    private int player_2_score = 0;
    public float speed;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }




    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {

        return (ballPos.y - racketPos.y) / racketHeight;
    }


    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.name == "Player 1")
        {
            
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

           
            Vector2 dir = new Vector2(1, y).normalized;

            
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        
        if (col.gameObject.name == "Player 2")
        {
            
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            
            Vector2 dir = new Vector2(-1, y).normalized;

            
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }



        if (col.gameObject.name == "WallLeft") {

            this.transform.position = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            player_1_score ++;

        }

        if (col.gameObject.name == "WallRight")
        {
            this.transform.position = new Vector2(0,0);
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;

            player_2_score++;
        }


        scoreboard.text = player_1_score.ToString() + ":" + player_2_score.ToString();
        print(player_1_score + " , " + player_2_score + " , ");


        if (player_1_score == 5) {

            SceneManager.LoadScene(0);

        }

        if (player_2_score == 5)
        {

            SceneManager.LoadScene(0);

        }

    }







}
