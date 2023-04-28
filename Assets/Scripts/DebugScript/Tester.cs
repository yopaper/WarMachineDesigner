using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.VehicelsComponents;
using WMD.Basic;
using WMD.Vehicels;

namespace WMD.DebugFunction{
    public class Tester : MonoBehaviour
    {
        protected ShipRotatableComponentTransform srct;
        protected Ship ship;
        protected float coolDown = 0;
        void Start()
        {
            ship = Ship.CreateEmptyShip();
            Debug.Log( ShipBlock1x1.PrefabSource );
            ShipBlock1x1 sb;
            sb = VehicleComponent.CreateVehicleComponentObject<ShipBlock1x1>( ShipBlock1x1.PrefabSource );
            sb.ComponentTransform.SetAnchorPoint( new Vector3Int(0, 1, 0) );
            ship.AddComponent( sb );
            sb = VehicleComponent.CreateVehicleComponentObject<ShipBlock1x1>( ShipBlock1x1.PrefabSource );
            sb.ComponentTransform.SetAnchorPoint( new Vector3Int(1, 0, 0) );
            ship.AddComponent( sb );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject<ShipBlock2x2>( ShipBlock2x2.PrefabSource, new Vector3Int(1, 1, 0) ) );
        }//--------------------------------------------------------------
        void Update()
        {
            
        }//--------------------------------------------------------------
    }
}