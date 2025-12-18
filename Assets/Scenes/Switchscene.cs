using UnityEngine;
using TMPro;
public class Switchscene : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        if(inputField.text == "hello")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }

    }
}
