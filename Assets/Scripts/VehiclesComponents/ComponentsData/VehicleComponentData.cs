using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WMD.VehicelsComponents{

    public class VehicleComponentData
    {
        public enum IntDataKey{
            Mass=10,
            Hp=20, HpMax=21,
        }//--------------------------------------------------
        public enum FloatDataKey{

        }//--------------------------------------------------
        public int Mass{get; protected set;}
        public float Hp{get; protected set;}
        public int HpMax{get; protected set;}
        //---------------------------------------------------
        public VehicleComponentData(
            int hp, int mass
        ){
            Hp = hp; HpMax = hp;
            Mass = mass;
        }
        //---------------------------------------------------
        public float SetHp(float hp){
            Hp = Mathf.Min( hp, HpMax );
            return Hp;
        }//--------------------------------------------------
        public void SetHpMax(int hpMax){
            HpMax = hpMax;
            Hp = Mathf.Min( Hp, HpMax );
        }//--------------------------------------------------
    }//======================================================
}