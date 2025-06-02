using UnityEngine;

public class Reflection : MonoBehaviour
{
    [SerializeField] float WaitTime = 0.1f;
    public bool canCollide = true;
    public Rigidbody2D rb;
    float speed;

    public bool nowCollide = false;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = rb.linearVelocity.magnitude;
    }

    void OnCollisionEnter2D(Collision2D wall)
    {
        if (!canCollide) return;
        Vector2 gelenYon = rb.linearVelocity.normalized;
        Vector2 normal = wall.contacts[0].normal;
        Vector2 yansiyanYon = Vector2.Reflect(gelenYon, normal);
        //rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, yansiyanYon * rb.linearVelocity.magnitude, 0.8f);

        if (speed < 2f)
        {
            speed = 2f;
        }
        rb.linearVelocity = yansiyanYon * speed;
        nowCollide = true;
        canCollide = false;
        Invoke("Wait", WaitTime);


    }
    void Wait()
    {
        nowCollide = false;
        canCollide = true;
    }
}
