using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagement : MonoBehaviour
{
    public CharacterController playercontrol;

 public GameObject player;
    public int maxHealth = 10;
    public int currentHealth;
    public float Energy = 100;
    public float coins;
    public Text healthtext;
    public Text CoinsText;
    GameObject EnergyBar;
    GameObject HealthBar;

    public GameObject ResumeGameButton;
    public GameObject QuitGameButton;
    public GameObject ResetGameButton;
    public GameObject TutorialButton;
    public Text TutorialButtonText;

    public GameObject PlayerText;
    public GameObject DrillText;
    public GameObject FloatText;

    public bool tutorials = true;

    public GameObject LeverText1;
    public GameObject LeverText2;

    public GameObject Lever1;
    public GameObject Lever2;
    public GameObject Opening;

    public GameObject DoorText;
    public GameObject DoorText2;
    public GameObject Fireworks;
    public GameObject VictoryText;

    public int CurrentTutorial;


    //Respawn
    private bool isRespawning;
    private Vector3 respawnPoint;
    private Vector3 currentPoint;


    // Start is called before the first frame update
    void Start()
    {
        playercontrol = GetComponent<CharacterController>();

        //   player = GameObject.Find("Playber");
        EnergyBar = GameObject.Find("EnergyBar");
        HealthBar = GameObject.Find("HealthBar");

        respawnPoint = player.transform.position;

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hurty") 
        {
            TakeDamage();
        }

        if(other.tag == "Ring")
        {
            TakeDamage();
        }


    }
    public void TakeDamage()
    {
        if(currentHealth <= 0)
        {
            StartCoroutine(Teleporting());
        }

        else
        {
            // Debug.Log("Health " + currentHealth);
            Debug.Log("respawn" + respawnPoint);
            Debug.Log("current" + currentPoint);

            currentHealth = currentHealth - 1;
        healthtext.text = "Health: " + currentHealth.ToString();
        HealthBar.GetComponent<Scrollbar>().size = currentHealth * 0.1f;

        }




    }

    IEnumerator Teleporting()
    {
        playercontrol.enabled = false;

        yield return new WaitForSeconds(.5f);

        //player.transform.position = respawnPoint.transform.position;
        currentPoint = respawnPoint;
        yield return new WaitForSeconds(.5f);

        playercontrol.enabled = true;

        currentHealth = maxHealth;


    }

    public void Respawn()
    {

  

       // currentPoint = player.transform.position;

       // currentPoint = respawnPoint;
        currentHealth = maxHealth;

    }


    public void LoseEnergy(int energysubtract)
    {
        Energy = Energy - energysubtract;
       
        //Debug.Log(Energy);
    }
    /*
    public void LoseHealth(int healthsubtract)
    {
        Health -= healthsubtract;
        healthtext.text = "Health: " + Health.ToString();
        HealthBar.GetComponent<Scrollbar>().size = Health * 0.1f;
    }
    */
    public void AddCoin(int coinsgained)
    {
        coins += coinsgained;
        CoinsText.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // EnergyBar.GetComponent<Scrollbar>().size = Energy * 0.01f;
        if (Energy < 100)
        {
            Energy = Energy + 0.2f;
        }
    }

    void OpenMenu()
    {
        TutorialButton.SetActive(true);
        ResumeGameButton.SetActive(true);
        QuitGameButton.SetActive(true);
        ResetGameButton.SetActive(true);
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
            if (ResumeGameButton.activeInHierarchy == false)
            {
                OpenMenu();
            }
            else
            {
                ResumeGame();
            }
       }


    }

    public void ActivateLever1()
    {
        Lever1.GetComponent<LeverScript>().ChecktoCalculate = true;
    }

    public void ActivateLever2()
    {
        Lever2.GetComponent<LeverScript>().ChecktoCalculate = true;
    }

    public void ToggleTutorials()
    {
        if (tutorials == true)
        {
            tutorials = false;
            PlayerText.SetActive(false);
            DrillText.SetActive(false);
            FloatText.SetActive(false);
            TutorialButtonText.text = "Toggle Tutorials: OFF";
        }
        else
        {
            tutorials = true;
            if (CurrentTutorial == 1) HideTutorial();
            if (CurrentTutorial == 2) Enemy2Tutorial();
            if (CurrentTutorial == 3) Enemy3Tutorial();
            TutorialButtonText.text = "Toggle Tutorials: ON";
        }
    }

    public void HideTutorial()
    {
        if (tutorials == true)
        {
            PlayerText.SetActive(true);
            DrillText.SetActive(false);
            FloatText.SetActive(false);
            CurrentTutorial = 1;
        }
        else
        {
            PlayerText.SetActive(false);
            DrillText.SetActive(false);
            FloatText.SetActive(false);
            CurrentTutorial = 1;
        }
    }

    public void Enemy2Tutorial()
    {
        if (tutorials)
        {
            PlayerText.SetActive(false);
            DrillText.SetActive(false);
            FloatText.SetActive(true);
            CurrentTutorial = 2;
        }
        else
        {
            PlayerText.SetActive(false);
            DrillText.SetActive(false);
            FloatText.SetActive(false);
            CurrentTutorial = 2;
        }
    }

    public void Enemy3Tutorial()
    {
        if (tutorials)
        {
            PlayerText.SetActive(false);
            DrillText.SetActive(true);
            FloatText.SetActive(false);
            CurrentTutorial = 3;
        }
        else
        {
            PlayerText.SetActive(false);
            DrillText.SetActive(false);
            FloatText.SetActive(false);
            CurrentTutorial = 3;
        }
    }

    public void DoorTextReveal()
    {
        if (coins < 45)
        {
            DoorText.SetActive(true);
        }
        if (coins >= 45)
        {
            DoorText2.SetActive(true);
        }
    }

    public void DoorTextHide()
    {
        if (coins < 45)
        {
            DoorText.SetActive(false);
        }
        if (coins >= 45)
        {
            DoorText2.SetActive(false);
        }
    }

    public void StartEnding()
    {
        Fireworks.SetActive(true);
        VictoryText.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        ResumeGameButton.SetActive(false);
        QuitGameButton.SetActive(false);
        ResetGameButton.SetActive(false);
        TutorialButton.SetActive(false);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("TestRoom");
    }
}
