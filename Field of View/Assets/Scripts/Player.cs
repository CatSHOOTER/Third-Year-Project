using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player:MonoBehaviour  {

   public string Name { get; set; }
    public string Score { get; set; }
    
    public Text LeaderBoard;
    public Player(string name,string score)
    {
        Name = name;
        Score = score;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//var query= from c in players
  //                 orderby c.Time
  //                 select new { c.}

	}
    public override string ToString()
    {
        return Name+ " ,"+ Score+",";
    }
}
