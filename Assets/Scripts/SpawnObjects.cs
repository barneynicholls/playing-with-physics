using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour
{
    public int XCount = 10;

    public int YCount = 10;

    public int ZCount = 10;

    public float Spacing = 1.2f;

    public TMP_Text XValue;
    public TMP_Text YValue;
    public TMP_Text ZValue;
    public TMP_Text SpacingValue;
    public TMP_Text GravityValue;
    public TMP_Text Spawned;

    private Slider sliderX;
    private Slider sliderY;
    private Slider sliderZ;
    private Slider sliderGravity;
    private Slider sliderSpacing;

    private List<GameObject> created = new List<GameObject>();

    void Start()
    {
        sliderX = GameObject.Find("SliderX").GetComponent<Slider>();
        sliderX.value = XCount;
        UpdateX(XCount);

        sliderY = GameObject.Find("SliderY").GetComponent<Slider>();
        sliderY.value = YCount;
        UpdateY(YCount);

        sliderZ = GameObject.Find("SliderZ").GetComponent<Slider>();
        sliderZ.value = ZCount;
        UpdateZ(ZCount);

        sliderSpacing = GameObject.Find("SliderSpacing").GetComponent<Slider>();
        sliderSpacing.value = Spacing;
        UpdateSpacing(Spacing);

        sliderGravity = GameObject.Find("SliderGravity").GetComponent<Slider>();
        sliderGravity.value = Physics.gravity.y;
        UpdateGravity(Physics.gravity.y);

        Spawn();
    }

    public void Spawn()
    {
        int count = 0;

        for (int y = 0; y < YCount; y++)
        {
            for (int x = 0; x < XCount; x++)
            {
                for (int z = 0; z < ZCount; z++)
                {
                    var pos = gameObject.transform.position;

                    pos.x += Spacing * x;
                    pos.y += Spacing * y;
                    pos.z += Spacing * z;

                    GameObject obj = null;

                    if (created.Count > count)
                    {
                        obj = created[count];
                        obj.transform.position = pos;
                        obj.transform.rotation = Quaternion.identity;
                        var rigidBody = obj.GetComponent<Rigidbody>();
                        rigidBody.velocity = Vector3.zero;
                        rigidBody.angularVelocity = Vector3.zero;
                        rigidBody.Sleep();
                        obj.SetActive(true);
                    }
                    else
                    {
                        obj = Instantiate(Resources.Load("Sphere"), pos, Quaternion.identity) as GameObject;
                        created.Add(obj);
                    }

                    count++;
                }
            }
        }

        if (count < created.Count)
        {
            for (int i = count; i < created.Count; i++)
            {
                created[i].SetActive(false);
            }
        }

        Spawned.text = (count--).ToString();
    }

    public void UpdateY(float value)
    {
        YCount = Convert.ToInt32(value);
        YValue.text = YCount.ToString();
    }

    public void UpdateX(float value)
    {
        XCount = Convert.ToInt32(value);
        XValue.text = XCount.ToString();
    }

    public void UpdateZ(float value)
    {
        ZCount = Convert.ToInt32(value);
        ZValue.text = ZCount.ToString();
    }

    public void UpdateSpacing(float value)
    {
        Spacing = value;
        SpacingValue.text = Spacing.ToString();
    }

    public void UpdateGravity(float value)
    {
        Physics.gravity = new Vector3(0, value, 0);
        GravityValue.text = value.ToString();
    }

}
