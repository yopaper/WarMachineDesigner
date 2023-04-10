using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WMD.VehicelsComponents
{
    public enum Direction
    {
        Null=5, Up=0, Down=2, Left=3, Right=1
    }
    public class BasicComponentTransform
    {
        public Vector2Int BlockSize { get; protected set; }
        public Vector2Int BlockSizeWithDirection => GetBlockSizeWithDirection();
        public Direction Direction { get; protected set; }
        public Vector2Int BlockPosition { get; protected set; }
        public Vector2Int[] OccupiedPositions => GetOccupiedPositions();
        //-----------------------------------------------------------------
        protected Vector2Int GetBlockSizeWithDirection()
        {
            if (Direction == Direction.Right || Direction == Direction.Left)
                return new Vector2Int(BlockPosition.y, BlockPosition.x);
            return BlockPosition;
        }//-----------------------------------------------------------------
        protected Vector2Int[] GetOccupiedPositions()
        {
            List<Vector2Int> positions = new List<Vector2Int>();
            for(int x=0; x<BlockSizeWithDirection.x; x++)
            {
                for(int y=0; y<BlockSizeWithDirection.y; y++)
                {
                    positions.Add(new Vector2Int(BlockPosition.x + x, BlockPosition.y + y));
                }
            }
            return positions.ToArray();
        }//-----------------------------------------------------------------
    }
}