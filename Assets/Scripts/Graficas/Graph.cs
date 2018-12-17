/*
	Based On: https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

    [SerializeField]
    private GameObject pointPrefab;

    [SerializeField]
    [Range(10, 100)]
    private int resolution = 10;

    [SerializeField]
    [Range(1f, 100f)]
    private float worldScale = 2f;

    [SerializeField]
    private GraphFunctionName function;

    [SerializeField]
    private Material graphMarkerMaterial;

    private Vector4 tempPos;

    private float step;

    private Transform[] points;

    private Transform pointsParent;

    static GraphFunction[] functions = {
        SineFunction,
        Sine2DFunction,
        SineMean2DFunction,
        MultiSineFunction,
        MultiSine2DFunction,
        Ripple,
        Circle,
        Whirl,
        Cylinder,
        WobblyCylinder,
        PotCylinder,
        TwistingCylinder,
        Sphere,
        CardioidSphere,
        PulsingSphere,
        OuterTorus,
        IntersectingTorus,
        HornTorus,
        RingTorus,
        StarTorus,
        MobiusStrip,
        SpecialMobiusStrip,
        KleinBottle,
        MovingKleinBottle,
    };

    public void SetMathFunction(GraphFunctionName f) {
        function = f;
    }

    void Awake()
    {
        pointsParent = (new GameObject("PointsGroup")).transform;
        pointsParent.SetParent(transform.parent, false);

        step = 2f / resolution; // length / resolution
        Vector3 scale = Vector3.one * step * worldScale;
        points = new Transform[resolution * resolution];
        graphMarkerMaterial = Material.Instantiate<Material>(graphMarkerMaterial);
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab.transform);
            point.localScale = scale;
            point.SetParent(pointsParent, false);
            point.GetComponent<Renderer>().material = graphMarkerMaterial;
            points[i] = point;
        }

        graphMarkerMaterial.SetFloat("_Scale", worldScale);
    }

    void Update()
    {
        tempPos.x = transform.position.x;
        tempPos.y = transform.position.y;
        tempPos.z = transform.position.z;
        tempPos.w = 0f;

        GraphFunction f = functions[(int)function];
        float t = Time.time;
        float step = 2f / resolution;
        for (int i = 0, z = 0; z < resolution; z++)
        {
            float v = (z + 0.5f) * step - 1f;
            for (int x = 0; x < resolution; x++, i++)
            {
                float u = (x + 0.5f) * step - 1f;
                points[i].localPosition = f(u, v, t) * worldScale;
            }
        }
        graphMarkerMaterial.SetVector("_Center", tempPos);
    }

    const float pi = Mathf.PI;
    static Vector3 SineFunction(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + t));
        p.z = v;
        return p;
    }

    static Vector3 Sine2DFunction(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + v + t));
        p.y *= 0.5f;
        p.z = v;
        return p;
    }
    static Vector3 SineMean2DFunction(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + t));
        p.y += Mathf.Sin(pi * (v + t));
        p.y *= 0.5f;
        p.z = v;
        return p;
    }

    static Vector3 MultiSineFunction(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Mathf.Sin(pi * (u + t));
        p.y += Mathf.Sin(2f * pi * (v + 2f * t)) / 2f;
        p.y *= 2f / 3f;
        p.z = v;
        return p;
    }

    static Vector3 MultiSine2DFunction(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = 4f * Mathf.Sin(pi * (u + v + t / 2f));
        p.y += Mathf.Sin(pi * (u + t));
        p.y += Mathf.Sin(2f * pi * (v + 2f * t)) * 0.5f;
        p.y *= 1f / 5.5f;
        p.z = v;
        return p;
    }

    static Vector3 Ripple(float u, float v, float t)
    {
        Vector3 p;
        float d = Mathf.Sqrt(u * u + v * v);
        p.x = u;
        p.y = Mathf.Sin(pi * (4f * d - t));
        p.y /= 1f + 10f * d;
        p.z = v;
        return p;
    }

    static Vector3 Circle(float u, float v, float t)
    {
        Vector3 p;
        p.x = Mathf.Sin(pi * u);
        p.y = 0f;
        p.z = Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 Whirl(float u, float v, float t)
    {
        Vector3 p;
        float w = u + t;
        p.x = Mathf.Sin(pi * w);
        p.y = u;
        p.z = Mathf.Cos(pi * w);
        return p;
    }

    static Vector3 Cylinder(float u, float v, float t)
    {
        Vector3 p;
        float r = 1f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 WobblyCylinder(float u, float v, float t)
    {
        Vector3 p;
        float r = 1f + Mathf.Sin(6f * pi * u) * 0.2f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 PotCylinder(float u, float v, float t)
    {
        Vector3 p;
        float r = 1f + Mathf.Sin(2f * pi * v) * 0.2f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 TwistingCylinder(float u, float v, float t)
    {
        Vector3 p;
        float r = 0.8f + Mathf.Sin(pi * (6f * u + 2f * v + t)) * 0.2f;
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 Sphere(float u, float v, float t)
    {
        Vector3 p;
        float r = Mathf.Cos(pi * 0.5f * v);
        p.x = r * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * 0.5f * v);
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 CardioidSphere(float u, float v, float t)
    {
        Vector3 p;
        float r = Mathf.Cos(pi * 0.5f * v);
        p.x = r * Mathf.Sin(pi * u);
        p.y = v;
        p.z = r * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 PulsingSphere(float u, float v, float t)
    {
        Vector3 p;
        float r = 0.8f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
        r += Mathf.Sin(pi * (4f * v + t)) * 0.1f;
        float s = r * Mathf.Cos(pi * 0.5f * v);
        p.x = s * Mathf.Sin(pi * u);
        p.y = r * Mathf.Sin(pi * 0.5f * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 OuterTorus(float u, float v, float t)
    {
        Vector3 p;
        float s = Mathf.Cos(pi * 0.5f * v) + 0.5f;
        p.x = s * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * 0.5f * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 IntersectingTorus(float u, float v, float t)
    {
        Vector3 p;
        float s = Mathf.Cos(pi * v) + 0.5f;
        p.x = s * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 HornTorus(float u, float v, float t)
    {
        float r1 = 1f;
        Vector3 p;
        float s = Mathf.Cos(pi * v) + r1;
        p.x = s * Mathf.Sin(pi * u);
        p.y = Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 RingTorus(float u, float v, float t)
    {
        float r1 = 1f;
        float r2 = 0.5f;
        Vector3 p;
        float s = r2 * Mathf.Cos(pi * v) + r1;
        p.x = s * Mathf.Sin(pi * u);
        p.y = r2 * Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 StarTorus(float u, float v, float t)
    {
        float r1 = 0.65f + Mathf.Sin(pi * (6f * u + t)) * 0.1f;
		float r2 = 0.2f + Mathf.Sin(pi * (4f * v + t)) * 0.05f;
        Vector3 p;
        float s = r2 * Mathf.Cos(pi * v) + r1;
        p.x = s * Mathf.Sin(pi * u);
        p.y = r2 * Mathf.Sin(pi * v);
        p.z = s * Mathf.Cos(pi * u);
        return p;
    }

    static Vector3 MobiusStrip(float u, float v, float t)
    {
        float halfnu = (u + t * 0.05f) * pi; 
        float halfnv = (v - 0.5f); 

        float nu = halfnu * 2f;
        //float nv = halfnv * 2f;
        
        float temp = 1f + halfnv *  Mathf.Cos(halfnu);
        Vector3 p;
        p.x = temp * Mathf.Cos(nu);
        p.y = temp * Mathf.Sin(nu);
        p.z = halfnv * Mathf.Sin(halfnu);
        return p;
    }

    static Vector3 SpecialMobiusStrip(float u, float v, float t)
    {
        float halfnu = (u + t * 0.05f) * pi; 
        float halfnv = (v - 0.5f) 
            * Mathf.Cos(pi * (t * 0.05f + v)) 
            * Mathf.Cos(pi * (t * 0.1f + u))
            * Mathf.Cos(pi * (t * 0.2f + u + v)); 

        float nu = halfnu * 2f;
        //float nv = halfnv * 2f;
        
        float temp = 1f + halfnv *  Mathf.Cos(halfnu);
        Vector3 p;
        p.x = temp * Mathf.Cos(nu);
        p.y = temp * Mathf.Sin(nu);
        p.z = halfnv * Mathf.Sin(halfnu);
        return p;
    }

    static Vector3 KleinBottle(float u, float v, float t)
    {

        float nu = u * pi;
        float nv = v * pi * 2f;

        float cu = Mathf.Cos(nu);
        float su = Mathf.Sin(nu);

        float cv = Mathf.Cos(nv);
        float sv = Mathf.Sin(nv);
        
        float cu2 = cu * cu;
        float cu3 = cu2 * cu;
        float cu4 = cu3 * cu;
        float cu5 = cu4 * cu;
        float cu6 = cu5 * cu;
        float cu7 = cu6 * cu;

        Vector3 p;
        p.x = -2f/15f * cu * (
            3f * cv 
            - 30f * su 
            + 90f * cu4 * su 
            - 60f * cu6 * su 
            + 5f * cu * cv * su
        );
        p.y = -1f/15f * su * (
            3f * cv
            - 3f * cu2 * cv
            - 48f * cu4 * cv 
            + 48f * cu6 * cv
            - 60f * su
            + 5f * cu * cv * su
            - 5f * cu3 * cv * su
            - 80f * cu5 * cv * sv 
            + 80f * cu7 * cv * su
        );
        p.z = 2f/15f * (3f + 5f * cu * su) * sv;

       p.y -=  2f; // Re center
        return p;
    }

    static Vector3 MovingKleinBottle(float u, float v, float t)
    {

        float nu = (u + t * 0.05f) * pi;
        float nv = (v + t * 0.2f) * pi * 2f;

        float cu = Mathf.Cos(nu);
        float su = Mathf.Sin(nu);

        float cv = Mathf.Cos(nv);
        float sv = Mathf.Sin(nv);
        
        float cu2 = cu * cu;
        float cu3 = cu2 * cu;
        float cu4 = cu3 * cu;
        float cu5 = cu4 * cu;
        float cu6 = cu5 * cu;
        float cu7 = cu6 * cu;

        Vector3 p;
        p.x = -2f/15f * cu * (
            3f * cv 
            - 30f * su 
            + 90f * cu4 * su 
            - 60f * cu6 * su 
            + 5f * cu * cv * su
        );
        p.y = -1f/15f * su * (
            3f * cv
            - 3f * cu2 * cv
            - 48f * cu4 * cv 
            + 48f * cu6 * cv
            - 60f * su
            + 5f * cu * cv * su
            - 5f * cu3 * cv * su
            - 80f * cu5 * cv * sv 
            + 80f * cu7 * cv * su
        );
        p.z = 2f/15f * (3f + 5f * cu * su) * sv;

        p.y -=  2f; // Re center
        return p;
    }
}
