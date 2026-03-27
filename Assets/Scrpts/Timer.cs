using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    [SerializeField] int timeOnStart = 60;
    [SerializeField] Text textBox;
    [SerializeField] string sceneName = "Endgame_Menu";
    int _counter;

    void OnEnable()
    {
        textBox.text = $"Time Left: --";
        ClockStart();
    }

    void OnDisable()
    {
        ClockStop();
    }

    public void ClockStart()
    {
        _counter = timeOnStart;
        UpdateText();
        InvokeRepeating(
            nameof(ClockTick),
            1f,// the very first tick after 1 second
            1f// 1 second between every tick
        );
    }

    public void ClockStop()
    {
        CancelInvoke(nameof(ClockTick));
    }

    void ClockTick()
    {
        _counter--;
        UpdateText();

        if (_counter <= 0)
        {
            ClockStop();
            SceneManager.LoadScene(sceneName);
        }
    }

    void UpdateText()
    {
        textBox.text = $"Time Left: {Mathf.Round(_counter)}";
    }

}