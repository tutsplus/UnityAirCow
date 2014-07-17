using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour
{
    private float moveSpeed = 0.02f;
    private float currentPos;
    public bool left = false;
    // Use this for initialization
    void Start()
    {
        currentPos = transform.position.x;
    }
    
    // Update is called once per frame
    void Update()
    {
        /* Move Hand */

        /* Move to the right if hand is on the left side */

        if (!left)
        {
            transform.position -= new Vector3(moveSpeed, 0, 0);
        } else
        {
            transform.position += new Vector3(moveSpeed, 0, 0);
        }

        /* Change moveSpeed to move in the other direction, creating a movement loop */

        if (transform.position.x <= currentPos - 0.7f)
        {
            moveSpeed *= -1;
        }
        if (transform.position.x >= currentPos + 0.7f)
        {
            moveSpeed *= -1;
        }
    }
}