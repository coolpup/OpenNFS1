﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenNFS1.Physics;

namespace OpenNFS1.Vehicles.AI
{
	class PlayerDriver : IDriver
	{
		DrivableVehicle _vehicle;

		public Vehicle Vehicle { get { return _vehicle; } }
		public PlayerDriver(DrivableVehicle vehicle)
		{
			_vehicle = vehicle;
		}

		public void Update(List<IDriver> otherDrivers)
		{
			_vehicle.ThrottlePedalInput = VehicleController.Acceleration;
			_vehicle.BrakePedalInput = VehicleController.Brake;
			_vehicle.SteeringInput= VehicleController.Turn;
			_vehicle.GearDownInput = VehicleController.GearDown;
			_vehicle.GearUpInput = VehicleController.GearUp;
			_vehicle.HandbrakeInput = VehicleController.Handbrake;
			_vehicle.Update();
		}

		public void Render()
		{

		}
	}
}
