using UnityEngine;
using TMPro;

public class GameTimeView : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private TMP_Text _tmpText;
    
    void Start()
    {
        UpdateText();
    }

    public void OnGameTimeUpdated(double redudant)
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _tmpText.text = GameTime.Now.ToString("dd-MM-yyyy\nHH:mm");
    }
}
