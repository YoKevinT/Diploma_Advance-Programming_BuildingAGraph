using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;

    [Range(10, 100)]
    public int resolution = 10;

    Transform[] points;

    void Awake()
    {
        // Divide by 2 the resolution for the scale size
        float step = 2f / resolution;

        // Change the full scale size
        Vector3 scale = Vector3.one * step;

        Vector3 position;
        position.y = 0f;
        position.z = 0f;
        points = new Transform[resolution];

        // Number of times (resolution) that is going to happen in a loop
        // i++ means i += 1
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            // Change x position so is next to each other
            position.x = (i + 0.5f) * step - 1f;
            // Define position as local
            point.localPosition = position;
            // Change the full scale, in this case divided by 5
            point.localScale = scale;
            // Set the Empty Game Object as the parent
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            // Change y position
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            point.localPosition = position;
        }
    }
}