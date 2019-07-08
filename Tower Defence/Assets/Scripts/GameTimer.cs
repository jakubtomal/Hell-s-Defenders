using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("lvl timer in seconds")]
    [SerializeField] float lvlTime = 1;
    bool timerFinished = false;



    void Update()
    {
        if (!timerFinished)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / lvlTime;

            timerFinished = Time.timeSinceLevelLoad >= lvlTime;

            if (timerFinished)
            {
                FindObjectOfType<LevelManager>().TimerFinished();
            }
        }
    }
}
