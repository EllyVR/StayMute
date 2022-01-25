using MelonLoader;
using System;
namespace StayMute
{
    public class StayMute : MelonMod
    {
        public static MelonLogger.Instance Logger = new MelonLogger.Instance("StayMute");
        public static MelonPreferences_Category _StayMute;
        public static MelonPreferences_Entry<bool> _Enabled;
        public override void OnApplicationStart()
        {
            _StayMute = MelonPreferences.CreateCategory("StayMute", "StayMute");
            _Enabled = _StayMute.CreateEntry("Enabled", false, "StayMute_Enabled", "Keep yourself from unmuting");
            //Thanks to DDAkebono for helping me find this. 
            DefaultTalkController.field_Private_Static_Action_0 += new Action(() =>
            {
                if (_Enabled.Value) return;
                DefaultTalkController.Method_Public_Static_Void_Boolean_0(true);
            });
            Logger.Msg("Started Successfully");
        }
    }
}