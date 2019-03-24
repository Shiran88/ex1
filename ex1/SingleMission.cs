using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        public event EventHandler<double> OnCalculate;
        private functionWhatToDo nameFunc;
        private string name;

        //CTOR of SingleMission - get function and name of the mission
        public SingleMission(functionWhatToDo func, String mission)
        {
            name = mission;
            nameFunc = func;
            Type = "Single ";
        }
        //Calculate Method- with the value , he get
        public double Calculate(double value)
        {
            double answer = nameFunc(value);
            if (OnCalculate != null)
            {
                OnCalculate.Invoke(this, answer);
            }
            return answer;
        }
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public String Type { get; }
    }
}