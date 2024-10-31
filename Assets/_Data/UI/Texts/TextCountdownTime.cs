using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCountdownTime : BaseText
{
    [Header("TextCountdownTime")]
    [SerializeField] protected DateTime endTime;
    [SerializeField] protected float countdownTimer;
    [SerializeField] protected GameObject bossSpawn;

    protected override void Start()
    {
        SetEndTime(DateTime.Now.AddMinutes(countdownTimer));
    }

    protected virtual void FixedUpdate()
    {
        this.SpawnBoss();
    }

    protected virtual void UpdateTime()
    {
        TimeSpan remainingTime = endTime - DateTime.Now;

        int minutes = remainingTime.Minutes;
        int seconds = remainingTime.Seconds;

        this.text.SetText(minutes + ":" + seconds);
    }

    public void SetEndTime(DateTime endTime)
    {
        this.endTime = endTime;
    }

    protected void SpawnBoss()
    {
        if (this.endTime <= DateTime.Now)
        {
            this.bossSpawn.SetActive(true);

            this.enabled = false;
        }
        else
        {
            this.UpdateTime();
        }
    }
}
