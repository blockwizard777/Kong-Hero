﻿using UnityEngine;
using System.Collections;

#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class UnityAds : MonoBehaviour {
	public int coinReward = 50;
	public AudioClip soundReward;

	// Use this for initialization
	void Start () {
	
	}



	public void ShowRewardVideo(){
		#if UNITY_ADS
		ShowRewardedAd ();
		#else
		Debug.Log("You need turn on the Ads in WinDows/Service to able watch the video ads");
		#endif
	}
	#if UNITY_ADS
	public void ShowNormalAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}


	private void ShowRewardedAd()
		{
		if (Advertisement.IsReady("rewardedVideo"))
			{
				var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
			}
	}
	



		private void HandleShowResult(ShowResult result)
		{
			switch (result)
			{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");

			GlobalValue.SavedCoins += coinReward;
			SoundManager.PlaySfx (soundReward);

				break;
			case ShowResult.Skipped:
				Debug.Log("The ad was skipped before reaching the end.");
				break;
			case ShowResult.Failed:
				Debug.LogError("The ad failed to be shown.");
				break;
			}
	}
	#endif
}
