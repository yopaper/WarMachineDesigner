using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Basic;

namespace WMD.VehicelsComponents
{
    public abstract class BasicComponentTransform
    {
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

            }//......................................................
            BlockPositionsOffset = BlockPositionOffsetSource;
            RootPositionsOffset = RootPositionsOffsetSource;
            BuildablePositionsOffset = BuildablePositionsOffsetSource;
            CheckOffset();
        }//----------------------------------------------------------------
        protected Vector2Int[] GetOccupiedPositions()
        {
            
        }//-----------------------------------------------------------------
        
    }//=================================================================================
}