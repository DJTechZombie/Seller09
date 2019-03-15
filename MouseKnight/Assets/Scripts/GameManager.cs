using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    static GameManager instance;
    public int difficulty = 0;

    // Use this for initialization
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void setDifficulty(int diff)
    {
        difficulty = diff;
    }

}
