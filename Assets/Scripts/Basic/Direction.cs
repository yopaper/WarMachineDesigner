using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WMD.Basic{
     public enum Direction
    {
        Null=5, Up=1, Down=3, Left=2, Right=0
    }//============================================================================
    public static class DirectionHandler{
        private static Dictionary<Direction, int> degreeTable = 
        new Dictionary<Direction, int>(){
            {Direction.Up, 90}, {Direction.Down, 270}, {Direction.Right, 0}, {Direction.Left, 180}
        };//----------------------------------------------------------------
        private static Dictionary<Direction, float> radianTable =
        new Dictionary<Direction, float>(){
            {Direction.Up, DegreeToRadian(90)}, {Direction.Down, DegreeToRadian(270)},
            {Direction.Right, DegreeToRadian(0)}, {Direction.Left, DegreeToRadian(180)},
        };//-----------------------------------------------------
        private static Dictionary<Direction, Vector2> vectorTable =
        new Dictionary<Direction, Vector2>(){
            {Direction.Null, new Vector2(0, 0)},
            {Direction.Up, RadianToVector( DirectionToRadian(Direction.Up).Value )},
            {Direction.Down, RadianToVector( DirectionToRadian(Direction.Down).Value )},
            {Direction.Right, RadianToVector( DirectionToRadian(Direction.Right).Value )},
            {Direction.Left, RadianToVector( DirectionToRadian(Direction.Left).Value )},
        };//-----------------------------------------------------
        private const int  MaxDirectionId = (int)Direction.Down;
        
        public static Direction TurnDirection( Direction direction, int delta ){
            return (Direction)( ( (int)direction+delta ) % MaxDirectionId );
        }
        //--------------------------------------------------
        public static Direction TurnRight( Direction direction ){
            return TurnDirection( direction, -1 );
        }
        //---------------------------------------------------
        public static Direction TurnLeft( Direction direction ){
            return TurnDirection( direction, 1 );
        }
        //---------------------------------------------------
        public static Direction Reverse( Direction direction ){
            return TurnDirection( direction, 2 );
        }
        //---------------------------------------------------
        public static int DirectionToDegree(Direction direction){
            return degreeTable[direction];
        }
        //----------------------------------------------------
        public static float DegreeToRadian(float degree){
            return degree / 180.0f * Mathf.PI;
        }
        //----------------------------------------------------
        public static float? DirectionToRadian(Direction direction){
            if( direction != Direction.Null )
                return radianTable[ direction ];
            return null;
        }
        //----------------------------------------------------
        public static Vector2 RadianToVector( float radian ){
            return new Vector2( Mathf.Cos(radian), Mathf.Sin(radian) );
        }
        //----------------------------------------------------
        public static Vector2 DirectionToVector( Direction direction ){
            return vectorTable[ direction ];
        }
    }//===============================================================================
}
