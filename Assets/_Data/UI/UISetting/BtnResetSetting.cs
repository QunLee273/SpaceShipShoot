using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BtnResetSetting : BaseButton
{
    [SerializeField] protected AudioSetting audioSetting;
    [SerializeField] protected GameObject confMess;
    [SerializeField] protected UIConfirmMess uiConfMess;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSetting();
    }
    
    protected virtual void LoadAudioSetting()
    {
        if (this.audioSetting != null) return;
        var setting = GameObject.Find("UISetting");
        audioSetting = setting.GetComponent<AudioSetting>();
        Debug.Log(transform.name + ": LoadAudioSetting", gameObject);
    }
    protected override void OnClick()
    {
        confMess.SetActive(true);
        
        uiConfMess.ShowDialog("Are you sure you want to reset?", 
            () => OnClickYes());;
    }

    protected void OnClickYes()
    {
        // Reset âm lượng về giá trị mặc định
        if (audioSetting != null)
            audioSetting.ResetSettings();
    }
}
