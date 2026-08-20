using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{



    public GameObject ScoreA;
    public GameObject ScoreB;

    public GameObject Logo;
    public GameObject texto;

    public GameObject TankA;
    public GameObject TankB;

    public int ScoreANum = 0;
    public int ScoreBNum = 0;

    public GameObject WinA;
    public GameObject WinB;
    public GameObject Retornar;

    public void termina()
        {
        
        if (ScoreANum == 5)
        {
            
            Debug.Log("A ganhou");
            WinA.SetActive(true);
            Retornar.SetActive(true);
            TankA.GetComponent<tanqueMovement>().enabled = false;
            TankB.GetComponent<tanqueMovement>().enabled = false;


            
        

        }

        if (ScoreBNum == 5)
        {
            Debug.Log("B ganhou");
            WinB.SetActive(true);
            Retornar.SetActive(true);
            TankA.GetComponent<tanqueMovement>().enabled = false;
            TankB.GetComponent<tanqueMovement>().enabled = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Start"))
        {
            ScoreA.SetActive(true);
            ScoreB.SetActive(true);

            Logo.SetActive(false);
            texto.SetActive(false);

            TankA.GetComponent<tanqueMovement>().enabled = true;
            TankB.GetComponent<tanqueMovement>().enabled = true;
        }

        if(Input.GetButton("Retornar") && (ScoreANum == 5 || ScoreBNum == 5))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
    }
}
