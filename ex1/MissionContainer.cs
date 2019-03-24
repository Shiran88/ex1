using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double functionWhatToDo(double val);
    public class FunctionsContainer
    {
        Dictionary<String, functionWhatToDo> arguments;

        //CTOR of the FunctionsContainer
        public FunctionsContainer()
        {
            arguments = new Dictionary<String, functionWhatToDo>();
        }
        //Indexer- can do set and get to place at arguments
        public functionWhatToDo this[String name]
        {
            get
            {
                //if the name of the func is not exict so empty
                if (!arguments.ContainsKey(name))
                {
                   
                    arguments.Add(name, val => val);
                }

                return arguments[name];
            }
            set
            {
                arguments[name] = value;
            }
        }
        //get the name of the all of mission
        public List<String> getAllMissions()
        {
            string key;
            List<string> listName = new List<string>();
            foreach (var pair in arguments)
            {
                key = pair.Key;
                listName.Add(key);
            }
            return listName;
            //  return arguments.Keys.ToList();
        }
    }
}