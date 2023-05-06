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
        ShipWeaponComponent cannon;
        protected float coolDown = 0;
        void Awake()
        {
            ship = Ship.CreateEmptyShip();
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock3x3.PrefabSource, new Vector3Int(0, 0, 0) ) );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock3x3.PrefabSource, new Vector3Int(0, -3, 0) ) );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock3x3.PrefabSource, new Vector3Int(0, 3, 0) ) );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock2x2.PrefabSource, new Vector3Int(2, -2, 0) ) );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock2x2.PrefabSource, new Vector3Int(-3, -2, 0) ) );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock1x1.PrefabSource, new Vector3Int(-2, 1, 0) ) );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock1x1.PrefabSource, new Vector3Int(-2, 0, 0) ) );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock1x1.PrefabSource, new Vector3Int(2, 1, 0) ) );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock1x1.PrefabSource, new Vector3Int(2, 0, 0) ) );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock1x1.PrefabSource, new Vector3Int(0, 0, 1) ) );
            ship.AddComponent( VehicleComponent.CreateVehicleComponentObject( ShipBlock3x3.PrefabSource, new Vector3Int(0, -2, 1) ) );
            cannon = VehicleComponent.CreateVehicleComponentObject<ShipWeaponComponent>(
                ShipTurret127x1.PrefabSource, new Vector3Int(0, 3, 1) );
            ship.AddComponent( cannon );
            ship.UpdateGravityCenter();
        }//--------------------------------------------------------------
        void Update()
        {
            coolDown += 1;
            if( coolDown >= 10 ){
                coolDown = 0;
                cannon.Rotator.RotateToDegree(270);
            }
        }//--------------------------------------------------------------
    }
}