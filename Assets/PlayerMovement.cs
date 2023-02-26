using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField]  KeyCode dropClaw = KeyCode.S;

    public bool canMove = true;

    void Update()
    {
        if (canMove) {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            Vector3 direction = new Vector3(horizontalInput, 0f, 0f).normalized;
            transform.position += direction * speed * Time.deltaTime;

            if (Input.GetKeyDown(dropClaw)) {
                ToggleControl(false);
                FindObjectOfType<ClawBehavior>().Drop();
            }
        }
    }

    public void ToggleControl(bool test) {
        canMove = test;
    }

}