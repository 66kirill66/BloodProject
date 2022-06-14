mergeInto(LibraryManager.library,
{
    callTNITfunction: function () 
  {
    globals.init();
  },

   ClickFunc: function (ClickId)
  {
    globals.entityClick(ClickId);
  },

   SetSugarLevelNew: function (ClickId,Value)
  {
    globals.setSugarLevel(ClickId,Value)
  },

   SetInsulinLevelNew: function (ClickId,Value)
  {
    globals.setInsulinLevel(ClickId,Value)
  },

   SetGlucagonLevelNew: function (ClickId,Value)
  {
    globals.setGlucagonLevel(ClickId,Value)
  },
  
   ApplyMeetReceptor: function (insulinId,receptorId)
  {
    globals.applyMeetReceptor(insulinId,receptorId)
  },

  


     
});
