using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float startForce = 15f;

    Rigidbody2D rb;

    void Start()
    {
        startForce *= GameManager.instance.fruitSpeedMult;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale *= GameManager.instance.gravityScaleMult;
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
        float scale = transform.localScale.x * GameManager.instance.fruitSizeMult;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(explosionPrefab, transform.position, rotation);
            Destroy(slicedFruit, .5f);
            Destroy(gameObject);
        }
    }

}
