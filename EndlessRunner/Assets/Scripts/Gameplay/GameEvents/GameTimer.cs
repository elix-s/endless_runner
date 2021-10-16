using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EndlessRunner;
 
namespace EndlessRunner.Gameplay
{
    ///<summary>
    ///События по игровому таймеру, увеличение скорости со временем
    ///</summary>
    public class GameTimer : MonoBehaviour
    {
        #region Private Variables

        private float _timer;
        private bool _speedIncreaseMoment;
        private int _counter;
 
        #endregion

        #region Public Variables

        [HideInInspector] public float DistanceTraveled;

        #endregion
 
        #region Private Methods
        
        ///<summary>
        ///момент изменения скорости
        ///</summary>
        private IEnumerator SpeedIncrease()
        {
            _counter = 1;
            GameSettings.Data.BasicSpeed -= GameSettings.Data.SpeedIncreaseStep;
            GameSettings.Data.EnemiesSpeed -= GameSettings.Data.SpeedIncreaseStep;
            yield return new WaitForSecondsRealtime(1f);
            _counter = 0;
        }

        #endregion
        
        #region MonoBehavior

        void FixedUpdate() 
        {
            if(GameSettings.Data.IsGameActive == true)
            {
                _timer += Time.deltaTime;
                DistanceTraveled += -GameSettings.Data.BasicSpeed * Time.deltaTime*60;

                if(Mathf.Round(_timer) > 0 && Mathf.Round(_timer) % GameSettings.Data.SpeedIncreaseInterval == 0)
                    if(_counter == 0)
                        StartCoroutine(SpeedIncrease());                 
            }
        }
 
        #endregion
    }
}
