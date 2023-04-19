using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.Basic;

namespace WMD.VehicelsComponents{
    public class ShipRotatableComponentTransform : RotatableComponentTransform
    {
        public override float SingleBlockSize => ShipComponentSize;
        //--------------------------------------------------------------------
        public ShipRotatableComponentTransform( Vector3Int anchorPoint, Direction direction,
            Vector2Int[] rootOffset, Vector2Int[] blockOffset, Vector2Int[] buildableOffset
        ):base( anchorPoint, direction, rootOffset, blockOffset, buildableOffset ) {}
    }//==========================================================================

    public class ShipNoDirectionComponentTransform : NoDirectionComponentTransform{
        public override float SingleBlockSize => ShipComponentSize;
        //----------------------------------------------------------------------
        public ShipNoDirectionComponentTransform( Vector3Int anchorPoint,
            Vector2Int[] rootOffset, Vector2Int[] blockOffset, Vector2Int[] buildableOffset
        ):base( anchorPoint, rootOffset, blockOffset, buildableOffset ) {}
    }//=================================================================
}