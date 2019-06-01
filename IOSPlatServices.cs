using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;

public class IOSPlatServices : MonoBehaviour
{

    string leaderboardID = "scoredtmt";
    public bool loginSuccessful;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        AuthenticateUser();
       
        // Authenticate and register a ProcessAuthentication callback
        // This call needs to be made before we can proceed to other calls in the Social API
        //Social.localUser.Authenticate(ProcessAuthentication);
        //GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showIOSAchievements()
    {
        Social.localUser.Authenticate(success => { if (success) {
                Debug.Log("==iOS GC authenticate OK");
                Social.ShowAchievementsUI();

            }

            else { Debug.Log("==iOS GC authenticate Failed"); } });
       
    }

    public void SubmitScoreLeaderboard()
    {
        //ReportScore(100, "scoredtmt");
    }

    public void ShowLeaderboard()
    {

        Social.ShowLeaderboardUI();
        
    }


    void AuthenticateUser()

    {

        Social.localUser.Authenticate((bool success) =>
        {

            if (success)

            {

                loginSuccessful = true;
                PostScoreOnLeaderBoard(100);
                Debug.Log("success");

            }

            else

            {

                Debug.Log("unsuccessful");

            }

            // handle success or failure

        });

    }


    public void PostScoreOnLeaderBoard(int myScore)

    {



        if (loginSuccessful)

        {

            Social.ReportScore(myScore, leaderboardID, (bool success) =>
            {

                if (success)

                    Debug.Log("Successfully uploaded");

                // handle success or failure

            });

        }

        else

        {

            Social.localUser.Authenticate((bool success) =>
            {

                if (success)

                {

                    loginSuccessful = true;

                    Social.ReportScore(myScore, leaderboardID, (bool successful) =>
                    {

                        // handle success or failure

                    });

                }

                else

                {

                    Debug.Log("unsuccessful");

                }

                // handle success or failure

            });

        }


    }

   
    /* // This function gets called when Authenticate completes
     // Note that if the operation is successful, Social.localUser will contain data from the server. 
     void ProcessAuthentication(bool success)
     {
         if (success)
         {
             Debug.Log("Authenticated, checking achievements");

             // Request loaded achievements, and register a callback for processing them
             Social.LoadAchievements(ProcessLoadedAchievements);
         }
         else
             Debug.Log("Failed to authenticate");
     }

     // This function gets called when the LoadAchievement call completes
     void ProcessLoadedAchievements(IAchievement[] achievements )
     {
         if (achievements.Length == 0)
             Debug.Log("Error: no achievements found");
         else
             Debug.Log("Got " + achievements.Length + " achievements");

     }*/








}
