using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WMD.VehicelsComponents{
    public class ShipTurret127x1 : ShipWeaponComponent
    {
        public static GameObject PrefabSource => Resources.Load
        <GameObject>( ShipComponentBasicPrefabPath + "ShipTurret127x1" );

        public override bool BaseComponent => false;
        public override ComponentScale Scale => ComponentScale.Medium;
        protected override VehicleComponentTransform TransformSource => new ShipNoDirectionComponentTransform(
            new Vector2Int[]{
                new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(-1, 0),
                new Vector2Int(0, -1), new Vector2Int(1, -1), new Vector2Int(-1, -1),
                new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(-1, 1) },
            new Vector2Int[]{new Vector2Int(2, 0), new Vector2Int(3, 0)},
            new Vector2Int[]{}
        );
        protected override VehicleComponentData DataSource => new VehicleComponentData(
            hp:0, mass:108
        );
        protected override WeaponRotator RotatorSource => new WeaponRotator(this);
    }//============================================================================
}