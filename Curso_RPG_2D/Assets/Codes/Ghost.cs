using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject ghost;
    public float ghostDelay;
    public Vector3 position;
    public Quaternion rotation;
    
    private float ghostDelaySeconds;
    public bool makeFirtsGhost = false;
    public bool makeGhost = false;

    // Start is called before the first frame update
    void Start()
    {
        ghostDelaySeconds = ghostDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(makeGhost)
        {
            if(!makeFirtsGhost){
                GameObject currentGhost1 = Instantiate(ghost, position, rotation);
                updateSprites(currentGhost1);
                Destroy(currentGhost1, 0.5f);
                makeFirtsGhost = true;
            }

            if(ghostDelaySeconds > 0)
            {
                ghostDelaySeconds -=Time.deltaTime;
            }else{
                GameObject currentGhost = Instantiate(ghost, 
                                    transform.position, transform.rotation);
                updateSprites(currentGhost);
                ghostDelaySeconds = ghostDelay;
                Destroy(currentGhost, 0.5f);
            }
        }
    }

    public void updateSprites(GameObject obj)
    {
        updateHead(obj);

        /* Update sprite da da Base dos olhos */
        Sprite currentBaseEyesSprite = 
                    transform.GetChild(0).
                    transform.GetChild(0).
                    gameObject.GetComponent<SpriteRenderer>().sprite;

        bool visible = 
                    transform.GetChild(0).
                    transform.GetChild(0).
                    gameObject.GetComponent<SpriteRenderer>().isVisible;

        updateArmsAndLegs(obj, 0, 0);

        obj.transform.GetChild(0).
            transform.GetChild(0).
            gameObject.GetComponent<SpriteRenderer>().sprite = currentBaseEyesSprite;

        obj.transform.GetChild(0).
            transform.GetChild(0).
            gameObject.SetActive(visible);

        /* Update sprite dos olhos 
        Sprite currentLeftEyeSprite = 
                    transform.GetChild(0).
                    transform.GetChild(0).
                    transform.GetChild(0).
                    gameObject.GetComponent<SpriteRenderer>().sprite;

        ghost.transform.GetChild(0).
            transform.GetChild(0).
            transform.GetChild(0).
            gameObject.GetComponent<SpriteRenderer>().sprite = currentLeftEyeSprite;

        Sprite currentRightEyeSprite = 
                    transform.GetChild(0).
                    transform.GetChild(0).
                    transform.GetChild(1).
                    gameObject.GetComponent<SpriteRenderer>().sprite;

        ghost.transform.GetChild(0).
            transform.GetChild(0).
            transform.GetChild(1).
            gameObject.GetComponent<SpriteRenderer>().sprite = currentRightEyeSprite;*/


        updateArmsAndLegs(obj, 2, 0);
        updateArmsAndLegs(obj, 2, 1);
        updateArmsAndLegs(obj, 3, 0);
        updateArmsAndLegs(obj, 3, 1);

        updateSword(obj);
    }

    public void updateHead(GameObject obj1)
    {
        /* Update sprite da cabeça */
        Sprite currentHeadSprite = 
                    transform.GetChild(0).
                    gameObject.GetComponent<SpriteRenderer>().sprite;

        obj1.transform.GetChild(0).
            gameObject.GetComponent<SpriteRenderer>().sprite = currentHeadSprite;

        /*Transform pos = transform.GetChild(0).
                GetComponent<Transform>();

        obj1.transform.GetChild(0).gameObject.transform.localPosition = pos.localPosition;

        obj1.transform.GetChild(0).
            gameObject.transform.rotation = pos.rotation;

        obj1.transform.GetChild(0).
            gameObject.transform.localScale = pos.localScale;*/

        int order = transform.GetChild(0).
            gameObject.GetComponent<SpriteRenderer>().sortingOrder;

        obj1.transform.GetChild(0).
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = order;
    }

    public void updateArmsAndLegs(GameObject obj2, int indexPai, int indexFilho)
    {
        Transform pos = transform.GetChild(indexPai).
            transform.GetChild(indexFilho).GetComponent<Transform>();

        obj2.transform.GetChild(indexPai).
            transform.GetChild(indexFilho).transform.localPosition = pos.localPosition;

        obj2.transform.GetChild(indexPai).
            transform.GetChild(indexFilho).
            gameObject.transform.rotation = pos.rotation;

        obj2.transform.GetChild(indexPai).
            transform.GetChild(indexFilho).
            gameObject.transform.localScale = pos.localScale;

        int order = transform.GetChild(indexPai).
            transform.GetChild(indexFilho).
            gameObject.GetComponent<SpriteRenderer>().sortingOrder;

        obj2.transform.GetChild(indexPai).
            transform.GetChild(indexFilho).
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = order;
    }

    public void updateSword(GameObject obj3)
    {
        int order = transform.GetChild(5).
            gameObject.GetComponent<SpriteRenderer>().sortingOrder;

        obj3.transform.GetChild(5).
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = order;

        Transform pos = transform.GetChild(5).
                GetComponent<Transform>();

        obj3.transform.GetChild(5).gameObject.transform.localPosition = pos.localPosition;

        obj3.transform.GetChild(5).
            gameObject.transform.rotation = pos.rotation;

        obj3.transform.GetChild(5).
            gameObject.transform.localScale = pos.localScale;
    }
}
