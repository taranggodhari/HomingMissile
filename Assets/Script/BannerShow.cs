using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class BannerShow : MonoBehaviour
{
    public static BannerShow i;
    public BannerView bannerView;
    string BannerID;
    public string APPID;

    void Awake()
    {
        if (!i)
        {
            i = this;

#if UNITY_EDITOR
            bannerView = new BannerView("", AdSize.SmartBanner, AdPosition.Bottom);
#elif UNITY_ANDROID
				bannerView = new BannerView(APPID, AdSize.SmartBanner, AdPosition.Bottom);
#elif UNITY_IOS
					bannerView = new BannerView("ca-app-pub-6996012155310080/8170685452", AdSize.SmartBanner, AdPosition.Bottom);
#endif

            AdRequest request = new AdRequest.Builder().Build();
            bannerView.LoadAd(request);

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
