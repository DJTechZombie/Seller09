using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MouseKnightController : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;
    public float speed;
    public bool isDead = false;

    [SerializeField]
    private bool _hasShield = false;
    [SerializeField]
    private bool _hasSword = false;

    public Animator anim;
    // Update is called once per frame

    private ItemController ic;
    private AudioSource bgMusic;
    private AudioListener listener;

    private void Start()
    {
        isDead = false;
        cam = Camera.main;
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        ic = this.gameObject.GetComponent<ItemController>();

        bgMusic = FindObjectOfType<AudioSource>();
        listener = FindObjectOfType<AudioListener>();
        if (ic != null)
        {
            _hasShield = ic._hasShield;
            _hasSword = ic._hasSword;
        }
        anim.SetBool("isDead", false);
    }

    void Update ()
    {
        if(isDead)
        {
            agent.isStopped=true;
            //transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z);
            //transform.rotation = Quaternion.identity;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

        }
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            anim.SetBool("isMoving", true);
        }
        else if(agent.remainingDistance < agent.stoppingDistance)
        {
            anim.SetBool("isMoving", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            //anim.Play("Attack01");
            //StartCoroutine(AttackDelay());
        }


    }

    public void Die(Vector3 enemyPOS)
    {
        if (_hasShield||_hasSword)
        {
            this.transform.LookAt(enemyPOS);
            if (_hasSword)
            {
                anim.SetTrigger("attacked");
                _hasSword = false;
            }
            else if (_hasShield)
            {
                anim.SetTrigger("blocked");
                _hasShield = false;
            }
        }
        else
        {
            this.transform.LookAt(enemyPOS);
            isDead = true;
            anim.SetBool("isMoving", false);
            anim.SetBool("isDead", true);
            StartCoroutine(LoadDeadScene());
        }
    }
    IEnumerator LoadDeadScene()
    {
        Debug.Log("You are Dead");
        yield return new WaitForSeconds(3.5f);
        bgMusic.Stop();
        Destroy(listener);
        SceneManager.LoadScene("DeadScene",LoadSceneMode.Additive);
    }
}
