using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Vehicels;

namespace WMD.VehicelsComponents{
    public abstract class ShipComponent : VehicleComponent
    {
        public static string ShipComponentBasicPrefabPath =>
        VehicleComponent.VehicleComponentBasicPrefabPath + "ShipComponent/";
        public Ship ShipOwner{
            get{return (Ship)VehicleOwner;} 
            set{VehicleOwner = value;} }
        
    }//=================================================================
}