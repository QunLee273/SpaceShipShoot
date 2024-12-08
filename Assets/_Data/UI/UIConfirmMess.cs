using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIConfirmMess : ShipMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMess;
    [SerializeField] protected Button confButton;
    [SerializeField] protected Button cancelButton;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        
        this.LoadTextMess();
        this.LoadBtnConfirm();
        this.LoadBtnCancel();
    }

    protected void LoadTextMess()
    {
        if (this.textMess != null) return;
        this.textMess = transform.Find("TextMess").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadTextMess", gameObject);
    }

    protected void LoadBtnConfirm()
    {
        if (this.confButton != null) return;
        this.confButton = transform.Find("BtnConfirm").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadBtnConfirm", gameObject);
    }

    protected void LoadBtnCancel()
    {
        if (this.cancelButton != null) return;
        this.cancelButton = transform.Find("BtnCancel").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadBtnCancel", gameObject);
    }

    public void ShowDialog(string message, System.Action onConfirm)
    {
        gameObject.SetActive(true); // Hiển thị dialog
        textMess.text = message;

        confButton.onClick.RemoveAllListeners();
        confButton.onClick.AddListener(() =>
        {
            onConfirm?.Invoke();
            gameObject.SetActive(false); // Ẩn dialog sau khi xác nhận
        });

        cancelButton.onClick.RemoveAllListeners();
        cancelButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false); // Ẩn dialog sau khi hủy
        });
    }
}
