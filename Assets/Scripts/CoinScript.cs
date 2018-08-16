using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CoinScript : MonoBehaviour
{
    public Text PlayerScore;
    public int Score;
    public Text WinText;
    public GameObject Coin;
    public GameObject Exit;
    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 CoinYAxis = Coin.transform.position;
        //if the coin manages to fall of the playfield, destroy that coin and respawn a new one
        if (CoinYAxis.y < -1)
        {
            RespawnCoin();
        }
    }

    void OnCollisionEnter(Collision otherObj)
    {
        GetComponent<AudioSource>().Play();
        if (otherObj.gameObject.tag == "Enemy")
        {

            PlayerScore.text = (Convert.ToInt32(PlayerScore.text) - Score).ToString();
            CheckIfWin();
        }
        else if (otherObj.gameObject.tag == "Player")
        {
            PlayerScore.text = (Convert.ToInt32(PlayerScore.text) + Score).ToString();
            CheckIfWin();
        }
        else if (otherObj.gameObject.tag == "Exit")
        {
            WinText.text = "WINNER! YOU WON AT LIFE!";
            
        }

    }

    void CheckIfWin()
    {

        if (Convert.ToInt32(PlayerScore.text) >= 100)
        {
            WinText.text = "WINNER! YOU WON AT LIFE!";
            Exit.SetActive(true);
        }
        if (Convert.ToInt32(PlayerScore.text) <=0)
        {
            WinText.text = "You are such a LOSER!";
        }
        if (Convert.ToInt32(PlayerScore.text) < 100)
        {
            Exit.SetActive(false);
        }
        if (WinText.text == "")
        {
            RespawnCoin();
        }
    }

    void RespawnCoin()
    {
        Vector3 position = new Vector3(UnityEngine.Random.Range(5.0f, 50.0f), 8, UnityEngine.Random.Range(5.0f, 50.0f));
        Coin.SetActive(false);
        Coin.transform.position = position;
        Coin.SetActive(true);
    }
}
