using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Valve.VR.InteractionSystem;
namespace DaschowStreet
{
    public class CustomTeleportArea : TeleportMarkerBase
    {
        [Tooltip("如果勾选就是使用SteamVR本来的位移机制")]
        public bool IsUseSteamVRTeleport = false;

        //Public properties
        public Bounds meshBounds { get; private set; }

        //Private data
        private MeshRenderer areaMesh;
        private int tintColorId = 0;
        private Color visibleTintColor = Color.clear;
        private Color highlightedTintColor = Color.clear;
        private Color lockedTintColor = Color.clear;
        private bool highlighted = false;


        private void Awake()
        {

            if (IsUseSteamVRTeleport)
            {
                areaMesh = GetComponent<MeshRenderer>();
                tintColorId = Shader.PropertyToID("_TintColor");
                CalculateBounds();
            }
        }
        private void Start()
        {
            if (IsUseSteamVRTeleport)
            {
                visibleTintColor = Teleport.instance.areaVisibleMaterial.GetColor(tintColorId);
                highlightedTintColor = Teleport.instance.areaHighlightedMaterial.GetColor(tintColorId);
                lockedTintColor = Teleport.instance.areaLockedMaterial.GetColor(tintColorId);
            }

        }

        public override void Highlight(bool highlight)
        {
            if (IsUseSteamVRTeleport)
            {
                if (!locked)
                {
                    highlighted = highlight;

                    if (highlight)
                    {
                        areaMesh.material = Teleport.instance.areaHighlightedMaterial;
                    }
                    else
                    {
                        areaMesh.material = Teleport.instance.areaVisibleMaterial;
                    }
                }
            }
        }

        public override void SetAlpha(float tintAlpha, float alphaPercent)
        {
            if (IsUseSteamVRTeleport)
            {
                Color tintedColor = GetTintColor();
                tintedColor.a *= alphaPercent;
                areaMesh.material.SetColor(tintColorId, tintedColor);

            }
        }

        public override bool ShouldActivate(Vector3 playerPosition)
        {
            return true;
        }

        public override bool ShouldMovePlayer()
        {
            return true;
        }

        public override void UpdateVisuals()
        {
            if (IsUseSteamVRTeleport)
            {
                if (locked)
                {
                    areaMesh.material = Teleport.instance.areaLockedMaterial;
                }
                else
                {
                    areaMesh.material = Teleport.instance.areaVisibleMaterial;
                }
            }
        }

        private bool CalculateBounds()
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            if (meshFilter == null)
            {
                return false;
            }

            Mesh mesh = meshFilter.sharedMesh;
            if (mesh == null)
            {
                return false;
            }

            meshBounds = mesh.bounds;
            return true;
        }

        private Color GetTintColor()
        {
            if (locked)
            {
                return lockedTintColor;
            }
            else
            {
                if (highlighted)
                {
                    return highlightedTintColor;
                }
                else
                {
                    return visibleTintColor;
                }
            }
        }
    }

}
