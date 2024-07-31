using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class WebScreen : MonoBehaviour
{
    [SerializeField] private ButtonsController _buttonsController;
    private UniWebView webView;

    private void Start()
    {
        var reference = FirebaseDatabase.DefaultInstance.RootReference;
         reference.Database.GetReference("url").GetValueAsync().ContinueWithOnMainThread(task => 
         {
             if (task.IsCompleted) 
             {
                 if (task.Result.Value != null && task.Result.Value.ToString() != "")
                 {
                     webView = gameObject.AddComponent<UniWebView>();
                     webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
                     webView.SetContentInsetAdjustmentBehavior(UniWebViewContentInsetAdjustmentBehavior.Automatic);
                     webView.Load(task.Result.Value.ToString());
                     webView.Show();
                 }
                 else
                 {
                     _buttonsController.StartGame();
                 }
             }
             else
             {
                 _buttonsController.StartGame();
             }
         });
    }
}