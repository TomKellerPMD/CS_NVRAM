using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using PMDLibrary;
using System.Net.NetworkInformation;
using System.Data.Common;

namespace CS_NVRAM
{
    public partial class Form1 : Form
    {
        static PMD.PMDPeripheral 
            perTCP, perSER;
        static PMD.PMDDevice devMC;
        public static volatile PMD.PMDAxis Axis1, Axis2;
        String ipaddress = "192.168.2.2";
        public Form1()
        {
            InitializeComponent();

            try
            {
                //perTCP = new PMD.PMDPeripheralTCP(System.Net.IPAddress.Parse(ipaddress), 40100, 1000);
                perSER = new PMD.PMDPeripheralCOM(1, 57600, PMD.PMDSerialParity.None, PMD.PMDSerialStopBits.SerialStopBits1);
              
                //devMC = new PMD.PMDDevice(perTCP, PMD.PMDDeviceType.ResourceProtocol);
                devMC = new PMD.PMDDevice(perSER, PMD.PMDDeviceType.MotionProcessor);
                Axis1 = new PMD.PMDAxis(devMC, PMD.PMDAxisNumber.Axis1);
             
                ushort gvfamily = 0, gvnaxes = 0, gvnchips = 0, gvcustom = 0, gvmajor = 0, gvminor = 0;
                PMD.PMDMotorTypeVersion mtype = 0;
                Axis1.GetVersion(ref gvfamily, ref mtype, ref gvnaxes, ref gvnchips, ref gvcustom, ref gvmajor, ref gvminor);
                         
                MotorTypeSelect.SelectedIndex = 0;
                DeviceSelection.SelectedIndex = 0;   // Text = "MC5x118";
                            
              //  UInt16 Indentifier = ReadAtlasNVRAM(Axis1, UserDataTest, 4);
                             

            }



            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.Close();


            }


        }

