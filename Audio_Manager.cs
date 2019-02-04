using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Audio_Manager : MonoBehaviour
{
    public Sons[] trilha; // array que referencia a classe sons
    public static Audio_Manager instance; //instanciar o objeto audio-manager
    public AudioMixer master;
    
    void Awake()
    {
        if (instance == null) // se nao tem audio-manager vai instanciar esse mesmo
        {
            instance = this;
        }
        else // se ja tiver destroi o outro
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject); // forma de assegurar que o audio-manager nao sera destruido 

        foreach (Sons s in trilha) //criação de todos os sons
        {
            //caracteristicas do audios criados:

            s.fonte = gameObject.AddComponent<AudioSource>(); //audio source vai ser igual a um novo objeto
            s.fonte.clip = s.musics; //gera uma nova musica
            s.fonte.volume = s.volume; //gera um novo controle de volume
            s.fonte.pitch = s.pitch; // gera um novo controlador de pitch
            s.fonte.loop = s.loop; // gera uma variavel para ver se o audio vai loopar
            s.fonte.playOnAwake = s.awake;
            s.fonte.outputAudioMixerGroup = s.mixer;
            
            
        }
    }



    public void SetSFX(float sfx_vol)
    {
        master.SetFloat("Volume SFX", sfx_vol);
    }
    
    public void SetVolume(float all_vol)
    {
        master.SetFloat("Volume Geral", all_vol);
    }

    public void Tocar (string name)
    // função que faz qualquer audio dentro do jogo ser tocado
    {
        //procura um item dentro do array que tenha o nome que foi digitado
        Sons s = System.Array.Find(trilha, sound => sound.nome == name);
        //se nao encontrar um item no array retorna
        if (s ==  null)
        {
            return;
        }
        // se encontrar toca
        s.fonte.Play();

    }

    public void MenuSel()
	{
        Tocar("Seleção");
	}

	public void Return()
	{
        Tocar("Return");
	}



    #region Musica das telas

    public void Musicas(string nome)
    {
        switch (nome)
        {
            case "Menu Principal":
            Tocar("Musica de Menu");
            Tocar("Menu Background");
            break;

            case "Level Selector":
            Tocar("A dança da chuva");
            break;

            case "Festival":
            Tocar("Promessas Quebradas");
            break;

            case "Cidade Solar":
            Tocar("Contos do Ontem");
            break;

            case "fase3":
            //tocar musicas
            break;

            case "fase4":
            //tocar musicas
            break;

            case "fase5":
            //tocar musicas
            break;

            case "fase6":
            //tocar musicas
            break;

            case "fase7":
            //tocar musicas
            break;

            case "fase8":
            //tocar musicas
            break;

            case "fase9":
            //tocar musicas
            break;

            case "fase10":
            //tocar musicas
            break;
        }
    }




    #endregion






}

[System.Serializable]
public class Sons
{
    public string nome; //nome da musica
    public AudioClip musics; //audio clip que habilita a musica
    [Range(0f, 1f)]
    public float volume; // float que delimita o volume
    [Range(0f, 2f)]
    public float pitch; // float que delimita o pitch da musica
    public bool loop; // se ta loopando ou nao
    //[HideInInspector]
    public AudioSource fonte; //fonte do audio
    public bool awake;
    public AudioMixerGroup mixer;
   
   
}
