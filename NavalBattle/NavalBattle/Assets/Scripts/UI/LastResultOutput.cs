using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
namespace NavalBattle.UI
{
    ///<summary>
    ///Счетчик уничтоженных кораблей
    ///</summary>
    public class LastResultOutput : MonoBehaviour
    {
        #region Private Variables

        [SerializeField] private Text _lastResult;

        #endregion

        void Start() {
            _lastResult.text = PlayerPrefs.GetInt("CurrentResult").ToString();
        }   
    }
}
