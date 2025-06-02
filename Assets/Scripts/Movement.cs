using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float rotateHiz = 0f;
    [SerializeField] float shootForce = 10f;
    [SerializeField] Renderer arrowRen;
    public Transform direction;
    bool canMove = true;
    bool rotatingLeft = false;
    bool rotatingRight = false;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!canMove) return;
        if (rotatingLeft)
        {
            transform.Rotate(0, 0, -rotateHiz * Time.deltaTime);
        }
        if (rotatingRight)
        {
            transform.Rotate(0, 0, rotateHiz * Time.deltaTime);
        }
        
    }
    void Move()
    {
        float steerAmount = Input.GetAxis("Horizontal");
        float rotateSpeed = steerAmount * Time.deltaTime * rotateHiz;
        transform.Rotate(0, 0, rotateSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.linearVelocity = shootForce * direction.up;

            arrowRen.enabled = false;
            canMove = false;
        }


    }
    public void OnRotateLeftDown() => rotatingLeft = true;
    public void OnRotateLeftUp() => rotatingLeft = false;
    public void OnRotateRightDown() => rotatingRight = true;
    public void OnRotateRightUp() => rotatingRight = false;

    public void Shoot()
    {
        rb.linearVelocity = shootForce * direction.up;
        arrowRen.enabled = false;
        canMove = false;

        GameObject[] moveButtons = GameObject.FindGameObjectsWithTag("moveButtonsTag");

        foreach (GameObject moveButton in moveButtons)
        {
            moveButton.SetActive(false);
        }
    }
    public void StopMove()
    {
        canMove = false;
        rb.linearVelocity = new Vector2(0, 0);

    }
}
