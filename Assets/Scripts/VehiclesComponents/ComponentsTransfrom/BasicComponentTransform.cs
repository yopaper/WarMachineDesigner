using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Basic;

namespace WMD.VehicelsComponents
{
    public abstract class ComponentTransform
    {
        // Static
        public const float ShipComponentSize = 2f, ShipComponentHeight = 1f;
        //===================================================================
        // Not Static

        // 偶數寬度
        public bool EvenWidth => ComponentSize.x % 2 == 0;
        // 偶數長度
        public bool EvenLength => ComponentSize.y % 2 == 0;
        // 單一格子大小
        public abstract float SingleBlockSize {get;}
        // 零件大小
        public Vector3Int ComponentSize { get; protected set; }
        // 零件方向
        public Direction ComponentDirection { get; }
        // 中心座標
        public Vector3Int AnchorPoint { get; protected set; }
        // 座標位移.......................................................
        public Vector2Int[] OccupiedPositionsOffset {get; protected set;}
        public Vector2Int[] RootPositionsOffset {get; protected set;}
        public Vector2Int[] BlockPositionsOffset{get; protected set;}
        public Vector2Int[] BuildablePositionsOffset{get; protected set;}
        // 索引座標........................................................
        public Vector3Int[] OccupiedIndex {get; protected set;}
        public Vector3Int[] RootIndex {get; protected set;}
        public Vector3Int[] BlockIndex {get; protected set;}
        public Vector3Int[] BuildableIndex {get; protected set;}
        // 相對座標........................................................
        public Vector3[] OccupiedLocalPositions { get; protected set; }
        //-----------------------------------------------------------------
        // 建構子
        public ComponentTransform( Vector3Int anchorPoint,
            Vector2Int[] rootOffset, Vector2Int[] blockOffset, Vector2Int[] buildableOffset ){
            // 組成 OccupiedOffset
            void BuildOccupiedOffset(){
                List< Vector2Int > offsetList = new List<Vector2Int>();
                HashSet< Vector2Int > offsetHashTable = new HashSet<Vector2Int>();
                //........................................................
                void AddOffset( Vector2Int offset ){
                    if( offsetHashTable.Contains(offset) )return;
                    offsetHashTable.Add( offset );
                    offsetList.Add( offset );
                }
                //........................................................
                void AddOffsetFromArray( Vector2Int[] offsetArray ){
                    for( int i=0; i<offsetArray.Length; i++ ){
                        AddOffset( offsetArray[i] );
                    }
                }
                //........................................................
                AddOffsetFromArray( RootPositionsOffset );
                AddOffsetFromArray( BlockPositionsOffset );
                OccupiedPositionsOffset = offsetList.ToArray();
            }
            //............................................................
            ComponentDirection = Direction.Right;
            AnchorPoint = anchorPoint;
            RootPositionsOffset = rootOffset;
            BlockPositionsOffset = blockOffset;
            BuildablePositionsOffset = buildableOffset;
            CheckOffset();
            BuildOccupiedOffset();
            UpdateIndex();
        }
        //------------------------------------------------------------------
        // Public
        public abstract void Rotate( int delta );
        public abstract void SetDirection( Direction direction );
        public abstract void TurnRight();
        public abstract void TurnLeft();
        public abstract void Reverse();

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        // Protected
        // 更新索引座標
        protected void UpdateIndex(){
            // Offset To Index
            RootIndex = OffsetsToIndexPositions( RootPositionsOffset );
            BlockIndex = OffsetsToIndexPositions( BlockPositionsOffset );
            BuildableIndex = OffsetsToIndexPositions( BuildablePositionsOffset );
            OccupiedIndex = OffsetsToIndexPositions( OccupiedPositionsOffset );
            // Index To Local Position
            
        }//--------------------------------------------------------------------------
        // 檢查位移量是否合法
        protected void CheckOffset(){
            void CheckOffsetArray( Vector2Int[] array ){
                string exceptionMessage = "位移{0}有重複!";
                HashSet< Vector2Int > checkTable = new HashSet<Vector2Int>();
                for(int i=0; i<array.Length; i++){
                    if( checkTable.Contains( array[i] ) )
                        throw new System.Exception( string.Format( exceptionMessage, array[i] ) );
                    checkTable.Add( array[i] );
                }
            }//...................................................
            CheckOffsetArray( RootPositionsOffset );
            CheckOffsetArray( BuildablePositionsOffset );
            CheckOffsetArray( BlockPositionsOffset );
        }//---------------------------------------------------------------------
        // 把一個位移陣列轉換成索引陣列
        protected Vector3Int[] OffsetsToIndexPositions( Vector2Int[] offsets ){
            UnityEngine.Debug.Log( offsets );
            Vector3Int[] indexPositions = new Vector3Int[ offsets.Length ];
            for(int i=0; i<offsets.Length; i++){
                indexPositions[ i ] = new Vector3Int(
                    AnchorPoint.x + offsets[i].x,
                    AnchorPoint.y + offsets[i].y,
                    AnchorPoint.z
                );
            }
            return indexPositions;
        }//-----------------------------------------------------------------
        // 把索引陣列轉成相對船艦相對偏差
        protected Vector3[] IndexToLoaclPosition( Vector3Int[] indexs)
		{
            Vector3[] positionArray = new Vector3[ indexs.Length ];
            for(int i=0; i<indexs.Length; i++){
                positionArray[i] = new Vector3(
                    indexs[i].x * SingleBlockSize, indexs[i].y * SingleBlockSize );
            }
            return positionArray;
		}//----------------------------------------------------------------------------
    }//=================================================================================
}