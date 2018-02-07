using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LeaderBoardLoad : MonoBehaviour {
 public static   List<Player> players = new List<Player>();
    string score;
    string lname;
    public GameObject DisplayLeaderBoard;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void PopulateLeaderBoard()
    {
        
        LoadFile("Saved/Profile.txt");


    }
    void LoadFile(string path)
    {
        using (StreamReader sr = new StreamReader(path))
        {
            players.Clear();

            string load = sr.ReadLine();
            while(load!=null)
            {
                string[] loadcheck = load.Split(',');
                lname = loadcheck[0];
                score = loadcheck[1];
                Player p = new Player(lname,score);
                players.Add(p);
               
                loadcheck = null;
                load = sr.ReadLine();

            }
           
            
        }
    }
    public void WriteToLeaderBoard()
    {
        DisplayLeaderBoard.GetComponent<Text>().text = "";
        foreach (Player p in players)
        {
            DisplayLeaderBoard.GetComponent<Text>().text += string.Format("{0}\n", p.ToString()) ;
        }
    }
    void Awake()
    {
        LoadFile("Saved/Profile.txt");
        WriteToLeaderBoard();
    }
}
