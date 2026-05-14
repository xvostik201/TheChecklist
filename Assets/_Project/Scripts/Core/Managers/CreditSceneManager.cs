namespace TheChecklist.Core.Managers
{
    using UnityEngine;
    
    public class CreditSceneManager : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.Quit();
            }
        }
    }
}

