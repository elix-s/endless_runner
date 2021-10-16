using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessRunner;
 
namespace EndlessRunner.Gameplay
{
    ///<summary>
    ///Управление кубиком через тапы
    ///</summary>
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Control : MonoBehaviour
    {
        #region Private Variables

        private Vector3 mousePos;
        private Vector3 mousePosClick;
        private float _offset;
        private int _counter;
 
        #endregion
 
        #region Private Methods

        ///<summary>
        ///Отслеживание позиции мыши относительно кубика, определние стороны смещения
        ///</summary>
        private void GetClickedPosition()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
 
            if (Physics.Raycast (ray, out hit))
            {
                if(hit.point.x > transform.position.x && transform.position.x < 1.5f)
                    _offset = 1;
                
                if(hit.point.x > transform.position.x && transform.position.x > 1.5f)
                    _offset = 0;
                
                if(hit.point.x < transform.position.x && transform.position.x > -1.5f)
                    _offset = -1;
                
                if(hit.point.x < transform.position.x && transform.position.x < -1.5f)
                    _offset = 0;                 
            }
        }
 
        #endregion
        
        #region MonoBehavior

        void Update()
        {
            if(Input.GetMouseButtonDown(0) && GameSettings.Data.IsGameActive == true)
            {
                GetClickedPosition();
                transform.position = new Vector3(transform.position.x + _offset, transform.position.y, transform.position.z);
            }
        }

        #endregion
    }
}


