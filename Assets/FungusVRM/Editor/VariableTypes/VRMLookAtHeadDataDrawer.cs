using UnityEditor;
using Fungus.EditorUtils;
using FungusExtensions.VRM;

namespace FungusExtensions.EditorUtils.VRM
{
	[CustomPropertyDrawer(typeof(VRMLookAtHeadData))]
	public class VRMLookAtHeadDataDrawer : VariableDataDrawer<VRMLookAtHeadVariable> { }
}