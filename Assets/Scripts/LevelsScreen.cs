using UnityEngine;

public class LevelsScreen : MonoBehaviour
{
    [SerializeField] private LevelButton[] levelButtons;
    
    private void OnEnable()
    {
        var levelsEnabled = PlayerPrefs.GetInt("level");
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelsEnabled)
            {
                continue;
            }
            levelButtons[i].Open();
        }
    }
}