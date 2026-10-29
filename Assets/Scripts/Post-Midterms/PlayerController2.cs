using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    
    public float playerWidth;
    public float playerHeight;
    
    private float verticalVelocity;
    private bool isGrounded;
    
    private AABBCollider currentCollider;

    private void Update()
    {
        float horizontalInput = 0;
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        
        Vector3 pos = transform.position;
        pos.x = pos.x + (horizontalInput * moveSpeed * Time.deltaTime);
        transform.position = pos;
        
        AABBCollider[] allColliders = FindObjectsByType<AABBCollider>(FindObjectsSortMode.None);
        
        for (int i = 0; i < allColliders.Length; i++)
        {
            currentCollider = allColliders[i];
            
            if (IsOverlapping() == true)
            {
                if (currentCollider.gameObject.tag == "Obstacle")
                {
                    float targetCenterX = currentCollider.min.x + ((currentCollider.max.x - currentCollider.min.x) / 2);
                    if (transform.position.x < targetCenterX)
                    {
                        pos.x = currentCollider.min.x - (playerWidth / 2);
                    }
                    if (transform.position.x > targetCenterX)
                    {
                        pos.x = currentCollider.max.x + (playerWidth / 2);
                    }
                    transform.position = pos;
                }
                if (currentCollider.gameObject.tag == "FallCollider")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpPower;
                pos.y = pos.y + 0.05f;
                transform.position = pos;
                isGrounded = false;
            }
            else
            {
                verticalVelocity = 0;
            }
        }
        else
        {
            verticalVelocity = verticalVelocity - (20f * Time.deltaTime);
        }

        pos = transform.position;
        pos.y = pos.y + (verticalVelocity * Time.deltaTime);
        transform.position = pos;
        
        isGrounded = false;

        for (int i = 0; i < allColliders.Length; i++)
        {
            currentCollider = allColliders[i];
            
            if (IsOverlapping() == true)
            {
                if (currentCollider.gameObject.tag == "Ground" || currentCollider.gameObject.tag == "Obstacle")
                {
                    float targetCenterY = currentCollider.min.y + ((currentCollider.max.y - currentCollider.min.y) / 2);
                    
                    if (transform.position.y > targetCenterY)
                    {
                        pos.y = currentCollider.max.y + (playerHeight / 2);
                        transform.position = pos;
                        isGrounded = true;
                        verticalVelocity = 0;
                    }
                    if (transform.position.y < targetCenterY)
                    {
                        pos.y = currentCollider.min.y - (playerHeight / 2);
                        transform.position = pos;
                        verticalVelocity = 0;
                    }
                }
                if (currentCollider.gameObject.tag == "FallCollider")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    private bool IsOverlapping()
    {
        float targetWidth = currentCollider.max.x - currentCollider.min.x;
        float targetHeight = currentCollider.max.y - currentCollider.min.y;
        
        float targetCenterX = currentCollider.min.x + (targetWidth / 2);
        float targetCenterY = currentCollider.min.y + (targetHeight / 2);

        float distanceX = Mathf.Abs(transform.position.x - targetCenterX);
        float distanceY = Mathf.Abs(transform.position.y - targetCenterY);

        float combinedHalfWidth = (playerWidth / 2) + (targetWidth / 2);
        float combinedHalfHeight = (playerHeight / 2) + (targetHeight / 2);

        if (distanceX <= combinedHalfWidth)
        {
            if (distanceY <= combinedHalfHeight)
            {
                return true;
            }
        }

        return false;
    }
}