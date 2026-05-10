using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAudioWwise : MonoBehaviour
{
    [Header("Spline")]
    private Vector3[] splinePoints;
    private int splineCount;
    public bool debug_drawSpline = true;

    [Header("Audio")]
    public AK.Wwise.Event waterLoopPlayEvent;
    public AK.Wwise.Event waterLoopStopEvent;
    public Transform playerTransform;

    // The emitter GameObject that will move along the spline
    private GameObject audioEmitter;

    private void Start()  // ← was lowercase 'start()' — Unity wouldn't call it
    {
        splineCount = transform.childCount;
        splinePoints = new Vector3[splineCount];

        for (int i = 0; i < splineCount; i++)
        {
            splinePoints[i] = transform.GetChild(i).position;
        }

        // Auto-find player if not assigned
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) playerTransform = player.transform;
        }

        // Create the audio emitter and start the water loop on it
        audioEmitter = new GameObject("WaterAudioEmitter");
        audioEmitter.AddComponent<AkGameObj>();
        waterLoopPlayEvent.Post(audioEmitter);
    }

    private void Update()
    {
        if (splineCount < 2 || playerTransform == null) return;

        // Find the closest point on the spline to the player
        Vector3 closestPoint = GetClosestPointOnSpline(playerTransform.position);

        // Move the audio emitter to that point
        audioEmitter.transform.position = closestPoint;

        // Debug draw
        if (debug_drawSpline)
        {
            for (int i = 0; i < splineCount - 1; i++)  // ← was 'i < splineCount' causing IndexOutOfRange
            {
                Debug.DrawLine(splinePoints[i], splinePoints[i + 1], Color.green);
            }

            // Draw a sphere at the emitter position
            Debug.DrawLine(closestPoint, closestPoint + Vector3.up * 1f, Color.red);
        }
    }

    private void OnDestroy()
    {
        if (audioEmitter != null)
        {
            waterLoopStopEvent.Post(audioEmitter);
            Destroy(audioEmitter);
        }
    }

    /// <summary>
    /// Iterates over each spline segment and returns the closest point on the whole spline.
    /// </summary>
    private Vector3 GetClosestPointOnSpline(Vector3 targetPosition)
    {
        Vector3 closestPoint = splinePoints[0];
        float closestDistSq = float.MaxValue;

        for (int i = 0; i < splineCount - 1; i++)
        {
            Vector3 candidate = GetClosestPointOnSegment(targetPosition, splinePoints[i], splinePoints[i + 1]);
            float distSq = (candidate - targetPosition).sqrMagnitude;

            if (distSq < closestDistSq)
            {
                closestDistSq = distSq;
                closestPoint = candidate;
            }
        }

        return closestPoint;
    }

    /// <summary>
    /// Projects a point onto a line segment and clamps it between A and B.
    /// </summary>
    private Vector3 GetClosestPointOnSegment(Vector3 point, Vector3 a, Vector3 b)
    {
        Vector3 ab = b - a;
        float t = Vector3.Dot(point - a, ab) / Vector3.Dot(ab, ab);
        t = Mathf.Clamp01(t);
        return a + t * ab;
    }
    private void OnDrawGizmos()
    {
        if (!debug_drawSpline) return;

        Gizmos.color = Color.cyan;

        int count = transform.childCount;
        for (int i = 0; i < count - 1; i++)
        {
            Vector3 a = transform.GetChild(i).position;
            Vector3 b = transform.GetChild(i + 1).position;
            Gizmos.DrawLine(a, b);
            Gizmos.DrawSphere(a, 0.5f); // optional: shows each point
        }
        // Draw last point
        if (count > 0)
            Gizmos.DrawSphere(transform.GetChild(count - 1).position, 0.5f);
    }
}