using UnityEngine;
using System.Collections;

public class AdFreeChecker : MonoBehaviour {

    public static AdFreeChecker Instance {set; get;}

    void Awake()
    {
        SetupAds();
        Instance =this;
    }

   void SetupAds()
    {
        if(PlayerPrefs.HasKey("Adsfree"))
        {
            return;
        }
    }

    public void RemoveAds()
    {
        if (PlayerPrefs.HasKey("Adsfree"))
            print("Ads Already Remover");
        else
        {
            PlayerPrefs.SetInt("Adsfree", 1);
            PlayerPrefs.Save();
            GameObject.Find("Banner").SetActive(false);
            GameObject.Find("FullAds").SetActive(false);
        }

    }
	
	
    }
