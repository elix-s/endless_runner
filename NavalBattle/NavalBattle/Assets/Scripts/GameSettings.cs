using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace NavalBattle
{
    ///<summary>
    ///Основные настройки игры
    ///</summary>
    public class GameSettings : MonoBehaviour
    {
        #region Properties

        public static GameSettings Data { get; set;}
        public bool IsGameActive { get; set; }

        public float ShipSpeed
        {
            get => _shipSpeed;
            set => _shipSpeed = value;
        }

        public float RocketSpeed
        {
            get => _rocketSpeed;
            set => _rocketSpeed = value;
        }

        public int NumberOfShipsLeft
        {
            get => _numberOfShipsLeft;
            set => _numberOfShipsLeft = value;
        }

        public int NumberOfShipsRight
        {
            get => _numberOfShipsRight;
            set => _numberOfShipsRight = value;
        }

        public int BorderTop
        {
            get => _borderTop;
            set => _borderTop = value;
        }

        public int BorderBottom
        {
            get => _borderBottom;
            set => _borderBottom = value;
        }

        public int BorderLeft
        {
            get => _borderLeft;
            set => _borderLeft = value;
        }

        public int PointsToVictory
        {
            get => _pointsToVictory;
            set => _pointsToVictory = value;
        }

        #endregion

        #region Private Variables

        [Header("Основные параметры")]

        [Range(-3,3)]
        [SerializeField] private float _shipSpeed;

        [Range(-1,1)]
        [SerializeField] private float _rocketSpeed;

        [Range(0,100)]
        [SerializeField] private int _numberOfShipsLeft;

        [Range(0,100)]
        [SerializeField] private int _numberOfShipsRight;

        [Range(1,20)]
        [SerializeField] private int _pointsToVictory;

        [Header("Настройка размера игровой области")]

        [Range(-5,5)]
        [SerializeField] private int _borderTop;

        [Range(5,-5)]
        [SerializeField] private int _borderBottom;

        [Range(-100,100)]
        [SerializeField] private int _borderLeft;

        #endregion
        
        #region MonoBehavior

        void Awake() 
        {
            if (Data != null && Data != this)
            {
                Destroy(this.gameObject);
            } 
            else {
                Data = this;
            }

            IsGameActive = true;
        }
 
        #endregion
    }
}
