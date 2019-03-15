using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour {

    public GameObject player;
    private int _nextScene;
    void Start ()
    {
        Debug.Log("Current Scene:" + SceneManager.GetActiveScene().name);
        player = GameObject.FindGameObjectWithTag("Player");
        _nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("You Reached the Goal");
            SceneManager.LoadScene(_nextScene);
        }

    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextScene);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
        
    }


}
