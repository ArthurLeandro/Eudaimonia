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
