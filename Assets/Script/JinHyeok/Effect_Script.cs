using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Script : MonoBehaviour
{

    public static Effect_Script instance;
    public List<ParticleSystem> effect_Enable;
    public List<ParticleSystem> effect_Disable;
    public GameObject effectParent;
    public GameObject resource;

    private void Awake()
    {
        if (Effect_Script.instance == null)
            Effect_Script.instance = this;
        Setup();
    }

    public void Setup()
    {
        effectParent = new GameObject();
        effectParent.name = "EffectParent";
        effect_Enable = new List<ParticleSystem>();
        effect_Disable = new List<ParticleSystem>();
        resource = Resources.Load("JinHyeok/Effect/0") as GameObject;
    }
    public void PopEffect(Transform pos)
    {
        GameObject newObj;
        if (effect_Disable.Count == 0)
        {
            newObj = Instantiate(resource, pos.position, Quaternion.identity);
        }
        else
        {
            newObj = effect_Disable[0].gameObject;
            newObj.transform.position = pos.position;
            effect_Disable.RemoveAt(0);
        }
        newObj.transform.parent = pos.parent;
        ParticleSystem particle = newObj.GetComponent<ParticleSystem>();
        effect_Enable.Add(particle);
        newObj.SetActive(true);
        particle.Play();
    }
    public void PushEffect(GameObject obj)
    {
        obj.transform.parent = effectParent.transform;
        ParticleSystem particle = obj.GetComponent<ParticleSystem>();
        obj.SetActive(false);
        effect_Enable.Remove(particle);
        effect_Disable.Add(particle);
    }
    private void Update()
    {
        if (effect_Enable.Count > 0)
        {
            for (int i = 0; i < effect_Enable.Count; i++)
            {
                if (!effect_Enable[i].isPlaying)
                    PushEffect(effect_Enable[i].gameObject);
            }
        }
    }
}