using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour {
    public GameObject Time;
    public InputField Username;
    string score;
    string sname;
	// Use this for initialization
	void Start () {

        Username.onEndEdit.AddListener(OnUsernameEntered);
    }

	
	// Update is called once per frame
	void Update () {
       
	}
    public void SaveFile()
    {

        score = Time.GetComponent<Text>().text;
        
        Player  player = new Player(sname, score);
        LeaderBoardLoad.players.Add(player);
         Debug.Log(player.ToString());
       // Player.players.Add(player);
        Save(LeaderBoardLoad.players, "Saved/Profile.txt");
         //   Save(Time, "Saved/Profile.csv");



    }
    public void Save(List<Player> objectToSave, string path)
    {
        

        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (Player item in objectToSave)
            {
                if (item.Name != string.Empty)
                {
                    sw.WriteLine(item.ToString());
                }
                else 
                {
                    item.Name = "Player";
                    sw.WriteLine(item.ToString());
                }
                
            }
            sw.Close();
            //string json = JsonUtility.ToJson(objectToSave, true);
            //sw.Write(json);
        }
    }
    private void OnUsernameEntered(string contents)
    {
        sname = contents;
    }
}
