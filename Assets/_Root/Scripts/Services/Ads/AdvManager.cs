using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Services
{
    /// <summary>
    /// �������� ������ �������� ���� � ���������� ��������� � �������� ������ � �������� ! ������ ��������� , ��������������� ���������� currentService
    /// </summary>
    internal class AdvManager : MonoBehaviour
    {
        private List <IAdvService> _adsServeces;
        private int currentService = 0;
        [SerializeField] private bool advForPeopleUnder13Age;
        private IAdvService advService;
        
        private void Awake()
        {
            _adsServeces = new List<IAdvService>() { new YaAdv() };
            advService = _adsServeces[currentService];


        }

      
        public void ShowFullScreenAdv() => advService.RequestInterstitial(advForPeopleUnder13Age);
        public void ShowRewardedAdv() => advService.RequestRewardedAd(advForPeopleUnder13Age);


        
    }
}
