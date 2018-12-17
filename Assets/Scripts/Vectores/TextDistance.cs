using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDistance : MonoBehaviour
{

    public static TextDistance TextHandler { get; private set; }

    [SerializeField]
    private TextMeshPro distance1;

    [SerializeField]
    private TextMeshPro pos1;

    [SerializeField]
    private TextMeshPro distance2;

    [SerializeField]
    private TextMeshPro pos2;

    [SerializeField]
    private TextMeshPro distanceExtra;

    [SerializeField]
    private TextMeshPro posExtra;

    [SerializeField]
    private Transform vector1;

    private Vector3 vector1Pos = Vector3.zero;

    private float vector1Dist = 0f;

    private bool updateVector1 = false;

    [SerializeField]
    private Transform vector2;

    private Vector3 vector2Pos = Vector3.zero;

    private float vector2Dist = 0f;

    private bool updateVector2 = false;

    private Vector3 vectorExtraPos = Vector3.zero;

    private float vectorExtraDist = 0f;

    private bool vectorExtraActive = false;

    private string vectorExtraText = "Set Text Using ExtraText()";

    [SerializeField]
    private float verticalOffset = 0.3f;

    private Vector3 tmpNormal, tmpBinormal;
    public void UpdateVector1Pos()
    {
        updateVector1 = true;
    }

    public void StopUpdateVector1Pos()
    {
        updateVector1 = false;
    }

    public void UpdateVector2Pos()
    {
        updateVector2 = true;
    }

    public void StopUpdateVector2Pos()
    {
        updateVector2 = false;
    }

    private void Awake()
    {
        if (TextHandler != null && TextHandler != this)
        {
            Debug.LogError("Duplicated TextHandler", this.gameObject);
            Destroy(this);
        }
        TextHandler = this;
    }

    private void Start()
    {
        Tracker track;
        track = vector1.GetComponent<Tracker>();

        track.OnTrackingFound += UpdateVector1Pos;
        track.OnTrackingLost += StopUpdateVector1Pos;

        track = vector2.GetComponent<Tracker>();

        track.OnTrackingFound += UpdateVector2Pos;
        track.OnTrackingLost += StopUpdateVector2Pos;

        HideExtra();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (updateVector1)
        {
            vector1Pos = vector1.position;
            vector1Dist = vector1Pos.magnitude;

            TextRotation(pos1, vector1Pos);
            TextRotation(distance1, vector1Pos);

            pos1.rectTransform.position = vector1Pos;
            distance1.rectTransform.localPosition = pos1.rectTransform.localPosition / 2.0f;

            pos1.rectTransform.position += verticalOffset * pos1.rectTransform.up;
            distance1.rectTransform.position -= verticalOffset * distance1.rectTransform.up;

            pos1.text = vector1Pos.ToString("0.0");
            distance1.text = string.Format("|V1|={0}", vector1Dist.ToString("0.0"));
        }
        else
        {
            TextRotation(pos1, vector1Pos);
            TextRotation(distance1, vector1Pos);
        }

        if (updateVector2)
        {
            vector2Pos = vector2.position;
            vector2Dist = vector2Pos.magnitude;

            TextRotation(pos2, vector2Pos);
            TextRotation(distance2, vector2Pos);

            pos2.rectTransform.position = vector2Pos;
            distance2.rectTransform.localPosition = pos2.rectTransform.localPosition / 2.0f;

            pos2.rectTransform.position += verticalOffset * pos2.rectTransform.up;
            distance2.rectTransform.position -= verticalOffset * distance2.rectTransform.up;

            pos2.text = vector2Pos.ToString("0.0");
            distance2.text = string.Format("|V2|={0}", vector2Dist.ToString("0.0"));
        }
        else
        {
            TextRotation(pos2, vector2Pos);
            TextRotation(distance2, vector2Pos);
        }

        if (vectorExtraActive)
        {
            TextRotation(posExtra, vectorExtraPos);
            TextRotation(distanceExtra, vectorExtraPos);
        }

    }

    void TextRotation(TextMeshPro _text, Vector3 look)
    {
        tmpNormal = Camera.main.transform.up;
        tmpBinormal = Camera.main.transform.forward;
        Vector3.OrthoNormalize(ref look, ref tmpNormal, ref tmpBinormal);
        _text.rectTransform.forward = tmpBinormal;
        _text.rectTransform.right = look;
        _text.rectTransform.up = tmpNormal;

        /*
		Vector3 objectNormal = _text.rectTransform.rotation * Vector3.forward;
        Vector3 cameraToText = _text.rectTransform.position - Camera.main.transform.position;
		float f = Vector3.Dot (objectNormal, cameraToText);
        if (f < 0f) 
        {
            _text.rectTransform.Rotate (0f, 180f, 0f);
        }
		_text.rectTransform.Rotate (90f, 0f, 0f);
		*/
    }

    public void ShowExtra()
    {
        posExtra.gameObject.SetActive(true);
        distanceExtra.gameObject.SetActive(true);
        vectorExtraActive = true;
    }

    public void HideExtra()
    {
        posExtra.gameObject.SetActive(false);
        distanceExtra.gameObject.SetActive(false);
        vectorExtraActive = false;
    }

    public void ExtraText(string newText)
    {
        vectorExtraText = newText;
        distanceExtra.text = string.Format("|{0}|={1}", vectorExtraText, vectorExtraDist.ToString("0.0"));
    }

    public void UpdateExtraPos(Vector3 pos)
    {
        vectorExtraPos = pos;
        vectorExtraDist = vectorExtraPos.magnitude;

        TextRotation(posExtra, vectorExtraPos);
        TextRotation(distanceExtra, vectorExtraPos);

        posExtra.rectTransform.position = vectorExtraPos;
        distanceExtra.rectTransform.localPosition = posExtra.rectTransform.localPosition / 2.0f;

        posExtra.rectTransform.position += verticalOffset * posExtra.rectTransform.up;
        distanceExtra.rectTransform.position -= verticalOffset * distanceExtra.rectTransform.up;

        posExtra.text = vectorExtraPos.ToString("0.0");
        distanceExtra.text = string.Format("|{0}|={1}", vectorExtraText, vectorExtraDist.ToString("0.0"));
    }
}
