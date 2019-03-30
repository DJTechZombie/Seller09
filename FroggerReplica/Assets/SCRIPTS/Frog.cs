using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour {

	public Rigidbody2D rb;
    public AudioClip jump;
    AudioSource audioSource;
    
    private void Start()
    {
            audioSource = GetComponent<AudioSource>();
    }
    void Update() {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.eulerAngles.z != -90)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            audioSource.PlayOneShot(jump, 0.7F);
            rb.MovePosition(rb.position + Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.eulerAngles.z != 90)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            audioSource.PlayOneShot(jump, 0.7F);
            rb.MovePosition(rb.position + Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (transform.eulerAngles.z != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            audioSource.PlayOneShot(jump, 0.7F);
            rb.MovePosition(rb.position + Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (transform.eulerAngles.z != 180)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            audioSource.PlayOneShot(jump, 0.7F);
            rb.MovePosition(rb.position + Vector2.down);
        }
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Car")
		{
            if (GameManager.manager.lives > 1)
            {
                GameManager.manager.lives--;
                GUI_Manager.guiMan.DisplayLives(GameManager.manager.lives);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                BGMcontroller.bgm.StopMusic();
                SceneManager.LoadScene("GameOver");
            }
		}
        else if(col.tag == "Fly")
        {
            Debug.Log("Fly collected");
            Destroy(col.gameObject);
            GameManager.manager.score += 250;
            GUI_Manager.guiMan.UpdateScore(GameManager.manager.score);
        }
	}
}
