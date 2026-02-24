using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Rendering
{
    public class ObjectLayering : MonoBehaviour
    {

        private CircleCollider2D playerBox;

        private PolygonCollider2D objectBox;
        private SortingGroup objectSortingGroup;

        // Use this for initialization
        void Start()
        {
            objectBox = GetComponentInChildren<PolygonCollider2D>();
            objectSortingGroup = GetComponent<SortingGroup>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (playerBox.bounds.center.y < objectBox.bounds.center.y)
                objectSortingGroup.sortingOrder = -1;
            else
                objectSortingGroup.sortingOrder = 1;
        }

    }
}