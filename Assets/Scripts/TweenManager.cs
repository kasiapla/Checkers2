using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tween
{
    public Vector3 finalPosition;
    public Vector3 speed;
    public float movementTime;
    public Transform objectToMove;
    //tutaj dodać delegate

    public void MoveObject()
    {
        if (movementTime <= 0 || objectToMove == null) return;
        objectToMove.position += speed * Time.deltaTime;
        movementTime -= Time.deltaTime;
    }
}

public class TweenManager : MonoBehaviour
{
    HashSet<Tween> tweens = new HashSet<Tween>();

    private void Awake()
    {
        GameMaster.tweenManager = this;
    }

    void Update()
    {
        if (tweens.Count > 0)
        {
            List<Tween> tweensList = tweens.ToList();
            for (int i = 0; i < tweensList.Count; i++)
            {
                if (tweensList[i].objectToMove == null || tweensList[i].movementTime <= 0)
                {
                    //tu wywołać delegate
                    tweens.Remove(tweensList[i]);
                    continue;
                }

                tweensList[i].MoveObject();
            }
        }
        else enabled = false;
    }



    public void AddToTweens(Tween tween)
    {
        if (tween.movementTime <= 0 || tween.objectToMove == null) return;
        tween.speed = (tween.finalPosition - tween.objectToMove.position) / tween.movementTime;
        enabled = true;
        tweens.Add(tween);
    }
}
