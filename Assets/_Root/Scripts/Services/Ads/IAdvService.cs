using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Services
{
    internal interface IAdvService
    {
        bool IsLoadedFullAdv { get; }
        bool IsLoadedRewardedAdv { get; }
        string ID_FullADV { get; }
        string ID_RewardedADV { get; }
        void ShowFullScreenAdv();
        void ShowRewardedAdv();
        void RequestInterstitial(bool userAge_Under13);
        void RequestRewardedAd(bool userAge_Under13);
    }
}
