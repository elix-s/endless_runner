using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavalBattle;
using NavalBattle.UI;
 
namespace NavalBattle.Gameplay
{
    ///<summary>
    ///Просчет траектории ракеты, респаун в изначальную позицию
    ///</summary>
    public class RocketController : MonoBehaviour
    {
        #region Private Variables

        ///<summary>
        ///Точка респауна ракеты
        ///</summary>
        [SerializeField] private GameObject _rocketSpawner;
        [SerializeField] private float _speed;
        [SerializeField] private RocketCounter _rocketCounter;

        ///<summary>
        ///Просчет направления полета
        ///</summary>
        private Vector3 _directionMovement = Vector3.zero;

        ///<summary>
        ///Координаты клика мыши
        ///</summary>
        private Vector2 _clickPosition;

        ///<summary>
        ///Угол наклона ракеты к точке клика
        ///</summary>
        private float _angleRotation;
        private bool _isShot;

        #endregion

        #region Unity Events

        void OnBecameInvisible()
        {
            _isShot = false;

            if(GameSettings.Data.IsGameActive == true)
            {
                transform.position = _rocketSpawner.transform.position;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                _rocketCounter.Counter();
            }
        }

        #endregion

        #region MonoBehavior

        void Update()
        {
            if(Input.GetMouseButtonDown(0) && _isShot == false && GameSettings.Data.IsGameActive == true)
            {
                _isShot = true;
                _clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _clickPosition.x = _clickPosition.x - transform.position.x;
                _clickPosition.y = _clickPosition.y - transform.position.y;
                _angleRotation = Mathf.Atan2(_clickPosition.x, _clickPosition.y) * Mathf.Rad2Deg;

                if(_clickPosition.x > 0)
                    _directionMovement = (_clickPosition - (Vector2)transform.position * _angleRotation).normalized;
                else
                    _directionMovement = (_clickPosition - (Vector2)transform.position * -_angleRotation).normalized;

                transform.Rotate(0, 0, -_angleRotation);
            }

            if(_isShot == true)
                transform.Translate(_directionMovement * GameSettings.Data.RocketSpeed);
        }

        void Start() {
            transform.position = _rocketSpawner.transform.position;
        }  

        #endregion
    }
}
