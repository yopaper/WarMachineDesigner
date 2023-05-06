using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Vehicels;
using WMD.Basic;

namespace WMD.VehicelsComponents{
    public class WeaponRotator
    {
        public VehicleComponent ComponentOwner{get; protected set;}
        public VehicleComponentTransform Transform => ComponentOwner.ComponentTransform;
        public Vehicle VehicleOwner => ComponentOwner.VehicleOwner;
        public int InitialDegree{get; protected set;}
        public float MaxRotateSpeed{get; protected set;}
        public float CurrentDegree => ComponentOwner.transform.eulerAngles.z;
        //____________________________________________________________
        public WeaponRotator( VehicleComponent componentOwner ){
            ComponentOwner = componentOwner;
            InitialDegree = DirectionHandler.DirectionToDegree(Transform.ComponentDirection);
        }//-----------------------------------------------------------
        public void RotateToDegree(float degree){
            int GetRotateDirection(){
                if( CurrentDegree <= 180f ){
                    // 小於180
                    float opposite = CurrentDegree + 180;
                    if( degree >= CurrentDegree && degree < opposite )
                        return 1;
                    return -1;
                }else{
                    // 大於180
                    float opposite = CurrentDegree - 180;
                    if( degree > opposite && degree <= CurrentDegree )
                        return -1;
                    return 1;
                }
            }//........................................................
            Debug.Log( ComponentOwner.transform.eulerAngles.z );
            ComponentOwner.transform.Rotate(0, 0, -1);
        }//------------------------------------------------------------
    }//===================================================================
}