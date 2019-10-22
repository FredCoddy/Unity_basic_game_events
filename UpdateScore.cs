using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public PlayerXP xp;
    public Text count_text;
    public string tmp_score;

    // Start is called before the first frame update
    void Start()
    {
        count_text.text = "Medics = 0";
        tmp_score = xp.m_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if ( xp.m_score.ToString() != tmp_score){
            count_text.text = "Medics = " + xp.m_score.ToString();
            tmp_score = xp.m_score.ToString();
        }
    }
}
