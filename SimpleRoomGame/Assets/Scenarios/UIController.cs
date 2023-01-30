using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreLabel.text =score.ToString();
        settingsPopup.Close();
    }

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }



    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }

    public void OnPointerDown()
    {
        Debug.Log("Pointer down");
    }

    private void OnEnemyHit()
    {
        score += 1;
        scoreLabel.text = score.ToString();
    }

    

}
