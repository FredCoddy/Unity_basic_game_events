/*
AI Behavior
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BOT_STATE{SANE, ILL, IMMUNED};

public class move_bot : SMAAgent {
	public BOT_STATE m_state;
	public float m_speed = 100.0f;
	public SpriteRenderer m_renderer;
	public Sprite m_frontSprite;
	public Sprite m_backSprite;
	public Sprite m_sideSprite;
	public Rigidbody2D rb2D;
	public Vector2 direction;
	public float count;

	// Use this for initialization
	void Start () {

		m_renderer = gameObject.GetComponent<SpriteRenderer> ();
		rb2D = gameObject.GetComponent<Rigidbody2D>();
		//direction = new Vector2 (0, +m_speed * Time.deltaTime) + rb2D.position;
		count = 0;
	}

	public override void SMAFixedUpdate(float dt){
		count += dt;
		Vector2 newPos = Vector2.zero;

		// haut / bas
		newPos.x = transform.position.x + m_speed * dt * direction.x;
		// newPos.x = 0;
		newPos.y = transform.position.y + m_speed * dt * direction.y;

		// rb2D.MovePosition(new Vector2 (-m_speed * dt,0)+  rb2D.position);
		rb2D.MovePosition(newPos);

		if(direction.y>0){
			m_renderer.sprite=m_backSprite;
		}else if(direction.y<0){
			m_renderer.sprite=m_frontSprite;

		}
		if(direction.x>0){
			m_renderer.sprite=m_sideSprite;
			m_renderer.flipX = true;
		}else if(direction.x<0){
			m_renderer.sprite=m_sideSprite;
			m_renderer.flipX = false;
		}

		if (m_state == BOT_STATE.SANE) {
			m_renderer.color = Color.blue;
		} else if (m_state == BOT_STATE.ILL) {
			m_renderer.color = Color.red;
		}
		else {
			m_renderer.color = Color.green;
		}

		if(m_state==BOT_STATE.SANE || m_state==BOT_STATE.IMMUNED){
			m_speed=50.0f;
		}else if(m_state==BOT_STATE.ILL){
			m_speed=100.0f;
		}

//		if (count >= 10) {
//			// rend les vikings vert après 10s
//			count = 0;
//			m_state = BOT_STATE.IMMUNED;
//		}
	}


	void OnCollisionEnter2D (Collision2D other) {
		// change direction
		if (other.gameObject.tag == "bot" || other.gameObject.tag == "bordure" || other.gameObject.tag == "water" || other.gameObject.tag == "degradable" || other.gameObject.tag == "player" ){
			direction.x = - direction.x;
			direction.y = - direction.y;
		}
		if (other.gameObject.tag == "bot" && m_state != BOT_STATE.IMMUNED){
			//Ne marche pas, si immuned peut contaminer un vikinbgs

			m_state = BOT_STATE.ILL;
		}


	}


}
