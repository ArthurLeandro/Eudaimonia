using UnityEngine;
using System;

public class Singleton<T>: MonoBehaviour{
  private static bool quitting = false;
  private static T instance;
  public static T Instance{get{Init(); return instance;}
  
  
  private void Init(){
    if(instance==null || instance.Equals(null)){
      var gameObject == new GameObject("Singleton Manager");
      gameObject.hideFlags = HideFlags.HideAndDontSave;
      instance = gameObject.AddComponent<Singleton>();
      DontDestroyOnLoad(gameObject);
    }
    
    private static bool OnApplicationQuit(){
      quitting = true;
    }
    private void OnDestroy(){
      if(!quitting){
        instance = null;
        Init();
      }
      
    }
  }
}
