using TheChecklist.Infrastructure;
using UnityEngine;

namespace TheChecklist.UI
{
    public class MenuScene : MonoBehaviour
    {
        [SerializeField] private string _f4PhantomSceneString = "F4_PhantomScene";
        [SerializeField] private UnityEngine.UI.Button _f4PhantomButton;
        [SerializeField] private string _boeingSceneString = "BoeingScene";
        [SerializeField] private UnityEngine.UI.Button _boeingButton;

        private void OnEnable()
        {
            _f4PhantomButton.onClick.AddListener(() => LoadScene(_f4PhantomSceneString));
            _boeingButton.onClick.AddListener(() => LoadScene(_boeingSceneString));
        }

        private void LoadScene(string sceneName)
        {
            SceneLoader.LoadScene(sceneName);
        }
    }
}

