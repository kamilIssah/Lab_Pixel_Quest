using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReverseMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 5;
    public string nextlevel = "Scene_2";
    public string thislevel;
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
            sr.color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sr.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sr.color = Color.black;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Death":
                // Reload current scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;

            case "Finish":
                LoadNextScene();
                break;
        }
    }
    void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        Debug.Log("Current Scene Index: " + currentIndex);
        Debug.Log("Next Scene Index: " + nextIndex);

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("All levels complete! No more scenes to load.");
        }
    }
}
