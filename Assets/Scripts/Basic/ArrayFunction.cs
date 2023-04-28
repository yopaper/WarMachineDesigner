using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WMD.Basic{
    public class ArrayFunction : MonoBehaviour
    {
        public delegate void ProcessFunction<T>(T element);
        public static void ProcessArray<T>(
            T[] array, ProcessFunction<T> processFunction ){
            for(int i=0; i<array.Length; i++){
                processFunction.Invoke( array[i] );
            }
        }//-------------------------------------------------------------
        public static void ProcessList<T>(
            List<T> list, ProcessFunction<T> processFunction){
            ProcessArray<T>( list.ToArray(), processFunction );
        }//-------------------------------------------------------------
        
    }//====================================================================
}