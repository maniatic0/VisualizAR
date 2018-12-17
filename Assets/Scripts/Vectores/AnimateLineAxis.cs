using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateLineAxis : MonoBehaviour
{

    private LineRenderer line;

    public GameObject doblelinea;
    private LineRenderer lRend;

    public float counter; 

    public float dist;
    public float distneg;

    public Transform origin;
    public Transform destination;

    public float line_speed = 6f;

    public float prev;

    public float actual;

    public bool centerdetected = false;

    public bool detected = false;

    public bool distinct = false;

    public bool flechazo = false;
    public bool dobleflechazo = false;
    public bool instantiated = false;

    public bool ejenormal = false;

    public bool ejedoble = false;

    public bool sineje = false;

    public bool ejesnegativos = false;

    //TESTS
    [SerializeField]
    public GameObject prefab;

    GameObject go;
    GameObject doblego;
    //Vector3 movePosition = new Vector3(10f, 10f, 10f);
    float arrow_speed = 20f;

    // Booleans for Functions
    public bool suma = false;

    public void centerdetectedfunc()
    {
        centerdetected = true;
    }

    public void detectedfunc()
    {
        //if (centerdetected)
        //{
            detected = true;
        //}
    }

    public void undetectedfunc()
    {
        detected = false;
    }

    public void noaxisfunc()
    {
        ejenormal = false;
        ejedoble = false;
        ejesnegativos = false;
        sineje = true;
    }

    public void regularaxisfunc()
    {
        ejedoble = false;
        ejesnegativos = false;
        sineje = false;
        ejenormal = true;
    }

    public void doubleaxisfunc()
    {
        ejenormal = false;
        ejesnegativos = false;
        sineje = false;
        ejedoble = true;
    }

    public void negaxisfunc()
    {
        ejenormal = false;
        ejedoble = false;
        sineje = false;
        ejesnegativos = true;
    }

    // Use this for initialization
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, origin.position);
        line.startWidth = 0;
        line.endWidth = 0;
        prev = 0;

        //lRend = new gameObject.AddComponent<LineRenderer>() as LineRenderer;
        lRend = doblelinea.GetComponent<LineRenderer>();
        lRend.SetPosition(0, origin.position);
        lRend.startWidth = 0;
        lRend.endWidth = 0;
        sineje = true;

        //dist = Vector3.Distance(origin.position, destination.position);

    }

    // Update is called once per frame
    void Update()
    {

        if (centerdetected)
        {
            line.startWidth = 0.25f;
            line.endWidth = 0.25f;
            dist = Vector3.Distance(origin.position, destination.position);

            lRend.startWidth = 0.25f;
            lRend.endWidth = 0.25f;
            distneg = Vector3.Distance(origin.position, destination.position);

            //if ((counter < dist))
            //{

                if (sineje)
                {
                    counter += 0.1f / line_speed;

                    float x = Mathf.Lerp(0, 0, counter);

                    Vector3 pointA = origin.position;
                    //Vector3 pointB = destination.position;
                    Vector3 pointB = origin.InverseTransformPoint(origin.position);
                    //Vector3 pointB = destination.InverseTransformPoint(origin.position).position;

                    Vector3 pointLine = x * Vector3.Normalize(pointB - pointA) + pointA;
                    print(pointLine);

                    line.SetPosition(1, pointLine);
                    lRend.SetPosition(1, pointLine);


                }

                if (ejenormal)
                {
                    dist = 2.0f * Vector3.Distance(origin.position, destination.position);
                    counter += 0.1f / line_speed;

                    float x = Mathf.Lerp(0, dist, counter);

                    Vector3 pointA = origin.position;
                    //Vector3 pointB = destination.position;
                    Vector3 pointB = origin.InverseTransformPoint(destination.position);
                    //Vector3 pointB = destination.InverseTransformPoint(origin.position).position;
                    pointB = (2.0f * pointB);


                    Vector3 pointLine = x * Vector3.Normalize(pointB - pointA) + pointA;
                    print(pointLine);

                    line.SetPosition(1, pointLine);
                    lRend.SetPosition(1, new Vector3(0,0,0));


                }

                if (ejedoble)
                {
                    dist = 4.0f*Vector3.Distance(origin.position, destination.position);
                    counter += 0.1f / line_speed;

                    float x = Mathf.Lerp(0, dist, counter);

                    Vector3 pointA = origin.position;
                    //Vector3 pointB = destination.position;
                    Vector3 pointB = origin.InverseTransformPoint(destination.position);
                    print(pointB);
                    pointB = (4.0f * pointB);
                    print(pointB);
                    //Vector3 pointB = destination.InverseTransformPoint(origin.position).position;

                    Vector3 pointLine = x * Vector3.Normalize(pointB - pointA) + pointA;
                    print(pointLine);

                    line.SetPosition(1, pointLine);
                    lRend.SetPosition(1, new Vector3(0, 0, 0));

                }

                if (ejesnegativos)
                {
                    if (instantiated == false)
                    {
                        dobleflechazo = true;
                    }

                    //dobleflechazo = true;
                    distneg = 2.0f * Vector3.Distance(origin.position, (-1.0f)*destination.position);
                    dist = 2.0f * Vector3.Distance(origin.position, destination.position);
                    counter += 0.1f / line_speed;

                    float y = Mathf.Lerp(0, distneg, counter);
                    float x = Mathf.Lerp(0, dist, counter);

                    Vector3 pointA = origin.position;
                    //Vector3 pointB = destination.position;
                    Vector3 pointB = origin.InverseTransformPoint(destination.position);
                    Vector3 pointBneg = origin.InverseTransformPoint(destination.position);

                    //Vector3 pointB = destination.InverseTransformPoint(origin.position).position;
                    pointB = (2.0f * pointB);
                    pointBneg = (-2.0f * pointBneg);

                    Vector3 pointLine = x * Vector3.Normalize(pointB - pointA) + pointA;
                    print(pointLine);

                    Vector3 pointLineneg = y * Vector3.Normalize(pointBneg - pointA) + pointA;
                    print(pointLineneg);

                    line.SetPosition(1, pointLine);

                    lRend.SetPosition(1, pointLineneg);

                }


                if (flechazo)
                {
                    go = Instantiate(prefab, origin.position, Quaternion.identity)as GameObject;
                    go.transform.parent = origin.transform;
                    go.transform.LookAt(origin);
                    flechazo = false;
                }

                if (dobleflechazo)
                {
                    doblego = Instantiate(prefab, (-1.0f)*origin.position, Quaternion.identity) as GameObject;
                    doblego.transform.parent = origin.transform;
                    doblego.transform.LookAt(origin);
                    instantiated = true;
                    dobleflechazo = false;
                }



            //}

            if (counter > dist)
            {
                counter = 0;
            }

        }

        else
        {
            dist = Vector3.Distance(origin.position, origin.position);
        }

        if ((flechazo == false))
        {

            if ((go.transform.position != origin.position) && (sineje))
            {
                Vector3 newPos = Vector3.MoveTowards(go.transform.position, origin.position, arrow_speed * Time.deltaTime);
                go.transform.position = newPos;
                go.transform.LookAt(origin);
                arrow_speed = arrow_speed + 1;
                doblego.SetActive(false);
            }

            if (ejenormal)
            {
                doblego.SetActive(false);

                if (go.transform.position != 2.0f * destination.position)
                {
                    Vector3 newPos = Vector3.MoveTowards(go.transform.position, 2.0f * destination.position, arrow_speed * Time.deltaTime);
                    go.transform.position = newPos;
                    go.transform.LookAt(origin);
                    arrow_speed = arrow_speed + 1;
                }

            }

            if ((go.transform.position != 4.0f*destination.position) && (ejedoble))
            {
                Vector3 newPos = Vector3.MoveTowards(go.transform.position, 4.0f*destination.position, arrow_speed * Time.deltaTime);
                go.transform.position = newPos;
                go.transform.LookAt(origin);
                arrow_speed = arrow_speed + 1;
                doblego.SetActive(false);
            }

            if ((go.transform.position != 2.0f * destination.position) && (ejesnegativos))
            {

                Vector3 newPos = Vector3.MoveTowards(go.transform.position, 2.0f * destination.position, arrow_speed * Time.deltaTime);
                go.transform.position = newPos;
                go.transform.LookAt(origin);
                arrow_speed = arrow_speed + 1;

                Vector3 newPos2 = Vector3.MoveTowards(doblego.transform.position, -2.0f * destination.position, arrow_speed * Time.deltaTime);
                doblego.SetActive(true);
                doblego.transform.position = newPos2;
                doblego.transform.LookAt(origin);
                //arrow_speed = arrow_speed + 1;


            }

            else
            {
                arrow_speed = 20f;
            }
        }

        
        

    }


    void FixedUpdate()
    {
        actual = Vector3.Distance(origin.position, destination.position);

        if (prev != actual)
        {

            distinct = true;

        }
        else
        {
            distinct = false;
        }

        prev = actual;
    }

}