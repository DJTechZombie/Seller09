using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public NavMeshAgent agent;
    public GameObject player;
    private MouseKnightController pc;
    public GameManager gameManager;
    private Collider myCollider;

    public bool _canMove = true;

    private Animator _anim;

    private float _startDelay = 1f;
    private float maxDistance = 10f;

    private float difficultyModifier;
    private int difficulty;
    private float defaultSpeed = 2.5f;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            difficulty = gameManager.difficulty;
        }
        else
        {
            difficulty = 1;
        }

        if(difficulty == 2)
        {
            difficultyModifier = 1.5f;
        }
        else if(difficulty == 1)
        {
            difficultyModifier = 0.5f;
        }
        else
        {
            difficultyModifier = 1;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<MouseKnightController>();
        _anim = this.gameObject.GetComponentInChildren<Animator>();
        myCollider = GetComponentInChildren<Collider>();
        _anim.SetBool("canMove", true);
        agent.speed *= difficultyModifier;
        defaultSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update ()
    {
        _startDelay = _startDelay - Time.deltaTime;
        if (_canMove && _startDelay < 0f)
        {
            if (!pc.isDead)
            {
                agent.SetDestination(player.transform.position);
            }
            else
            {
                agent.isStopped = true;
                _anim.SetBool("isIdle", true);
                _anim.SetBool("canMove", false);
                _canMove = false;
            }
        }
       /* if(agent.remainingDistance > maxDistance)
        {
            agent.speed *= 2;
        }
        else
        {
            agent.speed = defaultSpeed;
        }
        */
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _canMove = false;
            _anim.SetBool("canAttack", true);
            _anim.SetBool("canMove", false);
            Debug.Log("Collided with : " + other.gameObject.name);
            pc.Die(this.transform.position);
            StartCoroutine(stopCollider());
        }

    }

    IEnumerator stopCollider()
    {
        yield return new WaitForSeconds(2.5f);
        myCollider.enabled = false;
    }
}
