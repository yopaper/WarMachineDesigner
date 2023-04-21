using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WMD.VehicelsComponents
{
    public abstract class VehiclesComponents : MonoBehaviour
    {
        public VehicleComponentTransform ComponentTransform {get; protected set;}
        public abstract bool BaseComponent {get;}
        
    }//=================================================================
}