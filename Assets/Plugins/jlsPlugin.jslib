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
  
   ApplyMeetInsReceptor: function (insulinId,receptorId)
  {
    globals.applyMeetInsReceptor(insulinId,receptorId)
  },

   ApplyMeetGlucReceptor: function (glucagonId,receptorId)
  {
    globals.applyMeetGlucReceptor(glucagonId,receptorId)
  },

   ApplyMeetChannel: function (signalId,channelId)
  {
    globals.applyMeetChannel(signalId,channelId)
  },

  CreateRequestNewSignalM: function(receptorId)
  {  
    globals.createRequestSignalM(receptorId)
  },
   CreateRequestNewSignalMTo: function(receptorId)
  {  
    globals.createRequestNewSignalMTo(receptorId)
  },
   SugarMeetChannel: function (sugarId,channelId)
  {
    globals.sugarMeetChannel(sugarId,channelId)
  },
   SugarMeetInsulinRec: function (sugarId,receptorId)
  {
    globals.sugarMeetInsulinRec(sugarId,receptorId)
  },
   SugarMeetGlucagonRec: function (sugarId,receptorId)
  {
    globals.sugarMeetGlucagonRec(sugarId,receptorId)
  },


});
