using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour {

	public int m_score;
	public int immunisedAgent;
	public AudioClip clip;
	public AudioClip mainTheme;

	// Use this for initialization
	void Start () {
		AudioManager.instance.PlaySound(mainTheme);
	}


	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "coin" ) {
			Destroy (other.gameObject);
			m_score++;
			AudioManager.instance.PlaySound(clip);
		}

		else if (other.gameObject.tag == "bot" && m_score!=0 ) {
			move_bot target = other.gameObject.GetComponent<move_bot> ();
			if (target.m_state == BOT_STATE.ILL){
				target.m_state = BOT_STATE.SANE;
				m_score--;

				float contaminedAgent = Random.Range (0,1.0f);
				if(contaminedAgent <= 0.7){
					target.m_state = BOT_STATE.IMMUNED;
					immunisedAgent++;
					Debug.Log(immunisedAgent);
				}

			}
		}
		// END Condition
		if (m_score==0 && other.gameObject.tag == "bot" ){

		}

	}
}
