using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using UnityEngine.SceneManagement;

public class FirebaseLogin : MonoBehaviour
{
    public InputField input_pass;
    public Text result_text;

    Firebase.Auth.FirebaseAuth for_email_auth;
    private string authCode;

    void Start()
    {
        for_email_auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        OnClickGoogleLogin();
    }

    public void OnClickLoginAnonymous() // 익명인증
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.SignInAnonymouslyAsync().ContinueWith(task =>
      {
          if (task.IsCompleted && !task.IsCanceled && !task.IsFaulted)
          {
              Firebase.Auth.FirebaseUser newUser = task.Result;
              result_text.text = string.Format("FirebaseUser:{0}\nEmail :{1}", newUser.UserId, newUser.Email);
              SceneManager.LoadScene("StartUI");
          }
          else
          {
              result_text.text = "Failed!!!";
          }
      });
    }
    public void OnClickGoogleLogin()//클릭 구글로그인
    {
        InitGooglePlayService();

        Social.localUser.Authenticate((bool success) =>
        {
            result_text.text = string.Format("Google Login Result - {0}:{1}", success, Social.localUser.userName);
            if (success == false)
                return;

            if (success)
                authCode = PlayGamesPlatform.Instance.GetServerAuthCode();
            StartCoroutine(coLogin());
        });
    }

    void InitGooglePlayService()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .RequestServerAuthCode(false)
            .RequestIdToken()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);

        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    IEnumerator coLogin()
    {
        result_text.text = string.Format("\nTry to get Token...");
        while (System.String.IsNullOrEmpty(((PlayGamesLocalUser)Social.localUser).GetIdToken()))
            yield return null;

        string idToken = ((PlayGamesLocalUser)Social.localUser).GetIdToken();

        result_text.text = string.Format("\nToken:{0}", idToken);
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        Firebase.Auth.Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(idToken, null);
        auth.SignInWithCredentialAsync(credential).ContinueWith(
            task =>
            {
                if (task.IsCompleted && !task.IsCanceled && !task.IsFaulted)
                {
                    Firebase.Auth.FirebaseUser newUser = task.Result;
                    result_text.text = string.Format("FirebaseUser:{0}\nEmail:{1}", newUser.UserId, newUser.Email);
                }
            });
        //SceneManager.LoadScene("StartUI");
        //result_text.text = string.Format("\nStartUI");
    }

}