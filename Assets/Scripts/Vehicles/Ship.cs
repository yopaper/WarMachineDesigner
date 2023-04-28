using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WMD.Vehicels{
    public class Ship : Vehicle
    {
        protected const string ShipPrefabPath = BasicPrefabPath + "Ship";
        protected static GameObject ShipPrefabSource => Resources.Load<GameObject>(ShipPrefabPath);
        //---------------------------------------------------------------
        public static Ship CreateEmptyShip(Vector2 position){
            GameObject shipObject = GameObject.Instantiate( ShipPrefabSource );
            shipObject.transform.position = position;
            return shipObject.GetComponent<Ship>();
        }//--------------------------------------------------------------
        public static Ship CreateEmptyShip(){
            return CreateEmptyShip(new Vector2(0, 0));
        }//--------------------------------------------------------------
    }//==================================================================
}