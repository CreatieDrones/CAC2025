using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class userSelect : MonoBehaviour
{
    string URL = "http://192.168.1.166:8080/unity_db/userSelect.php"; // Corrected URL
    public string[] usersData;

    IEnumerator Start()
    {
       
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            
            yield return request.SendWebRequest();

            
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                
                string usersDataString = request.downloadHandler.text;
                Debug.Log("Received Data: " + usersDataString);

                
                usersData = usersDataString.Split(';');

              
                foreach (string user in usersData)
                {
                    Debug.Log("User: " + user);
                }
            }
        }
    }

    void Update()
    {
    }
}