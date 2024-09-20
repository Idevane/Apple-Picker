using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // Singleton instance
    public int round = 1;  // Start at round 1

    void Awake() {
        // Ensure that there is only one instance of GameManager
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Prevent this object from being destroyed when reloading the scene
        } else {
            Destroy(gameObject);  // Destroy any duplicate instances
        }
    }

    public void NextRound() {
        round++;  // Increment the round
    }

    public void ResetGame() {
        round = 1;  // Reset the round to 1
    }
}