using UnityEngine;
using VRM;
using Fungus;

namespace FungusExtensions.VRM
{
	[VariableInfo("VRM", nameof(VRMLookAtHead))]
	[AddComponentMenu("")]
	[System.Serializable]
	public class VRMLookAtHeadVariable : VariableBase<VRMLookAtHead> { }

	[System.Serializable]
	public struct VRMLookAtHeadData
	{
		[SerializeField]
		[VariableProperty("<Value>", typeof(VRMLookAtHeadVariable))]
		public VRMLookAtHeadVariable vRMLookAtHeadRef;

		[SerializeField]
		public VRMLookAtHead vRMLookAtHeadVal;

		public static implicit operator VRMLookAtHead(VRMLookAtHeadData vRMLookAtHeadData)
		{
			return vRMLookAtHeadData.Value;
		}

		public VRMLookAtHeadData(VRMLookAtHead v)
		{
			vRMLookAtHeadVal = v;
			vRMLookAtHeadRef = null;
		}

		public VRMLookAtHead Value
		{
			get { return (vRMLookAtHeadRef == null) ? vRMLookAtHeadVal : vRMLookAtHeadRef.Value; }
			set { if (vRMLookAtHeadRef == null) { vRMLookAtHeadVal = value; } else { vRMLookAtHeadRef.Value = value; } }
		}

		public string GetDescription()
		{
			if (vRMLookAtHeadRef == null)
			{
				return vRMLookAtHeadVal != null ? vRMLookAtHeadVal.ToString() : "Null";
			}
			else
			{
				return vRMLookAtHeadRef.Key;
			}
		}
	}
}