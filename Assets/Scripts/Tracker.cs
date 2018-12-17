using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Vuforia;
using System;

/// <summary>
/// Tracker Handler: Checks if the target is vivsible or not and handles event messages 
/// https://answers.unity.com/questions/938259/vuforia-disableenable-game-object-mesh-renderer-on.html
/// </summary>
[RequireComponent(typeof(TrackableBehaviour))]
public class Tracker : MonoBehaviour, ITrackableEventHandler
{
    /// <summary>
    /// Functions to call when object is just Tracked
    /// </summary>
    public event Action OnTrackingFound = () => { };
    /// <summary>
    /// Functions to call when object is just Lost
    /// </summary>
    public event Action OnTrackingLost = () => { };

    public UnityEvent OnTrackFound, OnTrackLost;

    private TrackableBehaviour mTrackableBehaviour;

    private void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (!mTrackableBehaviour)
        {
            Debug.LogError("Could not find the Trackable Behaviour", this);
        }
        mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    private void OnDestroy()
    {
        if (mTrackableBehaviour != null)
        {
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
        }
    }

    /// <summary>
    /// What to to when the Tracker Changes Status
    /// </summary>
    /// <param name="previousStatus">Previous Status</param>
    /// <param name="newStatus">New Status</param>
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED ||
                   newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
            OnTrackFound.Invoke();
        }
        else
        {
            OnTrackingLost();
            OnTrackLost.Invoke();
        }
    }

}
