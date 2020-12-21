using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour

    
{
    public InputField email;
    public InputField password;
    public Text resultText;

   

    Firebase.Auth.FirebaseAuth auth;

    // Start is called before the first frame update

    void Start()
    {
      auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SignUp()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text.ToString(), password.text.ToString()).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            resultText.text = "signed up";
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }





    public void SignIn()

        // code to verify if user puts in email or password
    {
        if (email.text == "" || password.text == "")
        {
            resultText.text = "Not signed in";
        }
        else
        {
            resultText.text = "hello user";
        }





       

        auth.SignInWithEmailAndPasswordAsync(email.text.ToString(), password.text.ToString()).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            //resultText.text = "signed in";
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }
}
