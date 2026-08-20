using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class bulletBehavior : MonoBehaviour
{
    // Prefab do efeito ao atingir algo
    public GameObject bulletFX;

    public TextMeshProUGUI ScoreA;
    public TextMeshProUGUI ScoreB;


    private void Start()
    {
        ScoreA = GameObject.Find("ScoreA").GetComponent<TextMeshProUGUI>();
        ScoreB = GameObject.Find("ScoreB").GetComponent<TextMeshProUGUI>();
    }


 private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TankA")
        {
            // Busca o objeto GameManager e incrementa o ponto
            GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            manager.ScoreBNum++;

            // Atualiza o texto do placar
            ScoreB.text = manager.ScoreBNum.ToString();

            // Instancia o efeito e destrói a bala
            Instantiate(bulletFX, transform.position, Quaternion.identity);

            GameObject.Find("GameManager").GetComponent<GameManager>().termina();

            Destroy(gameObject);
        }
        else
        {
            // Instancia o efeito na posição da bala se atingir outro objeto
            Instantiate(bulletFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.gameObject.name == "TankB")
        {
            // Busca o objeto GameManager e incrementa o ponto
            GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            manager.ScoreANum++;

            // Atualiza o texto do placar
            ScoreA.text = manager.ScoreANum.ToString();

            // Instancia o efeito e destrói a bala
            Instantiate(bulletFX, transform.position, Quaternion.identity);
            GameObject.Find("GameManager").GetComponent<GameManager>().termina();

            Destroy(gameObject);
        }
        else
        {
            // Instancia o efeito na posição da bala se atingir outro objeto
            Instantiate(bulletFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}