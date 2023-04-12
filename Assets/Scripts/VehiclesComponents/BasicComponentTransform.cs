using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Basic;

namespace WMD.VehicelsComponents
{
    public abstract class BasicComponentTransform
    {
        // Static

        //===================================================================
        // Not Static

        // 偶數寬度
        public bool EvenWidth => BlockSize.x % 2 == 0;
        // 偶數長度
        public bool EvenLength => BlockSize.y % 2 == 0;
        // 零件大小
        public Vector2Int BlockSize { get; protected set; }
        // 零件方向
        public Direction Direction { get; protected set; }
        public Vector2 CenterPosition { get; protected set; }
        public Vector2Int[] OccupiedPositionsOffset {get; protected set;}
        public Vector2Int[] RootPositionsOffset {get; protected set;}
        public Vector2Int[] BlockPositionsOffset{get; protected set;}
        public Vector2Int[] BuildablePositionsOffset{get; protected set;}
        public Vector2Int[] OccupiedPositions => GetOccupiedPositions();
        //................................................
        protected abstract Vector2Int[] BuildablePositionsOffsetSource {get;}
        protected abstract Vector2Int[] RootPositionsOffsetSource {get;}
        protected abstract Vector2Int[] BlockPositionOffsetSource {get;}
        //-----------------------------------------------------------------
        protected void LoadOffsetSource(){
            void CheckOffset(){
                void CheckOffsetArray( Vector2Int[] array ){
                    string exceptionMessage = "長或寬為偶數時, 位移量不可為零!";
                    for(int i=0; i<array.Length; i++){
                        if( (EvenWidth && array[i].x==0)||(EvenLength && array[i].y==0) )
                            throw new System.Exception(exceptionMessage);
                    }
                }//...................................................
                if( !EvenWidth && !EvenLength )return;
                CheckOffsetArray( RootPositionsOffset );
                CheckOffsetArray( BuildablePositionsOffset );
                CheckOffsetArray( BlockPositionsOffset );
            }//......................................................
            BlockPositionsOffset = BlockPositionOffsetSource;
            RootPositionsOffset = RootPositionsOffsetSource;
            BuildablePositionsOffset = BuildablePositionsOffsetSource;
            CheckOffset();
        }//----------------------------------------------------------------
        protected Vector2Int[] GetOccupiedPositions()
        {
            
        }//-----------------------------------------------------------------
        protected Vector2Int[] OffsetsToIndexPositions( Vector2Int[] offsets ){
            List< Vector2Int > indexPositions = new List<Vector2Int>();
            for(int i=0; i<offsets.Length; i++){
                Vector2 currentOffset = offsets[i];
                Vector2 offsetDelta = new Vector2(
                    ( EvenWidth )? -currentOffset.x /Mathf.Abs(currentOffset.x) /2f:0,
                    ( EvenLength )? -currentOffset.y /Mathf.Abs(currentOffset.y) /2f:0
                );
                indexPositions.Add( new Vector2Int(
                    Mathf.RoundToInt(CenterPosition.x + currentOffset.x + offsetDelta.x),
                    Mathf.RoundToInt(CenterPosition.y + currentOffset.y + offsetDelta.y)
                ) );
            }
            return indexPositions.ToArray();
        }//-----------------------------------------------------------------
    }//=================================================================================
}