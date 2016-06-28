using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 快速移动控制 位置检测基于 xz平面
/// </summary>
public class FastMoveControl : MonoBehaviour {

    /// <summary>
    /// 碰撞事件
    /// </summary>
    public Action<GameObject> collisionEnterFun;
    /// <summary>
    /// 精度
    /// </summary>
    public float accuracy = 0.01f;

    /// <summary>
    /// 碰撞标签
    /// </summary>
    public string collisionTag = "";

    private Action<Transform> _done;
    private Transform _targetTf;

    /// <summary>
    /// 移动
    /// </summary>
    /// <param name="targetTf"></param>
    /// <param name="targetPos"></param>
    /// <param name="speed"></param>
    /// <param name="addSpeed"></param>
    /// <param name="done"></param>
    public void Move(Transform targetTf, Vector3 targetPos, float speed, float addSpeed, Action<Transform> done)
    {
        _done = done;
        _targetTf = targetTf;
        StartCoroutine(_Move(targetTf, targetPos, speed, addSpeed));
    }

    IEnumerator _Move(Transform targetTf, Vector3 targetPos, float speed, float addSpeed)
    {
        float currentTime = 0;

        while (Vector3.Distance(targetTf.position, targetPos) > accuracy)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            speed += currentTime * addSpeed;
            targetTf.position = Vector3.MoveTowards(targetTf.position, targetPos, Time.deltaTime * speed );
        }

        _done(targetTf);
    }

    /// <summary>
    /// 碰撞检测 一旦碰撞停止动画
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(collisionTag))
        {
            //停止携程
            StopAllCoroutines();

            if (_done != null)
            {
                _done(_targetTf);
            }

            if (collisionEnterFun != null)
            {
                collisionEnterFun(collision.gameObject);
            }
        }
       
    }
}
