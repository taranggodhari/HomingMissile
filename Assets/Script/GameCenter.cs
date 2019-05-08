using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;


public class GameCenter : MonoBehaviour 
{
    public static GameCenter Instance { get; set; }

    void Awake()
    {
        LoginButton();
         Instance = this;
    }
        
	public void LoginButton()
	{
		PlayerPrefs.SetInt("Login" , 1);
		#if UNITY_IPHONE
		Social.localUser.Authenticate((bool success) =>	{});
		#elif UNITY_ANDROID
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate((bool success) =>	{});
		#endif

	}

	public void GameCenteButton()
	{
		if(Social.localUser.authenticated)
		{
			HighScore_ReportScore(PlayerPrefs.GetInt("TotalScore"));
			Social.ShowLeaderboardUI();
		}
		else
			LoginButton();
	}

	void ProcessAuthentication (bool success) {}

	public void HighScore_ReportScore(int bestScore)
	{
		#if UNITY_IPHONE
		if(Social.localUser.authenticated)
			Social.ReportScore((long)bestScore, "HitHalo", (bool success) => {});

		#elif UNITY_ANDROID
		if(Social.localUser.authenticated)
            Social.ReportScore((long)bestScore, "CgkIoOGklO8SEAIQBw", (bool success) => { });

		#endif

	}
    public void ShowAchivements()
    {
        if (Social.localUser.authenticated)
            Social.ShowAchievementsUI();
    }
	public void RateUs()
	{
		#if UNITY_IPHONE
		Application.OpenURL(" https://itunes.apple.com/us/app/hit-halo-racing-game/id1142497036?ls=1&mt=8");

		#elif UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.absolutezero.homingmissile");

		#endif
	}
	public void GetMore()
	{
		#if UNITY_IPHONE
		Application.OpenURL("https://itunes.apple.com/us/developer/divyarajsinh-jadeja/id1031187359?mt=8");

		#elif UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Absolute+Zero+Inc.");

		#endif


	}

}
