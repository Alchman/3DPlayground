using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour
{
    [SerializeField] float maxYValue = 0.2f;
    [SerializeField] float moveTime = 1;
    [SerializeField] float waitTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(Movement());

        /*
        Sequence movementSequence = DOTween.Sequence();
        movementSequence.AppendInterval(waitTime);
        movementSequence.Append(transform.DOMoveY(maxYValue, moveTime));
        movementSequence.AppendCallback(() => PrintUp("Up"));
        movementSequence.AppendInterval(waitTime);
        movementSequence.Append(transform.DOMoveY(0, moveTime));
        movementSequence.AppendCallback(() => 
            {
                //callback multiple strings
            }
        );
        movementSequence.SetLoops(-1);
        */

        Sequence movementSequence = DOTween.Sequence();
        movementSequence.AppendInterval(waitTime/2)
            .Append(transform.DOMoveY(maxYValue, moveTime).SetEase(Ease.InExpo))
            .AppendInterval(waitTime/2)
            .SetLoops(-1, LoopType.Yoyo);
    }

    void PrintUp(string position)
    {
        //print smth
    }

    IEnumerator Movement()
    {
        while(true)
        {
            transform.DOMoveY(maxYValue, moveTime);
            yield return new WaitForSeconds(moveTime + waitTime);
            transform.DOMoveY(0, moveTime);
            yield return new WaitForSeconds(moveTime + waitTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        cube.Die();
    }

}
