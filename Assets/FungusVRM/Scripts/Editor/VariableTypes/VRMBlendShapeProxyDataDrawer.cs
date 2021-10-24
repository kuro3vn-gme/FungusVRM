using UnityEditor;
using Fungus.VRM;

namespace Fungus.EditorUtils.VRM
{
    [CustomPropertyDrawer(typeof(VRMBlendShapeProxyData))]
    public class VRMBlendShapeProxyDataDrawer : VariableDataDrawer<VRMBlendShapeProxyVariable>
    { }
}