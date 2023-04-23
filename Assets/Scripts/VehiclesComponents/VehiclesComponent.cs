using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WMD.VehicelsComponents
{
    public abstract class VehicleComponent : MonoBehaviour
    {
        public enum ComponentScale{ Small, Medium, Large }
        public VehicleComponentTransform ComponentTransform {get; protected set;}
        public VehicleComponentData ComponentData{get; protected set;}
        public abstract bool BaseComponent {get;}
        public abstract ComponentScale Scale {get;}
        //--------------------------------------------------------------
        protected abstract VehicleComponentTransform TransformSource{get;}
        protected abstract VehicleComponentData DataSource{get;}
        //-------------------------------------------------------------
        protected void InitialVariable(){
            ComponentTransform = TransformSource;
            ComponentData = DataSource;
        }//-------------------------------------------------------------
        protected void Awake(){
            InitialVariable();
        }//-------------------------------------------------------------
    }//=================================================================
}