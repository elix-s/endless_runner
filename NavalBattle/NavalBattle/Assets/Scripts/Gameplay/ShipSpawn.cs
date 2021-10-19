using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace NavalBattle.Gameplay
{
    ///<summary>
    ///Проставление кораблей в нужную позицию при старте, в зависимости от того слева или справа они плывут
    ///</summary>
    public class ShipSpawn : MonoBehaviour
    {
        ///<summary>
        ///Точка респауна слева
        ///</summary>
        [SerializeField] private GameObject _shipSpawnLeft;

        ///<summary>
        ///Точка респауна справа
        ///</summary>
        [SerializeField] private GameObject _shipSpawnRight;
        [SerializeField] private GameObject _shipPrefab;

        ///<summary>
        ///Список кораблей слева
        ///</summary>
        private List<GameObject> _shipsLeft = new List<GameObject>();

        ///<summary>
        ///Список кораблей справа
        ///</summary>
        private List<GameObject> _shipsRight = new List<GameObject>();
        
        void Start() 
        {
            for(int i = 0; i < GameSettings.Data.NumberOfShipsLeft; i++)
                _shipsLeft.Add(Instantiate(_shipPrefab, _shipSpawnLeft.transform));

            for(int i = 0; i < GameSettings.Data.NumberOfShipsRight; i++)
                _shipsRight.Add(Instantiate(_shipPrefab, _shipSpawnRight.transform));
    
            //ставим корабли слева
            foreach(var ship in _shipsLeft)
            {
                var randomPositionY = Mathf.Round(Random.Range(GameSettings.Data.BorderTop, GameSettings.Data.BorderBottom));
                var randomPositionX = Mathf.Round(Random.Range(_shipSpawnLeft.transform.position.x, GameSettings.Data.BorderLeft));
                ship.transform.position = new Vector2(randomPositionX, randomPositionY);
            }

            //ставим корабли справа
            foreach(var ship in _shipsRight)
            {
                var randomPositionY = Mathf.Round(Random.Range(GameSettings.Data.BorderTop, GameSettings.Data.BorderBottom));
                var randomPositionX = Mathf.Round(Random.Range(_shipSpawnRight.transform.position.x, -GameSettings.Data.BorderLeft));
                ship.transform.position = new Vector2(randomPositionX, randomPositionY);
            }  
        }  
    }
}
