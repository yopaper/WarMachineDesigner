using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WMD.VehicelsComponents{
    public class ShipRotatableComponentTransform : RotatableComponentTransform
    {
        public override float SingleBlockSize => ShipComponentSize;
        //--------------------------------------------------------------------
        public ShipRotatableComponentTransform(
            Vector2Int[] rootOffset, Vector2Int[] blockOffset, Vector2Int[] buildableOffset
        ):base( rootOffset, blockOffset, buildableOffset ) {}
    }//==========================================================================

    public class ShipNoDirectionComponentTransform : NoDirectionComponentTransform{
        public override float SingleBlockSize => ShipComponentSize;
        //----------------------------------------------------------------------
        public ShipNoDirectionComponentTransform(
            Vector2Int[] rootOffset, Vector2Int[] blockOffset, Vector2Int[] buildableOffset
        ):base( rootOffset, blockOffset, buildableOffset ) {}
    }//=================================================================
}