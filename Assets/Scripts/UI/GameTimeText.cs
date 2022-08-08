using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class GameTimeText : MonoBehaviour
{
    private TMP_Text _tmpText;
    
    void Start()
    {
        _tmpText = GetComponent<TMP_Text>();
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
