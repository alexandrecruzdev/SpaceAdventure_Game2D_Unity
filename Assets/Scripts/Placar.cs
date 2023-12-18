/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LootLocker.Requests;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class Placar : MonoBehaviour
{
    public TMP_InputField nome;
    public string ID;
    public float time = 0;
    int MaxScores = 3;
    bool GameOver = false;
    public TextMeshProUGUI[] Entries;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (!GameOver)
            {
                if (time>0)
                    SubmitScore();
            }
        }
        else
        {
            time += Time.deltaTime;
        }
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucesso");
            }
            else
            {
                Debug.Log("Falha");
            }
        });
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerMember[] scores = response.items;

                for (int i = 0; i < scores.Lenght; i++)
                {
                    Entries[i].text = (scores[i].rank + ".   " + scores[i].score);
                }

                if (scores.Lenght < MaxScores)
                {
                    for (int i = scores.Lenght; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() = ".   none";
                    }
                }
            }
            else
            {
                Debug.Log("Falha");
            }
        });

    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(nome.text, ((int)time), ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucesso");
            }
            else
            {
                Debug.Log("Falha");
            }

        });
        GameOver = true;
    }
   
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LootLocker;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using LootLocker.Requests;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Placar : MonoBehaviour
{
    public TMP_InputField nome;
    public string ID;
    public float time = 0;
    int MaxScores = 3;
    bool GameOver = false;
    public TextMeshProUGUI[] Entries;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (!GameOver)
            {
                if (time > 0)
                    SubmitScore();
            }
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession("nome", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucesso");
            }
            else
            {
                Debug.Log("Falha de login");
            }
        });
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                // LootLockerMember[] scores = response.items;
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    Entries[i].text = (scores[i].rank + "." + scores[i].score);
                }

                if (scores.Length < MaxScores)
                {
                    for (int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + "." + "none";
                    }
                }
            }
            else
            {
                Debug.Log("Falha");
            }
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(nome.text, (int)time, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucesso");
            }
            else
            {
                Debug.Log("Falha ao enviar pontos!!");
            }

            GameOver = true;
        });
    }
}