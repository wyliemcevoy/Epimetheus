using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.Markov
{
    class QLearningAgent : MarkovProblemSolver
    {
        public MarkovProblem problem { private get; set; }
        public int maxEpochs { get; set; } = 10000;
        public int maxActionsInEpoch { get; set; } = 10000;
        private static double gamma = .9;
        private double epsilon = .1;
        private static double learningRate = .9;
        private Random rand;
        private ActionExecutor executer;
        private int epochs;

        public QLearningAgent(int maxEpochs, int maxActionsInEpoch, int seed)
        {
            this.maxEpochs = maxEpochs;
            this.maxActionsInEpoch = maxActionsInEpoch;
            executer = new ActionExecutor(seed);
            rand = new Random(seed);
        }

        public void accept(MarkovProblem problem)
        {
            this.problem = problem;
        }

        
         public void solve()
        {
            int currentEpoch = 0;
            bool policyHasChanged = true;
            while (policyHasChanged && currentEpoch < maxEpochs)
            {
                policyHasChanged = runEpoch();
                currentEpoch++;
            }
            epochs = currentEpoch;
        }

        private bool runEpoch()
        {
            bool policyHasChanged = false;
            int usedActions = 0;
            MarkovState current = problem.getStartState();
            while (!current.isTerminal && usedActions < maxActionsInEpoch)
            {

                double oldEstimatedValue = current.estimatedValue;

                current.calculatePolicy();
                double bestActionValue = 0;
                foreach(ActionResult result in current.policy.getPossibleResults())
                {
                    bestActionValue += result.state.estimatedValue * result.probability;
                }

                double newEstimatedValue = oldEstimatedValue + learningRate * (current.value + gamma * bestActionValue - oldEstimatedValue);
                current.nextEstimatedValue = newEstimatedValue;

                if (rand.NextDouble() > epsilon)
                {
                    // Explore over Exploit

                    int actionIndex = rand.Next(current.actions.Count());

                    current = executer.getResult(current.actions[actionIndex]);

                }
                else
                {
                    // Exploit over Explore
                    current = executer.getResult(current.policy);
                }

                if (oldEstimatedValue != newEstimatedValue)
                {
                    policyHasChanged = true;
                }

                usedActions++;
            }

            problem.update();

            Console.WriteLine(problem.ToString());

            return policyHasChanged;
        }

        public int getNumberOfItterations()
        {
            return epochs;
        }
    
    }
}
