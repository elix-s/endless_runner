using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace EndlessRunner.Gameplay
{
    ///<summary>
    ///Бесконечный респаун частей уровня
    ///</summary>
    public class TrackPartsRespown : MonoBehaviour
    {
        #region Private Variables

        ///<summary>
        ///Список со всеми частями трассы
        ///</summary>
        [SerializeField] private List<GameObject> _roadParts = new List<GameObject>();
        private float _partSize;

        ///<summary>
        ///Объект,куда будут респауниться части трассы
        ///</summary>
        [SerializeField] private GameObject _roadRespownPoint;
        [SerializeField] private GameObject _respawnPrefabs;
        private float _roadRespownPosition;
        private int _currentPart;
        private GameObject[] _parts;
        private int _totalParts;
        private float _targetPositionZ;
 
        #endregion
 
        #region Private Methods

        ///<summary>
        ///Расстановка 3-х частей трассы друг за другом при старте, скрытие остальных
        ///</summary>
        private void StartInitialization()
        {
            foreach(GameObject i in _roadParts)
            {
                Instantiate(i, _respawnPrefabs.transform);
            }

            _parts = GameObject.FindGameObjectsWithTag("TrackParts");
            _totalParts = _parts.Length;
            _partSize = _parts[0].GetComponent<BoxCollider>().size.z;

            for(int i = 0; i < _totalParts; i++)
            {
                if(i == 0)
                {
                    _parts[i].transform.position = new Vector3(0.0f, 0.0f, -_partSize);
                }

                if(i == 1)
                {
                    _parts[i].transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                }

                if(i == 2)
                {
                    _parts[i].transform.position = new Vector3(0.0f, 0.0f, _partSize);
                }

                if(i > 2)
                {
                    _parts[i].SetActive(false);
                }
            }

            _roadRespownPosition = 2 * -_partSize;
            _roadRespownPoint.transform.position = new Vector3(0.0f, 0.0f, _roadRespownPosition);
            _targetPositionZ = 2 * _partSize;
        }

        ///<summary>
        ///Респаун, часть достигшая точки респауна ставиться в позицию за 3-им элементом
        ///</summary>
        private void Respown()
        {
            _parts[_currentPart].SetActive(false);
            var nextPart = _currentPart + 3;
            var previousPart = _currentPart + 2;

            if (nextPart > _totalParts)
               nextPart = nextPart - _totalParts;

            if (nextPart == _totalParts)
                nextPart = 0;

            if(previousPart > _totalParts)
                previousPart = previousPart - _totalParts;

            if(previousPart == _totalParts)
                previousPart = 0;
  
            _parts[nextPart].SetActive(true);
            _parts[nextPart].transform.localPosition = new Vector3(0.0f, 0.0f, _parts[previousPart].transform.position.z + _partSize - 0.01f);
            _currentPart++;

            if (_currentPart == _totalParts)
                _currentPart = 0;
        }

        private void OnTriggerEnter(Collider other) {
            if(other.tag == "TrackParts")
                Respown();
        }
 
        #endregion
        
        #region MonoBehavior
 
        void Start()
        {
           StartInitialization();
        }
 
        #endregion
    }
}