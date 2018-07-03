
using UnityEngine;

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
	
	void Start () {
		SetRandomColor();
	}
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			rb.velocity = Vector2.up*jumpForce;
		}
	}

	private void OnTriggerEnter2D(Collider2D collider2D)
	{
		//Debug.Log(collider2D.tag);
		if (currentColor != collider2D.tag)	
		{
			Debug.Log("GAME OVER");
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
