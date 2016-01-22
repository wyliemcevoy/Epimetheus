using Epimetheus.GridGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epimetheus.QNet
{
    class QNetAgent
    {
        private List<ReplayMemory> memoryBank;
        private int maxEpochs = 10000;
        private int maxActions = 10000;
        private Epsilon epsilon;
        Random rand;

        public QNetAgent()
        {
            memoryBank = new List<ReplayMemory>();
            epsilon = new ConstantEpsilon(.1);
        }

        public void runTest(MarkovGridGame game, int seed)
        {
            int inputSize = game.width * game.height * 4;
            rand = new Random(seed);
            NeuralNet net = new NeuralNet(new int[] { inputSize, inputSize/2, 8, game.numberOfActions });

            // Initialize outside of loops
            QNetState currentState;
            ReplayMemory replay;
            int numActions;

            // Loop over total number of games
            for (int epoch=0; epoch < maxEpochs; epoch ++)
            {
                replay = new ReplayMemory();
                numActions = 0;
                // Loop until current game is completed or maximum number of steps
                while ( !game.isCompleted && numActions <maxActions)
                {
                    currentState = game.toQNetState();
                    Console.Clear();
                    Console.WriteLine(game);
                    // With probability epsilon select a random action aT
                    if(rand.NextDouble() <= epsilon.getE())
                    {
                        // Select a random action
                        // Explore instead of Exploit
                        currentState.chosenAction = rand.Next(0, game.numberOfActions);
                    } else
                    {
                        // Exploit instead of Explore


                        // Convert to input
                        double[] networkInput = new double[currentState.input.Count()];
                        for(int i=0; i< currentState.input.Count(); i++)
                        {
                            networkInput[i] = currentState.input[i];
                        }

                        net.setInput(networkInput);
                        net.forwardPass();
                        double[] output = net.Output;

                        for(int i=0; i<output.Count(); i++)
                        {
                            Console.WriteLine(output[i]);
                        }

                        // Ugly inefficient implementation
                        double bestQScore = output.Max();
                        currentState.chosenAction = output.ToList().IndexOf(bestQScore);


                        //net.backPropogate(.05,output);
                    }
                    Console.WriteLine(numActions);

                    game.acceptAction(currentState.chosenAction);
                    numActions++;
                    replay.Add(currentState);
                }

                memoryBank.Add(replay);
                game.reset();
            }



            //BackPropogationRunner bpr = new BackPropogationRunner();


        }

    }
}
