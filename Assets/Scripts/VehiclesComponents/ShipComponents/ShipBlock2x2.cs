using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WMD.VehicelsComponents{
    public class ShipBlock2x2 : ShipComponent
    {
        public static GameObject PrefabSource => Resources.Load
        <GameObject>( ShipComponentBasicPrefabPath + "ShipBlock2x2" );
        public override ComponentScale Scale => ComponentScale.Large;
        public override bool BaseComponent => true;
        protected override VehicleComponentTransform TransformSource => new ShipNoDirectionComponentTransform(
            new Vector2Int[]{ new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(0, 1), new Vector2Int(1, 1) },
            new Vector2Int[]{},
            new Vector2Int[]{ new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(0, 1), new Vector2Int(1, 1) }
        );
        protected override VehicleComponentData DataSource => new VehicleComponentData(
            hp:0, mass:0
        );
    }
}