using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Updateimmuned : MonoBehaviour
{
    public PlayerXP xp;
    public Text count_text;
    public string tmp_score;
    // Start is called before the first frame update
    void Start()
    {
        count_text.text = "Immunised vikings = 0";
        tmp_score = xp.immunisedAgent.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if ( xp.immunisedAgent.ToString() != tmp_score){
            count_text.text = "Immunised vikings = " + xp.immunisedAgent.ToString();
            tmp_score = xp.immunisedAgent.ToString();
        }
    }
}
