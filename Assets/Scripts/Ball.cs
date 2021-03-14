using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject monkey;
    public GameObject textUI;
    float speed;

    bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        shoot = true;
        speed = 15;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shoot)
        {
            var rigidball = this.GetComponent<Rigidbody2D>();
            var rigidmonkey = monkey.GetComponent<Rigidbody2D>();
            rigidball.bodyType = RigidbodyType2D.Dynamic;
            rigidmonkey.bodyType = RigidbodyType2D.Dynamic;

            textUI.SetActive(false);
            shoot = false;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - this.transform.position), new Vector3(1, 1, 0)).normalized;

            this.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        textUI.SetActive(true);
        Text targetText = textUI.GetComponent<Text>();
        targetText.text = "Clear!!";

        var rigidball = this.GetComponent<Rigidbody2D>();
        var rigidmonkey = monkey.GetComponent<Rigidbody2D>();
        rigidball.bodyType = RigidbodyType2D.Kinematic;
        rigidmonkey.bodyType = RigidbodyType2D.Kinematic;
    }
}
