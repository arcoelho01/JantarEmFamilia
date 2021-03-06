﻿using UnityEngine;
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

    void OnGUI()
    {
        try
        {
            GUI.skin = titleSkin;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture[index]);

            Vector2 titleTextSize = GUI.skin.GetStyle("Label").CalcSize(new GUIContent(menuTitleText));
            GUI.Label(new Rect(Screen.width / 2f - titleTextSize.x / 2f, titleTextSize.y / 10f, Screen.width, titleTextSize.y), menuTitleText);

            GUI.skin = textSkin;

						GUILayout.BeginArea(new Rect(Screen.width / 1.525f, Screen.height / 1.55f, width, heigth));

						if (Application.loadedLevelName == "Menu")
						{
							if (GUILayout.Button("Play", buttonStyle))
							{
								OnChangeScreen("Level1");
							}

							if (GUILayout.Button("How To Play", buttonStyle))
							{
								OnChangeScreen("HowToPlay");
							}

							if (GUILayout.Button("Credits", buttonStyle))
							{
								OnChangeScreen("Credits");
							}

							if (GUILayout.Button("Exit", buttonStyle))
							{
								Application.Quit();
							}
						}
						else
						{
							if (GUILayout.Button("Menu", buttonStyle))
							{
								OnChangeScreen("Menu");
							}
							if (GUILayout.Button("Play", buttonStyle)) {

								OnChangeScreen("Level1");
							}
						}

            GUILayout.EndArea();
        }
        catch (System.Exception exc)
        {
            Debug.LogError(Application.loadedLevelName + exc.Message + exc.StackTrace);
        }
    }

    void OnChangeScreen(string levelName)
    {
        audio.PlayOneShot(clickButtonClip);
        soundManager.control = SoundControl.OUT;

        AutoFade.LoadLevel(levelName, 1.5f, 1.5f, Color.black);
    }
}
