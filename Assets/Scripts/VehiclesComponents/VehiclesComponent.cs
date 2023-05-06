using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Vehicels;
using WMD.Basic;

namespace WMD.VehicelsComponents
{
    public abstract class VehicleComponent : MonoBehaviour
    {
        public enum ComponentScale{ Small, Medium, Large }
        public static string VehicleComponentBasicPrefabPath => "VehicleComponent/";
        //_______________________________________________________________________
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
        public static VehicleComponent CreateVehicleComponentObject(
            GameObject prefabSource, Vector3Int anchorPoint){
            return CreateVehicleComponentObject<VehicleComponent>(prefabSource, anchorPoint);
        }
        //-----------------------------------------------------------------------

        //=======================================================================
        public Vehicle VehicleOwner;
        public VehicleComponentTransform ComponentTransform {get; protected set;}
        public VehicleComponentData ComponentData{get; protected set;}
        public abstract bool BaseComponent {get;}
        public virtual float PositionZOffset => 0f;
        public abstract ComponentScale Scale {get;}
        //_______________________________________________________________________
        public void XFlip(){
            ArrayFunction.ProcessList( Sprites, (SpriteRenderer sprite)=>{
                sprite.flipX = !sprite.flipX;
            } );
        }//---------------------------------------------------------------
        public Vector3 UpdateLocalPosition(Vector2 offset){
            float z = ComponentTransform.AnchorPoint.z + PositionZOffset;
            transform.localPosition = new Vector3(
                ComponentTransform.CenterPoint.x + offset.x,
                ComponentTransform.CenterPoint.y + offset.y,
                -z );
            ArrayFunction.ProcessList( Sprites, (SpriteRenderer sprite)=>{
                sprite.sortingOrder = Mathf.RoundToInt(z);
            } );
            return transform.localPosition;
        }//------------------------------------------------------------
        public Vector3 UpdateLocalPosition(){
            return UpdateLocalPosition( Vector2.zero );
        }//------------------------------------------------------------
        //________________________________________________________________________
        protected abstract VehicleComponentTransform TransformSource{get;}
        protected abstract VehicleComponentData DataSource{get;}
        protected List<SpriteRenderer> Sprites = new List<SpriteRenderer>();
        //________________________________________________________________________
        protected void LoadSprite(){
            void LoadSpriteFromObject( Transform targetTransform ){
                SpriteRenderer sprite = GetComponent<SpriteRenderer>();
                if( sprite != null )Sprites.Add( sprite );
                for(int i=0; i<targetTransform.childCount; i++){
                    LoadSpriteFromObject(targetTransform.GetChild(i));
                }
            }//..........................................................
            LoadSpriteFromObject(transform);
        }//--------------------------------------------------------------
        protected virtual void InitialVariable(){
            ComponentTransform = TransformSource;
            ComponentData = DataSource;
        }//-------------------------------------------------------------
        protected void Awake(){
            InitialVariable();
            LoadSprite();
        }//-------------------------------------------------------------
    }//============================================================================

}