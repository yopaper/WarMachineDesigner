using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Basic;

namespace WMD.VehicelsComponents
{
    public abstract class ComponentTransform
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
        // 中心座標
        public Vector2 CenterPosition { get; protected set; }
        // 座標位移.......................................................
        public Vector2Int[] OccupiedPositionsOffset {get; protected set;}
        public Vector2Int[] RootPositionsOffset {get; protected set;}
        public Vector2Int[] BlockPositionsOffset{get; protected set;}
        public Vector2Int[] BuildablePositionsOffset{get; protected set;}
        // 索引座標........................................................
        public Vector2Int[] OccupiedIndex {get; protected set;}
        public Vector2Int[] RootIndex {get; protected set;}
        public Vector2Int[] BlockIndex {get; protected set;}
        public Vector2Int[] BuildableIndex {get; protected set;}
        //-----------------------------------------------------------------
        // 建構子
        public ComponentTransform(
            Vector2Int[] rootOffset, Vector2Int[] blockOffset, Vector2Int[] buildableOffset ){
            RootPositionsOffset = rootOffset;
            BlockPositionsOffset = blockOffset;
            BuildablePositionsOffset = buildableOffset;
            CheckOffset();
        }
        //------------------------------------------------------------------
        // 檢查位移量是否合法
        protected void CheckOffset(){
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
        }//---------------------------------------------------------------------
        // 把一個位移陣列轉換成索引陣列
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