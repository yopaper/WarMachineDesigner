using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.VehicelsComponents;

namespace WMD.Debug {
    public static class ComponentTransformDebug
    {
        private static void DrawRect( Vector3 position, float size, Color color ){
            Vector3
            leftTop = position + new Vector3( -size, size, 0 ),
            rightTop = position + new Vector3( size, size, 0 ),
            leftBottom = position + new Vector3( -size, -size ),
            rightBottom = position + new Vector3( size, -size, 0 );
            UnityEngine.Debug.DrawLine( leftTop, rightTop, color, 0.1f );
            UnityEngine.Debug.DrawLine( rightTop, rightBottom, color, 0.1f );
            UnityEngine.Debug.DrawLine( rightBottom, leftBottom, color, 0.1f );
            UnityEngine.Debug.DrawLine( leftBottom, leftTop, color, 0.1f );
        }//--------------------------------------------------------------
        public static void DrawTransformRect( ComponentTransform transform )
		{
            void DrawRectFromArray( Vector3[] array, float rectSize, Color color ){
                for(int i=0; i<array.Length; i++){
                    DrawRect( array[i], rectSize, color );
                }
            }//.........................................................
            
		}//---------------------------------------------------------------
    }
}