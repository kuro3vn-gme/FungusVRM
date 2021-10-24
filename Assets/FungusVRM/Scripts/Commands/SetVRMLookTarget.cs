using System.Collections.Generic;
using UnityEngine;
using VRM;

namespace Fungus.VRM
{
    [CommandInfo("VRM",
                 "Set VRM Look Target",
                 "Set look target.")]
    [AddComponentMenu("")]
    public class SetVRMLookTarget : Command
    {
        [Tooltip("VRM Look At Head")]
        [SerializeField] protected VRMLookAtHeadData vrmLookAtHead = new VRMLookAtHeadData();

        [Tooltip("Target Transform")]
        [SerializeField] protected TransformData target = new TransformData();

        #region Public members

        public override void OnEnter()
        {
            if (vrmLookAtHead.Value == null || target.Value == null)
            {
                Continue();
            }
            vrmLookAtHead.Value.Target = target.Value;
            Continue();
        }

        public override string GetSummary()
        {
            if (vrmLookAtHead.Value == null)
            {
                return "Error: No VRMLookAtHead selected";
            }
            if (target.Value == null)
            {
                return "Error: No Target Selected";
            }
            var sb = new System.Text.StringBuilder();
            sb.Append(vrmLookAtHead.Value.name);
            sb.Append(":");
            sb.Append(target.Value.name);
            return sb.ToString();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

        public override bool HasReference(Variable variable)
        {
            return vrmLookAtHead.vRMLookAtHeadRef == variable
                   || target.transformRef == variable
                   || base.HasReference(variable);
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