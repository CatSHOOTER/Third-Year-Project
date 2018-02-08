using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public class LeaderBoardLoad : MonoBehaviour {
 public static   List<Player> players = new List<Player>();
    
    string score;
    string lname;
    int LeaderBoardRank;
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
        WriteToLeaderBoard();


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

        var query = from p in players
                    orderby p.Score ascending
                    select p;

        LeaderBoardRank = 1;
       
        foreach (Player p in query)
        {
           
            if (LeaderBoardRank <= 5)
            {
                DisplayLeaderBoard.GetComponent<Text>().text += string.Format("\n# {0}.\t{1}\n", LeaderBoardRank, p.ToString());
                
            }
            LeaderBoardRank++;  
        }


    }
    void Awake()
    {
        LoadFile("Saved/Profile.txt");
        WriteToLeaderBoard();
    }
}
