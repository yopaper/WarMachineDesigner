using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Basic;

namespace WMD.VehicelsComponents{
    public abstract class NoDirectionComponentTransform : ComponentTransform
    {
        new public Direction Direction => Direction.Null;
        public NoDirectionComponentTransform(
            Vector2Int[] rootOffset, Vector2Int[] blockOffset, Vector2Int[] buildableOffset
        ):base(rootOffset, blockOffset, buildableOffset){}
        public override void Rotate(int delta) {}
        public override void SetDirection(Direction direction) {}
        public override void TurnLeft() {}
        public override void TurnRight() {}
        public override void Reverse() {}
    }//================================================================================
}