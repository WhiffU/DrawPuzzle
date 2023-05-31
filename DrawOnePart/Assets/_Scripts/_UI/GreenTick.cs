using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Spine.Unity;
using UnityEngine.UI;

public class GreenTick : MonoBehaviour
{
    public AnimationReferenceAsset startAnim;
    public AnimationReferenceAsset loopAnim;
    public SkeletonGraphic skeletonGraphic;

    private void OnEnable()
    {
        SetSkeletonAnim();
    }

    private void SetSkeletonAnim()
    {
        var skeletonGraphic = GetComponent<SkeletonGraphic>();
        skeletonGraphic.AnimationState.SetAnimation(1, startAnim, false);
        skeletonGraphic.AnimationState.SetAnimation(2, loopAnim, true);
    }
}