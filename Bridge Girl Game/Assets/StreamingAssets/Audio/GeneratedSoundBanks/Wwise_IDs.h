/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID DRAW_BOW = 2590733006U;
        static const AkUniqueID FIRE_ARROW = 2638661999U;
        static const AkUniqueID FOOTSTEPS = 2385628198U;
        static const AkUniqueID GAMEPLAY_MUSIC = 2322231365U;
        static const AkUniqueID MONSTER_BREATH_NEARBY = 2827716032U;
        static const AkUniqueID MONSTER_DAMAGE = 3498479171U;
        static const AkUniqueID MONSTER_DEATH = 3534274334U;
        static const AkUniqueID PLAYER_DAMAGE = 2074073782U;
        static const AkUniqueID TITLE_SEQUENCE = 3365447687U;
        static const AkUniqueID TO_CORRIDOR = 698227667U;
        static const AkUniqueID TO_MAIN = 3277579866U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace MUSIC_STATE
        {
            static const AkUniqueID GROUP = 3826569560U;

            namespace STATE
            {
                static const AkUniqueID CORRIDOR_STATE = 470836253U;
                static const AkUniqueID MAIN_STATE = 128436828U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace MUSIC_STATE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace GAMEPLAY
        {
            static const AkUniqueID GROUP = 89505537U;

            namespace SWITCH
            {
                static const AkUniqueID CORRIDOR_THEME = 3769669153U;
                static const AkUniqueID MAIN_THEME = 2557777556U;
                static const AkUniqueID TRANSITION_CORRIDOR_TO_MAIN = 3112872809U;
            } // namespace SWITCH
        } // namespace GAMEPLAY

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
