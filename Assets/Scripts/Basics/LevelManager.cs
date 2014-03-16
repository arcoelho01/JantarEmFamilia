using UnityEngine;
using System.Collections;

/// <summary>
/// Controls all things related to the level flow
/// </summary>
public class LevelManager : MonoBehaviour
{

	public SoundManager soundManager;

	public string stMenuLevelName;	//< Name of the level loaded when the player presses the 'Menu' button

	string stThisLevelName;
	GUILevelEnd guiLevelEnd;
	MainGame	mainGameScript;

	/* ==========================================================================================================
	 * UNITY METHODS
	 * ==========================================================================================================
	 */

	void Awake()
	{

		guiLevelEnd = gameObject.GetComponent<GUILevelEnd>();
		mainGameScript = gameObject.GetComponent<MainGame>();
	}

	void Start()
	{

		stThisLevelName = Application.loadedLevelName;
	}

	void Update() {

		if(Input.GetKeyDown(KeyCode.Escape)) {

				LevelPaused();
		}
	}


	/* ==========================================================================================================
	 * CLASS METHODS
	 * ==========================================================================================================
	 */
	void OnChangeScreen(string levelName)
	{
		soundManager.control = SoundControl.OUT;
		AutoFade.LoadLevel(levelName, 1.5f, 1.5f, Color.black);
	}

	/// <summary>
	/// What to do when the player won the level, i.e., kills the correct target
	/// </summary>
	public void LevelWon()
	{

		//objectivesCardScript.ForceCardToBeShow();
		//guiObjectivesCardScript.IconShowRightTarget();
		guiLevelEnd.SetGUILevelWon();
	//	mainGameScript.SetGamePause(true);
	}

	/// <summary>
	/// What to do when the player looses the level 
	/// </summary>
	public void LevelLost()
	{

		guiLevelEnd.SetGUILevelLost();
	}

	/// <summary>
	/// What to do when the player looses the level by being caught by the stalker
	/// </summary>
	public void LevelPaused()
	{
		if(mainGameScript.IsGamePaused())
			return;

		guiLevelEnd.SetGUILevelPaused();
	}
}
