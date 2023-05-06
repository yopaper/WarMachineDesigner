using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.VehicelsComponents;
using WMD.Basic;

namespace WMD.Vehicels{
    public abstract class Vehicle : MonoBehaviour
    {
        protected const string BasicPrefabPath = "Vehicles/";

        public string Name{get; protected set;}
        public Vector2 GravityCenter{get; protected set;}
        protected List<VehicleComponent> ComponentSet = new List<VehicleComponent>();
        protected Dictionary< Vector3Int, VehicleComponent > ComponentIndexTable
        = new Dictionary<Vector3Int, VehicleComponent>();
        protected HashSet<Vector3Int> BuildableIndex
        = new HashSet<Vector3Int>();
        protected Transform ComponentsGroup;
        //___________________________________________________________
        public void UpdateGravityCenter(){
            if( ComponentSet.Count<=0 )return;
            Vector2 center = Vector2.zero;
            int massSum = 0;
            ArrayFunction.ProcessList( ComponentSet, (VehicleComponent component)=>{
                int mass = Mathf.Max(1, component.ComponentData.Mass);
                massSum += mass;
                center = center + new Vector2(
                    component.ComponentTransform.CenterPoint.x * mass,
                    component.ComponentTransform.CenterPoint.y * mass
                );
            });
            GravityCenter = center / massSum;
            Debug.Log( string.Format("{0},{1}", GravityCenter.x, GravityCenter.y) );
            ArrayFunction.ProcessList( ComponentSet, (VehicleComponent component)=>{
                component.UpdateLocalPosition( -GravityCenter );
            });
        }
        //----------------------------------------------------------
        public VehicleComponent[] GetAllComponents()
        => ComponentSet.ToArray();
        //----------------------------------------------------------
        public VehicleComponent GetComponent( Vector3Int index ){
            if( ComponentIndexTable.ContainsKey( index ) )
                return ComponentIndexTable[ index ];
            return null;
        }
        //--------------------------------------------------------
        public bool HaveComponent( VehicleComponent component )
        => ComponentSet.Contains( component );
        //---------------------------------------------------------
        public bool CanAddComponent( VehicleComponent component ){
            VehicleComponentTransform componentTransform =
            component.ComponentTransform;
            //.....................................................
            bool CheckBuildBase(){
                if( component.BaseComponent && componentTransform.AnchorPoint.z == 0 )
                    return true;
                for( int i=0; i<componentTransform.RootIndex.Length; i++ ){
                    Vector3Int rootIndex = componentTransform.RootIndex[i];
                    if( !BuildableIndex.Contains( rootIndex + new Vector3Int(0, 0, -1) ) )
                        return false;
                }
                return true;
            }
            //.....................................................
            bool CheckOccupiedIndex(){
                for(int i=0; i<componentTransform.OccupiedIndex.Length; i++){
                    Vector3Int occupiedIndex = componentTransform.OccupiedIndex[i];
                    if( ComponentIndexTable.ContainsKey( occupiedIndex ) )
                        return false;
                }
                return true;
            }
            //.....................................................
            if( HaveComponent(component) )return false;
            return( CheckBuildBase() && CheckOccupiedIndex() );
        }
        //---------------------------------------------------------
        public void AddComponent( VehicleComponent component ){
            if( !CanAddComponent( component ) )return;
            VehicleComponentTransform componentTransform = component.ComponentTransform;
            ComponentSet.Add( component );
            component.transform.SetParent( ComponentsGroup );
            component.VehicleOwner = this;
            // Occupied Index .............
            ArrayFunction.ProcessArray(
                componentTransform.OccupiedIndex, (Vector3Int index)=>{
                    ComponentIndexTable[index] = component;
                }
            );
            // Buildable Base ..................
            ArrayFunction.ProcessArray(
                componentTransform.BuildableIndex, (Vector3Int index)=>{
                    BuildableIndex.Add( index );
                }
            );
            component.UpdateLocalPosition();
        }
        //----------------------------------------------------------
        public void RemoveComponent( VehicleComponent component ){
            if( !HaveComponent( component ) )return;
            ComponentSet.Remove( component );
            component.transform.SetParent( null );
            VehicleComponentTransform componentTransform = component.ComponentTransform;
            ArrayFunction.ProcessArray( componentTransform.OccupiedIndex,
            (Vector3Int index)=>{ ComponentIndexTable.Remove(index); } );
            ArrayFunction.ProcessArray( componentTransform.BuildableIndex,
            (Vector3Int index)=>{ BuildableIndex.Remove(index); } );
        }
        //----------------------------------------------------------

        // ========================================================
        // Not Public
        protected void Awake(){
            LoadComponentsGroup();
        }
        //---------------------------------------------------------
        protected void LoadComponentsGroup(){
            ComponentsGroup = transform.Find("Components").transform;
        }
        //----------------------------------------------------------
    }//=============================================================
}