using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
namespace NavalBattle.UI
{
    ///<summary>
    ///Счетчик израсходованных ракет
    ///</summary>
    public class RocketCounter : MonoBehaviour
    {
        #region Private Variables

        [SerializeField] private int _rocketCounter;
        [SerializeField] private Text _rocketCounterUI;
        [SerializeField] private FailedPanel _failedPanel;
        [SerializeField] private ShipDestroyedCounter _destroyedShips;

        #endregion

        #region Public Methods
       
        ///<summary>
        ///Счетчик
        ///</summary>
        public void Counter()
        {
            _rocketCounter--;
            _rocketCounterUI.text = _rocketCounter.ToString();

            if(_rocketCounter == 0)
            {
                GameSettings.Data.IsGameActive = false;
                _failedPanel.ShowPanel();
                PlayerPrefs.SetInt("CurrentResult", _destroyedShips.ShipCounter);
            }
        }

        #endregion

        void Start() {
             _rocketCounterUI.text = _rocketCounter.ToString();
        }
    }
}
