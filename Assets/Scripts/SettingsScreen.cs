using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; 
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;
    [SerializeField] private Button audio;
    [SerializeField] private Image image;
    [SerializeField] private Button privacy;
    [SerializeField] private Button terms;

    private void Awake()
    {
        var isOn = PlayerPrefs.GetInt("audio") == 0;
        audio.onClick.AddListener((() =>
        {
            isOn = !isOn;
            if (isOn)
            {
                PlayerPrefs.SetInt("audio", 0);
                audioSource.Play();
                image.sprite = on;
            }
            else
            {
                PlayerPrefs.SetInt("audio", 1);
                audioSource.Stop();
                image.sprite = off;
            }
        }));
    }

    private void OnEnable()
    {
        privacy.onClick.AddListener((() =>
        {
            var webView = gameObject.AddComponent<UniWebView>();
            webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
            webView.SetShowToolbar(true);
            webView.SetBackButtonEnabled(true);
            webView.Load("https://licorsoftltd.co.uk/d/privacy-policy/");
            webView.Show();
        }));
        terms.onClick.AddListener((() =>
        {
            var webView = gameObject.AddComponent<UniWebView>();
            webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
            webView.SetShowToolbar(true);
            webView.SetBackButtonEnabled(true);
            webView.Load("https://licorsoftltd.co.uk/d/terms-of-use/");
            webView.Show();
        }));
    }
    
    private void OnDisable()
    {
        privacy.onClick.RemoveAllListeners();
        terms.onClick.RemoveAllListeners();
    }
}