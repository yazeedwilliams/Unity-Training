using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    // initialised the list
    private readonly List<string> TextToDisplay = new();

    private float TimeToNextText;

    private int CurrentText;

    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 1.0f;
        CurrentText = 0;

        TextToDisplay.Add("Congratulations");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[CurrentText];

        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            if (CurrentText > TextToDisplay.Count - 1)
            {
                CurrentText = 0;
            }
            if (TimeToNextText > 1.5f)
            {
                TimeToNextText = 0.0f;
            }

            Text.text = TextToDisplay[CurrentText];
            CurrentText++;
        }
    }
}