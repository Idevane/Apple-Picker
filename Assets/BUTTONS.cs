using UnityEngine;
using TMPro;  
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BUTTONS : MonoBehaviour
{
    public TextMeshProUGUI roundText;  
    public Button restartButton;  

    private int totalRounds = 4;  

    void Start()
    {
        UpdateRoundText(GameManager.instance.round);  
        restartButton.gameObject.SetActive(false);  
    }

    public void NextRound()
    {
        GameManager.instance.NextRound(); 

        if (GameManager.instance.round <= totalRounds)
        {
            UpdateRoundText(GameManager.instance.round);  
        }
        else
        {
            GameOver();  
        }
    }

    public void UpdateRoundText(int round)
    {
        roundText.text = "Round " + round;  
    }

    void GameOver()
    {
        roundText.text = "Game Over";  
        restartButton.gameObject.SetActive(true);  
    }

    public void RestartGame()
    {
        GameManager.instance.ResetGame();  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }
}//test