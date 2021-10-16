using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace EndlessRunner
{
    public class GameSettings : MonoBehaviour
    {
        #region Properties

        public static GameSettings Data { get; set;}

        public float BasicSpeed
        {
            get => _basicSpeed;
            set => _basicSpeed = value;
        }

        public float EnemiesSpeed
        {
            get => _enemiesSpeed;
            set => _enemiesSpeed = value;
        }

        public float SpeedIncreaseInterval
        {
            get => _speedIncreaseInterval;
            set => _speedIncreaseInterval = value;
        }

        public float SpeedIncreaseStep
        {
            get => _speedIncreaseStep;
            set => _speedIncreaseStep = value;
        }

        public bool IsGameActive { get; set;}

        #endregion

        #region Private Variables

        [Header("Player Character")]

        [Range(-1,1)]
        [SerializeField] private float _basicSpeed;

        [Range(-1,1)]
        [SerializeField] private float _enemiesSpeed;

        [Range(0,100)]
        [SerializeField] private float _speedIncreaseInterval;

        [Range(-1,1)]
        [SerializeField] private float _speedIncreaseStep;
 
        #endregion
 
        #region Private Methods
 
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
        }
 
        void Start()
        {
           
        }

       
 
        #endregion
    }
}
