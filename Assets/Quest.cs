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
    private bool _gameStarted = false;


    /// <summary>
    /// Når man finder et korrekt ord, skal det tjekkes af fra listen og man får point. Og det ord man tjekkede af skal skifte til rød.
    /// Når man har alle "AmountOfWordsToFind", så bliver listen fyldt med 1 ord mere og nyt random
    /// 
    /// </summary>

	// Use this for initialization


	void Start () 
    {
        
        if (PlayerPrefs.HasKey("Highscore"))
        {
            HighscoreText.text = "Bedste tid: "+PlayerPrefs.GetFloat("Highscore");
        }

        QuestText.text = "Tryk E for at starte...";

  


	}

    void NewQuestText()
    {
        QuestText.text = "Find ";
        for (int i = 0; i < AmountOfWordsToFind; i++)
        {
            //tilføjer random ord 
            int word = Random.Range(0, WordsReference.AllTheWords.Length);
            WordsToFind.Add(WordsReference.AllTheWords[word]);

            if (i == AmountOfWordsToFind - 1)
            {
                QuestText.text += "<color=#00ff00ff>" + WordsReference.AllTheWords[word] + "</Color>";
            }
            else if (i != AmountOfWordsToFind)
            {
                QuestText.text += "<color=#00ff00ff>" + WordsReference.AllTheWords[word] + "</Color>" + ", ";
            }

        }

    }
 

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E) && _gameStarted == false)
        {
            _gameStarted = true;
            NewQuestText();
        }
    }

	public void AddCorrectWord()
	{
		PointController.AddCorrectPoint();
	}
	
    public bool CheckWord(string word)
    {
        for (int i = 0; i < WordsToFind.Count; i++)
        {
            if (WordsToFind[i] == word)
            {

                WordsToFind[i] = "";
                _amountFound++;
                AddCorrectWord();
                if(_amountFound >= AmountOfWordsToFind)
                {
                    // Der er fundet dem alle, new quest og sværere!
                    AmountOfWordsToFind++;
                    NewQuestText();
                }
                // noget med at gøre den rigtige tekst rød så man kan se progress. Men prøver ikke i starten.
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


                }
                    
            }
        }
    }
}
