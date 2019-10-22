using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : SMAAgent {

	public float m_speed = 100.0f;
	public SpriteRenderer m_renderer;
	public Sprite m_frontSprite;
	public Sprite m_backSprite;
	public Sprite m_sideSprite;
	public Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		m_renderer = gameObject.GetComponent<SpriteRenderer> ();
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}

	public override void SMAFixedUpdate(float dt){
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb2D.MovePosition(new Vector2 (-m_speed * dt,0)+  rb2D.position);
			m_renderer.sprite = m_sideSprite;
			m_renderer.flipX = true;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb2D.MovePosition(new Vector2 (+m_speed * dt,0)+  rb2D.position);
			m_renderer.sprite = m_sideSprite;
			m_renderer.flipX = false;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			rb2D.MovePosition(new Vector2 (0,+m_speed * dt)+  rb2D.position);
			m_renderer.sprite = m_backSprite;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			rb2D.MovePosition(new Vector2 (0,-m_speed * dt)+  rb2D.position);
			m_renderer.sprite = m_frontSprite;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "grass dark") {
			m_speed = 50.0f;
		}
	}

	private void OnTriggerExit2D(Collider2D collision){
		m_speed = 100.0f;
	}
}
