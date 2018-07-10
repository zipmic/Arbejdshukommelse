using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Quest : MonoBehaviour {

    public Words WordsReference;
	public Points PointController;

    public List<string> WordsToFind = new List<string>();
    public int AmountOfWordsToFind = 3;
    public GameObject PrefabWordBLock;

    public Text QuestText;
    public int AmountOfBlocksToSpawn = 12;
    public List<GameObject> SpawnPoints = new List<GameObject>();

    public Text TidBrugt,HighscoreText;
  

    private int _amountFound = 0;

	// Use this for initialization
	void Start () 
    {
        
        if (PlayerPrefs.HasKey("Highscore"))
        {
            HighscoreText.text = "Bedste tid: "+PlayerPrefs.GetFloat("Highscore");
        }

        QuestText.text = "Find ";
        for (int i = 0; i < AmountOfWordsToFind; i++)
        {
            //tilføjer random ord 
            int word = Random.Range(0, WordsReference.AllTheWords.Length);
            WordsToFind.Add(WordsReference.AllTheWords[word]);

            if(i == AmountOfWordsToFind-1)
            {
                QuestText.text += "<color=#00ff00ff>"+WordsReference.AllTheWords[word]+"</Color>";
            }
            else if (i != AmountOfWordsToFind)
            {
                QuestText.text += "<color=#00ff00ff>"+WordsReference.AllTheWords[word]+"</Color>" + ", ";
            }
         
                  
        }


        /*// Spawn 120 Blocks
        for (int i = 0; i < SpawnPoints.Count; i++)
        {

            GameObject t = Instantiate(PrefabWordBLock) as GameObject;
            t.transform.position = SpawnPoints[i].transform.position;
            t.GetComponent<WordBlock>().SetBlock(WordsReference.AllTheWords[i]); 

        }
        */


     

	}

    public void FoundAllWords()
    {
      


    }

    void Update()
    {

       
    }

	public void AddCorrectWord()
	{
		PointController.AddCorrectPoint();
	}
	
    public bool CheckWord(string word)
    {
        foreach(string s in WordsToFind)
        {
            if (s == word)
            {
                print("s: " + s + " er det samme som: " + word);
                return true;
            }
        }

        return false;
    }
    public GameObject WinScreen;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Block")
        {
            if (CheckWord(other.GetComponent<WordBlock>().BlockText))
            {
                print("You got one!");
                _amountFound += 1;

                Destroy(other.gameObject);

                if (_amountFound >= AmountOfWordsToFind)
                {
                    // win
                    WinScreen.gameObject.SetActive(true);

                    FoundAllWords();

                }
                    
            }
        }
    }
}
