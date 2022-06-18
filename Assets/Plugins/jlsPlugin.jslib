mergeInto(LibraryManager.library,
{
    callTNITfunction: function () 
  {
    globals.init();
  },

   ClickFunc: function (bloodId)
  {
    globals.entityClick(bloodId);
  },

   SetSugarLevelNew: function (sugarId,Value)
  {
    globals.setSugarLevel(sugarId,Value)
  },

   SetInsulinLevelNew: function (insulinId,Value)
  {
    globals.setInsulinLevel(insulinId,Value)
  },

   SetGlucagonLevelNew: function (glucagonId,Value)
  {
    globals.setGlucagonLevel(glucagonId,Value)
  },
  
   ApplyMeetReceptor: function (insulinId,receptorId)
  {
    globals.applyMeetReceptor(insulinId,receptorId)
  },





});
