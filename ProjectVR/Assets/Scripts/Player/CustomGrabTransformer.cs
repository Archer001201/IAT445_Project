using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class CustomGrabTransformer : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Transform controllerTransform;
    private bool isLeftHand;  // 判断是否是左手控制器
    private Vector3 offset;
    private Quaternion customRotation;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // 订阅抓取事件
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // 获取控制器的Transform
        controllerTransform = args.interactorObject.transform;

        // 判断是左手还是右手抓取
        isLeftHand = controllerTransform.name.ToLower().Contains("left");

        // 根据控制器决定偏移
        if (isLeftHand)
        {
            // 左手控制器，物体在右边1厘米
            offset = new Vector3(0.01f, 0, 0);
        }
        else
        {
            // 右手控制器，物体在左边1厘米
            offset = new Vector3(-0.01f, 0, 0);
        }

        // 自定义相对旋转 (Y轴旋转90度)
        customRotation = Quaternion.Euler(0, 90, 0);

        // 设置物体的初始位置和旋转
        transform.position = controllerTransform.position + controllerTransform.TransformDirection(offset);
        transform.rotation = controllerTransform.rotation * customRotation;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // 释放时，清除控制器引用
        controllerTransform = null;
    }

    void Update()
    {
        // 如果物体被抓取，持续更新物体的位置和旋转
        if (grabInteractable.isSelected && controllerTransform != null)
        {
            // 保持相对位置和旋转
            transform.position = controllerTransform.position + controllerTransform.TransformDirection(offset);
            transform.rotation = controllerTransform.rotation * customRotation;  // 保持Y轴旋转90度
        }
    }

    private void OnDestroy()
    {
        // 移除事件监听，防止内存泄漏
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
