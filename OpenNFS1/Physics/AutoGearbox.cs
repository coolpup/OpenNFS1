using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using GameEngine;
using Microsoft.Xna.Framework.Input;

namespace OpenNFS1.Physics
{
    class AutoGearbox : BaseGearbox
    {
        private const float ChangeUpPoint = 0.94f;
        private const float ChangeDownPoint = 0.65f;

        public AutoGearbox(List<float> ratios, float changeTime)
            : base(ratios, changeTime)
        {
        }

        public override void Update(float motorRpmPercent, GearboxAction action)
        {
			if (_motor.Rpm < 2 && (_currentGear == GEAR_NEUTRAL || _currentGear == GEAR_1) && action == GearboxAction.GearDown)
			{
				GearDown();
			}
			if ((_currentGear == GEAR_REVERSE || _currentGear == GEAR_NEUTRAL) && action == GearboxAction.GearUp)
			{
				GearUp();
			}
            
            if (!_motor.WheelsSpinning)
            {
                
                if (_currentGear == GEAR_REVERSE || _currentGear == GEAR_NEUTRAL)
                {

                }
                else
                {
                    if (motorRpmPercent > ChangeUpPoint && _currentGear < Ratios.Count - 1)
                        GearUp();
                    if (motorRpmPercent < ChangeDownPoint && CurrentGear > 1 && GearEngaged && !_motor.IsAccelerating && _motor.CanChangeDown)
                        GearDown();
                }
            }

            base.Update(motorRpmPercent, action);
        }
    }
}
