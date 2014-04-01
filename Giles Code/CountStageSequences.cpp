#include <stdio.h>
#include <stdlib.h>

const int nMinGreen = 7;
const int nIntergreen = 5;

const int nStages = 4;

const int nIncrement = 1;

static void traverseStages(int remainingTime, int currentStage, __int64& nSequencePatterns)
{
    for (remainingTime -= nIncrement; remainingTime >= nMinGreen + nIntergreen; remainingTime -= nIncrement)
    {
        for (int iStage = 1; iStage <= nStages; iStage++)
        {
            if (iStage != currentStage)
            {
                nSequencePatterns++;
                traverseStages(remainingTime - nMinGreen - nIntergreen, iStage, nSequencePatterns);
            }
        }
    }
}

int main(int argc, char* argv[])
{
    __int64 nSequencePatterns = 1;

    traverseStages(100, 1, nSequencePatterns); 

    printf("Number of possible stage sequences: %lld\n", nSequencePatterns);
}