using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    public AudioClip clickButtonClip;

    public GUISkin titleSkin;
    public GUISkin textSkin;

    public SoundManager soundManager;
    public Texture2D[] backgroundTexture;

    public GUIStyle buttonStyle;

    public float width;
    public float heigth;

    public string menuTitleText;
    private int index = 0;

    private string[] warningTexts = { "Avoid the Stalker\r\n\r\nand\r\n\r\nFind the Target!", "Look carefuly\r\n\r\nand\r\n\r\nClick when you are sure!", "Move\r\n\r\nand\r\n\r\nBe precisely!", "Because\r\n\r\nyou got just\r\n\r\nOne shot!" };

    void OnGUI()
    {
        try
        {
            GUI.skin = titleSkin;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture[index]);

            Vector2 titleTextSize = GUI.skin.GetStyle("Label").CalcSize(new GUIContent(menuTitleText));
            GUI.Label(new Rect(Screen.width / 2f - titleTextSize.x / 2f, titleTextSize.y / 10f, Screen.width, titleTextSize.y), menuTitleText);

            GUI.skin = textSkin;

						GUILayout.BeginArea(new Rect(Screen.width / 2f - width / 2, Screen.height / 1.675f, width, heigth));
//
//            if (Application.loadedLevelName != "HowToPlay")
//            {
//                if (Application.loadedLevelName == "Credits" || Application.loadedLevelName == "Final")
//                {
//                    GUILayout.BeginArea(new Rect(Screen.width / 2f - width / 2, Screen.height / 1.3f, width, heigth));
//                }
//                else
//                {
//                    GUILayout.BeginArea(new Rect(Screen.width / 2f - width / 2, Screen.height / 1.675f, width, heigth));
//                }
//            }
//
            {
                if (Application.loadedLevelName == "Menu")
                {
                    if (GUILayout.Button("PlAY", buttonStyle))
                    {
                        OnChangeScreen("Level1");
                    }

                    if (GUILayout.Button("Credits", buttonStyle))
                    {
                        OnChangeScreen("Credits");
                    }
                }
                else
                {
                    if (GUILayout.Button("Menu", buttonStyle))
                    {
                        OnChangeScreen("Menu");
                    }
                }
            }

            GUILayout.EndArea();
        }
        catch (System.Exception exc)
        {
            Debug.LogError(exc.Message + exc.StackTrace);
        }
    }

    void OnChangeScreen(string levelName)
    {
        audio.PlayOneShot(clickButtonClip);
        soundManager.control = SoundControl.OUT;

        AutoFade.LoadLevel(levelName, 1.5f, 1.5f, Color.black);
    }
}
