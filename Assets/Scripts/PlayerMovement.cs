using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] KeyCode dropClaw = KeyCode.S;

    private bool canMove = true;

    private float _boundary = 100f;

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

            Vector3 pos = transform.position;
            if (pos.x > _boundary) {
                pos.x = _boundary;
            }
            else if (pos.x < -_boundary) {
                pos.x = -_boundary;
            }
            transform.position = pos;
        }
    }

    public void ToggleControl(bool test) {
        canMove = test;
    }

}