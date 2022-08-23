mergeInto(LibraryManager.library,
{
    callTNITfunction: function () 
  {
    globals.init();
  },

  //
   ClickFunc: function (bloodId)
  {
    globals.entityClick(bloodId);
  },

  //
   SetSugarLevelNew: function (sugarId,Value)
  {
    globals.setSugarLevel(sugarId,Value)
  },

  //
   SetInsulinLevelNew: function (insulinId,Value)
  {
    globals.setInsulinLevel(insulinId,Value)
  },

  //
   SetGlucagonLevelNew: function (glucagonId,Value)
  {
    globals.setGlucagonLevel(glucagonId,Value)
  },

  // 
   ApplyMeetInsReceptor: function (insulinId,receptorId)
  {
    globals.applyMeetInsReceptor(insulinId,receptorId)
  },
 
   // 
    InsulunMeetGlucReceptor: function (insulinId,receptorId)
  {
    globals.insulunMeetGlucReceptor(insulinId,receptorId)
  },

   // 
    GlucagonMeetInsReceptor: function (glucagonId,receptorId)
  {
    globals.glucagonMeetInsReceptor(glucagonId,receptorId)
  },

    // 
    GlucagonMeetChannal: function (glucagonId,channalId)
  {
    globals.glucagonMeetChannal(glucagonId,channalId)
  },

    // 
    InsulunMeetChannal: function (glucagonId,channalId)
  {
    globals.insulunMeetChannal(glucagonId,channalId)
  },

  //
   ApplyMeetGlucReceptor: function (glucagonId,receptorId)
  {
    globals.applyMeetGlucReceptor(glucagonId,receptorId)
  },

  //
   ApplyMeetChannel: function (signalId,channalId)
  {
    globals.applyMeetChannel(signalId,channalId)
  },

  //
  CreateRequestNewSignalM: function(receptorId)
  {  
    globals.createRequestSignalM(receptorId)
  },

  //
   CreateRequestNewSignalMTo: function(receptorId)
  {  
    globals.createRequestNewSignalMTo(receptorId)
  },

  //
   SugarMeetChannal: function (sugarId,channalId)
  {
    globals.sugarMeetChannal(sugarId,channalId)
  },

  //
   SugarMeetInsulinRec: function (sugarId,receptorId)
  {
    globals.sugarMeetInsulinRec(sugarId,receptorId)
  },

  //
   SugarMeetGlucagonRec: function (sugarId,receptorId)
  {
    globals.sugarMeetGlucagonRec(sugarId,receptorId)
  },

  //
   SetSignalLevel: function (signalId)
  {
    globals.setSignalLevel(signalId)
  },



  


});
