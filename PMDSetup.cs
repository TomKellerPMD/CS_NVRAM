﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDLibrary;

class PMDSetup
{

        public void DoStepAtlasSetup(PMD.PMDAxis axis)
        {
            try
            {

                axis.SampleTime = 256;
                axis.SPIMode = 0;
                axis.SetEventAction(PMD.PMDEventActionEvent.Immediate, PMD.PMDEventAction.DisableMotorOutputAndHigherModules);
                axis.ResetEventStatus(0);
                axis.MotorType = PMD.PMDMotorType.Stepping;
                axis.OutputMode = PMD.PMDOutputMode.Atlas;
                this.WaitForAtlasToConnect(axis);
                axis.PositionErrorLimit = 65535;
                axis.SettleTime = 50;
                axis.SettleWindow = 1000;
                axis.TrackingWindow = 0;
                axis.EncoderModulus = 0;
                axis.EncoderSource = PMD.PMDEncoderSource.Incremental;
                axis.ActualPositionUnits = PMD.PMDActualPositionUnits.Steps;
                axis.SetEncoderToStepRatio(8000, 12800);
                axis.PositionErrorLimit = 200;
                axis.SetGearMaster(PMD.PMDAxisNumber.Axis1, PMD.PMDGearMasterSource.Actual);
                axis.GearRatio = 0x00000000;
                axis.MotionCompleteMode = PMD.PMDMotionCompleteMode.ActualPosition;
                axis.SignalSense = 0x0801;
                axis.CaptureSource = PMD.PMDCaptureSource.Index;
                axis.PhaseCounts = 256;
                axis.SetAuxiliaryEncoderSource(PMD.PMDAuxiliaryEncoderMode.None, PMD.PMDAxisNumber.Axis1);
                axis.PWMFrequency = 5000;
                axis.ClearDriveFaultStatus();
                axis.CurrentControlMode = PMD.PMDCurrentControlMode.FOC;
                axis.SetFOC(PMD.PMDFOC.Both, PMD.PMDFOCParameter.Kp, 50);
                axis.SetFOC(PMD.PMDFOC.Both, PMD.PMDFOCParameter.Ki, 40);
                axis.SetFOC(PMD.PMDFOC.Both, PMD.PMDFOCParameter.Ilimit, 16000);
                axis.SetAxisOutMask(PMD.PMDAxisNumber.Axis1, PMD.PMDAxisOutRegister.None, 0x0000, 0x0000);
                axis.SetDriveFaultParameter(PMD.PMDDriveFaultParameter.OvervoltageLimit, 44085);
                axis.SetDriveFaultParameter(PMD.PMDDriveFaultParameter.UndervoltageLimit, 7947);
                axis.SetCurrentFoldback(0, 5242);
                axis.SetCurrentFoldback(1, 582);
                axis.SetEventAction(PMD.PMDEventActionEvent.PositiveLimit, PMD.PMDEventAction.AbruptStopWithPositionErrorClear);
                axis.SetEventAction(PMD.PMDEventActionEvent.NegativeLimit, PMD.PMDEventAction.AbruptStopWithPositionErrorClear);
                axis.SetEventAction(PMD.PMDEventActionEvent.MotionError, PMD.PMDEventAction.DisablePositionLoopAndHigherModules);
                axis.SetEventAction(PMD.PMDEventActionEvent.CurrentFoldback, PMD.PMDEventAction.DisableMotorOutputAndHigherModules);
                //axis.SetDrivePWM(PMD.PMDDrivePWM.PWMLimit,16302);
                axis.SetDriveFaultParameter(PMD.PMDDriveFaultParameter.WatchdogLimit, 5);
                axis.SetDriveFaultParameter(PMD.PMDDriveFaultParameter.TemperatureLimit, 19200);
                //axis.FaultOutMask=0x0861;
                axis.Update();
                axis.SetCurrent(PMD.PMDCurrent.DriveCurrent, 3000);
                axis.SetCurrent(PMD.PMDCurrent.HoldingMotorLimit, 3000);
                axis.SetCurrent(PMD.PMDCurrent.HoldingDelay, 1000);
                axis.OperatingMode = (ushort)PMD.PMDOperatingMode.AllEnabled;
                axis.ClearPositionError();
                axis.ActualPosition = 0;
            }

           
                
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Setup Error!!");
            
            }

             
            
        }

        

        public void DoBLDCAtlasSetup(PMD.PMDAxis axis)
        {
            try
            {

                axis.SampleTime = 256;
                axis.SPIMode = 0;
                axis.SetEventAction(PMD.PMDEventActionEvent.Immediate, PMD.PMDEventAction.DisableMotorOutputAndHigherModules);
                axis.ResetEventStatus(0);
                axis.MotorType = PMD.PMDMotorType.BrushlessDC3Phase;
                axis.OutputMode = PMD.PMDOutputMode.Atlas;
                this.WaitForAtlasToConnect(axis);
                axis.PositionErrorLimit = 65535;
                axis.SettleTime = 50;
                axis.SettleWindow = 1000;
                axis.TrackingWindow = 0;
                axis.EncoderModulus = 0;
                axis.EncoderSource = PMD.PMDEncoderSource.Incremental;
                axis.ActualPositionUnits = PMD.PMDActualPositionUnits.Steps;
                axis.SetEncoderToStepRatio(8000, 12800);
                axis.PositionErrorLimit = 200;
                axis.SetGearMaster(PMD.PMDAxisNumber.Axis1, PMD.PMDGearMasterSource.Actual);
                axis.GearRatio = 0x00000000;
                axis.SetPositionLoop(PMD.PMDPositionLoop.Kp, 100);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Ki, 80);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Ilimit, 10000);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Kd, 400);
                axis.SetPositionLoop(PMD.PMDPositionLoop.DerivativeTime, 10);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Kout, 13107);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Kvff, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Kaff, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad1Enable,0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad1B0, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad1B1, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad1B2, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad1A1, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad1A2, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad1K, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad2Enable, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad2B0, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad2B1, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad2B2, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad2A1, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad2A2, 0);
                axis.SetPositionLoop(PMD.PMDPositionLoop.Biquad2K, 0);
                axis.MotorBias = 0;
                axis.MotorLimit = 13106;
                axis.MotionCompleteMode = PMD.PMDMotionCompleteMode.ActualPosition;
                axis.SignalSense = 0x0801;
                axis.CaptureSource = PMD.PMDCaptureSource.Index;
                axis.PhaseCounts = 1000;
                axis.CommutationMode = PMD.PMDCommutationMode.Sinusoidal;
                axis.PhaseCorrectionMode = PMD.PMDPhaseCorrectionMode.Disabled;
                axis.PhaseInitializeMode = PMD.PMDPhaseInitializeMode.HallBased;
                axis.PhaseInitializeTime = 0;
                axis.PhasePrescale = PMD.PMDPhasePrescale.Off;
                axis.SetAuxiliaryEncoderSource(PMD.PMDAuxiliaryEncoderMode.None, PMD.PMDAxisNumber.Axis1);
                axis.PWMFrequency = 5000;
                axis.ClearDriveFaultStatus();
                axis.CurrentControlMode = PMD.PMDCurrentControlMode.FOC;
                axis.SetFOC(PMD.PMDFOC.Both, PMD.PMDFOCParameter.Kp, 50);
                axis.SetFOC(PMD.PMDFOC.Both, PMD.PMDFOCParameter.Ki, 40);
                axis.SetFOC(PMD.PMDFOC.Both, PMD.PMDFOCParameter.Ilimit, 16000);
                axis.SetAxisOutMask(PMD.PMDAxisNumber.Axis1, PMD.PMDAxisOutRegister.None, 0x0000, 0x0000);
                axis.SetDriveFaultParameter(PMD.PMDDriveFaultParameter.OvervoltageLimit, 44085);
                axis.SetDriveFaultParameter(PMD.PMDDriveFaultParameter.UndervoltageLimit, 7947);
                axis.SetCurrentFoldback(0, 5242);
                axis.SetCurrentFoldback(1, 582);
                axis.SetEventAction(PMD.PMDEventActionEvent.PositiveLimit, PMD.PMDEventAction.AbruptStopWithPositionErrorClear);
                axis.SetEventAction(PMD.PMDEventActionEvent.NegativeLimit, PMD.PMDEventAction.AbruptStopWithPositionErrorClear);
                axis.SetEventAction(PMD.PMDEventActionEvent.MotionError, PMD.PMDEventAction.DisablePositionLoopAndHigherModules);
                axis.SetEventAction(PMD.PMDEventActionEvent.CurrentFoldback, PMD.PMDEventAction.DisableMotorOutputAndHigherModules);
                //axis.SetDrivePWM(PMD.PMDDrivePWM.PWMLimit,16302);
                axis.SetDriveFaultParameter(PMD.PMDDriveFaultParameter.WatchdogLimit, 5);
                axis.SetDriveFaultParameter(PMD.PMDDriveFaultParameter.TemperatureLimit, 19200);
                //axis.FaultOutMask=0x0861;
                axis.Update();
                axis.InitializePhase();
               // axis.SetCurrent(PMD.PMDCurrent.DriveCurrent, 3000);
                //axis.SetCurrent(PMD.PMDCurrent.HoldingCurrent, 3000);
                //axis.SetCurrent(PMD.PMDCurrent.Delay, 1000);
                axis.OperatingMode = (ushort)PMD.PMDOperatingMode.AllEnabled;
                axis.ClearPositionError();
                axis.ActualPosition = 0;
            }



            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Setup Error!!");

            }



        }

    public void DoNVRAMAtlasSetup(PMD.PMDAxis axis)
    {
        try
        {

            axis.SetEventAction(PMD.PMDEventActionEvent.Immediate, PMD.PMDEventAction.DisableMotorOutputAndHigherModules);
            axis.ResetEventStatus(0);
            axis.OutputMode = PMD.PMDOutputMode.Atlas;
            this.WaitForAtlasToConnect(axis);
            
        }



        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            MessageBox.Show("Setup Error!!");

        }



    }

    // ****************************************************************************
    // wait for the "DriveNotConnected" bit in the Magellan's Drive Status register to go low.
    private PMD.PMDResult WaitForAtlasToConnect(PMD.PMDAxis axis)
        {
            UInt16 status = 0;
            long starttime, currenttime;
            UInt32 timeoutms = 1000;

            starttime = DateTime.Now.Ticks / 10000;// there are 10,000 ticks in one millisecond.
            do
            {
                status = axis.DriveStatus;
                currenttime = DateTime.Now.Ticks / 10000;

                if (currenttime > starttime + timeoutms)
                {
                    MessageBox.Show("Timeout waiting for Atlas to connect.\n");
                    return PMD.PMDResult.ERR_Timeout;
                }
            }
            while ((status & 0x8000) != 0);   //PMDDriveStatusDriveNotInitialized

            return PMD.PMDResult.ERR_OK;
        }
}

