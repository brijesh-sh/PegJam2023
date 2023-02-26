using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 8f;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0f, 0f).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

}