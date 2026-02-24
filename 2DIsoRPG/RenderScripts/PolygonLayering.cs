using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Rendering
{
    public class PolygonLayering : MonoBehaviour
    {

        [SerializeField]
        private CircleCollider2D playerBox;

        private PolygonCollider2D objectBox;
        private SortingGroup objectSortingGroup;
        private Vector2[] outerpoints = new Vector2[2];

        // Use this for initialization
        void Start()
        {
            objectBox = GetComponentInChildren<PolygonCollider2D>();
            objectSortingGroup = GetComponent<SortingGroup>();
            outerpoints[0] = getLeftistPoint();
            outerpoints[1] = getRightestPoint();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector2 closestpoint = getClosestPoint();
            if (playerBox.bounds.center.y < closestpoint.y)
                objectSortingGroup.sortingOrder = -1;
            else
                objectSortingGroup.sortingOrder = 1;
        }

        Vector2 getClosestPoint()
        {
            Vector2 point = new Vector2();
            for (int i = 0; i < outerpoints.Length; ++i)
            {
                if (Vector2.Distance(outerpoints[i], playerBox.bounds.center) < Vector2.Distance(point, playerBox.bounds.center))
                {
                    point = outerpoints[i];
                }
            }
            return point;
        }

        Vector2 getLeftistPoint()
        {
            Vector2 point = new Vector2();
            for (int i = 0; objectBox.points.Length > i; ++i)
            {
                if (objectBox.points[i].x + objectBox.transform.position.x < point.x + objectBox.transform.position.x)
                {
                    point = objectBox.points[i];
                }
            }
            point.x = point.x * objectBox.transform.lossyScale.x + objectBox.transform.position.x;
            point.y = point.y * objectBox.transform.lossyScale.y + objectBox.transform.position.y;
            return point;
        }

        Vector2 getRightestPoint()
        {
            Vector2 point = new Vector2();
            for (int i = 0; objectBox.points.Length > i; ++i)
            {
                if (objectBox.points[i].x + objectBox.transform.position.x > point.x + objectBox.transform.position.x)
                {
                    point = objectBox.points[i];
                }
            }
            point.x = point.x * objectBox.transform.lossyScale.x + objectBox.transform.position.x;
            point.y = point.y * objectBox.transform.lossyScale.y + objectBox.transform.position.y;
            return point;
        }
    }
}