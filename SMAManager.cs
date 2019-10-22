using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMAManager : MonoBehaviour
{
	public static SMAManager instance = null;
	public SMAAgent[] m_agents;
	public float count;
	public float count_direction;

	// public float count_die;

	void Start(){
		count = 0;
		count_direction = 0;
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
			m_agents = FindObjectsOfType<SMAAgent>();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Update(){
		foreach (SMAAgent currenAgent in m_agents) {
			currenAgent.SMAUpdate (Time.deltaTime);

		}
		// for(int i =0; i<m_agents.Length;i++){
		// move_bot currentBot = m_agents [i].gameObject.GetComponent<move_bot> ();
		// 	if(currentBot.m_state==BOT_STATE.IMMUNED){
		// 		died++;
		// 	}
		// }
	}
	void FixedUpdate(){
		count += Time.deltaTime;
		count_direction += Time.deltaTime;

		if (count >= 3) {
			int contaminedAgent = Random.Range (0, m_agents.Length - 1);
			move_bot currentBot = m_agents [contaminedAgent].gameObject.GetComponent<move_bot> ();
			if(currentBot.m_state!=BOT_STATE.IMMUNED){
				currentBot.m_state = BOT_STATE.ILL;
			}
			count = 0;
		}
		if (count_direction >= 1 ){
			int contaminedAgent = Random.Range (0, m_agents.Length - 1);
			move_bot currentBot = m_agents [contaminedAgent].gameObject.GetComponent<move_bot> ();
			if(currentBot != null){
				// mv=Random.Range (-1,1);
				currentBot.direction.x = Random.Range (-1,1);
				currentBot.direction.y = Random.Range (-1,1);


				count_direction = 0;
			}
		}


		foreach (SMAAgent currenAgent in m_agents) {
			currenAgent.SMAFixedUpdate(Time.fixedDeltaTime);
		}
	}

}
