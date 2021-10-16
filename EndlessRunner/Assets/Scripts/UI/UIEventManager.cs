using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace EndlessRunner.UI
{
    ///<summary>
    ///определяем основные события интерфейса
    ///</summary>
    public class UIEventManager : MonoBehaviour
    {
        #region Variables

        ///<summary>
        ///событие клика по экрану при запусе игры
        ///</summary>
        public UnityEvent OnMainScreenClick;
        [SerializeField] private GameObject _replayButton;
        [SerializeField] private GameObject _gameTimer;
        [SerializeField] private GameObject _bestResult;
        [SerializeField] private GameObject _textLabel1;
        [SerializeField] private GameObject _textLabel2;
        [SerializeField] private GameObject _textLabel3;
        private float _basicSpeed;
        private float _enemiesSpeed;

        #endregion

        #region Private Methods

        ///<summary>
        ///скрываем главный экран меню при запуске игры
        ///</summary>
        private void MainScreenClick()
        {  
            GameSettings.Data.IsGameActive = true;
            GameSettings.Data.BasicSpeed = _basicSpeed;
            GameSettings.Data.EnemiesSpeed = _enemiesSpeed; 
            _textLabel3.SetActive(false);         
        }

        ///<summary>
        ///запуск экрана загрузки
        ///</summary>
        public void ReplayButtonClick()
        {
            SceneManager.LoadScene(0);
        }

        ///<summary>
        ///пауза игры
        ///</summary>
        private void Pause()
        {
            GameSettings.Data.BasicSpeed = 0.0f;
            GameSettings.Data.EnemiesSpeed = 0.0f;
        }

        #endregion

        #region MonoBehaviour

        void Start()
        {
            OnMainScreenClick = new UnityEvent();
            OnMainScreenClick.AddListener(MainScreenClick);

            _basicSpeed = GameSettings.Data.BasicSpeed;
            _enemiesSpeed = GameSettings.Data.EnemiesSpeed;

            Pause();

            _replayButton.SetActive(false);
            _gameTimer.SetActive(false);
            _bestResult.SetActive(false);
            _textLabel1.SetActive(false);
            _textLabel2.SetActive(false);
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0) && GameSettings.Data.IsGameActive == false)
            {
                OnMainScreenClick.Invoke();
            }
        }

        #endregion
    }
}
