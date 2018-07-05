using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerMove : MonoBehaviour
{


	public float jumpForce = 10f;

	public Rigidbody2D rb;

	public string currentColor;

	[SerializeField] private SpriteRenderer _spriteRenderer;

	public Color _colorCyan;
	public Color _colorYellow;
	public Color _colorMagenta;
	public Color _colorPink;
	[SerializeField] private String sceneName;



void Start () {
		SetRandomColor();
	}
	
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			//_audioSource.Play();
			SoundManager.playSound("jump");
			rb.velocity = Vector2.up*jumpForce;
		
			
		}
	}

	private void OnTriggerEnter2D(Collider2D collider2D)
	{
		if (collider2D.tag == "ColorChanger"){
			SetRandomColor();
			Destroy(collider2D.gameObject);
			return;	
		}
		if (collider2D.tag == "NextLevel"){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
			
		}
		if (collider2D.tag == "LoadScene"){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			
		}
		//Debug.Log(collider2D.tag);
		if (currentColor != collider2D.tag)
		{
			SoundManager.playSound("bum");
			StartCoroutine(weiter());
			//Debug.Log("GAME OVER");
			//
		}
	
		

		
	}

	IEnumerator weiter(){
		//yield return new WaitForSeconds(0.1f);
		yield return new WaitForSecondsRealtime(0.1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		
	}

	void SetRandomColor()
	{
		int index = Random.Range(0, 4);
		
		switch (index)
		{
			case 0 :
				currentColor = "Cyan";
				_spriteRenderer.color = _colorCyan;
				break;
			case 1 :
				currentColor = "Yellow";
				_spriteRenderer.color = _colorYellow;
				break;
			case 2 : 
				currentColor = "Magenta";
				_spriteRenderer.color = _colorMagenta;
				break;
			case 3 : 
				currentColor = "Pink";
				_spriteRenderer.color = _colorPink;
				break;
			
		}
	}

}
