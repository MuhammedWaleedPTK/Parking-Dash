using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelctor : MonoBehaviour
{
   public int level;
    int unlockedLevel;
    private void Start()
    {
        unlockedLevel = PlayerPrefs.GetInt("unlockedLevels", 1);
        if (unlockedLevel < level)
        {
            Button button =gameObject.GetComponent<Button>();
            button.interactable = false;
        }
    }


    public void OpenScene()
    {
        SceneManager.LoadScene("Level0"+level.ToString());
    }
}
