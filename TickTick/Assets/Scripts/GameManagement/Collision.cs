using UnityEngine;
using System.Collections;

public class Collision {

    public static Vector2 CalculateIntersectionDepth(Rect rectA, Rect rectB)
    {
        Vector2 minDistance = new Vector2(rectA.width + rectB.width,
            rectA.height + rectB.height) / 2;
        Vector2 centerA = new Vector2(rectA.center.x, rectA.center.y);
        Vector2 centerB = new Vector2(rectB.center.x, rectB.center.y);
        Vector2 distance = centerA - centerB;
        Vector2 depth = Vector2.zero;
        if (distance.x > 0)
            depth.x = minDistance.x - distance.x;
        else
            depth.x = -minDistance.x - distance.x;
        if (distance.y > 0)
            depth.y = minDistance.y - distance.y;
        else
            depth.y = -minDistance.y - distance.y;
        return depth;
    }

    public static Rect Intersection(Rect rect1, Rect rect2)
    {
        int xmin = (int)Mathf.Max(rect1.xMin, rect2.xMin);
        int xmax = (int)Mathf.Min(rect1.xMax, rect2.xMax);
        int ymin = (int)Mathf.Max(rect1.yMin, rect2.yMin);
        int ymax = (int)Mathf.Min(rect1.yMax, rect2.yMax);
        return new Rect(xmin, ymin, xmax - xmin, ymax - ymin);
    }
}
