using UnityEngine;
using UnityEngine.UI;

public class MuteButtonHandler : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.RemoveAllListeners(); // Clean up any broken references
        button.onClick.AddListener(() =>
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.ToggleMute();
            }
        });
    }
}
