using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evrodiffusion
{
    class DistributeTransaction
    {
        List<Action> operations;

        public DistributeTransaction()
        {
            operations = new List<Action>();
        }

        public void AddOperation(Action action)
        {
            operations.Add(action);
        }

        public void Commit()
        {
            foreach (Action o in operations)
            {
                o();
            }

            operations.Clear();
        }
    }
}
