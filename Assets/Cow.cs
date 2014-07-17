using UnityEngine;
using System.Collections;

public class Cow : MonoBehaviour
{
    private Vector3 gravity = new Vector3(0, 0.02f, 0);
    public GameObject micVolume;
    private float moveSpeed;
    private byte balloons = 3;
    public GameObject alertWin;
    public GameObject alertLose;

    void FixedUpdate()
    {
        /* Move Cow upwards based on Mic volume */

        moveSpeed = micVolume.GetComponent<MicrophoneInput>().loudness * 0.01f;
        transform.position = new Vector3(0, transform.position.y + moveSpeed, 0);

        /* Simulate our own gravity (this one doesn't get stronger when high) */

        transform.position -= gravity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /* Hands Collision */

        if (other.name == "Hand" && transform.GetComponent<SpriteRenderer>().color.a == 1)
        {
            other.audio.Play();

            /* Prevent from multiple collision */

            Color alpha = new Color(1, 1, 1, 0.5f);
            transform.GetComponent<SpriteRenderer>().color = alpha;
            Invoke("EnableCollision", 1);

            /* Remove Balloon */

            Destroy(GameObject.Find("Balloon"));
            balloons--;

            /* Game Over */

            if(balloons == 0)
            {
                GameObject alert = Instantiate(alertLose, new Vector3(0, 0, 0), transform.rotation) as GameObject;
                gravity.y = 0;
                Time.timeScale = 0;
            }
        }

        /* Star Collision */

        if (other.name == "Star")
        {
            audio.Play();
            Destroy(other.gameObject);
            GameObject alert = Instantiate(alertWin, new Vector3(0, 0, 0), transform.rotation) as GameObject;
            gravity.y = 0;
        }
    }

    void EnableCollision()
    {
        Color alpha = new Color(1, 1, 1, 1);
        transform.GetComponent<SpriteRenderer>().color = alpha;
    }
}