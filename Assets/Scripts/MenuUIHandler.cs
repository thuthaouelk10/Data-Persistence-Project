using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField playerNameInput; // or TMP_InputField
    public TMP_Text bestScoreText; // or Text

    // Start is called before the first frame update
    void Start()
    {
        // Show current best score from previous sessons if any
        if (DataManager.Instance != null)
        {
            var dm = DataManager.Instance;
            if (!string.IsNullOrEmpty(dm.BestPlayer) || dm.BestScore > 0)
                bestScoreText.text = $"Best Score : {dm.BestScore} by {dm.BestPlayer}";
            else
                bestScoreText.text = "Best Score : 0";
        }
    }

    public void StartNew()
    {
        var dm = DataManager.Instance;
        if (dm != null) dm.PlayerName = playerNameInput.text.Trim();
            SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        DataManager.Instance.SaveNameandScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
