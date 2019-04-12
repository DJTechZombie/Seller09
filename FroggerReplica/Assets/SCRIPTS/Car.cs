using UnityEngine;

public class Car : MonoBehaviour {

	public Rigidbody2D rb;

	public float minSpeed = 8f;
	public float maxSpeed = 12f;

	float speed = 1f;
    private float activeTime; // time object is instantiated.
    private float CurrentTime; // current time each update frame.

	void Start ()
	{
		speed = Random.Range(minSpeed, maxSpeed);
        activeTime = Time.time;
        speed *= GameManager.manager.carSpeed;
        setSize();
	}

	void FixedUpdate () {
		Vector2 forward = new Vector2(transform.right.x, transform.right.y);
		rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
	}

    private void Update()
    {
        CurrentTime = Time.time - activeTime; // time since instantiated

        if (CurrentTime >= 2f) // Destroy car after 2 seconds
        {
            DestroyAfterTime();
        }

    }

    void DestroyAfterTime()
    {
        Destroy(this.gameObject);
    }

    void setSize()
    {
        float sizeX = transform.localScale.x * GameManager.manager.carSize;
        float sizeY = transform.localScale.y * GameManager.manager.carSize;
        transform.localScale = new Vector3(sizeX, sizeY, 1f);

    }
}
