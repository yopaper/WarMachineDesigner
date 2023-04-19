using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Basic;

namespace WMD.VehicelsComponents{
    public abstract class NoDirectionComponentTransform : ComponentTransform
    {
        new public Direction ComponentDirection => Direction.Null;
        public NoDirectionComponentTransform( Vector3Int anchorPoint,
            Vector2Int[] rootOffset, Vector2Int[] blockOffset, Vector2Int[] buildableOffset
        ):base(anchorPoint, rootOffset, blockOffset, buildableOffset){}
        public override void Rotate(int delta) {}
        public override void SetDirection(Direction direction) {}
        public override void TurnLeft() {}
        public override void TurnRight() {}
        public override void Reverse() {}
    }//================================================================================
}