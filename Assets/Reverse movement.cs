using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reversemovement : MonoBehaviour
{
    int var = 3
    private Rigidbody2D rb;
    public int speed = -5;
    public string nextlevel = "Scene_2";
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sr.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sr.color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sr.color = Color.green;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    SceneManager.LoadScene(thislevel);
                    break;
                }
            case "Finish":
                { SceneManaer.LoadScene(nextlevel);
                    break;
                }
        }
}
