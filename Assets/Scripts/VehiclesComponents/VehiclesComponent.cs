using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WMD.VehicelsComponents
{
    public abstract class VehicleComponent : MonoBehaviour
    {
        public VehicleComponentTransform ComponentTransform {get; protected set;}
        public abstract bool BaseComponent {get;}
        //--------------------------------------------------------------
        protected abstract VehicleComponentTransform TransformSource{get;}
        
    }//=================================================================
}