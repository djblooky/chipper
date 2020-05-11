using UnityEngine;
using Vector3 = UnityEngine.Vector3;

enum State { Incrementing, Decrementing, StoppedByHit, Disabled };

public class SwingForceMeter : MonoBehaviour
{
    HitBall hitBall;
    LineRenderer lineBackground;
    LineRenderer lineRenderer;

    float lineHeight;
    float scaleInterval = 0.05f;
    State meterState;

    void Start()
    {
        SetUpComponents();
        HideMeter();
    }

    void SetUpComponents()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineBackground = GetComponentsInChildren<LineRenderer>()[1];
        hitBall = GetComponentInParent<HitBall>();
    }

    void Update()
    {
        UpdateMeterState();
        AnimateMeterBasedOnState();
    }

    void UpdateMeterState()
    {
        if (Input.GetMouseButton(0)) //hold mouse button to begin swing a
        {
            ShowMeter();
            GetLineHeight();

            if (hitBall.wasHit && meterState != State.StoppedByHit) //if ball has been hit on this swing
            {
                hitBall.HitForce *= lineHeight; //scale force based on line height
                meterState = State.StoppedByHit;
            }

            if (lineHeight >= 1 && !hitBall.wasHit)
            {
                meterState = State.Decrementing;

            }
            if (lineHeight <= 0 && !hitBall.wasHit)
            {
                meterState = State.Incrementing;
            }

        }
        else //if mouse is not down
        {
            HideMeter();
        }
    }

    void GetLineHeight()
    {
        lineHeight = lineRenderer.GetPosition(1).z;
    }

    void SetLineHeight()
    {
        lineRenderer.SetPosition(1, new Vector3(lineRenderer.GetPosition(1).x, lineRenderer.GetPosition(1).y, lineHeight));
    }

    void AnimateMeterBasedOnState()
    {
        switch (meterState)
        {
            case State.Incrementing:
                IncrementMeter();
                break;
            case State.Decrementing:
                DecrementMeter();
                break;
            case State.StoppedByHit: 
                if(lineHeight > 0.8)
                    lineRenderer.endColor = Color.red;
                else if(lineHeight > 0.5)
                    lineRenderer.endColor = new Color(255, 165, 0); //orange
                else if (lineHeight < 0.3)
                    lineRenderer.endColor = Color.green;
                else if (lineHeight < 0.5)
                    lineRenderer.endColor = Color.yellow;
                break;
            case State.Disabled:
                lineHeight = 0; SetLineHeight();
                break;
        }
    }

    void IncrementMeter()
    {
        lineHeight += scaleInterval;
        SetLineHeight();
    }

    void DecrementMeter()
    {
        lineHeight -= scaleInterval;
        SetLineHeight();
    }

    private void ShowMeter()
    {
        lineRenderer.endColor = Color.green;
        lineRenderer.enabled = true;
        lineBackground.enabled = true;
    }

    private void HideMeter()
    {
        meterState = State.Disabled;
        lineRenderer.enabled = false;
        lineBackground.enabled = false;
    }
}
