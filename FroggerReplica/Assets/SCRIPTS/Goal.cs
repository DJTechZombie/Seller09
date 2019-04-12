using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	void OnTriggerEnter2D ()
	{
		Debug.Log("YOU WON!");
        GameManager.manager.score += 100;
        GameManager.manager.lifeScore += 100;
        GameManager.manager.levelsCleared++;
        GUI_Manager.guiMan.UpdateScore(GameManager.manager.score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
