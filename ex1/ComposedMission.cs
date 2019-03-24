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

        //CTOR of the ComposedMission
        public ComposedMission(String nameOfFunction)
        {
            Name = nameOfFunction;
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
        public String Name { get; }
        public String Type { get; }
    }
}