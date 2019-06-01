using UnityEngine;
using System.Collections;
using Facebook.Unity;
using UnityEngine.UI;
using System.Collections.Generic;
//using ChartboostSDK;

public class FacebookScripter : MonoBehaviour {

    public Text userIdText;
    public GameObject Parent;
    public TileSpawner aq;
    private const string FACEBOOK_APP_ID = "911971812269063";
    private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init();
        }else
        {
            FB.ActivateApp();
        }

        aq = this.GetComponent<TileSpawner>();
    }

    public void LogIn()
    {
        Chartboost.showInterstitial(CBLocation.HomeScreen);
       // FB.LogInWithReadPermissions(callback:OnLogIn);
    }

    private void OnLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {


            AccessToken token = AccessToken.CurrentAccessToken;
            userIdText.text = token.UserId;
        }
        else
        {
            Debug.Log("Canceled Login");
        }
    }

    public void Share()
    {
        if (aq.bool_bossmode)
        {
            

            FB.ShareLink(
        contentTitle: "You defended yourself from " + Parent.GetComponent<TileSpawner>().int_current_score.ToString() + " Shots",
        contentURL: new System.Uri("https://www.facebook.com/Dont-Touch-Me-Twice-1748231942103967/"),
        contentDescription: "Don't Touch me Twice ",
        callback: OnShare);

          

        }
        else
        {
            FB.ShareLink(
          contentTitle: "I touched " + Parent.GetComponent<TileSpawner>().int_current_score + " Tiles. Think you can beat my score?",
          contentURL: new System.Uri("https://www.facebook.com/Dont-Touch-Me-Twice-1748231942103967/"),
          contentDescription: "Don't Touch me Twice ",
          callback: OnShare);

            Parent.GetComponent<TileSpawner>().ach14();
        }
           

       

    }

    

    private void OnShare(IShareResult result)
    {
        if(result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink error: " + result.Error);
        }else if(!string.IsNullOrEmpty(result.PostId)){
            Debug.Log("Share succeed");
        }
    }
}
