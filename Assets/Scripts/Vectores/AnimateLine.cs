using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateLine : MonoBehaviour
{


    private LineRenderer line;

    private LineRenderer line1;
    private LineRenderer linex1;
    private LineRenderer linex2;

    private LineRenderer line2;
    private LineRenderer liney1;
    private LineRenderer liney2;

    private LineRenderer line3;
    private LineRenderer linez1;
    private LineRenderer linez2;
    public float counter;
    public float dist;
    public float dest;

    public Transform origin;
    public Transform destination;

    public float line_speed = 6f;

    public float prev;

    public float actual;

    public bool centerdetected = false;

    public bool detected = false;

    public bool distinct = false;

    public bool flechazo = true;
    public bool instantiated = false;

    public bool proyectate = false;

    [SerializeField]
    private Color toggleColor = Color.green;

    //TESTS
    [SerializeField]
    public GameObject prefab;

    GameObject go;
    //Vector3 movePosition = new Vector3(10f, 10f, 10f);
    float arrow_speed = 20f;

    // Booleans for Functions
    public bool suma = false;

    GameObject proyectx;
    GameObject proyectx1;
    GameObject proyectx2;

    GameObject proyecty;
    GameObject proyecty1;
    GameObject proyecty2;

    GameObject proyectz;
    GameObject proyectz1;
    GameObject proyectz2;

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

    public void proyectedfunc()
    {
        proyectate = true;
    }

    public void unproyectedfunc()
    {
        proyectate = false;
    }

    // Use this for initialization
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, origin.position);
        line.startWidth = 0;
        line.endWidth = 0;
        prev = 0;
        proyectx = new GameObject("AxisXProject");
        proyectx1 = new GameObject("AxisX1Project");
        proyectx2 = new GameObject("AxisX2Project");

        proyecty = new GameObject("AxisYProject");
        proyecty1 = new GameObject("AxisY1Project");
        proyecty2 = new GameObject("AxisY2Project");

        proyectz = new GameObject("AxisZProject");
        proyectz1 = new GameObject("AxisZ1Project");
        proyectz2 = new GameObject("AxisZ2Project");

        proyectx.AddComponent<LineRenderer>();
        proyectx1.AddComponent<LineRenderer>();
        proyectx2.AddComponent<LineRenderer>();

        proyecty.AddComponent<LineRenderer>();
        proyecty1.AddComponent<LineRenderer>();
        proyecty2.AddComponent<LineRenderer>();

        proyectz.AddComponent<LineRenderer>();
        proyectz1.AddComponent<LineRenderer>();
        proyectz2.AddComponent<LineRenderer>();

        line1 = proyectx.GetComponent<LineRenderer>();
        linex1 = proyectx1.GetComponent<LineRenderer>();
        linex2 = proyectx2.GetComponent<LineRenderer>();

        line2 = proyecty.GetComponent<LineRenderer>();
        liney1 = proyecty1.GetComponent<LineRenderer>();
        liney2 = proyecty2.GetComponent<LineRenderer>();

        line3 = proyectz.GetComponent<LineRenderer>();
        linez1 = proyectz1.GetComponent<LineRenderer>();
        linez2 = proyectz2.GetComponent<LineRenderer>();

        line1.material.color = toggleColor;
        line2.material.color = toggleColor;
        line3.material.color = toggleColor;
        linex1.material.color = toggleColor;
        linex2.material.color = toggleColor;
        liney1.material.color = toggleColor;
        liney2.material.color = toggleColor;
        linez1.material.color = toggleColor;
        linez2.material.color = toggleColor;

        line1.startWidth = 0;
        line1.endWidth = 0;
        linex1.startWidth = 0;
        linex1.endWidth = 0;
        linex2.startWidth = 0;
        linex2.endWidth = 0;

        line2.startWidth = 0;
        line2.endWidth = 0;
        liney1.startWidth = 0;
        liney1.endWidth = 0;
        liney2.startWidth = 0;
        liney2.endWidth = 0;

        line3.startWidth = 0;
        line3.endWidth = 0;
        linez1.startWidth = 0;
        linez1.endWidth = 0;
        linez2.startWidth = 0;
        linez2.endWidth = 0;

        line1.SetPosition(0, origin.position);
        linex1.SetPosition(0, origin.position);
        linex2.SetPosition(0, origin.position);

        line2.SetPosition(0, origin.position);
        liney1.SetPosition(0, origin.position);
        liney2.SetPosition(0, origin.position);

        line3.SetPosition(0, origin.position);
        linez1.SetPosition(0, origin.position);
        linez2.SetPosition(0, origin.position);

        //dist = Vector3.Distance(origin.position, destination.position);

    }

    // Update is called once per frame
    void Update()
    {

        if (detected && centerdetected)
        {
            line.startWidth = 0.45f;
            line.endWidth = 0.45f;
            dist = Vector3.Distance(origin.position, destination.position);
            proyectx.transform.position = destination.position;

            if (counter < dist)
            {

                counter += 0.1f / line_speed;

                float x = Mathf.Lerp(0, dist, counter);

                Vector3 pointA = origin.position;
                //Vector3 pointB = destination.position;
                Vector3 pointB = origin.InverseTransformPoint(destination.position);
                //Vector3 pointB = destination.InverseTransformPoint(origin.position).position;

                Vector3 pointLine = x * Vector3.Normalize(pointB - pointA) + pointA;

                line.SetPosition(1, pointLine);

                if (flechazo)
                {
                    go = Instantiate(prefab, origin.position, Quaternion.identity)as GameObject;
                    go.transform.parent = origin.transform;
                    go.transform.LookAt(origin);
                    flechazo = false;
                }

                if (proyectate)
                {



                    line1.startWidth = 0.25f;
                    line1.endWidth = 0.25f;
                    linex1.startWidth = 0.25f;
                    linex1.endWidth = 0.25f;
                    linex2.startWidth = 0.25f;
                    linex2.endWidth = 0.25f;

                    line2.startWidth = 0.25f;
                    line2.endWidth = 0.25f;
                    liney1.startWidth = 0.25f;
                    liney1.endWidth = 0.25f;
                    liney2.startWidth = 0.25f;
                    liney2.endWidth = 0.25f;

                    line3.startWidth = 0.25f;
                    line3.endWidth = 0.25f;
                    linez1.startWidth = 0.25f;
                    linez1.endWidth = 0.25f;
                    linez2.startWidth = 0.25f;
                    linez2.endWidth = 0.25f;

                    Vector3 pointstart = origin.InverseTransformPoint(destination.position);
                    Vector3 point1 = Vector3.Scale(pointLine, new Vector3(0, 1, 1));
               

                    Vector3 point2 = Vector3.Scale(pointLine, new Vector3(1, 0, 1));
                    Vector3 point3 = Vector3.Scale(pointLine, new Vector3(1, 1, 0));

                    Vector3 pointx1 = Vector3.Scale(point1, new Vector3(1, 0, 1));
                    Vector3 pointx2 = Vector3.Scale(point1, new Vector3(1, 1, 0));

                    Vector3 pointy1 = Vector3.Scale(point2, new Vector3(0, 1, 1));
                    Vector3 pointy2 = Vector3.Scale(point2, new Vector3(1, 1, 0));

                    Vector3 pointz1 = Vector3.Scale(point3, new Vector3(0, 1, 1));
                    Vector3 pointz2 = Vector3.Scale(point3, new Vector3(1, 0, 1));

                    line1.SetPosition(0, point1);
                    line1.SetPosition(1, pointLine);
                    linex1.SetPosition(0, point1);
                    linex1.SetPosition(1, pointx1);
                    linex2.SetPosition(0, point1);
                    linex2.SetPosition(1, pointx2);

                    line2.SetPosition(0, point2);
                    line2.SetPosition(1, pointLine);
                    liney1.SetPosition(0, point2);
                    liney1.SetPosition(1, pointy1);
                    liney2.SetPosition(0, point2);
                    liney2.SetPosition(1, pointy2);

                    line3.SetPosition(0, point3);
                    line3.SetPosition(1, pointLine);
                    linez1.SetPosition(0, point3);
                    linez1.SetPosition(1, pointz1);
                    linez2.SetPosition(0, point3);
                    linez2.SetPosition(1, pointz2);


                }

                if (proyectate == false)
                {
                    line1.startWidth = 0;
                    line1.endWidth = 0;
                    linex1.startWidth = 0;
                    linex1.endWidth = 0;
                    linex2.startWidth = 0;
                    linex2.endWidth = 0;

                    line2.startWidth = 0;
                    line2.endWidth = 0;
                    liney1.startWidth = 0;
                    liney1.endWidth = 0;
                    liney2.startWidth = 0;
                    liney2.endWidth = 0;

                    line3.startWidth = 0;
                    line3.endWidth = 0;
                    linez1.startWidth = 0;
                    linez1.endWidth = 0;
                    linez2.startWidth = 0;
                    linez2.endWidth = 0;

                    line1.SetPosition(0, origin.position);
                    linex1.SetPosition(0, origin.position);
                    linex2.SetPosition(0, origin.position);

                    line2.SetPosition(0, origin.position);
                    liney1.SetPosition(0, origin.position);
                    liney2.SetPosition(0, origin.position);

                    line3.SetPosition(0, origin.position);
                    linez1.SetPosition(0, origin.position);
                    linez2.SetPosition(0, origin.position);
                }

            }

            if ((counter > dist) && distinct)
            {
                counter = 0;
            }


        }

        else
        {
            dist = Vector3.Distance(origin.position, origin.position);
            line1.SetPosition(0, origin.position);
            //line2.SetPosition(0, origin.position);
            //line3.SetPosition(0, origin.position);
        }

        if (flechazo == false)
        {
            if (go.transform.position != destination.position)
            {
                Vector3 newPos = Vector3.MoveTowards(go.transform.position, destination.position, arrow_speed * Time.deltaTime);
                go.transform.position = newPos;
                go.transform.LookAt(origin);
                arrow_speed = arrow_speed + 1;
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