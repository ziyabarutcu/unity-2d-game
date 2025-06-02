using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuUI : MonoBehaviour
{
    public void LoadLevel()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        TextMeshProUGUI tmpText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();

        if (tmpText == null) { Debug.Log("Buton içinde TMP bileşeni bulunamadı!"); }
        if (int.TryParse(tmpText.text, out int sceneIndex))
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else { Debug.Log("Geçersiz Sahne Adı"); }
    }
    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
