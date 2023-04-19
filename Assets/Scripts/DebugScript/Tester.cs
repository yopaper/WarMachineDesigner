using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WMD.VehicelsComponents;
using WMD.Basic;

namespace WMD.DebugFunction{
    public class Tester : MonoBehaviour
    {
        protected ShipRotatableComponentTransform srct;
        void Start()
        {
            srct = new ShipRotatableComponentTransform(
                new Vector3Int(0, 0, 0), Direction.Up,
                new Vector2Int[]{ new Vector2Int(0, 0), new Vector2Int(1, 0),
                new Vector2Int(0, 1), new Vector2Int(0, -1) },
                new Vector2Int[]{ new Vector2Int(2, 0) }, new Vector2Int[]{}
            );
        }//--------------------------------------------------------------
        void Update()
        {
            ComponentTransformDebug.DrawTransformRect( srct );
        }//--------------------------------------------------------------
    }
}