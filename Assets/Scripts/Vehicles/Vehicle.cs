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
        protected HashSet<Vector3Int> BuildableIndex
        = new HashSet<Vector3Int>();
        //----------------------------------------------------------
        public VehicleComponent[] GetAllComponents()
        => Components.ToArray();
        //----------------------------------------------------------
        public VehicleComponent GetComponent( Vector3Int index ){
            if( ComponentIndexTable.ContainsKey( index ) )
                return ComponentIndexTable[ index ];
            return null;
        }
        //--------------------------------------------------------
        public bool HaveComponent( VehicleComponent component )
        => Components.Contains( component );
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
            
        }
    }//=============================================================
}