        public void WriteMC58113NVRAM(PMD.PMDAxis axis, int num_words)
        {

            try
            {

                //The last 4 words of the header can be used generically.  For example to store an 8 byte ASCII Configuration name.
                UInt16[] headerdata = { 0x0000, 0x0000, 0x0000, 0x0000, 0x0123, 0x4567, 0x89AB, 0xCDEF };
                UInt16 checksum;
                Int16 MtrTypedata=-1;
                
                // CAN Config
                int CANID = (int)CANNodeUpDown.Value;
                int baud = CANBaudSelect.SelectedIndex;
                if(baud==(int)-1)
                {
                    MessageBox.Show("Must select CAN baud");
                    return;
                }
                UInt16 CANdata = (UInt16)(baud * 0x2000);   // baudrate is bits 13-15.
                CANdata += (UInt16)CANID;
                UInt16[] CANrow = { 0x0000, 0x0012, (ushort)CANdata };
                checksum=MC58113Checksum(CANrow, 3);
                CANrow[0] = checksum;



                //Motor Type Config
                if (MotorTypeSelect.SelectedIndex != 0)
                {
                    int MotorType = MotorTypeSelect.SelectedIndex;
                    switch (MotorType)
                    {
                        case 1:
                            MtrTypedata = 0;
                            break;
                        case 2:
                            MtrTypedata = 3;
                            break;
                        case 3:
                            MtrTypedata = 7;
                            break;
                        default:
                            MtrTypedata = -1;
                            break;
                    }
                }
                
                UInt16[] MtrTyperow = { 0x0000, 0x0002, (ushort)MtrTypedata };
                if (MtrTypedata != -1)
                {
                    checksum = MC58113Checksum(MtrTyperow, 3);
                    MtrTyperow[0] = checksum;
                }
              
                //Start NVRAM programming
                Axis1.DriveNVRAM(PMD.PMDNVRAMOption.Mode58113, 0);
                Thread.Sleep(100);

                //Erase NVRAM
                try
                {
                    axis.DriveNVRAM(PMD.PMDNVRAMOption.EraseNVRAM, 0);
                }
                catch (Exception e)
                {
                   //do nothing
                }

                // Delay to allow NVRAM Erase to complete
                Thread.Sleep(3000);

                // Write Header
                for (int i = 0; i < 8; i++)
                    axis.DriveNVRAM(PMD.PMDNVRAMOption.Write, headerdata[i]);
               
                //Write CAN data
                for (int i = 0; i < 3; i++)
                    axis.DriveNVRAM(PMD.PMDNVRAMOption.Write, CANrow[i]);

                //Write Motor Type data
                if (MtrTypedata != -1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        axis.DriveNVRAM(PMD.PMDNVRAMOption.Write, MtrTyperow[i]);
                    }
                }

                Axis1.Reset();
                Thread.Sleep(100);
                MessageBox.Show("MC58113 NVRAM Program Complete.\n");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);


            }

        }

        public void WriteJunoNVRAM(PMD.PMDAxis axis, UInt16[] data, int num_words)
        {

            UInt16 SegmentType = 0xD0;
            UInt16 Identifier = 0xA;

            try
            {

                axis.SetEventAction(PMD.PMDEventActionEvent.Immediate, PMD.PMDEventAction.DisableMotorOutputAndHigherModules);
                axis.ResetEventStatus(0);
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Setup Error!!");

            }

            axis.DriveNVRAM(PMD.PMDNVRAMOption.Mode58113, 0);
           
            //Erase NVRAM
            try
            {
                axis.DriveNVRAM(PMD.PMDNVRAMOption.EraseNVRAM, 0);
            }
            catch (Exception e)
            {
                //do nothing
            }

            // Delay to allow NVRAM Erase to complete
            Thread.Sleep(3000);

            //   WaitForAtlasToConnect(axis);

            UInt16[] StartData = { 0, 0, 0, 1, 0x1234, 0x5678, 0xABCD, 0xEDFF };

            for (int i = 0; i < 8; i++)
            {
                axis.DriveNVRAM(PMD.PMDNVRAMOption.Write, StartData[i]);
            }

            UInt16 num_words_low = (ushort)(num_words & 0xFFFF);
            UInt16 num_words_high = (ushort)(num_words & 0xFFFF0000);

            UInt16[] HeaderData = { SegmentType, Identifier, 0, num_words_low, num_words_high };

            UInt16 chksum = (UInt16)AtlasCheckSum(HeaderData, data, num_words);
            UInt16 temp = (ushort)(chksum << 8);

            HeaderData[0] += temp;


            for (int i = 0; i < 5; i++)
            {
                axis.DriveNVRAM(PMD.PMDNVRAMOption.Write, HeaderData[i]);
            }

            for (int i = 0; i < num_words; i++)
            {
                axis.DriveNVRAM(PMD.PMDNVRAMOption.Write, data[i]);
            }

            axis.Reset();


        }


        public void WriteAtlasNVRAM(PMD.PMDAxis axis, UInt16[] data, int num_words)
        {

            UInt16 SegmentType = 0xD0;
            UInt16 Identifier = 0xA;

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


            axis.DriveNVRAM(PMD.PMDNVRAMOption.ModeAtlas, 0);
            WaitForAtlasToConnect(axis);
            axis.DriveNVRAM(PMD.PMDNVRAMOption.EraseNVRAM, 0);
            WaitForAtlasToConnect(axis);

            UInt16[] StartData = { 0, 0, 0, 1, 0x1234, 0x5678, 0xABCD, 0xEDFF };

            for (int i = 0; i < 8; i++)
            {
                axis.DriveNVRAM(PMD.PMDNVRAMOption.Write, StartData[i]);
                WaitForAtlasToConnect(axis);
            }

            UInt16 num_words_low = (ushort)(num_words & 0xFFFF);
            UInt16 num_words_high = (ushort)(num_words & 0xFFFF0000);

            UInt16[] HeaderData = { SegmentType, Identifier, 0, num_words_low, num_words_high };

            UInt16 chksum = (UInt16)AtlasCheckSum(HeaderData, data, num_words);
            UInt16 temp = (ushort)(chksum << 8);

            HeaderData[0] += temp;


            for (int i = 0; i < 5; i++)
            {
                axis.DriveNVRAM(PMD.PMDNVRAMOption.Write, HeaderData[i]);
                WaitForAtlasToConnect(axis);
            }

            for (int i = 0; i < num_words; i++)
            {
                axis.DriveNVRAM(PMD.PMDNVRAMOption.Write, data[i]);
                WaitForAtlasToConnect(axis);
            }

            AtlasReset(Axis1);

           
        }

        UInt16 ReadAtlasNVRAM(PMD.PMDAxis axis, UInt16[] data, int num_words)
        {
             
            PMD.PMDAxis Atlas = axis.AtlasAxis();
            UInt16 Identifier,num_word_low,num_word_high;
            int UserDataOffset = 9;


            Atlas.SetBufferStart(3, 0x20000000 + UserDataOffset) ;
            Atlas.SetBufferLength(3, 0x400);

            Identifier = (UInt16)Atlas.ReadBuffer16(3);
            Atlas.ReadBuffer16(3);  // reserved
            num_word_low = (UInt16)Atlas.ReadBuffer16(3);
            num_word_high = (UInt16)Atlas.ReadBuffer16(3);

            for (int i = 0; i < num_words; i++)
            {
                data[i]=(UInt16)Atlas.ReadBuffer16(3);
                //WaitForAtlasToConnect(axis);
            }

            Atlas.Close();
            return Identifier;



        }

        UInt16 MC58113Checksum(UInt16[] data, int num_words)
        {
            int sum = 0;
            UInt16 nvram_cksum = 0xAA;
            int hisum, losum;

            for (int i = 0; i < num_words; i++)
            {
                sum += (char)(data[i] >> 8);
                sum += (char)(data[i] & 0xFF);

            }

            
            hisum = (int)((UInt32)0xFFFF0000 & sum);
            nvram_cksum += (UInt16)sum;
            hisum >>= 16;
            nvram_cksum += (UInt16)hisum;

            hisum = nvram_cksum >> 8;
            losum = nvram_cksum & 0xFF;

            hisum = nvram_cksum >> 8;
            losum = nvram_cksum & 0xFF;


            nvram_cksum = (UInt16)(0xFF- losum - hisum);
            return nvram_cksum;

        }


        char AtlasCheckSum(UInt16[] HeaderData,UInt16[] data, int num_words)
        {
            
            int sum = 0;
            int nvram_cksum=0;
            int hisum, losum;

            // Header is always 5 words
            for (int i = 0; i < 5; i++)
            {
                sum += (char)(HeaderData[i] >> 8);
                sum += (char)(HeaderData[i] & 0xFF);

            }

            for (int i = 0; i < num_words; i++)
            {
                sum += (char)(data[i] >> 8);
                sum += (char)(data[i] & 0xFF);

            }

            nvram_cksum += sum;
            nvram_cksum += 0xAA;
            hisum = nvram_cksum >> 8;
            losum = nvram_cksum & 0xFF;
            sum = losum + hisum;
            hisum = sum >> 8;
            losum = sum & 0xFF;
            nvram_cksum = 0xFF - losum - hisum;

            return (char) nvram_cksum;
        }

       


        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeviceSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DeviceSelection.SelectedIndex == 2)
            {
                CANBaudSelect.Visible = false;
                CANNodeUpDown.Visible = false;
            }
            else
            {
                CANBaudSelect.Visible=true;
                CANNodeUpDown.Visible=true;
            }

        }

        
        private void CANNodeUpDown_ValueChanged(object sender, EventArgs e)
        {
            int num_words = 6;

            if ((string)DeviceSelection.SelectedItem == "MC5x113") WriteMC58113NVRAM(Axis1, num_words);
            else MessageBox.Show("Supported in future versions");
        }

        private void NVRAMButton_Click_1(object sender, EventArgs e)
        {
            int num_words = 6;

            if ((string)DeviceSelection.SelectedItem == "MC5x113") WriteMC58113NVRAM(Axis1, num_words);
            else MessageBox.Show("Supported in future versions");
        }

        private void DeviceSelection_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if((string)DeviceSelection.SelectedItem == "Atlas")
            {
                CANBaudSelect.Visible = false;
                CANNodeUpDown.Visible=false;
            }
            else
            {
                CANBaudSelect.Visible = true;
                CANNodeUpDown.Visible = true;
            }

        }

        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            if (perTCP != null) perTCP.Close();
            if (perSER != null) perSER.Close(); 
            if (devMC != null) devMC.Close();
            if (Axis1 != null) Axis1.Close();
            this.Close();
                     

        }

        void AtlasReset(PMD.PMDAxis axis)
        {

            PMD.PMDAxis Atlas = axis.AtlasAxis();
            Atlas.Reset();
            WaitForAtlasToConnect(axis);
            Atlas.Close();
        }



        private PMD.PMDResult WaitForAtlasToConnect(PMD.PMDAxis axis)
        {
            UInt16 status = 0;
            long starttime, currenttime;
            UInt32 timeoutms = 2000;

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
}


