using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Vehicels;

namespace WMD.VehicelsComponents
{
    public abstract class VehicleComponent : MonoBehaviour
    {
        public enum ComponentScale{ Small, Medium, Large }
        public static string VehicleComponentBasicPrefabPath => "VehicleComponent/";
        public static ComponentType CreateVehicleComponentObject<ComponentType>
        (GameObject prefabSource, Vector3Int anchorPoint) where ComponentType:VehicleComponent{
            GameObject componentObject = GameObject.Instantiate( prefabSource );
            ComponentType component = componentObject.GetComponent<ComponentType>();
            component.ComponentTransform.SetAnchorPoint( anchorPoint );
            return component;
        }
        //-----------------------------------------------------------------------
        public static ComponentType CreateVehicleComponentObject<ComponentType>
        (GameObject prefabSource) where ComponentType:VehicleComponent{
            return CreateVehicleComponentObject<ComponentType>(prefabSource, Vector3Int.zero);
        }
        //-----------------------------------------------------------------------
        //=======================================================================
        public Vehicle VehicleOwner;
        public VehicleComponentTransform ComponentTransform {get; protected set;}
        public VehicleComponentData ComponentData{get; protected set;}
        public abstract bool BaseComponent {get;}
        public virtual float PositionZOffset => 0f;
        public abstract ComponentScale Scale {get;}
        //--------------------------------------------------------------
        public Vector3 UpdateLocalPosition(){
            transform.localPosition = ComponentTransform.CenterPoint + new Vector3(0, 0, PositionZOffset);
            return transform.localPosition;
        }//------------------------------------------------------------
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