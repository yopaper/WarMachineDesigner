using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WMD.Basic;
namespace WMD.VehicelsComponents{
    public abstract class RotatableComponentTransform : ComponentTransform
    {
        // Static
        protected static Dictionary<int, int[][]> RightAngleTable
        = new Dictionary<int, int[][]>();
        //--------------------------------------------------------------
        protected static int[][] GetRightAngleMatrix(int delta){
            if( !RightAngleTable.ContainsKey( delta ) ){
                RightAngleTable[ delta ] = GetIntRotatedMatrix(
                    DirectionHandler.DegreeToRadian( delta * 90 ) );
            }
            return RightAngleTable[ delta ];
        }//-----------------------------------------------------------
        protected static float[][] GetRotatedMatrix(float radian){
            return new float[][]{
                new float[] { Mathf.Cos(radian), -Mathf.Sin(radian) },
                new float[] { Mathf.Sin(radian), Mathf.Cos(radian) },
            };
        }//--------------------------------------------------------
        protected static int[][] GetIntRotatedMatrix(float radian){
            float[][] matrix = GetRotatedMatrix( radian );
            return new int[][]{
                new int[]{ Mathf.RoundToInt(matrix[0][0]), Mathf.RoundToInt(matrix[0][1]) },
                new int[]{ Mathf.RoundToInt(matrix[1][0]), Mathf.RoundToInt(matrix[1][1]) },
            };
        }//--------------------------------------------------------
        protected static Vector2Int MultiRotatedMatrix(
            Vector2Int vector, int[][] matrix ){
            return new Vector2Int(
                vector.x * matrix[0][0] + vector.y * matrix[0][1],
                vector.x * matrix[1][0] + vector.y * matrix[1][1] );
        }//-----------------------------------------------------------
        protected static void MultiRotatedMatrix(
            Vector2Int[] vectorArray, int[][] matrix ){
            for(int i=0; i<vectorArray.Length; i++){
                vectorArray[i] = MultiRotatedMatrix( vectorArray[i], matrix );
            }
        }//-----------------------------------------------------------
        

        
        //______________________________________________________________________________________
        // Not Static
        public new Direction Direction{get; protected set;}
        //-----------------------------------------------------------------------
        public RotatableComponentTransform(
            Vector2Int[] rootOffset, Vector2Int[] blockOffset, Vector2Int[] buildableOffset 
        ):base(rootOffset, blockOffset, buildableOffset){
            this.Direction = Direction.Right;
        }
        //----------------------------------------------------------------------
        public override void SetDirection(Direction direction)
        {
            Rotate( (int)direction - (int)Direction );
        }//------------------------------------------------------------
        public override void Rotate( int delta ){
            int[][] matrix = GetRightAngleMatrix( delta );
            MultiRotatedMatrix( RootPositionsOffset, matrix );
            MultiRotatedMatrix( BlockPositionsOffset, matrix );
            MultiRotatedMatrix( BuildablePositionsOffset, matrix );
            MultiRotatedMatrix( OccupiedPositionsOffset, matrix );
            Direction = DirectionHandler.TurnDirection( Direction, delta );
            UpdateIndex();
        }//-------------------------------------------------------------
        public override void TurnRight()
        {
            Rotate(-1);
        }//-------------------------------------------------------------
        public override void TurnLeft()
        {
            Rotate(1);
        }//-------------------------------------------------------------
        public override void Reverse()
        {
            Rotate(2);
        }//-------------------------------------------------------------
    }//=================================================================
}