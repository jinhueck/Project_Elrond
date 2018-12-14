using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Script : MonoBehaviour
{

    public static Effect_Script instance;
    [SerializeField] List<Struct_Effect> effect_Enable;
    [SerializeField] List<Struct_Effect> effect_Disable;
    [SerializeField] List<Struct_Effect> effect_DisableFever;
    public GameObject effectParent;
    public GameObject resource;
    public GameObject resource_Fever;

    private void Awake()
    {
        if (Effect_Script.instance == null)
            Effect_Script.instance = this;
        
    }

    private void Start()
    {
        Setup();
    }

    public struct Struct_Effect
    {
        public CheckEffect key;
        public ParticleSystem effect;
    }

    public void Setup()
    {
        effectParent = new GameObject();
        effectParent.name = "EffectParent";
        effect_Enable = new List<Struct_Effect>();
        effect_Disable = new List<Struct_Effect>();
        effect_DisableFever = new List<Struct_Effect>();
        resource = Resources.Load("JinHyeok/Effect/" + Map_Group_Script.instance.ReturnSelectNum()) as GameObject;
        resource_Fever = Resources.Load("JinHyeok/Effect/Fever") as GameObject;
    }
    public void PopEffect(Transform pos)
    {
        GameObject newObj;
        Struct_Effect newStruct;
        if(InGameManager.instance.CheckFever() == false)
        {
            if (effect_Disable.Count == 0)
            {
                newObj = Instantiate(resource, pos.position, Quaternion.identity);
                newStruct = new Struct_Effect();
                newStruct.key = CheckEffect.Bomb;
                newStruct.effect = newObj.GetComponent<ParticleSystem>();
            }
            else
            {
                newStruct = effect_Disable[0];
                newStruct.effect.transform.position = pos.position;
                effect_Disable.RemoveAt(0);
            }
        }
        else
        {
            if (effect_DisableFever.Count == 0)
            {
                newObj = Instantiate(resource_Fever, pos.position, Quaternion.identity);
                newStruct = new Struct_Effect();
                newStruct.key = CheckEffect.Fever;
                newStruct.effect = newObj.GetComponent<ParticleSystem>();
            }
            else
            {
                newStruct = effect_DisableFever[0];
                newStruct.effect.transform.position = pos.position;
                effect_DisableFever.RemoveAt(0);
            }
        }
        newStruct.effect.transform.parent = pos.parent;
        ParticleSystem particle = newStruct.effect.GetComponent<ParticleSystem>();
        effect_Enable.Add(newStruct);
        newStruct.effect.gameObject.SetActive(true);
        particle.Play();
    }
    void PushEffect(Struct_Effect obj)
    {
        obj.effect.transform.parent = effectParent.transform;
        ParticleSystem particle = obj.effect.GetComponent<ParticleSystem>();
        
        effect_Enable.Remove(obj);
        if (obj.key == CheckEffect.Bomb)
        {
            effect_Disable.Add(obj);
        }   
        else if (obj.key == CheckEffect.Fever)
        {
            effect_DisableFever.Add(obj);
        }
        obj.effect.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (effect_Enable.Count > 0)
        {
            for (int i = 0; i < effect_Enable.Count; i++)
            {
                if (effect_Enable[i].effect == null)
                {
                     effect_Enable.Remove(effect_Enable[i]);
                }
                    
                else if (!effect_Enable[i].effect.isPlaying)
                    PushEffect(effect_Enable[i]);
            }
        }
    }
}

public enum CheckEffect
{
    Fever = 0,
    Bomb
}