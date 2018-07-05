using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

	
	public float jumpForce = 10f;

	public Rigidbody2D rb;

	public string currentColor;
	
	[SerializeField] 
	private SpriteRenderer _spriteRenderer;

	public Color _colorCyan;
	public Color _colorYellow;
	public Color _colorMagenta;
	public Color _colorPink;
	
	public AudioClip _audioJump;
	public AudioSource _audioSource;
	
	void Start () {
		SetRandomColor();
		_audioSource.clip = _audioJump;
	}
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			_audioSource.Play();
			rb.velocity = Vector2.up*jumpForce;
		
			
		}
	}

	private void OnTriggerEnter2D(Collider2D collider2D)
	{
		if (collider2D.tag == "ColorChanger")
		{
			SetRandomColor();
			Destroy(collider2D.gameObject);
			return;
			
		}
		//Debug.Log(collider2D.tag);
		if (currentColor != collider2D.tag)
		{
			//Debug.Log("GAME OVER");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			
		}
		

		
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
