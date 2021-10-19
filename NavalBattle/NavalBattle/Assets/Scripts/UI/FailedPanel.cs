using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
namespace NavalBattle.UI
{
    ///<summary>
    ///Показ, скрытие панели проигрыша
    ///</summary>
 
    public class FailedPanel : MonoBehaviour
    {
        #region Private Variables

        [SerializeField] private GameObject _failedPanel;

        #endregion

        #region Public Methods
       
        public void ShowPanel()
        {
            _failedPanel.SetActive(true);
        }

        public void HidePanel()
        {
            _failedPanel.SetActive(false);
        }

        #endregion

        void Start() {
            _failedPanel.SetActive(false);
        }
    }
}
