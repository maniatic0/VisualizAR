using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSound : MonoBehaviour
{

    public Graph graph;
    public AudioClip[] aClips;
    public AudioSource myAudioSource;
    private Vector3 MovingDirection;
    public GameObject button;
    string btnName;

    public Transform farEnd;
    private Vector3 frometh;
    private Vector3 untoeth;
    private float secondsForOneLength = 0.5f;

    public bool presionado;
    public float delay;
    public int page;
    public TextMesh text1;
    public TextMesh text2;
    public TextMesh text3;
    public TextMesh text4;
    public TextMesh text5;
    public TextMesh text6;
    public TextMesh text7;
    public TextMesh text8;
    public TextMesh textscreen;


    // Use this for initialization
    void Start()
    {
        page = 0;
        myAudioSource = GetComponent<AudioSource>();
        presionado = false;
        //btnName = "button1";
        //button = GameObject.Find("button1");
        //if (button = GameObject.Find("button1")){
        print("vayalo");

        text1 = GameObject.Find("Text1").GetComponent<TextMesh>();
        text1.text = "A";
        text2 = GameObject.Find("Text2").GetComponent<TextMesh>();
        text2.text = "B";
        text3 = GameObject.Find("Text3").GetComponent<TextMesh>();
        text3.text = "C";
        text4 = GameObject.Find("Text4").GetComponent<TextMesh>();
        text4.text = "D";
        text5 = GameObject.Find("Text5").GetComponent<TextMesh>();
        text5.text = "E";
        text6 = GameObject.Find("Text6").GetComponent<TextMesh>();
        text6.text = "F";
        text7 = GameObject.Find("Text7").GetComponent<TextMesh>();
        text7.text = "G";
        text8 = GameObject.Find("Text8").GetComponent<TextMesh>();
        text8.text = "H";

        textscreen = GameObject.Find("TextPantalla").GetComponent<TextMesh>();
        textscreen.text = "Seleccionar una figura";
        textscreen.characterSize = 0.015f;
        //frometh = button.transform.localPosition;
        //untoeth = button.transform.localPosition;
        //untoeth[1] = button.transform.localPosition.y - 0.5f;
        delay = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //float delay = 0f;
        //button.transform.position = Vector3.Lerp(untoeth, frometh, Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time / secondsForOneLength, 1f)));


        //button.transform.Translate(MovingDirection * Time.smoothDeltaTime);

        //if (button.transform.position.y > 3)
        //{
        //    MovingDirection = Vector3.down;
        //}
        //else if (button.transform.position.y < -3)
        //{
        //    MovingDirection = Vector3.up;
        //}
        //}
        //else
        //{
        //    print("F");
        //}
        //button = GameObject.Find("button1");

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && (presionado == false))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                btnName = Hit.transform.name;
                button = GameObject.Find(btnName);

                frometh = button.transform.localPosition;
                untoeth = button.transform.localPosition;
                untoeth[1] = button.transform.localPosition.y - 0.25f;

                switch (btnName)
                {
                    case "button1":
                        myAudioSource.clip = aClips[0];
                        myAudioSource.Play();
                        graph.SetMathFunction(GraphFunctionName.Sine + page);

                        if (page == 0)
                        {
                            textscreen.text = "Seno";
                            textscreen.characterSize = 0.02f;
                        }
                        if (page == 8)
                        {
                            textscreen.text = "Cilindro";
                            textscreen.characterSize = 0.02f;
                        }
                        if (page == 16)
                        {
                            textscreen.text = "Toroide de Interseccion";
                            textscreen.characterSize = 0.012f;
                        }
                        presionado = true;

                        break;
                    case "button2":
                        myAudioSource.clip = aClips[1];
                        myAudioSource.Play();
                        graph.SetMathFunction(GraphFunctionName.Sine2D + page);
                        if (page == 0)
                        {
                            textscreen.text = "Seno 2D";
                            textscreen.characterSize = 0.02f;
                        }
                        if (page == 8)
                        {
                            textscreen.text = "Cilindro Tambaleante";
                            textscreen.characterSize = 0.015f;
                        }
                        if (page == 16)
                        {
                            textscreen.text = "Toroide de Cuerno";
                            textscreen.characterSize = 0.015f;
                        }
                        presionado = true;

                        break;

                    case "button3":
                        myAudioSource.clip = aClips[0];
                        myAudioSource.Play();
                        graph.SetMathFunction(GraphFunctionName.SineMean2D + page);
                        if (page == 0)
                        {
                            textscreen.text = "Media del Seno";
                            textscreen.characterSize = 0.02f;
                        }
                        if (page == 8)
                        {
                            textscreen.text = "Cilindro de Olla";
                            textscreen.characterSize = 0.015f;
                        }
                        if (page == 16)
                        {
                            textscreen.text = "Toroide Anidado";
                            textscreen.characterSize = 0.015f;
                        }
                        presionado = true;

                        break;

                    case "button4":
                        myAudioSource.clip = aClips[1];
                        myAudioSource.Play();
                        graph.SetMathFunction(GraphFunctionName.MultiSine + page);
                        if (page == 0)
                        {
                            textscreen.text = "Multiseno";
                            textscreen.characterSize = 0.02f;
                        }
                        if (page == 8)
                        {
                            textscreen.text = "Cilindro de Torsion";
                            textscreen.characterSize = 0.015f;
                        }
                        if (page == 16)
                        {
                            textscreen.text = "Toroide Estrella";
                            textscreen.characterSize = 0.015f;
                        }
                        presionado = true;

                        break;

                    case "button5":
                        myAudioSource.clip = aClips[0];
                        myAudioSource.Play();
                        graph.SetMathFunction(GraphFunctionName.MultiSine2DF + page);
                        if (page == 0)
                        {
                            textscreen.text = "Multiseno 2D";
                            textscreen.characterSize = 0.015f;
                        }
                        if (page == 8)
                        {
                            textscreen.text = "Esfera";
                            textscreen.characterSize = 0.02f;
                        }
                        if (page == 16)
                        {
                            textscreen.text = "Banda de Mobius";
                            textscreen.characterSize = 0.015f;
                        }
                        presionado = true;

                        break;

                    case "button6":
                        myAudioSource.clip = aClips[1];
                        myAudioSource.Play();
                        graph.SetMathFunction(GraphFunctionName.Ripple + page);
                        if (page == 0)
                        {
                            textscreen.text = "Onda";
                            textscreen.characterSize = 0.02f;
                        }
                        if (page == 8)
                        {
                            textscreen.text = "Esfera cardioide";
                            textscreen.characterSize = 0.02f;
                        }
                        if (page == 16)
                        {
                            textscreen.text = "Banda Especial de Mobius";
                            textscreen.characterSize = 0.012f;
                        }
                        presionado = true;

                        break;

                    case "button7":
                        myAudioSource.clip = aClips[1];
                        myAudioSource.Play();
                        graph.SetMathFunction(GraphFunctionName.Circle + page);
                        if (page == 0)
                        {
                            textscreen.text = "Circulo";
                            textscreen.characterSize = 0.02f;
                        }
                        if (page == 8)
                        {
                            textscreen.text = "Esfera Pulsante";
                            textscreen.characterSize = 0.015f;
                        }
                        if (page == 16)
                        {
                            textscreen.text = "Botella de Klein Estatica";
                            textscreen.characterSize = 0.012f;
                        }
                        presionado = true;

                        break;

                    case "button8":
                        myAudioSource.clip = aClips[1];
                        myAudioSource.Play();
                        graph.SetMathFunction(GraphFunctionName.Whirl + page);
                        if (page == 0)
                        {
                            textscreen.text = "Remolino";
                            textscreen.characterSize = 0.02f;
                        }
                        if (page == 8)
                        {
                            textscreen.text = "Toroide Exterior";
                            textscreen.characterSize = 0.015f;
                        }
                        if (page == 16)
                        {
                            textscreen.text = "Botella de Klein Dinamica";
                            textscreen.characterSize = 0.012f;
                        }
                        presionado = true;

                        break;

                    case "prev":

                    
                        if (page > 0)
                        {
                            page = page - 8;
                            myAudioSource.clip = aClips[3];
                            myAudioSource.Play();
                            if (page == 0)
                            {
                                text1.text = "A";
                                text2.text = "B";
                                text3.text = "C";
                                text4.text = "D";
                                text5.text = "E";
                                text6.text = "F";
                                text7.text = "G";
                                text8.text = "H";
                            }
                            if (page == 8)
                            {
                                text1.text = "I";
                                text2.text = "J";
                                text3.text = "K";
                                text4.text = "L";
                                text5.text = "M";
                                text6.text = "N";
                                text7.text = "O";
                                text8.text = "P";
                            }
                        }

                        else
                        {
                            myAudioSource.clip = aClips[2];
                            myAudioSource.Play();
                        }

                        presionado = true;
                        break;

                    case "next":
                        if (page < 16)
                        {
                            page = page + 8;
                            myAudioSource.clip = aClips[3];
                            myAudioSource.Play();
                            if (page == 8)
                            {
                                text1.text = "I";
                                text2.text = "J";
                                text3.text = "K";
                                text4.text = "L";
                                text5.text = "M";
                                text6.text = "N";
                                text7.text = "O";
                                text8.text = "P";
                            }
                            if (page == 16)
                            {
                                text1.text = "Q";
                                text2.text = "R";
                                text3.text = "S";
                                text4.text = "T";
                                text5.text = "U";
                                text6.text = "V";
                                text7.text = "W";
                                text8.text = "X";
                            }
                        }

                        else
                        {
                            myAudioSource.clip = aClips[2];
                            myAudioSource.Play();
                        }
                        presionado = true;
                        break;

                    default:
                        break;
                }
            }
        }

        if (presionado)
        {
            button.transform.localPosition = Vector3.Lerp(frometh, untoeth, Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time / secondsForOneLength, 1f)));

            print(delay);

            if (delay > 0.7f)
            {
                button.transform.localPosition = frometh;
                delay = 0f;
                presionado = false;
            }
            else
            {
                delay += Time.deltaTime;
            }
        }

    }
}
