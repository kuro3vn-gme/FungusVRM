using System.Collections.Generic;
using UnityEngine;
using VRM;

namespace Fungus.VRM
{
    [CommandInfo("VRM", 
                 "Set VRM Blend Shape", 
                 "Set blend shape value.")]
    [AddComponentMenu("")]
    public class SetVRMBlendShape : Command 
    {
        [Tooltip("VRM Blend Shape Proxy")]
        [SerializeField] protected VRMBlendShapeProxyData vrmBlendShapeProxy = new VRMBlendShapeProxyData();

        [Tooltip("Blend Shape")]
        [SerializeField] protected List<BlendShapeInfo> blendShape = new List<BlendShapeInfo>();

        #region Public members

        public override void OnEnter ()
        {
            if (vrmBlendShapeProxy.Value != null)
            {
                foreach (var bs in blendShape)
                {
                    vrmBlendShapeProxy.Value.AccumulateValue(BlendShapeKey.CreateFromPreset(bs.preset), bs.value.Value);
                }
                vrmBlendShapeProxy.Value.Apply();
            }
            Continue();
        }

        public override string GetSummary()
        {
            if (vrmBlendShapeProxy.Value == null)
			{
                return "Error: No BlendShapeProxy selected";
			}
            var sb = new System.Text.StringBuilder();
            sb.Append(vrmBlendShapeProxy.Value.name);
            foreach(var bs in blendShape)
			{
                sb.Append(" (");
                sb.Append(bs.preset.ToString());
                sb.Append(" : ");
                sb.Append(bs.value.Value.ToString());
                sb.Append(") ");
			}
            return sb.ToString();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

		public override bool HasReference(Variable variable)
		{
            if (base.HasReference(variable)) return true;
            if (vrmBlendShapeProxy.vRMBlendShapeProxyRef == variable) return true;
            foreach(var bs in blendShape)
			{
                if (bs.value.floatRef == variable) return true;
			}
            return false;
		}

        #endregion

        [System.Serializable]
        public struct BlendShapeInfo
        {
            [Tooltip("Blend Shape Preset")]
            [SerializeField] public BlendShapePreset preset;

            [Tooltip("Value")]
            [SerializeField] public FloatData value;
        }
    }
}