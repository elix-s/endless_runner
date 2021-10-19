using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
namespace NavalBattle.UI
{
    ///<summary>
    ///Показ, скрытие панели победы
    ///</summary>
    public class VictoryPanel : MonoBehaviour
    {
        #region  Private Methods

        [SerializeField] private GameObject _victoryPanel;

        #endregion

        #region  Public Methods
       
        public void ShowPanel()
        {
            _victoryPanel.SetActive(true);
        }

        public void HidePanel()
        {
            _victoryPanel.SetActive(false);
        }

        #endregion

        void Start() {
            _victoryPanel.SetActive(false);
        }
    }
}
