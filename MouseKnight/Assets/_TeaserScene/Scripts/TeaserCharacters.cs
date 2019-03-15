using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeaserCharacters : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        agent.SetDestination(target.transform.position);
        
    }

    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Detected.");
        if (this.tag == "Player")
        {
            Debug.Log(this.name + " collided with " + other.gameObject.name);
            if (other.gameObject.tag == "Enemy")

            {
                anim.SetBool("inRange", true);
            }
        }
        else if(this.tag == "Enemy")
        {
            Debug.Log(this.name + " collided with " + other.gameObject.name);
            if (other.gameObject.tag == "Player")
            {
                anim.SetBool("inRange", true);
            }
        }
        else
        {
            Debug.Log("No Matching Tags found");
        }
    }
}
