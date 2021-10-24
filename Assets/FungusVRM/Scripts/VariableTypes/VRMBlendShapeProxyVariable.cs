using UnityEngine;
using VRM;

namespace Fungus.VRM
{
    [VariableInfo("VRM", "VRMBlendShapeProxy")]
    [AddComponentMenu("")]
    [System.Serializable]
    public class VRMBlendShapeProxyVariable : VariableBase<VRMBlendShapeProxy>
    {
    }

    [System.Serializable]
    public struct VRMBlendShapeProxyData
    {
        [SerializeField]
        [VariableProperty("<Value>", typeof(VRMBlendShapeProxyVariable))]
        public VRMBlendShapeProxyVariable vRMBlendShapeProxyRef;
        
        [SerializeField]
        public VRMBlendShapeProxy vRMBlendShapeProxyVal;

        public static implicit operator VRMBlendShapeProxy(VRMBlendShapeProxyData vRMBlendShapeProxyData)
        {
            return vRMBlendShapeProxyData.Value;
        }

        public VRMBlendShapeProxyData(VRMBlendShapeProxy v)
        {
            vRMBlendShapeProxyVal = v;
            vRMBlendShapeProxyRef = null;
        }
            
        public VRMBlendShapeProxy Value
        {
            get { return (vRMBlendShapeProxyRef == null) ? vRMBlendShapeProxyVal : vRMBlendShapeProxyRef.Value; }
            set { if (vRMBlendShapeProxyRef == null) { vRMBlendShapeProxyVal = value; } else { vRMBlendShapeProxyRef.Value = value; } }
        }

        public string GetDescription()
        {
            if (vRMBlendShapeProxyRef == null)
            {
                return vRMBlendShapeProxyVal != null ? vRMBlendShapeProxyVal.ToString() : "Null";
            }
            else
            {
                return vRMBlendShapeProxyRef.Key;
            }
        }
    }
}