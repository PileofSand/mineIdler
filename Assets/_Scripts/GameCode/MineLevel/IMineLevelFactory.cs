using GameCode.Finance;
using UniRx;
using UnityEngine;

namespace GameCode.MineLevel
{
    public interface IMineLevelFactory
    {
        void CreateMine(int levelID);
    }
}