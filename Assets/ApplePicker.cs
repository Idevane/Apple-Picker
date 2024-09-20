using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -10f;
    public float basketSpacingY = 3f;
    public List<GameObject> basketList;

    // Use this for initialization
    void Start () {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        UpdateRoundText();  // Update the round text when the game starts
    }  // <-- Closing bracket for Start method

    public void AppleDestroyed() {
        // Getting all the Apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray) {
            Destroy(tGO);
        }

        // Only attempt to destroy a basket if there are any left
        if (basketList.Count > 0) {
            // Destroy one of the baskets
            int basketIndex = basketList.Count - 1;
            GameObject tBasketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(tBasketGO);
        }

        // If we ran out of baskets - reset the game or go to the next round
        if (basketList.Count == 0) {
            GameManager.instance.NextRound();  // Move to the next round
            SceneManager.LoadScene("ApplePicker");  // Reload the scene
        }
    }

    void UpdateRoundText() {
        // Update the round text on the UI using the BUTTONS script
        FindObjectOfType<BUTTONS>().UpdateRoundText(GameManager.instance.round);
    }
}