using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
namespace NavalBattle.UI
{
    ///<summary>
    ///События кнопок интерфейса
    ///</summary>
    public class UIButtons : MonoBehaviour
    {
        #region  Public Methods

        public void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }

        public void LoadLevel1()
        {
            SceneManager.LoadScene(1); 
        }

        public void LoadLevel2()
        {
            SceneManager.LoadScene(2); 
        }

        public void LoadLevel3()
        {
            SceneManager.LoadScene(3); 
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene(0); 
        }

        public void QuitGame()
        {
            Application.Quit(); 
        }

        #endregion
    }
}