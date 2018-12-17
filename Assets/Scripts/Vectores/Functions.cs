using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour {

    private LineRenderer line;
    public float counter;
    public float dist;

    public Transform origin;
    public Transform v1;
    public Transform v2;

    public float line_speed = 6f;

    public float v1prev;

    public float v2prev;

    public float v1actual;

    public float v2actual;

    public bool centerdetected = false;

    public bool v1detected = false;

    public bool v2detected = false;

    public bool clear = false;

    public bool distinct = false;

    //Tests
    [SerializeField]
    public GameObject prefab;
    public bool flechazo = true;
    GameObject go;
    //Vector3 movePosition = new Vector3(10f, 10f, 10f);
    float arrow_speed = 25f;
    //End Tests

    // Booleans for Function
    public bool sumabool = false;
    public bool restabool = false;
    public bool cruzbool = false;
    public bool puntobool = false;

    public void centerdetectedfunc()
    {
        centerdetected = true;
    }

    public void v1detectedfunc()
    {
        v1detected = true;
    }

    public void v1undetectedfunc()
    {
        v1detected = false;
    }

    public void v2detectedfunc()
    {
        v2detected = true;
    }

    public void v2undetectedfunc()
    {
        v2detected = false;
    }

    public void clearfunc()
    {
        clear = true;
        sumabool = false;
        restabool = false;
        cruzbool = false;
        puntobool = false;
    }

    public void sumafunc()
    {
        if (sumabool)
        {
            sumabool = false;
        }
        else
        {
            sumabool = true;
            clear = true;
            restabool = false;
            cruzbool = false;
            puntobool = false;
        }


    }

    public void restafunc()
    {
        if (restabool)
        {
            restabool = false;
        }
        else
        {
            restabool = true;
            clear = true;
            sumabool = false;
            cruzbool = false;
            puntobool = false;
        }
    }

    public void puntofunc()
    {
        if (puntobool)
        {
            puntobool = false;
        }
        else
        {
            puntobool = true;
            clear = true;
            sumabool = false;
            restabool = false;
            cruzbool = false;
        }
    }

    public void cruzfunc()
    {
        if (cruzbool)
        {
            cruzbool = false;
        }
        else
        {
            cruzbool = true;
            clear = true;
            sumabool = false;
            restabool = false;
            puntobool = false;
        }
    }

    public Vector3 value;
    public float f;
    // Tracker Functions
    public bool alldetected;
    public bool textput;

    // Use this for initialization
    void Start () {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, origin.position);
        line.startWidth = 0;
        line.endWidth = 0;
        v1prev = 0;
        v2prev = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (v1detected && centerdetected && v2detected)
        {
            alldetected = true;
        }


        if (alldetected)
        {

            if (flechazo)
            {

                go = Instantiate(prefab, origin.position, Quaternion.identity) as GameObject;
                go.transform.parent = origin.transform;
                go.transform.LookAt(origin);
                flechazo = false;
                go.SetActive(false);
            }

            if (clear)
            {
                line.startWidth = 0;
                line.endWidth = 0;
                counter = 0;
                clear = false;
                go.transform.position = origin.position;
                go.SetActive(false);
                TextDistance.TextHandler.HideExtra();
                textput = false;
            }

            if (sumabool)
            {

                line.startWidth = 0.45f;
                line.endWidth = 0.45f;
                value = v1.position + v2.position;
                dist = Vector3.Distance(origin.position, value);
                go.SetActive(true);
                TextDistance.TextHandler.ShowExtra();
                if (textput == false)
                {
                    TextDistance.TextHandler.ExtraText("V1 + V2");
                    TextDistance.TextHandler.UpdateExtraPos(value);
                    textput = true;
                }


                if (counter < dist)
                {
                    counter += 0.1f / line_speed;

                    float x = Mathf.Lerp(0, dist, counter);

                    Vector3 pointA = origin.position;
                    //Vector3 pointB = v1.position + v2.position;
                    Vector3 pointB = origin.InverseTransformPoint(value);
                    //Vector3 pointB = destination.InverseTransformPoint(origin.position).position;

                    Vector3 pointLine = x * Vector3.Normalize(pointB - pointA) + pointA;

                    line.SetPosition(1, pointLine);

                    /*
                    if (flechazo)
                    {

                        go = Instantiate(prefab, v1.position + v2.position, Quaternion.identity) as GameObject;
                        go.transform.LookAt(origin);
                        flechazo = false;
                    }
                    */
                    //TextDistance.TextHandler.UpdateExtraPos(v1.position + v2.position);

                    if (go.transform.position != value)
                    {
                        Vector3 newPos = Vector3.MoveTowards(go.transform.position, value, arrow_speed * Time.deltaTime);
                        go.transform.position = newPos;
                        go.transform.LookAt(origin);
                        textput = false;
                        arrow_speed = arrow_speed + 1f;
                    }
                    else
                    {
                        arrow_speed = 25f;
                    }

                }

                if ((counter > dist) && distinct)
                {
                    counter = 0;
                }


            }

            if (restabool)
            {

                line.startWidth = 0.45f;
                line.endWidth = 0.45f;
                value = v1.position - v2.position;
                dist = Vector3.Distance(origin.position, value);
                go.SetActive(true);
                TextDistance.TextHandler.ShowExtra();
                if (textput == false)
                {
                    TextDistance.TextHandler.ExtraText("V1 - V2");
                    TextDistance.TextHandler.UpdateExtraPos(value);
                    textput = true;
                }

                if (counter < dist)
                {

                    counter += 0.1f / line_speed;

                    float x = Mathf.Lerp(0, dist, counter);

                    Vector3 pointA = origin.position;
                    //Vector3 pointB = v1.position + v2.position;
                    Vector3 pointB = origin.InverseTransformPoint(value);
                    //Vector3 pointB = destination.InverseTransformPoint(origin.position).position;

                    Vector3 pointLine = x * Vector3.Normalize(pointB - pointA) + pointA;

                    line.SetPosition(1, pointLine);

                    if (go.transform.position != value)
                    {
                        Vector3 newPos = Vector3.MoveTowards(go.transform.position, value, arrow_speed * Time.deltaTime);
                        go.transform.position = newPos;
                        go.transform.LookAt(origin);
                        textput = false;
                        arrow_speed = arrow_speed + 1f;
                    }
                    else
                    {
                        arrow_speed = 25f;
                    }

                }

                if ((counter > dist) && distinct)
                {
                    counter = 0;
                }
            }
            
            if (puntobool)
            {

                line.startWidth = 0.75f;
                line.endWidth = 0.75f;
                f = Vector3.Dot(v1.position, v2.position);
                //Vector3 punto = Vector3.Normalize((v1.position * f) / Vector3.Distance(origin.position, v1.position));
                value = Vector3.Project(v1.position, v2.position);
                dist = Vector3.Distance(origin.position, value);

                go.SetActive(true);
                TextDistance.TextHandler.ShowExtra();
                if (textput == false)
                {
                    TextDistance.TextHandler.ExtraText("V1 . V2");
                    TextDistance.TextHandler.UpdateExtraPos(value);
                    textput = true;
                }

                if (counter < dist)
                {

                    counter += 0.1f / line_speed;

                    float x = Mathf.Lerp(0, dist, counter);

                    Vector3 pointA = origin.position;
                    //Vector3 pointB = v1.position + v2.position;
                    Vector3 pointB = origin.InverseTransformPoint(value);
                    //Vector3 pointB = destination.InverseTransformPoint(origin.position).position;

                    Vector3 pointLine = x * Vector3.Normalize(pointB - pointA) + pointA;

                    //(pointLine = Vector3.Normalize(pointLine);

                    line.SetPosition(1, pointLine);

                    if (go.transform.position != value)
                    {
                        Vector3 newPos = Vector3.MoveTowards(go.transform.position, value, arrow_speed * Time.deltaTime);
                        go.transform.position = newPos;
                        go.transform.LookAt(origin);
                        textput = false;
                        arrow_speed = arrow_speed + 1f;
                    }
                    else
                    {
                        arrow_speed = 25f;
                    }

                }

                if ((counter > dist) && distinct)
                {
                    counter = 0;
                }

            }

            if (cruzbool)
            {

                line.startWidth = 0.45f;
                line.endWidth = 0.45f;
                //Vector3 cruz = new Vector3(
                //    (v1.position.y*v2.position.z)-(v1.position.z*v2.position.y),
                //    (v1.position.z*v2.position.x)-(v1.position.x* v2.position.z),
                //    (v1.position.x*v2.position.y) -(v1.position.y*v2.position.x));
                value = Vector3.Cross(v1.position, v2.position);
                dist = Vector3.Distance(origin.position, value);

                go.SetActive(true);
                TextDistance.TextHandler.ShowExtra();
                if (textput == false)
                {
                    TextDistance.TextHandler.ExtraText("V1 x V2");
                    TextDistance.TextHandler.UpdateExtraPos(value*0.1f);
                    textput = true;
                }

                if (counter < dist)
                {

                    counter += 0.1f / line_speed;

                    float x = Mathf.Lerp(0, dist, counter);

                    Vector3 pointA = origin.position;
                    //Vector3 pointB = v1.position + v2.position;
                    Vector3 pointB = origin.InverseTransformPoint(value);
                    //Vector3 pointB = destination.InverseTransformPoint(origin.position).position;

                    Vector3 pointLine = x * 0.1f * Vector3.Normalize(pointB - pointA) + pointA;

                    //(pointLine = Vector3.Normalize(pointLine);

                    line.SetPosition(1, pointLine);

                    if (go.transform.position != (value*0.1f))
                    {
                        Vector3 newPos = Vector3.MoveTowards(go.transform.position, value*0.1f, arrow_speed * Time.deltaTime);
                        go.transform.position = newPos;
                        go.transform.LookAt(origin);
                        textput = false;
                        arrow_speed = arrow_speed + 1f;
                    }
                    else
                    {
                        arrow_speed = 25f;
                    }

                }

                if ((counter > dist) && distinct)
                {
                    counter = 0;
                }
            }
        


        }

        else
        {
            if (sumabool || restabool  || cruzbool || puntobool)
            {
                dist = Vector3.Distance(origin.position, origin.position);
            }
        }


    }

    void FixedUpdate()
    {
        v1actual = Vector3.Distance(origin.position, v1.position);
        v2actual = Vector3.Distance(origin.position, v2.position);

        if ((v1prev != v1actual) || (v2prev !=v2actual))
        {
            distinct = true;
        }
        else
        {
            distinct = false;
        }

        v1prev = v1actual;
        v2prev = v2actual;

    }
}
