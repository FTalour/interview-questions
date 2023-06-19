using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class TestUSGadget
    {
        public static void Test()
        {
            USGadget gadget = new USGadget();
            //Indian or European power supply
            PowerSupply supply = new PowerSupply(VoltageTypes.V240);
            if (gadget.ExpectedVoltage != supply.Voltage)
            {
                StepUpStepDownPowerAdapter adapter = new StepUpStepDownPowerAdapter();
                //Getting the converted power
                supply = adapter.Convert(supply, gadget.ExpectedVoltage);
                gadget.Power = supply;
                gadget.Start();
            }
        }
    }

    public class StepUpStepDownPowerAdapter
    {
        public StepUpStepDownPowerAdapter()
        {
        }
        //Method for coverting voltages
        public PowerSupply Convert(PowerSupply supply, VoltageTypes convertToVoltage)
        {
            if (supply == null) return supply;
            //Convert iff the voltage is not in expected way
            if (supply.Voltage != convertToVoltage)
                supply.Voltage = convertToVoltage;
            return supply;
        }
    }

    /// The power supply class
    public class PowerSupply
    {
        VoltageTypes voltageType;
        //There will be other properties as well
        public PowerSupply(VoltageTypes vType)
        {
            voltageType = vType;
        }
        public VoltageTypes Voltage
        {
            get
            {
                return voltageType;
            }
            set
            {
                voltageType = value;
            }
        }
    }

    //Voltage Types enum
    public enum VoltageTypes { V110, V240 };

    //Gadget which expects 110V
    public class USGadget
    {
        VoltageTypes reqVoltage;
        PowerSupply supply;
        public USGadget()
        {
            reqVoltage = VoltageTypes.V110;
        }
        public VoltageTypes ExpectedVoltage
        {
            get
            {
                return reqVoltage;
            }
        }
        public PowerSupply Power
        {
            get
            {
                return supply;
            }
            set
            {
                supply = value;
            }
        }
        public void Start()
        {
        }
    }
}
