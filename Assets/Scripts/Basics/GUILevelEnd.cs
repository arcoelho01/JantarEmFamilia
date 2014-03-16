using UnityEngine;
using System.Collections;

/// <summary>
/// Menu to be shown when the level ends (player kills someone or is caught)
/// </summary>
public class GUILevelEnd : MonoBehaviour
{

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */

	public AudioClip clickButtonClip;

	public GUISkin titleSkin;
	public GUIStyle buttonStyle;

	public string menuTitleText;
	public string stNextLevelName;	//< Name of the next level to be loaded

	public float width;
	public float height;

	bool bnWasTheMissionAccomplished = false;
	bool bnShowGUI = false;

	GameObject	goMainGame;
	MainGame		mainGameScript;
	// Use this for initialization
	void Awake()
	{
		goMainGame = GameObject.Find("/MainGame");
		if(goMainGame != null) {

			mainGameScript = goMainGame.GetComponent<MainGame>();
		}

	}

	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
	void OnGUI()
	{
		if (!bnShowGUI)
			return;

		GUI.skin = titleSkin;

		Vector2 titleTextSize = GUI.skin.GetStyle("Label").CalcSize(new GUIContent(menuTitleText));
		GUI.Label(new Rect((Screen.width - titleTextSize.x) / 2, titleTextSize.y / 2f, Screen.width, titleTextSize.y), menuTitleText);

		if (bnWasTheMissionAccomplished)
		{
			GUILayout.BeginArea(new Rect(Screen.width / 2f - width / 4, Screen.height - height, width, height));

			if (GUILayout.Button("Next Level", buttonStyle))
			{
				OnChangeScreen(stNextLevelName);
			}
		}
		else
		{
			GUILayout.BeginArea(new Rect(Screen.width / 2f - width / 2, Screen.height / 1.55f, width, height));

			//GUILayout.BeginHorizontal();
			if (GUILayout.Button("Restart Level", buttonStyle))
			{
				OnChangeScreen(Application.loadedLevelName);
			}
			if (GUILayout.Button("Menu", buttonStyle))
			{
				OnChangeScreen("Menu");
			}
			if (GUILayout.Button("Back to Game", buttonStyle))
			{
				bnShowGUI = false;
				// Return to the game
				mainGameScript.SetGamePause(false);
			}
			//GUILayout.EndHorizontal();
		}
		GUILayout.EndArea();
	}

	public void SetGUILevelLost()
	{

		menuTitleText = "Level lost!";
		bnShowGUI = true;

		// Pauses the game
		mainGameScript.SetGamePause(false);
	}

	public void SetGUILevelPaused()
	{

		menuTitleText = "Pause";
		bnShowGUI = true;
		// Pauses the game
		mainGameScript.SetGamePause(true);
	}

	public void SetGUILevelWon()
	{

		menuTitleText = "Mission Accomplished!";
		bnShowGUI = true;
		bnWasTheMissionAccomplished = true;
		// Pauses the game
		mainGameScript.SetGamePause(true);
	}

	void OnChangeScreen(string levelName)
	{
		if (clickButtonClip)
			audio.PlayOneShot(clickButtonClip);

		AutoFade.LoadLevel(levelName, 1.5f, 1.5f, Color.black);
	}
}
