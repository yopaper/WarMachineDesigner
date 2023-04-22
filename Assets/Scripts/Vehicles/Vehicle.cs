using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.VehicelsComponents;

namespace WMD.Vehicels{
    public abstract class Vehicle : MonoBehaviour
    {
        public string Name{get; protected set;}
        protected List< VehicleComponent > Components = new List<VehicleComponent>();
        protected Dictionary< Vector3Int, VehicleComponent > ComponentIndexTable
        = new Dictionary<Vector3Int, VehicleComponent>();
        //----------------------------------------------------------
        public VehicleComponent[] GetAllComponents()
        => Components.ToArray();
        //----------------------------------------------------------
        public VehicleComponent GetComponent( Vector3Int index ){
            if( ComponentIndexTable.ContainsKey( index ) )
                return ComponentIndexTable[ index ];
            return null;
        }//--------------------------------------------------------
    }//=============================================================
}