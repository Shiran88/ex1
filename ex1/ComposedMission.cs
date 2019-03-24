using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        public event EventHandler<double> OnCalculate;

        private List<functionWhatToDo> allTheFunction;
        private string name;

        //CTOR of the ComposedMission
        public ComposedMission(String nameOfFunction)
        {
            name = nameOfFunction;
            allTheFunction = new List<functionWhatToDo>();
            Type = "Composed";
        }
        //add the function to the list 
        public ComposedMission Add(functionWhatToDo func)
        {
            allTheFunction.Add(func);
            return this;
        }
        //Calculate Method- get value and calculate it 
        public double Calculate(double value)
        {
            double answer = value;
            foreach (var func in allTheFunction)
            {
                answer = func(answer);
            }
            //if have event 
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