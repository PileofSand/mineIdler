using GameCode.Elevator;
using GameCode.Mineshaft;
using GameCode.UI;
using GameCode.Warehouse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCode.MineLevel
{
    public class MineLevelView : MonoBehaviour
    {
        [SerializeField] private ElevatorView _elevatorView;
        [SerializeField] private WarehouseView _warehouseView;
        [SerializeField] private Transform _mineshaftStartingPosition;
        [SerializeField] private HudView _hubView;

        public ElevatorView ElevatorView { get => _elevatorView;}
        public WarehouseView WarehouseView { get => _warehouseView;}
        public Transform MineshaftStartingPosition { get => _mineshaftStartingPosition;}
        public HudView HubView { get => _hubView; set => _hubView = value; }
    }
}