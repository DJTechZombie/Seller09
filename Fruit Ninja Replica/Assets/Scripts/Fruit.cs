using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	public GameObject fruitSlicedPrefab;
	public float startForce = 15f;

	Rigidbody2D rb;

	void Start ()
	{
        startForce *= GameManager.instance.fruitSpeedMult;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale *= GameManager.instance.gravityScaleMult;
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
        float scale = transform.localScale.x * GameManager.instance.fruitSizeMult;
        transform.localScale = new Vector3(scale,scale,scale);
       
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Blade")
		{
            GameManager.instance.IncreaseScore();
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction);

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
			Destroy(slicedFruit, 3f);
			Destroy(gameObject);
		}
        else if(col.tag == "Explosion")
        {
            GameManager.instance.score -= 1;
            Destroy(gameObject);
        }
	}

}
