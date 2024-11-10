using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : ShipMonoBehaviour
{
    private static ExperienceBar instance;
    public static ExperienceBar Instance => instance;

    [SerializeField] protected Slider slider;
    public Slider Slider => slider;

    [SerializeField] protected TextMeshProUGUI txtExp;
    public TextMeshProUGUI TxtExp => txtExp;

    [SerializeField] protected TextMeshProUGUI txtLevel;
    public TextMeshProUGUI TxtLevel => txtLevel;

    [SerializeField] protected int maxXP = 100;
    [SerializeField] public int currentXP = 0;
    [SerializeField] protected int currentLV = 1;

    [SerializeField] protected DamageSender damageSender;
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected int increaseHp = 25;
    [SerializeField] protected int increaseDamage = 5;
    [SerializeField] protected float delayShoot = 0.05f;

    protected override void Awake()
    {
        base.Awake();

        if (ExperienceBar.instance != null) Debug.LogError("Only 1 ExperienceBar allow to exist");
        ExperienceBar.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
        this.LoadTxt();
        this.LoadTxtLevel();
    }

    protected void FixedUpdate()
    {
        this.XPShowing();
        this.LevelUp();
        
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = transform.GetComponentInChildren<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
    }

    protected virtual void LoadTxt()
    {
        if (this.txtExp != null) return;
        this.txtExp = transform.GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTxt", gameObject);
    }
    protected virtual void LoadTxtLevel()
    {
        if (this.txtLevel != null) return;
        this.txtLevel = transform.GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTxtLevel", gameObject);
    }

    public virtual void XPShowing()
    {
        float XPPercent = this.currentXP / this.maxXP;
        this.slider.value = XPPercent;

        this.txtExp.SetText(currentXP + "/" + maxXP);
        this.txtLevel.SetText("Level: " + currentLV);
    }

    public virtual void SetMaxHp(int maxXP)
    {
        this.maxXP = maxXP;
    }

    public virtual void SetCurrentHp(int currentXP)
    {
        this.currentXP = currentXP;
    }

    protected virtual void LevelUp()
    {
        if (currentXP >= maxXP)
        {
            this.currentXP = currentXP - maxXP;

            maxXP += 50;

            currentLV++;

            this.IncreaseParameter();
        }
    }

    protected virtual void IncreaseParameter()
    {
        this.damageSender.damage += increaseDamage;
        //Debug.Log("Damage increased to: " + this.damageSender.damage);

        this.shootableObjectCtrl.DamageReceiver.HPMax += increaseHp;
        this.shootableObjectCtrl.DamageReceiver.HP = this.shootableObjectCtrl.DamageReceiver.HPMax;
        //Debug.Log("Max HP increased to: " + this.shootableObjectCtrl.DamageReceiver.HPMax);

        this.shootableObjectCtrl.ObjShooting.shootDelay -= delayShoot; 
        //Debug.Log("Shoot Delay increased to: " + this.shootableObjectCtrl.ObjShooting.shootDelay);
    }
}
