using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveZ += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveZ -= 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX += 1f;
        }

        float moveLength = Mathf.Sqrt((moveX * moveX) + (moveZ * moveZ));

        if (moveLength > 0f)
        {
            moveX = moveX / moveLength;
            moveZ = moveZ / moveLength;
        }

        transform.position += new Vector3(moveX, 0f, moveZ) * speed * Time.deltaTime;
    }
}