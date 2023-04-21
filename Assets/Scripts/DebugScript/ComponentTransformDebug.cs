using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.VehicelsComponents;

namespace WMD.DebugFunction {
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
        public static void DrawTransformRect( VehicleComponentTransform transform )
		{
            void DrawRectFromArray( Vector3[] array, float rectSize, Color color ){
                for(int i=0; i<array.Length; i++){
                    DrawRect( array[i], rectSize, color );
                }
            }//.........................................................
            DrawRectFromArray( transform.OccupiedLocalPositions,
            transform.SingleBlockSize/2.1f, new Color(1f, 0f, 0f) );
            DrawRectFromArray( transform.RootLocalPositions,
            transform.SingleBlockSize/2.3f, new Color(0f, 1f, 0f) );
            DrawRectFromArray( transform.BlockLocakPositions,
            transform.SingleBlockSize/2.5f, new Color(0f, 1f, 1f) );
            DrawRect( transform.CenterPoint, transform.SingleBlockSize/3f, new Color(1f, 1f, 1f) );
		}//---------------------------------------------------------------
    }//====================================================================
}