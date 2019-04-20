using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Fruit")
        {
            if(!other.isTrigger)
            { 
            GameManager.instance.fruitMissed++;
            Debug.Log("Fruit Missed");
            }
        }
        Destroy(other.gameObject);
    }
}
