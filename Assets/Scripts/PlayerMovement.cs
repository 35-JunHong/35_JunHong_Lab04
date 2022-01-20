using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody PlayerRigidBody;

    public Text scoreTxt;
    public int score = 0;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidBody.AddForce(movement * speed * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(score>=4)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            score++;
            scoreTxt.text = "Score: " + score;
        }

        if(collision.gameObject.tag=="Hazard")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameLose");
        }
    }
}
