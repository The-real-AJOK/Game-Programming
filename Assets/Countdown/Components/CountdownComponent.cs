using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownComponent : MonoBehaviour
{
    private TextMeshProUGUI countdownText;
    private float currentTime = 0f;
    private float startingTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        this.countdownText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        this.countdownText.text = "5";
        currentTime = startingTime;
    }

    // Update is called once per frame
    public void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            enabled = false;
        }
    }
}
