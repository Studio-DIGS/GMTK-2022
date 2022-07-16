using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//From https://www.youtube.com/watch?v=13KrnisMf14&list=PLGXzgnKhu_mCTmg_AS66j8U7duSzcsub7&index=6

public class DrawTrajectory : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    [Range(5,50)]
    private int lineSegmentCount = 20;

    private List<Vector3> linePoints = new List<Vector3>();
    /*
    #region Singleton

    public static DrawTrajectory instance;

    private void Awake() 
    {
        instance = this;
    }

    #endregion
    */
    public void UpdateTrajectory(Vector3 _forceVector, Rigidbody _rigidBody, Vector3 _startingPoint)
    {
        Vector3 velocity = (_forceVector / _rigidBody.mass) * Time.fixedDeltaTime;

        float flightDuration = (2*velocity.y) / Physics.gravity.y;

        float stepTime = flightDuration / lineSegmentCount;

        linePoints.Clear();

        for (int i = 0; i < lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 movementVector = new Vector3(
                velocity.x * stepTimePassed,
                velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                velocity.z * stepTimePassed
            );

            linePoints.Add(-movementVector + _startingPoint);
        }

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
    }

    public void HideLine()
    {
        lineRenderer.enabled = false;
    }

    public void ShowLine()
    {
        lineRenderer.enabled = true;
    }
}
