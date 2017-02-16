using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour {

	private const string PREF_TEST_KEY = "test";
	private const string PREF_HIGH_SCORE = "highScorePref";

	private int score;

	public int Score{
		get{
			return score;	
		}

		set{
			score = value;

			if(score > HighScore){
				HighScore = score;
			}

			Debug.Log(score);
		}
	}

	private int highScore = 33;

	public int HighScore{
		get{
			highScore = PlayerPrefs.GetInt(PREF_HIGH_SCORE);
			return highScore;
		}

		set{
			Debug.Log("Confetti!!!");
			highScore = value;
			PlayerPrefs.SetInt(PREF_HIGH_SCORE, highScore);
		}
	}

	public static ScoreManagerScript instance;

	// Use this for initialization
	void Start () {
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		PlayerPrefs.SetString(PREF_TEST_KEY, "Something else!!!");
//
//		Debug.Log("Play Pref test: " + PlayerPrefs.GetString(PREF_TEST_KEY));
	}
}
