using System;
using System.Text;
using System.Collections.Generic;

public enum BatteryType { LiIon, NiMH, NiCd }

class GSM
{
    static GSM IPhone4s = new GSM("IPhone4S", "Nokia");
    private string model;
    private string manufacturer;
    private decimal? price;
    private string owner;
    private static List<Call> callHistory = new List<Call>();

    public Battery Battery = new Battery();
    public Display Display = new Display();

    public string Model
    {
        get { return model; }
        set { this.model = value; }
    }
    public string Manufacturer
    {
        get { return manufacturer; }
        set { this.manufacturer = value; }
    }
    public decimal? Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid input!");
            }
            else
            {
                this.price = value;
            }
        }
    }
    public string Owner
    {
        get { return owner; }
        set { this.owner = value; }
    }

    //constructors
    public GSM(string Model, string Manufacturer)
    {
        this.model = Model;
        this.manufacturer = Manufacturer;
        this.price = null;
        this.owner = null;
    }
    public GSM(string Model, string Manufacturer, int Price)
    {
        this.model = Model;
        this.manufacturer = Manufacturer;
        if (Price < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid value!");
        }
        else
        {
            this.price = Price;
        }
        this.owner = null;
    }
    public GSM(string Model, string Manufacturer, int Price, string Owner)
    {
        this.model = Model;
        this.manufacturer = Manufacturer;
        if (Price < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid value!");
        }
        else
        {
            this.price = Price;
        }
        this.owner = Owner;
    }
    //

    //Problem 9
    public List<Call> CallHistory
    {
        get { return callHistory; }
    }
    //

    //Problem 10
    public void AddCallInHistory(Call call)
    {
        callHistory.Add(call);
    }

    public bool DeletingCallFromHistory(Call call)
    {
        for (int i = 0; i < callHistory.Count; i++)
        {
            if (callHistory[i].Date == call.Date &&
                callHistory[i].Time == call.Time &&
                callHistory[i].DialedPhoneNumber == call.DialedPhoneNumber &&
                callHistory[i].Duration == call.Duration)
            {
                callHistory.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public void ClearHistory()
    {
        callHistory.Clear();
    }
    //

    //Problem 11
    public decimal CallPrice(decimal pricePerMinute)
    {
        decimal sum = 0;
        foreach (var item in callHistory)
        {
            sum += (decimal)item.Duration;
        }
        return sum * pricePerMinute;
    }
    //

    //proble 5
    public GSM IPhone4S 
    { 
        get {return this.IPhone4S;}
        set { this.IPhone4S = value; }
    }
    //

    //Problem 4
    public override string ToString()
    {
        StringBuilder information = new StringBuilder();
        information.Append("Model: " + this.model + '\n');
        information.Append("Manufacturer: " + this.manufacturer + '\n');
        information.Append("Owner: " + this.owner + '\n');
        information.Append("Price: " + this.price + '\n');
        information.Append(new string('-', 50) + '\n');
        information.Append("Battery model: " + Battery.Model + '\n');
        information.Append("Battery idle: " + Battery.Idle + '\n');
        information.Append("Battery talk: " + Battery.Talk + '\n');
        information.Append("Battery type: " + Battery.TypeOfBattery + '\n');
        information.Append(new string('-', 50) + '\n');
        information.Append("Display size: " + Display.Size + "\"" + '\n');
        information.Append("Display colors: " + Display.Colors + "m" + '\n');

        return information.ToString();
    }
}

class GSMTest
{
    public GSMTest(uint NumberOfTests)
    {
        GSM[] myPhone = new GSM[NumberOfTests];
        for (int index = 0; index < myPhone.Length; index++)
        {
            myPhone[index] = new GSM("Model Test " + (index + 1), "Manufacturer Test " + (index + 1), ((index + 1) * 50), "Owner Test " + (index + 1));
            myPhone[index].Display = new Display((index + 1) * 10, (index + 1) * 55);
            myPhone[index].Battery = new Battery("Battery Test " + (index + 1), (index + 1) * 60, (index + 1) * 123);
            Console.WriteLine(myPhone[index]);
            Console.WriteLine();
        }
        GSM myIPhone = new GSM("", "");
        Console.WriteLine(myIPhone.IPhone4S);
    }
}

class GSMCallHistoryTest
{
    private GSM callHistory = new GSM("Model Test 1", "Manufacturer Test 1");
    Random randomNumber = new Random();//I use random generator for generating some random numbers for the tests

    public GSMCallHistoryTest(uint NumberOfTests)
    {
        if (NumberOfTests > 0)
        {
            for (int i = 0; i < NumberOfTests; i++)
            {
                Call call = new Call(DateTime.Today, DateTime.Today, 0831921123, (ulong)((i + 1) * randomNumber.Next(1, 50)));
                callHistory.AddCallInHistory(call);

            }

            for (int i = 0; i < callHistory.CallHistory.Count; i++)
            {
                Console.WriteLine("Call {0}:\nDate: {1}\nTime: {2}\nPhone Number: {3}\nDuration: {4}\n",
                    i + 1, callHistory.CallHistory[i].Date, callHistory.CallHistory[i].Time,
                    callHistory.CallHistory[i].DialedPhoneNumber, callHistory.CallHistory[i].Duration);
            }

            Console.WriteLine("Total price: " + callHistory.CallPrice(0.37m));

            ulong longestCallDuration = 0;
            Call longestCall = new Call(DateTime.Today, DateTime.Today, 0, 0);

            foreach (var call in callHistory.CallHistory)
            {
                if (call.Duration >= longestCallDuration)
                {
                    longestCall = call;
                }
            }

            callHistory.DeletingCallFromHistory(longestCall);
            Console.WriteLine("New price: " + callHistory.CallPrice(0.37m));
            callHistory.ClearHistory();

            foreach (var call in callHistory.CallHistory)
            {
                Console.WriteLine(call);
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
}

class Call
{
    private DateTime date;
    private DateTime time;
    private long dialedPhoneNumber;
    private double duration;// in seconds

    public Call (DateTime date, DateTime time, long dialedPhoneNumber, double duration)
    {
        this.date = date;
        this.time = time;
        this.dialedPhoneNumber = dialedPhoneNumber;
        this.duration = duration;
    }

    public DateTime Date
    {
        get { return this.date; }
    }

    public DateTime Time
    {
        get { return this.time; }
    }

    public long DialedPhoneNumber
    {
        get { return this.dialedPhoneNumber; }
    }

    public double Duration
    {
        get { return this.duration; }
    }
}

class Battery
{
    public string Model { get; set; }
    public double Idle { get; set; }
    public double Talk { get; set; }
    private BatteryType type;

    public BatteryType TypeOfBattery { get; set; }

    public Battery(string model = null, int idle = 0, int talk = 0, BatteryType type = 0)
    {
        this.Model = model;
        this.Idle = idle;
        this.Talk = talk;
        this.type = type;
    }
}

class Display
{
    private double? size = 0;
    private double? colors = 0;

    public Display()
    {
        this.size = null;
        this.colors = null;
    }
    public Display(int SizeColors)
    {
        if (SizeColors < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid value!");
        }
        else
        {
            this.size = SizeColors;
        }
        this.colors = null;
    }
    public Display(int SizeColors, int NumberColors)
    {
        if (SizeColors < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid value!");
        }
        else
        {
            this.size = SizeColors;
        }
        if (NumberColors < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid value!");
        }
        else
        {
            this.colors = NumberColors;
        }
    }
    public double? Size 
    {
        get { return this.size; }
        set
        {
            if (value.GetType() == typeof(double))
            {
                if (value > 0)
                {
                    this.size = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new FormatException();
            }
        }
    }

    public double? Colors
    {
        get { return this.colors; }
        set
        {
            if (value.GetType() == typeof(double))
            {
                if (value > 0)
                {
                    this.colors = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}

class Phone
{
    static void Main()
    {
        GSM phoneCharacteristics = new GSM("Galaxy S4", "Samsung");
        //GSMCallHistoryTest callHistoryTest = new GSMCallHistoryTest(1);//If you want to generate call history tests just uncomment the current row
        phoneCharacteristics.Model = "Galaxy S4";
        phoneCharacteristics.Manufacturer = "Samsung";
        phoneCharacteristics.Owner = "Pesho";
        phoneCharacteristics.Price = 900;
        phoneCharacteristics.Battery.Model = "Lipoly";
        phoneCharacteristics.Battery.TypeOfBattery = BatteryType.NiCd;
        phoneCharacteristics.Battery.Idle = 4.8;
        phoneCharacteristics.Battery.Talk = 3.5;
        phoneCharacteristics.Display.Colors = 16.5;
        phoneCharacteristics.Display.Size = 5;

        //here I print the information
        Console.WriteLine(phoneCharacteristics);
    }
}
