using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Modules.LevelManager
{
    ///<summary>
    ///Экран загрузки
    ///</summary>
    public class LevelManager : MonoBehaviour
    {
        #region Private Variables

        private int _currentLevel;     
        public Text ProgressText;
        public Image ProgressImage;

        #endregion

        #region Private Methods

        ///<summary>
        ///Загрузка текущего уровня
        ///</summary>
        private IEnumerator LoadingFunction()
        {
            if(PlayerPrefs.GetInt("CurrentLevel") > 1)
            {
                _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            }
            else
            {
                _currentLevel = 1;
            }

            AsyncOperation Operation = SceneManager.LoadSceneAsync(_currentLevel);
                
            while (!Operation.isDone)
            {
                float Progress = Operation.progress;
                ProgressText.text = $"{(Progress * 100).ToString("0")}%"; 
                //ProgressImage.fillAmount = Progress;
                yield return null;
            }
        }

        #endregion

        #region MonoBehavior

        public void Awake()
        {
            StartCoroutine(LoadingFunction());
        }

        #endregion
    }
}
