using UnityEngine;
using UnityEngine.UI;

public class AllowScreen : MonoBehaviour
{
    [SerializeField] private Button privacy;
    [SerializeField] private Button terms;
    
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