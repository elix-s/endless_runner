using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace EndlessRunner.Gameplay
{
    ///<summary>
    ///Генерация врагов
    ///</summary>
    public class EnemyGenerator : MonoBehaviour
    {
        #region Private Variables

        [SerializeField] private Transform _enemiesRespownTransform;
        [SerializeField] private GameObject _enemyType1Prefab;
        [SerializeField] private GameObject _enemyType2Prefab;
        [SerializeField] private GameObject _enemyType3Prefab;
        [SerializeField] private int _enemiesNumberType1;
        [SerializeField] private int _enemiesNumberType2;
        [SerializeField] private int _enemiesNumberType3;
 
        #endregion
        
        #region MonoBehavior
 
        void Start()
        {
            for(int i = 0; i < _enemiesNumberType1; i++)
            {
                Instantiate(_enemyType1Prefab, _enemiesRespownTransform);
                _enemyType1Prefab.transform.position = new Vector3(Random.Range(-2,2), transform.position.y, Random.Range(20,80));
            }

            for(int i = 0; i < _enemiesNumberType2; i++)
            {
                Instantiate(_enemyType2Prefab, _enemiesRespownTransform);
                _enemyType2Prefab.transform.position = new Vector3(Random.Range(-2,2), transform.position.y, Random.Range(20,80));
            }

            for(int i = 0; i < _enemiesNumberType3; i++)
            {
                Instantiate(_enemyType3Prefab, _enemiesRespownTransform);
                _enemyType3Prefab.transform.position = new Vector3(Random.Range(-2,2), transform.position.y, Random.Range(20,80));
            }
        }
        
        #endregion
    }
}

