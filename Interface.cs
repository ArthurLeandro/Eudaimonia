public namespace Unity Ads{
  public interface IService{
  void Initializd();
  }

  public interface INonRewardable{
    string NonRewardPlacementId{get;set;} //string nonRewardedPlacementId = "var(this var is setted into Unity Dashboard)"; 
  }
  public interface IRewarded{
    string RewardPlacementId{get;set;}
  }
  public interface IARable{
    string ArPlacementId{get;set;}
  }
  public interface IBannerable{
    string BannerPlacementId{get;set;}
  }

  public interface IBannerDisplayable{
    IEnumerator DisplayBanner();
    /*yield return new WaitUntil(() => Advertisement.IsReady(placementBannerId);Advertisement.Banner.Show(placementBannerId)*/
  }

  public interface IIsReadbyable{
    void ContentReady(object sender, PlacementContentReadyEventArgs event,Placement); /*if(event.PlacementId == placementIdAr){arContent = event.placementContent;}*/
  }

  public interface IRewardableDisplayable{
    IEnumerator DisplayRewarded();/*yield return new WaitUntil(() => Monetization.IsReady(placementRewardedId));ShownAdPlacementContent adContent = Monetization.GetPlacementContent(placementRewardedId) as ShownAdPlacementContent;adContent.gamerSid = "usar um ID para Callback";ShowAdCallbacks callbackOptions = new ShowAdCallbacks();callbackOptions.finishCallback+=RewardCallback;if(adContent!=null){adContent.Show(callbackOptions)else{Debug.Log(Falhou)}}*/
    void RewardCallback(ShowResult result); /*switch(result){case ShowResult.Finished;case ShowResult.Skipped;case ShowResul.Failed}*/
  }

  public interface INonRewardableDisplay{
    void NonRewardedDisplay(); /*if(Monetization.IsReady(placementNonRewardedID)){ShowAdPlacementContent adContent = Monetization.GetPlacementCOntent(placementNonRewardedID) as ShowAdPlacementContent is(adContent!=null){adContent.Show();};}*/
  }

  public interface IServiceManager /*Singleton*/{
    AdService ads{get;set;};
    List <IService> _serviceManagers;
    void InitializeServices(); /* ads = GetComponent<AdService>(); _serviceManagers.Add(ads); for each(Iservice service in _serviceManagers){service.Initialize();}*/
  }
}

public namespace ControllerRelated{
 
    public interface IControllerConectable{
      public bool IsController{get;set;}
      public string Controller{get;set}
     void DetectController();/*try{if(Input.GetJoystickNames()[0]!= null){isController = true;IdentifyController();}else{isController = false;}}*/ 
    }
  
    public interface IIdentifyControlable{
     void IdentifyController{} //Controller = Input.GetJoystickNames() [0]; 
    }
  
    public interface IPCcontroller{
      //This Controller need to have the name of the Action
      public string[] AllPlayerActionsNames{get;set;}
    }
    public interface IXboxController{
      //This Controller need to have the name of the Action /*Xbox_Move, Xbox_Rotate, Xbox_Item1, Xbox_Item2, Xbox_Item3, Xbox_Item4, Xbox_Inv, Xbox_Pause, Xbox_AttackUse, Xbox_Aim;*/
      public string[] AllPlayerActionsNames{get;set;}
    }
  
  public interface ISetDefaultValues{
   void SetDefaultValues();/*PC_Move = "WASD";PC_Rotate = "Mouse";PC_Item1 = "1";PC_Item2 = "2";PC_Item3 = "3";PC_Item4 = "4";PC_Inv = "I";PC_Pause = "Escape";PC_AttackUse = "Left Mouse Button";PC_Aim = "Right Mouse Button";}else{PC_Move = "WASD";PC_Rotate = "Mouse";PC_Item1 = "1";PC_Item2 = "2";PC_Item3 = "3";PC_Item4 = "4";PC_Inv = "I";PC_Pause = "Escape";PC_AttackUse = "Left Mouse Button";PC_Aim = "Right Mouse Button";Interactive Input[ 12 ]Xbox_Move = "Left Thumbstick";Xbox_Rotate = "Right Thumbstick";Xbox_Item1 = "D-Pad Up";Xbox_Item2 = "D-Pad Down";Xbox_Item3 = "D-Pad Left";Xbox_Item4 = "D-Pad Right";Xbox_Inv = "A Button";Xbox_Pause = "Start Button";Xbox_AttackUse = "Right Trigger";Xbox_Aim = "Left Trigger";*/ 
  }
  public interface IControllerProfile{
   enum ControllerProfile{PC,CONTROLLER}; 
    public ControllerProfile CP{get;set;}
  }
  public interface IProfileSwitchable{
   void SwitchProfile(ControllerProfile c); //CP = c; 
  }
  public interface IKeySettable{
   string SetString(string _setTo); //switch(_setTo){case "Alpha1":_setTo="1";}return _setTo;
   void SetNewKey(KeyCode _keyToSet KeyCode _setTo); //switch(_keytoSet){case KeyCode.Alpha1: pcItem1 = _setTo;PC_Item1 = SetString(pcItem1.ToString());) } 
  }
  
}
