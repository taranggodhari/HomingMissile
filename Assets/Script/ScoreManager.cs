using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{

    //	public GameObject plane;
    public static ScoreManager Instance { set; get; }

    public Text starScoreText;
    private int starScore;
    public Text missileScoreText;
    public Text finalScoreText;
    public Text finalStarScoreText;
    public Text finalTimerScoreText;
    public Text finalBonusScoreText;
    public Text TotalScoreText;
    public GameObject highScoreRibbon;
    public GameObject HighScoreAnimator;
    private int missileScore;
    private int timeSpent = 0;
    private int finalScore;
    public int doubleScore = 0;
    public int totalScore;
    private int highScore;
    //	private float planeX,planeY;
    Timer myTimer;
    public bool scoreSet, scoreDoubler;
    public bool ResetPlayerPrefrence;



    void Start()
    {
        //		SpawnPlane ();
        myTimer = (Timer)GameObject.FindObjectOfType(typeof(Timer));
        starScore = 00;
        UpdateStarScore();
        missileScore = 00;
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
        finalScore = PlayerPrefs.GetInt("FinalScore", finalScore);
        //		PlayerPrefs.DeleteAll();
        //		float planeX = plane.transform.position.x;
        //		float planeY = plane.transform.position.y;


    }
    void Awake()
    {
        Instance = this;
    }
    void Update()
    {
       
        if (ResetPlayerPrefrence == true)
            PlayerPrefs.DeleteAll();
        finalScore = starScore + missileScore + myTimer.timeSpent + doubleScore;

        //if(UiHandler.Instance.gameover == true)
        UpdateFinalScore();
        UpdateTotalScore();
        if (scoreSet == false)
        {
            StoreTotalScore();
            scoreSet = true;
        }
        //if (scoreDoubler == false)
        //{
        //    doubleScore = finalScore;
        //    StoreTotalScore();
        //    scoreDoubler = true;
        //}

        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            Debug.Log("highScore is: " + highScore);
            highScoreRibbon.SetActive(true);
            HighScoreAnimator.GetComponent<Animator>().enabled = true;
            HighScoreAnimator.GetComponent<Animator>().Play("HighScoreAnimation");

        }
        PlayerPrefs.SetInt("FinalScore", finalScore);
        //finalScore = PlayerPrefs.GetInt("FinalScore");
    }
    //StarScore
    public void AddStarScore(int newScoreValue)
    {
        starScore += newScoreValue;
        UpdateStarScore();
    }
    void UpdateStarScore()
    {

        starScoreText.text = "" + starScore;

    }

    //MissileCrashScore
    public void AddMissileScore(int newScoreValue)
    {
        missileScore += newScoreValue;

        UpdateMissileScore();
    }
    void UpdateMissileScore()
    {
        StartCoroutine(DelayScore());
    }

   public void UpdateFinalScore()
    {
        
        finalScoreText.text = "" + finalScore;
        finalStarScoreText.text = "+" + starScore;
        finalTimerScoreText.text = "+" + myTimer.timeSpent;
        finalBonusScoreText.text = "+" + missileScore;


    }
    public void StoreTotalScore()
    {

        totalScore = PlayerPrefs.GetInt("TotalScore") + finalScore;
        PlayerPrefs.SetInt("TotalScore", totalScore);
        totalScore = PlayerPrefs.GetInt("TotalScore");
        TotalScoreText.text = "" + totalScore;
    }
    public void UpdateTotalScore()
    {

        TotalScoreText.text = "" + totalScore;

    }
    public void UpdateRewardedAdsScore()
    {
        totalScore = PlayerPrefs.GetInt("TotalScore") + 100;
        PlayerPrefs.SetInt("TotalScore", totalScore);
        totalScore = PlayerPrefs.GetInt("TotalScore");
        TotalScoreText.text = "" + totalScore;
    }
    public void UpdateScoreDoubler()
    {
        doubleScore = finalScore;
        StoreTotalScore();
        
    }
    public void  UpdateIAPScore()
    {
        totalScore = PlayerPrefs.GetInt("TotalScore") + 1000;
        PlayerPrefs.SetInt("TotalScore", totalScore);
        totalScore = PlayerPrefs.GetInt("TotalScore");
        TotalScoreText.text = "" + totalScore;
    }
    public void CheatScore(int TotalScore)
    {
        print("Cheat Applied");
        PlayerPrefs.SetInt("TotalScore", TotalScore);
        totalScore = PlayerPrefs.GetInt("TotalScore");
        UpdateTotalScore();
    }
    public void ResetAllScore()
    {
        PlayerPrefs.DeleteAll();
        UpdateTotalScore();

    }




    IEnumerator DelayScore()
    {
        missileScoreText.text = "+20";
        missileScoreText.enabled = true;
        yield return new WaitForSeconds(1.5f);
        missileScoreText.enabled = false;
        yield return null;
    }

    //	public void SpawnPlane()
    //	{
    //		Instantiate (plane, new Vector3(planeX,planeY,0), Quaternion.identity);
    //	}

}

