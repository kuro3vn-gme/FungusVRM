using UnityEditor;
using Fungus.EditorUtils;
using FungusExtensions.VRM;

namespace FungusExtensions.EditorUtils.VRM
{
	[CustomPropertyDrawer(typeof(VRMBlendShapeProxyData))]
	public class VRMBlendShapeProxyDataDrawer : VariableDataDrawer<VRMBlendShapeProxyVariable> { }
}