using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
namespace NavalBattle.UI
{
    ///<summary>
    ///Счетчик уничтоженных кораблей
    ///</summary>
    public class ShipDestroyedCounter : MonoBehaviour
    {
        #region Properties

        public int ShipCounter {get; set;}

        #endregion

        #region Private Variables

        [SerializeField] private Text _shipCounterUI;
        [SerializeField] private VictoryPanel _victoryPanel;

        #endregion

        #region Public Methods
       
        ///<summary>
        ///Счетчик 
        ///</summary>
        public void Counter()
        {
            ShipCounter++;
            _shipCounterUI.text = ShipCounter.ToString();

            if(ShipCounter == GameSettings.Data.PointsToVictory)
            {
                GameSettings.Data.IsGameActive = false;
                _victoryPanel.ShowPanel();
                PlayerPrefs.SetInt("CurrentResult", ShipCounter);
            }
        }

        #endregion
    }
}

